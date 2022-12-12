\ Maze definition
: line1 s" |------------------------------|" ;
: line2 s" >   |--------------------------|" ;
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

: renderLine ( line len -- )
  type newline ;

: renderLineWithPlayer ( position line len -- )
  { position line len }
  line position 1 - type
    ." P"
  line position + len position - type newline ;

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
      119 of x y 1 + endof  \ W
      97 of x 1 - y endof   \ A
      115 of x y 1 - endof  \ S
      100 of x 1 + y endof  \ D
    endcase ;

: gameLoop ( -- )
  begin
    xPos @ yPos @
    movePlayer
    yPos ! xPos ! 

    line1 renderLine
    line2 renderLine
    line3 renderLine
    line4 renderLine
    line5 renderLine 
    xPos @ line6
    renderLineWithPlayer
    line7 renderLine 
  again ;

: renderGame ( -- )
  line1 lines @ .s drop drop

  5 begin
    \ dup yPos @ = if
      dup lines swap cells + @ .s      \ stack: counter, xPos, line, length
      renderLine
    \ endif
    1 1 =
  until ;
    
\ dup xPos @ swap .s            \ stack: counter, xPos, counter

\ Starting Logic 

clear-screen
banner-screen
115 check-keypress
." success"
newline

line1 renderLine
line2 renderLine
line3 renderLine
line4 renderLine
line5 renderLine 
xPos @ line6
renderLineWithPlayer
line7 renderLine

renderGame

\ gameLoop


