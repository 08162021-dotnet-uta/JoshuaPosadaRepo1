function getConsonantSubstrings() {
  var str = arguments[0];
  let vowels = new Array('a', 'e', 'i', 'o', 'u');
  let Aarray = new Array();
  for (var i = 0; i < str.length; i++) {
    if (!vowels.includes(str[i])) {
      if (!Aarray.includes(str[i]))
        Aarray.push(str[i]);
      for (var j = str.length; j > i; j--) {
        if (!vowels.includes(str[j])) {
          if (!Aarray.includes(str.substring(i, j + 1)))
            Aarray.push(str.substring(i, j + 1));
        }
      }
    }

  }
  Aarray = Aarray.sort();
  return Aarray;
}

function getVowelSubstrings() {
  var str = arguments[0];
  let vowels = new Array('a', 'e', 'i', 'o', 'u');
  let Aarray = new Array();
  for (var i = 0; i < str.length; i++) {
    if (vowels.includes(str[i])) {
      if (!Aarray.includes(str[i]))
        Aarray.push(str[i]);
      for (var j = str.length; j > i; j--) {
        if (vowels.includes(str[j])) {
          if (!Aarray.includes(str.substring(i, j + 1)))
            Aarray.push(str.substring(i, j + 1));
        }
      }
    }

  }
  Aarray.sort();
  return Aarray;
}

function redundant() {
  return f1(arguments[0])
}
function f1() {
  return arguments[0]
}
