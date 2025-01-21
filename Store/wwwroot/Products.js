
const categories = []
sessionStorage.setItem("Categories", JSON.stringify(categories))
//const cart = []
//localStorage.setItem("Cart", JSON.stringify(cart))

const load = addEventListener("load", async () => {
    getProductsList()
    getCategories()
    let updateCart = JSON.parse(sessionStorage.getItem("Cart")) || []
    document.querySelector("#ItemsCountText").innerHTML = updateCart.length
})

const getAllFilters = () => {
    document.getElementById('ProductList').innerHTML =""
    const filter = {
        position: position = 0,
        skip: skip = 0,
        minPrice: document.querySelector('#minPrice').value,
        maxPrice: document.querySelector('#maxPrice').value,
        desc: document.querySelector('#nameSearch').value,
        categoryIds: JSON.parse(sessionStorage.getItem("Categories"))||[]
    }
    return filter;
}
const getProductsList = async () => {
    let filters = getAllFilters();
    let url = `api/Products/?position=${filters.position}&skip=${filters.skip}`
    if (filters.desc != '')
        url +=`&desc=${filters.desc}`
    if (filters.minPrice != '')
        url +=`&minPrice=${filters.minPrice}`
    if (filters.maxPrice != '')
        url+=`&maxPrice=${filters.maxPrice}`
    if (filters.categoryIds.length != 0) { 
        for (let i=0; i < filters.categoryIds.length; i++) { 
            url +=`&categoryIds=${filters.categoryIds[i]}`
        }
    }

    try {
        const response = await fetch(url, {
            method: 'GET',
            headers: {
                "Content-Type": "application/json"
            },
            query: {
                position: filters.position, skip: filters.skip, desc: filters.desc,
                minPrice: filters.minPrice, maxPrice: filters.maxPrice, categoryIds: filters.categoryIds
            }
        })
        
        if (response.status == 204) {
            alert("there is not products")
        }
        else { 
            const productData = await response.json()
            console.log(productData)
            drawProducts(productData)
        }
      
    }
        catch (error) {
            console.log(error)
        }
    }



const drawProducts = (products) => {
    for (let i = 0; i < products.length; i++) {
        drawOneProduct(products[i])
    }
}


const drawOneProduct = (product) => {
    let tmp = document.getElementById('temp-card');
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector('img').src = `./bags/${product.picture}`
    cloneProduct.querySelector('h1').textContent = product.productName
    cloneProduct.querySelector('.price').innerText = `$${product.price}`
    cloneProduct.querySelector('.description').innerText = product.description
    cloneProduct.querySelector('button').addEventListener("click", () => { addToCart(product) })
    document.getElementById('ProductList').appendChild(cloneProduct)
}

const getCategories = async() => {
    try {
        const data =await fetch('api/Categories', {
            method: 'GET',
            headers: {
                "Content-Type": "application/json"
            },
        }),
         categories = await data.json()
        
        if (categories.status == 204) {
            alert("There is no categories")
            categories = []
        }
        else { 
            drawCategories(categories)
        }
    }
    catch (error) {
        console.log()
    }
}

const drawCategories = (categories) => {
    for (let i = 0; i < categories.length; i++) {
        drawOneCategory(categories[i])
    }
}


const drawOneCategory = (category) => {
    console.log(category)
    let tmp = document.getElementById('temp-category');
    let cloneCategory = tmp.content.cloneNode(true)
    cloneCategory.querySelector('.opt').addEventListener("change", () => { chooseCategories(category.id)}) 
    cloneCategory.querySelector('.OptionName').innerText = category.categoryName
    document.getElementById('categoryList').appendChild(cloneCategory)
}

const chooseCategories = (cId) => {
    let currCategories = JSON.parse(sessionStorage.getItem("Categories"))
    let cindex = currCategories.indexOf(cId)
    if (cindex == -1) {
        currCategories.push(cId)
        console.log(currCategories)
    }
    else {
        currCategories.splice(cindex,1)
        console.log(currCategories)
    }
    sessionStorage.setItem("Categories", JSON.stringify(currCategories))
    getProductsList()
}
const addToCart = (product) => {
    if (!JSON.parse(sessionStorage.getItem("id"))) {
        alert("you have not login yet")
        window.location.href = "login.html"
    }
    else { 
    let updateCart = JSON.parse(sessionStorage.getItem("Cart"))||[]
        updateCart.push(product)
        sessionStorage.setItem("Cart", JSON.stringify(updateCart))
        document.querySelector("#ItemsCountText").innerHTML = updateCart.length
    }
} 
