class MainContent {
    constructor() {
        this.imageSectionOne = document.getElementById("imageSectionOne");
        this.offerPhotos = document.getElementById("offerPhotos");
    }
    Init() {
        this.DisplayMainPhoto();
        this.AddImagesToDiv();
    }
    DisplayMainPhoto() {
        let mainPhoto = document.createElement("img");

        mainPhoto.src = "../images/others/hairSalon.jpg";

        mainPhoto.style.width = "100%";
        mainPhoto.style.height = "100%";
        mainPhoto.style.borderBottom = "1px solid white";

        this.imageSectionOne.appendChild(mainPhoto);
    }

    AddImagesToDiv() {

    }
}
let mainContent = new MainContent();
mainContent.Init();