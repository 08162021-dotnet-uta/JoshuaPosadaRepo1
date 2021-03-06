(function () {
	fetch("Stores/Storelist")
		.then(res => res.json())
		.then(data => {
			console.log(data)
            const lop = document.querySelector('.listofstores');

            for (let x = 0; x < data.length; x++) {
                 
                lop.innerHTML += `
                <div class="col mb-5" onmouseover="sessionStorage.StoreId=${data[x].storeId}">
                    <div class="card h-100">
                        <!-- Product details-->
                        <div class="card-body p-4">
                            <div class="text-center">
                                <!-- Product name-->
                                <h5 class="fw-bolder">${data[x].storeName}</h5>
                                <!-- Product price-->
                                Store ID: ${data[x].storeId}
                            </div>
                        </div>
                        <!-- Product actions-->
                        <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                            <div class="text-center"><a class="btn btn-outline-dark mt-auto" href="storesorderhistory.html"><div id="${data[x].storeId}" onClick="sessionStorage.StoreId=${data[x].storeId}">View Products</div></a></div>
                             
                         </div>
                    </div>
                </div>`;
            }
  

		});
})();