// SPDX-License-Identifier: GPL-3.0
pragma solidity >=0.4.25 <0.9.0;

contract Mapping {
    // Mapping from address to uint
    mapping(string => address) public myMap;

    event Map(address contractAddress);

    function getId(string memory _id) public returns (address) {
        // Mapping always returns a value.
        // If the value was never set, it will return the default value.
        emit Map(myMap[_id]);
        return myMap[_id];
    }

    function getIdview(string memory _id) public view returns (address) {
       return myMap[_id];
    }

    function setId(string memory _id, address _addr) public {
        // Update the value at this address
        myMap[_id] = _addr;
    }

    function removeId(string memory _id) public {
        // Reset the value to the default value.
        delete myMap[_id];
    }
}