const { ethers } = require("hardhat");
// For Hardhat
const contract = require("./artifacts/contracts/ClientFactory.sol/SmartContractFactory.json");
// Provider
const provider = new ethers.providers.WebSocketProvider("ws://localhost:9545");
// Signer
const signer = new ethers.Wallet("06b91f40bafe25bb97844ca576675d475ad4c197a4acab0f00a7dabf8326d480", provider);
// Contract
const client = new ethers.Contract("0x3f21BC64076e7c9ed8695d053DCCBE6D8d5E6f43", contract.abi, signer);

const express = require("express");
const bodyParser = require("body-parser");
const app = express();

app.listen(3000, () => {
  console.log("Application started and Listening on port 3000");
});

// server css as static
app.use(express.static(__dirname));

// get our app to use body parser 
app.use(bodyParser.urlencoded({ extended: true }))

app.get("/", (req, res) => {
  res.sendFile(__dirname + "/public/index.html");
});

app.post("/", async (req, res) => {
  const emailAddress = req.body.emailAddress
  const policy = req.body.policy;
  const name = req.body.name;
  const date_of_policy = req.body.date_of_policy;
  const phone = req.body.phone;
  const duration = req.body.duration;
  const price = req.body.price;
  console.log(emailAddress, policy, name, date_of_policy, phone, duration, price);

  // Wait for all of the Client Information to be stored
  const txc = await client.update(emailAddress, policy, name, date_of_policy, phone, duration, price);
  const receipt = await txc.wait()
    console.log(receipt.events);

    }
 //res.send("Hello " + subName + ", Thank you for subcribing. You email is " + subEmail);
);
