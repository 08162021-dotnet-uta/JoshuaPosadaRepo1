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
			                     <!-- Product image-->
			                     <img class="card-img-top" src="https://dummyimage.com/450x300/dee2e6/6c757d.jpg" alt="..." />
			                     <!-- Product details-->
			                     <div class="card-body p-4">
			                         <div class="text-center">
			                             <!-- Product name-->
			                             <h5 class="fw-bolder">${data[x].productName}</h5>
										<h2 class="fw-bolder">${data[x].productPrice}</h2>
			                             <!-- Product price-->
			                             ${data[x].productDescription}
			                         </div>
			                     </div>
			                     <!-- Product actions-->
			                     <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
			                         <div class="text-center"><a class="btn btn-outline-dark mt-auto" href="#">Add to Cart</a></div>
			                     </div>
			                 </div>
			             </div>`;
			         }


			});
		
})();