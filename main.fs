: clear-screen page ;
: print-nl 10 emit ;

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

  form ( height width )
  2 / swap 2 /
  blank-gamefield
  print-nl print-nl print-nl
  ."     "
  ;

clear-screen
banner-screen

