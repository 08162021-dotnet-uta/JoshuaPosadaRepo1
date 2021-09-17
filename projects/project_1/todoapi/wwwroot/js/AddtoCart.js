window.addEventListener("load", addhandlerorsomething);

function addhandlerorsomething() {
    var guid = CreateGuid();
    const addtocart = document.querySelector(".jsonpostaddtocart");
    console.log(addtocart);
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


        const userData2 = {
            OrderId: guid,
            CustomerId: sessionStorage.getItem('customerid'),
            StoreProductId: 1,
            ProductId: sessionStorage.getItem('productid'),
            OrderDate: new Date()
        }
        //GET fetch request
        fetch('/api/ItemizedOrders/addtostorecartIO', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userData2)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Network response was not ok (${response.status})`);
                } else // When the page is loaded convert it to text
                    return response.json();
            })
            .then(res => {
                sessionStorage.setItem('user', JSON.stringify(res)); //, json.stringify(res));
                let user = sessionStorage.getItem('user');
                console.log(sessionStorage.user);
                location.href = "Store.html";
            })
            .then((jsonResponse) => {
                //debugger;
                //console.log(jsonResponse);
                ////registerResponse.textContent
                ////registerResponse.textContent = ` Welcome, ${jsonResponse.fname} ${jsonResponse.lname}`;
                ////console.log(jsonResponse);
                //location.href = "Store.html";
                //return jsonResponse;
            })
            //.then(res => {
            //	//save the personId to localStorage
            //	localStorage.setItem('person', JSON.stringify(res));// this is available to the whole browser
            //	sessionStorage.setItem('personId', res);// this is ony vailable to the certain window tab.
            //	//switch the screen
            //	location.href = "Store.html";
            //location = 'index.html';// 
            //})
            .catch(function (err) {
                console.log('Failed to fetch page: ', err);
            });
    })
};





function CreateGuid() {
    function _p8(s) {
        var p = (Math.random().toString(16) + "000000000").substr(2, 8);
        return s ? "-" + p.substr(0, 4) + "-" + p.substr(4, 4) : p;
    }
    return _p8() + _p8(true) + _p8(true) + _p8();
}