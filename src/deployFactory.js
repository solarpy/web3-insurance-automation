const { ethers } = require("hardhat");

async function main() {
    const Factory = await ethers.getContractFactory("SmartContractFactory");

    const factory = await Factory.deploy();
    
    console.log("Contract deployed to address:", factory.address);
 }
 
 main()
   .then(() => process.exit(0))
   .catch(error => {
     console.error(error);
     process.exit(1);
   });