
function trackRobot() {
  var x = 0;
  var y = 0;
  for (let i = 0; i < arguments.length; i++) {
    if (i % 4 == 0)
      y += arguments[i];
    else if (i % 4 == 1)
      x += arguments[i];
    else if (i % 4 == 2)
      y -= arguments[i];
    else if (i % 4 == 3)
      x -= arguments[i];
  }
  return [x, y];
}

console.log(trackRobot());

var coins = [500, 200, 100, 50, 20, 10];

var Products = [
  { name: 'Gum', cost: 400 },
  { name: 'Ritbits', cost: 170 },
  { name: 'Hershey bar', cost: 100 },
  { name: 'Honeybun', cost: 50 },
  { name: 'Cookies n Cream', cost: 100 },
  { name: 'Honeybun', cost: 50 },
  { name: 'Crackers', cost: 300 },
]

function vendingMachine() {
  if (arguments[2] == 0 || arguments[2] > arguments[2].length)
    return "Enter a valid product number"
  else if (arguments[1] < arguments[0][arguments[2] - 1].cost)
    return "Not enough money for this product"

  var totalremainder = arguments[1] - arguments[0][arguments[2] - 1].cost;
  console.log(totalremainder);
  var change = [];
  while (totalremainder > 0) {
    for (i = 0; i < coins.length; i++) {
      if (totalremainder >= coins[i]) {
        change.push(coins[i]);
        totalremainder -= coins[i]
        break;
      }
    }
  }
  return "{product: " + arguments[0][arguments[2] - 1].name + ",change: " + JSON.stringify(change) + "}";


}
