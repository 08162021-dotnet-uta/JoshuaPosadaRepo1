window.addEventListener("load", addhandlerorsomething);

function addhandlerorsomething() {
    //let guid = CreateGuid();
    if (sessionStorage.getItem("guid") === null) {
        sessionStorage.setItem('guid', CreateGuid())
    }
   // localStorage.setItem('guid', CreateGuid())
    const addtocart = document.querySelector(".jsonpostaddtocart");
    addtocart.addEventListener('click', (e) => {
        //    e.preventDefault();
        //    const storeid = sessionStorage.getItem('StoreId'); //sessionStorage.StoreId.value;
        //    const productid = sessionStorage.getItem('productid'); //sessionStorage.productid.value;
        //    console.log(storeid);
        //    console.log(productid);
        //    const userData = {
        //        StoreguidId: '2F472542-41C7-4F87-A5B3-717AFE821304',
        //        StoreId: storeid,
        //        ProductId: productid
        //    }; //storeProductId:-1,StoreguidId: uuidv4(),

        //    //GET fetch request
        //    fetch('/api/StoresProducts/addtostorecart', {
        //        method: 'POST',
        //        headers: {
        //            'Accept': 'application/json',
        //            'Content-Type': 'application/json'
        //        },
        //        body: JSON.stringify(userData)
        //    })
        //        .then(response => {
        //            if (!response.ok) {
        //                throw new Error(`Network response was not ok (${response.status})`);
        //            } else // When the page is loaded convert it to text
        //                return response.json();
        //        })
        //        .then(res => {
        //            sessionStorage.setItem('user', JSON.stringify(res)); //, json.stringify(res));
        //            let user = sessionStorage.getItem('user');
        //            console.log(sessionStorage.user);
        //            location.href = "Store.html";
        //        })
        //        .then((jsonResponse) => {
        //            //debugger;
        //            //console.log(jsonResponse);
        //            ////registerResponse.textContent
        //            ////registerResponse.textContent = ` Welcome, ${jsonResponse.fname} ${jsonResponse.lname}`;
        //            ////console.log(jsonResponse);
        //            //location.href = "Store.html";
        //            //return jsonResponse;
        //        })
        //        //.then(res => {
        //        //	//save the personId to localStorage
        //        //	localStorage.setItem('person', JSON.stringify(res));// this is available to the whole browser
        //        //	sessionStorage.setItem('personId', res);// this is ony vailable to the certain window tab.
        //        //	//switch the screen
        //        //	location.href = "Store.html";
        //        //location = 'index.html';// 
        //        //})
        //        .catch(function (err) {
        //            console.log('Failed to fetch page: ', err);
        //        });
        //});
        var buttonclicked = event.target;
        console.log(buttonclicked);
        if (buttonclicked.classList.contains('outofstock')) {
            console.log(true);
            return;
        }
        var n = sessionStorage.getItem('counter');
        if (n === null) {
            n = 1;
        } else {
            n++;
        }

        sessionStorage.setItem("counter", n);




 
        var user = JSON.parse(sessionStorage.user);
        //var guid = JSON.parse(localStorage.guid);

        var cart = {
            OrderId: sessionStorage.guid,
            CustomerId: user.customerId,
            StoreProductId:1,
            ProductId: sessionStorage.getItem('productid'),
            StoreId: sessionStorage.StoreId,
            OrderDate: formatAMPM(new Date)
        }
        if (sessionStorage.getItem('productid' + sessionStorage.getItem('productid')) != null) {
            var numberparsed = parseInt(sessionStorage.getItem('productid' + sessionStorage.getItem('productid'))) + 1;
            sessionStorage.setItem('productid' + sessionStorage.getItem('productid'), numberparsed);
        }
        else
            sessionStorage.setItem('productid' + sessionStorage.getItem('productid'), 1);

        var record = JSON.stringify(cart);

        localStorage.setItem('cart'+sessionStorage.counter, record);
   

       // var a = a ? JSON.parse(a) : [];
       // a.push(JSON.parse(localStorage.getItem('cart')));
       // localStorage.setItem('cartss', JSON.stringify(a));
       // var names = names ? JSON.parse(localStorage.names) : [];
       // for (var i = 0; i < localStorage.counter-1; i++) {
       //     alert(localStorage.names(i));
       //     names[i] = JSON.parse(localStorage.names(i));

       // }
       // names[localStorage.counter] = JSON.parse(localStorage.getItem('cart'));
       // localStorage.setItem("names", JSON.stringify(names));
       //// var carts =[];// = localStorage.getItem('cart');

       // var carts = carts ? JSON.parse(carts) : [];
    


       // carts.push(JSON.stringify(localStorage.getItem('cart')));

       // localStorage.setItem("carts", JSON.stringify(carts));;
        //location.replace("Store.html");
        //sessionStorage.setItem("cart", { "OrderId": $"{guid}", "CustomerId": sessionStorage.getItem('customerId'), "StoreProductId": "1", "ProductId": sessionStorage.getItem('productid'), "OrderDate": new Date() });
    //    const userData2 = {
    //        OrderId: guid,
    //        CustomerId: 2,//getItem('customerId'),
    //        StoreProductId: 1,
    //        ProductId: sessionStorage.getItem('productid'),
    //        OrderDate: new Date()
    //    }
    //    //GET fetch request
    //    fetch('/api/ItemizedOrders/addtostorecartIO', {
    //        method: 'POST',
    //        headers: {
    //            'Accept': 'application/json',
    //            'Content-Type': 'application/json'
    //        },
    //        body: JSON.stringify(userData2)
    //    })
    //        .then(response => {
    //            if (!response.ok) {
    //                throw new Error(`Network response was not ok (${response.status})`);
    //            } else // When the page is loaded convert it to text
    //                return response.json();
    //        })
    //        .then(res => {
    //            sessionStorage.setItem('user', JSON.stringify(res)); //, json.stringify(res));
    //            let user = sessionStorage.getItem('user');
    //            console.log(sessionStorage.user);
    //            location.href = "Store.html";
    //        })
    //        .then((jsonResponse) => {
    //            //debugger;
    //            //console.log(jsonResponse);
    //            ////registerResponse.textContent
    //            ////registerResponse.textContent = ` Welcome, ${jsonResponse.fname} ${jsonResponse.lname}`;
    //            ////console.log(jsonResponse);
    //            //location.href = "Store.html";
    //            //return jsonResponse;
    //        })
    //        //.then(res => {
    //        //	//save the personId to localStorage
    //        //	localStorage.setItem('person', JSON.stringify(res));// this is available to the whole browser
    //        //	sessionStorage.setItem('personId', res);// this is ony vailable to the certain window tab.
    //        //	//switch the screen
    //        //	location.href = "Store.html";
    //        //location = 'index.html';// 
    //        //})
    //        .catch(function (err) {
    //            console.log('Failed to fetch page: ', err);
    //        });
    })
};





function CreateGuid() {
    function _p8(s) {
        var p = (Math.random().toString(16) + "000000000").substr(2, 8);
        return s ? "-" + p.substr(0, 4) + "-" + p.substr(4, 4) : p;
    }
    return _p8() + _p8(true) + _p8(true) + _p8();
}
function formatAMPM(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return strTime;
}