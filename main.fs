\ Maze definition
: line1 s" |------------------------------|" ;
: line2 s" |>  |--------------------------|" ;
: line3 s" |-| |---|        |-------------|" ;
: line4 s" |-|       |-----|       |------|" ;
: line5 s" |-| |-----------| |---|        F" ;
: line6 s" |-|               |------------|" ;
: line7 s" |------------------------------|" ;

variable xPos
variable yPos
10 xPos !
1 yPos !

\ create lines 
\  line7 , line6 , line5 , line4 , line3 , line2 , line1 ,

: clear-screen page ;
: newline 10 emit ;

: renderLineWithoutPlayer ( line len -- )
  type newline ;

: renderLineWithPlayer ( line len -- )
  { line len }
  line xPos @ 1 - type
    ." P"
  line xPos @ + len xPos @ - type newline ;

: banner-screen ( -- )
  clear-screen
  ." Welcome to ForthMaze"
  newline
  ." Press s + Enter to start"
  ;


: check-keypress ( x -- )
  begin
      key
      over =
    until
  drop ;

: movePlayer ( x y -- x y )
  { x y }
    key
    case
      119 of x y 1 - endof  \ W
      97 of x 1 - y endof   \ A
      115 of x y 1 + endof  \ S
      100 of x 1 + y endof  \ D
    endcase ;

: renderLine ( line len index -- )
  yPos @ = if
        renderLineWithPlayer
      else
        renderLineWithoutPlayer
      endif ;

: renderGame ( -- )
  line1 1 renderLine
  line2 2 renderLine
  line3 3 renderLine
  line4 4 renderLine
  line5 5 renderLine 
  line6 6 renderLine
  line7 7 renderLine 
  newline ;

: gameLoop ( -- )
  renderGame
  begin
    xPos @ yPos @
    movePlayer
    yPos ! xPos ! 

    renderGame
  again ;


\ Starting Logic 

clear-screen
banner-screen
115 check-keypress
." success"
newline

gameLoop
