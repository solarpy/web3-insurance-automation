const clientDataInput = require('./clientDataInput.js');

const { ethers } = require("hardhat");
// For Hardhat
const contract = require("../artifacts/contracts/ClientFactory.sol/SmartContractFactory.json");
// Provider
const provider = new ethers.providers.WebSocketProvider("ws://localhost:9545");
// Signer
const signer = new ethers.Wallet("06b91f40bafe25bb97844ca576675d475ad4c197a4acab0f00a7dabf8326d480", provider);
// Contract
const client = new ethers.Contract("0x3f21BC64076e7c9ed8695d053DCCBE6D8d5E6f43", contract.abi, signer);


async function storebesu() {
    while (true) {

    const data = clientDataInput.input();
    
    // Wait for all of the Client Information to be stored
    const txc = await client.update(data.emailAddress, data.policy, data.duration, data.date_of_policy, data.phone, data.name, data.price);
    const receipt = await txc.wait()
      console.log(receipt.events);

      }
    }

    storebesu();
  
