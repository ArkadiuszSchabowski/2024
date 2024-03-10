let btn = document.getElementById("btnBuy");
let discount = false;

btn.addEventListener("click", () =>{
    if(discount){
        console.log("You buy this for price - discount")
    }
    console.log("You buy this for normal price")
})