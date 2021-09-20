window.addEventListener("load", addhandlestoreproducts);

function addhandlestoreproducts() {
	console.log(sessionStorage);
	//fetch("Products/Productlist")
	fetch(`api/Products/ProductsbyStore/${sessionStorage.StoreId}`)
		.then(res => res.json())
		.then(data => {
			console.log(data)
			const lop = document.querySelector('.listofstoreproducts');

			for (let x = 0; x < data.length; x++) {
				let counter2 = 0;
				if (sessionStorage.getItem('productid' + data[x].productId))
					counter2 = parseInt(sessionStorage.getItem('productid' + data[x].productId));
				else
					counter2 = 0;
	


					lop.innerHTML += `
			             <div class="col mb-5">
			                 <div class="card h-100">
			                    
			                     <div class="card-body p-4">
			                         <div class="text-center">
			                             <!-- Product name-->
			                             <h5 class="fw-bolder">${data[x].productName}</h5>
										<h5 class="fw-bolder">Quantity Left: ${data[x].productQuantity - counter2}</h5>
										<h2 class="fw-bolder">$${data[x].productPrice}</h2>
			                             <!-- Product price-->
			                             ${data[x].productDescription}
			                         </div>
			                     </div>
			                    
			                 </div>
			             </div>`;
				
				
			}



		});
		
};
