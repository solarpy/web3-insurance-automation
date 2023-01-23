//inputValues = []

function input () {
  const prompt = require('prompt-sync')();

  const emailAddress = prompt('Input your Email Address:');

  const policy = prompt("Input your Policy ID: ");

  const duration = prompt("Input your duration: ");

  const date_of_policy = prompt("Input Date of Policy: "); //DD/MM/YYYY

  const phone = prompt("Input Phone Number: ");

  const name = prompt("Input Full Name: ");

  const price = prompt("Input Price of Policy: ");

  const payment = prompt("Please make an initial payment of :$", "before proceding")

  return {"emailAddress":emailAddress, "policy":policy, "duration":duration, "date_of_policy":date_of_policy
  , "phone":phone, "name":name, "price":price}

  //inputValues.push(emailAddress, policy, duration, date_of_policy, phone, name, price)
}



module.exports = {
  input //inputValues
}