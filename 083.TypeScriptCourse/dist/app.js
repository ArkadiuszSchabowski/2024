let btn = document.getElementById("btnBuy");
let price = 50;
let discountValue = 0.1
let discount = false;

btn.addEventListener("click", () =>{
    if(discount){
        let newPrice = price * price - (price*discountValue);
        console.log(`You buy this for ${newPrice}zl`);
        return;
    }
    console.log(`You buy this for ${price} zl`)
});