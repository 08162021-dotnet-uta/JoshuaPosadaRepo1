
//we can call an IIFE to get a list of all the customers
(function () {
	fetch("customer/Customerlist")
		.then(res => res.json())
		.then(data => {
			console.log(data)
			const lop = document.querySelector('.listofplayers');
			for (let x = 0; x < data.length; x++) {

                lop.innerHTML += `
                <div class="col mb-5">
                    <div class="card h-100">
                        <!-- Product image-->
                        <img class="card-img-top" src="https://static3.bigstockphoto.com/6/2/4/small2/426681128.jpg" alt="..." />
                        <!-- Product details-->
                        <div class="card-body p-4">
                            <div class="text-center">
                                <!-- Product name-->
                                <h5 class="fw-bolder">${data[x].fname} ${data[x].lname}</h5>
                                <!-- Product price-->
                                Email: ${data[x].email}
                            </div>
                        </div>
                        <!-- Product actions-->
                        <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
<div class="text-center"><a class="btn btn-outline-dark mt-auto" href="ordersbyStore.html"><div id="${data[x].customerId}" onClick="sessionStorage.customerId=${data[x].customerId}">View Past Orders</div></a></div>

                       
                        </div>
                    </div>
                </div>`;
            }
			//	lop.innerHTML += `<p>The customer is ${data[x].email} ${data[x].lname}.</p>`;
			
		});
})();




//function validateForm() {
//	let x = document.forms["myForm"]["email"].value;
//	let x = document.forms["myForm"]["password"].value;
//	fetch("customer/Customerlist")
//		.then(res => res.json())
//		.then(data => {
//			console.log(data)
//			const lop = document.querySelector('.listofplayers');
//			for (let y = 0; y < data.length; y++) {
//				data[y].email;
//				lop.innerHTML += `<p>The customer is ${data[x].fname} ${data[x].lname}.</p>`;
//			}
//		});
//	if (x == "") {
//		alert("Name must be filled out");
//		return false;
//	}
