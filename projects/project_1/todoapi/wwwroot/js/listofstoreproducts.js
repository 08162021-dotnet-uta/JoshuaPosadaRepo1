(function () {
	console.log(sessionStorage);
	//fetch("Products/Productlist")
	fetch(`api/Products/ProductsbyStore/${sessionStorage.StoreId}`)
		.then(res => res.json())
		.then(data => {
			console.log(data)
			const lop = document.querySelector('.listofstoreproducts');

			for (let x = 0; x < data.length; x++) {
				lop.innerHTML += `
			             <div class="col mb-5">
			                 <div class="card h-100">
			                    
			                     <div class="card-body p-4">
			                         <div class="text-center">
			                             <!-- Product name-->
			                             <h5 class="fw-bolder">${data[x].productName}</h5>
										<h5 class="fw-bolder">Quantity: ${data[x].productQuantity}</h5>
										<h2 class="fw-bolder">$${data[x].productPrice}</h2>
			                             <!-- Product price-->
			                             ${data[x].productDescription}
			                         </div>
			                     </div>
			                     <!-- Product actions-->
			                     <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                <div class="text-center"><a class="btn btn-outline-dark mt-auto" href="productsbystore.html"><div id="${data[x].productId}d" onClick="sessionStorage.productid=${data[x].productId}">Add To Cart</div></a></div>

			                        
			                     </div>
			                 </div>
			             </div>`;
				
			}



		});
		
})();

//function addhandlerorsomething() {
//	const addtocart = document.querySelector(".jsonpostaddtocart");
//	console.log(addtocart);
//	addtocart.addEventListener('click', (e) => {
//		e.preventDefault();
//		const storeid = addtocart.StoreId.value;
//		const productid = addtocart.productId.value;
//		console.log(storeid);
//		console.log(productid);
//		const userData = { StoreguidId: uuidv4(), StoreId: storeid, ProductId: productid }

//		//GET fetch request
//		fetch('addtostorecart', {
//			method: 'POST',
//			headers: {
//				'Accept': 'application/json',
//				'Content-Type': 'application/json'
//			},
//			body: JSON.stringify(userData)
//		})
//			.then(response => {
//				if (!response.ok) {
//					throw new Error(`Network response was not ok (${response.status})`);
//				}
//				else       // When the page is loaded convert it to text
//					return response.json();
//			})
//			.then(res => {
//				sessionStorage.setItem('user', JSON.stringify(res));//, json.stringify(res));
//				let user = sessionStorage.getItem('user');
//				console.log(sessionStorage.user);
//				location.href = "Store.html";
//			})
//			.then((jsonResponse) => {
//				//debugger;
//				//console.log(jsonResponse);
//				////registerResponse.textContent
//				////registerResponse.textContent = ` Welcome, ${jsonResponse.fname} ${jsonResponse.lname}`;
//				////console.log(jsonResponse);
//				//location.href = "Store.html";
//				//return jsonResponse;
//			})
//			//.then(res => {
//			//	//save the personId to localStorage
//			//	localStorage.setItem('person', JSON.stringify(res));// this is available to the whole browser
//			//	sessionStorage.setItem('personId', res);// this is ony vailable to the certain window tab.
//			//	//switch the screen
//			//	location.href = "Store.html";
//			//location = 'index.html';// 
//			//})
//			.catch(function (err) {
//				console.log('Failed to fetch page: ', err);
//			});
//	});
//}

//function uuidv4() { return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) { var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8); return v.toString(16); }); }

