: clear-screen page ;
: newline 10 emit ;

: blank-gamefield ( x y -- )
  2 -
  swap 73 2 / - swap
  2dup     at-xy ." >   ----------------------------------| "
  2dup 1 + at-xy ." |-- ----------------------------------| "
  2dup 2 + at-xy ." |-- ----------------------------------| "
  2dup 3 + at-xy ." |--                                   F "
       4 + at-xy ." |-------------------------------------|"
  ;

: banner-screen ( -- )
  clear-screen
  ." Welcome to ForthMaze"
  newline
  ." Press S + Enter to start"
  ;

: check-keypress ( x -- )
  begin
      key
      over =
    until
  drop ;

clear-screen
banner-screen
98 check-keypress
." success"


      





