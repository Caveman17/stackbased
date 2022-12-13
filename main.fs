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
\ line7 , line6 , line5 , line4 , line3 , line2 , line1 ,

: clearScreen page ;
: newline 10 emit ;

: checkKeypress ( u -- )
  begin
      key
      over =
    until
  drop ;

: startScreen ( -- )
  ." Welcome to ForthMaze" newline
  ." Press s + Enter to start"
  115 checkKeypress
  ." success"
  newline
  ;

: movePlayer ( u1 u2 -- u1 u2 )
  { x y }
    key
    case
      119 of x y 1 - endof  \ W
      97 of x 1 - y endof   \ A
      115 of x y 1 + endof  \ S
      100 of x 1 + y endof  \ D
    endcase ;

: renderLineWithoutPlayer ( c-addr u -- )
  type newline ;

: renderLineWithPlayer ( c-addr u -- )
  { line len }
  line xPos @ 1 - type
    ." >"
  line xPos @ + len xPos @ - type newline ;
  
: renderLine ( c-addr u1 u2 -- )
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

clearScreen
startScreen

gameLoop
