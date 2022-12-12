\ Maze definition
: line1 s" |------------------------------|" ;
: line2 s" >   |--------------------------|" ;
: line3 s" |-| |---|        |-------------|" ;
: line4 s" |-|       |-----|       |------|" ;
: line5 s" |-| |-----------| |---|        F" ;
: line6 s" |-|               |------------|" ;
: line7 s" |------------------------------|" ;

: clear-screen page ;
: newline 10 emit ;

: renderLine ( x -- )
  type newline ;

: renderLineWithPlayer ( position line len -- )
  { position line len }
  line position 1 - type
    ." P"
  line position + len position - type newline ;

: swap ( x1 x2 -- x2 x1 x2 )
  { a b } b a b .s ;

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

variable xPos
variable yPos
10 xPos !
1 yPos !

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
      






