
let cart = JSON.parse(sessionStorage.getItem("Cart")) || []
let totalPrice = 0
const load = addEventListener("load", () => {
    drawProductsInCart()
})


const drawProductsInCart = () => {
    
    for (let i = 0; i < cart.length; i++) {
         totalPrice+=cart[i].price
        drawOneProductInCart(cart[i])
    }
    totalAmountAndPrice(totalPrice)
}
const totalAmountAndPrice = (total) => {
   document.getElementById("totalAmount").innerHTML =`$${total}`
   document.getElementById("itemCount").innerHTML =cart.length
}

const drawOneProductInCart = (product) => {
    let url = `bags/${product.picture}`
    //let total+=product.price
    let tmp = document.getElementById("temp-row")
    let cloneProductInCart = tmp.content.cloneNode(true)
    cloneProductInCart.querySelector(".image").style.backgroundImage=`url(${url})`
    cloneProductInCart.querySelector(".itemName").innerText=product.productName
    cloneProductInCart.querySelector(".price").innerText = `$${product.price}`
    cloneProductInCart.querySelector(".expandoHeight").addEventListener("click", () => { deleteProductInCart(product.productName) })

  /*  cloneProductInCart.querySelector(".totalColumn delete").addEventListener("click", () => { deleteProductInCart(product.productName)})*/

    //cloneProductInCart.querySelector(".Hide DeleteButton showText")
    document.querySelector("tbody").appendChild(cloneProductInCart)
}

const deleteProductInCart = (pName) => {
    //let cart = JSON.parse(sessionStorage.getItem("Cart")) || []
    //let a=cart.find(p => p.productName = pName)
    let pid = cart.findIndex(c=>c.productName==pName)
    console.log(pid)
    cart.splice(pid, 1)
    console.log(cart)
    sessionStorage.setItem("Cart", JSON.stringify(cart))
    document.querySelector("tbody").innerHTML = ""
    drawProductsInCart()
}

const placeOrder = async () => {
   let order = createOrder()
    try { 
        const data = await fetch("api/Orders", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body:JSON.stringify(order)
        })
        let orderData = await data.json()
        if (data.status == 400) {
               alert(`Your order can not complete`)
        }
        else {
            alert("your order place successfully!!!")
            sessionStorage.setItem("Cart", JSON.stringify([]))
            window.location.href = "products.html"
}
    }
       
    catch (error) {
}
}

const createOrder = () => {
    const orderItemsList = cart.map(c => { return { "productId": c.id,"quantity":1} })
    
    let order = {
        "orderDate":new Date(),
        "orderSum": totalPrice,
        "userId": JSON.parse(sessionStorage.getItem("id")) || "",
        "orderItems": orderItemsList
    }
    return order;

}


   
