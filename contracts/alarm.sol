//SPDX-License-Identifier: UNLICENSED

pragma solidity >=0.4.25 <0.9.0;

contract Alarm {
    uint number = 25;
    event Plus(uint plus);

   function Add(uint add) public {
       number = number + add;
       emit Plus(number);
   }
   
   function getInput() view public returns (uint) {
       return number;
   }
}