\ Maze definition
: line1 s" |------------------------------|" ;
: line2 s" |   |--------------------------|" ;
: line3 s" |-| |---|        |-------------|" ;
: line4 s" |-|       |-----|       |------|" ;
: line5 s" |-| |-----------| |---|        F" ;
: line6 s" |-|               |------------|" ;
: line7 s" |------------------------------|" ;

variable xPos
variable yPos
2 xPos !
1 yPos !

\ stringlength must not be saved, as it is static
create lines 
  line1 drop , line2 drop , line3 drop , line4 drop , line5 drop , line6 drop , line7 drop , 

variable lineLen
32 lineLen !

variable lineCnt
7 lineCnt !

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
  newline
  ;

: winScreen ( -- )
  ." Congratulations!" newline
  ." You successfully escaped the maze!" newline
  ." Press s + Enter to start a new game"
  115 checkKeypress
  newline
  ;

: checkCollision ( u1 u2 c -- u1 u2 f)  \ check if f is bool??, c for char??
  { x y char }
    x y
    lines y cells + @       \ get line     
    x 1 - chars + c@        \ get character at position
    char =                    \ check if position is moveable
  ;

: movePlayer ( u1 u2 -- u1 u2 )
  { x y }
    key
    case
      'w' of x y 1 - endof
      'a' of x 1 - y endof
      's' of x y 1 + endof
      'd' of x 1 + y endof
    endcase 
    ;

: renderLineWithoutPlayer ( c-addr u -- )
  type newline ;

: renderLineWithPlayer ( c-addr u -- )
  { line len }
  line xPos @ 1 - type
    ." >"
  line xPos @ + len xPos @ - type newline ;
  
\ expects the line (addr + len) and the y-index of the line
: renderLine ( c-addr u1 u2 -- )
  yPos @ = if
        renderLineWithPlayer
      else
        renderLineWithoutPlayer
      endif ;

: renderGame ( -- )
  lineCnt @ 0 u+do
    lines i cells + @ lineLen @ i renderLine
  loop
  newline ;

: gameLoop ( -- )
  renderGame
  begin
    xPos @ yPos @
    movePlayer

    32 checkCollision invert if     \ check if field is movable
      70 checkCollision if            \ check if player may have won
        clearScreen winScreen
        2 xPos ! 1 yPos !
      else
        drop drop
      endif
    else
      yPos ! xPos !
    endif

    renderGame
  again ;


\ Starting Logic 

clearScreen
startScreen

gameLoop
