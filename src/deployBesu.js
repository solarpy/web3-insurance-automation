const { ethers } = require("hardhat");

async function main() {
    const Mapping = await ethers.getContractFactory("Mapping");

    const mapping = await Mapping.deploy();
    console.log("Contract deployed to address:", mapping.address);
 }
 
 main()
   .then(() => process.exit(0))
   .catch(error => {
     console.error(error);
     process.exit(1);
   });




  
  
