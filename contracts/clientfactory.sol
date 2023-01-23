// SPDX-License-Identifier: GPL-3.0
pragma solidity >=0.4.25 <0.9.0;

contract PolicySmartContract {

    //Emitted when update function is called
   //Smart contract events are a way for your contract to communicate that something happened on the blockchain to your app front-end, which can be 'listening' for certain events and take action when they happen.
   event _updatedMessages(string newMessage, string policy, string duration, string date_of_policy, string phone, string name, string price);

   // Declares a state variable `message` of type `string`.
   // State variables are variables whose values are permanently stored in contract storage. The keyword `public` makes variables accessible from outside a contract and creates a function that other contracts or clients can call to access the value.
   string public message;
   string public policy;
   string public duration;
   string public date_of_policy;
   string public phone;
   string public name;
   string public price;

   // Similar to many class-based object-oriented languages, a constructor is a special function that is only executed upon contract creation.
   // Constructors are used to initialize the contract's data. Learn more:https://solidity.readthedocs.io/en/v0.5.10/contracts.html#constructors

   constructor(string memory newMessage, string memory _policy, string memory _duration, string memory _date_of_policy, string memory _phone, string memory _name, string memory _price) {
      message = newMessage;
      policy = _policy;
      duration = _duration;
      date_of_policy = _date_of_policy;
      phone = _phone;
      name = _name;
      price = _price;
   }

   function getEmailAddress() view public returns (string memory) {
       return message;
   }

   function getPolicy() view public returns (string memory) {
       return policy;
   }

   function getDuration() view public returns (string memory) {
       return duration;
   }

   function getDate_of_policy() view public returns (string memory) {
       return date_of_policy;
   }

   function getPhone() view public returns (string memory) {
       return phone;
   }

   function getName() view public returns (string memory) {
       return name;
   }

   function getPrice() view public returns (string memory) {
       return price;
   }

}

contract SmartContractFactory {

    PolicySmartContract a;
    event Policy(PolicySmartContract a, string newMessage, string policy, string duration, string date_of_policy, string phone, string name, string price);

    function update(string memory newMessage, string memory _policy, string memory _duration, string memory _date_of_policy, string memory _phone, string memory _name, string memory _price) public returns(PolicySmartContract) {
      // Create the policy smart contract here
       a = new PolicySmartContract(newMessage, _policy, _duration, _date_of_policy, _phone, _name, _price);
       emit Policy(a, newMessage, _policy, _duration, _date_of_policy, _phone, _name, _price);
       return a; 
   }
}