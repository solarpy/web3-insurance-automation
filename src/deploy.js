const { ethers } = require("hardhat");

async function main() {
    const Alarm = await ethers.getContractFactory("Alarm");

    const alarm = await Alarm.deploy();
    console.log("Contract deployed to address:", alarm.address);
 }
 
 main()
   .then(() => process.exit(0))
   .catch(error => {
     console.error(error);
     process.exit(1);
   });