const { ethers } = require("hardhat");
// For Hardhat
const contract = require("../artifacts/contracts/mapping.sol/Mapping.json");
const contract1 = require("../artifacts/contracts/clientfactory.sol/PolicySmartContract.json");
// Provider
const provider = new ethers.providers.WebSocketProvider("ws://localhost:9545");
// Signer
const signer = new ethers.Wallet("06b91f40bafe25bb97844ca576675d475ad4c197a4acab0f00a7dabf8326d480", provider);
// Contract
const payment = new ethers.Contract("0x7B3BEA60bD856E8095f73d7F79E5f932f98F2B35", contract.abi, signer);


async function paymentrpa() {
    while (true) {
      // View Data
      const prompt = require('prompt-sync')();
      const policy = prompt("Input your Policy ID: ");
      const viewId = await payment.getIdview(policy);
      const newClient = new ethers.Contract(viewId, contract1.abi, signer);
      const price = await newClient.getPrice();
      const premiumPayment = prompt("Please make payment for your Premium costing "+price+" per annum:$")
      const eventId = await payment.getId(policy);
      const receipt = await eventId.wait();
      console.log("Smart Contract Address for Policy Id", policy,"is", viewId );    
      console.log(receipt.events);
    }
  }

  paymentrpa();
