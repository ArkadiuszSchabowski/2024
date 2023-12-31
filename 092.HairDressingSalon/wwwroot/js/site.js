class MainContent {
    constructor() {
        this.imageSectionIntroduction = document.getElementById("imageSectionIntroduction");
        this.hairstylesPhotos = document.getElementById("hairstylesPhotos");
        this.hairStylesArray = [
            "../images/hairstyles/hair1.jpg",
            "../images/hairstyles/hair2.jpg",
            "../images/hairstyles/hair3.jpg"
        ];
        this.currentImageIndex = 0;
        this.cureentOpinion = 0;
        this.opinionsContent = document.getElementById("opinionsContent");
        this.btnPreviousOpinion = document.getElementById("btnPreviousOpinion");
        this.btnNextOpinion = document.getElementById("btnNextOpinion");
        this.arrayOpinions = [];
    }

    Init() {
        this.DisplayMainPhoto();
        this.DisplayHairstylesPhoto();
        this.DisplayOpinions();
        this.SetButtonsAction();
    }

    SetButtonsAction() {
        this.btnPreviousOpinion.addEventListener("click", () => {
            this.cureentOpinion--;

            if (this.cureentOpinion < 0) {
                this.cureentOpinion = this.arrayOpinions.length - 1;
                this.DisplayOpinions();
            }
            else this.DisplayOpinions();
        });

        this.btnNextOpinion.addEventListener("click", () => {
            this.cureentOpinion++
            if (this.cureentOpinion == this.arrayOpinions.length) {
                this.cureentOpinion = 0;
                this.DisplayOpinions();
            }
            else this.DisplayOpinions();
        });
    }

    DisplayMainPhoto() {
        let mainPhoto = document.createElement("img");

        mainPhoto.src = "../images/others/hairSalon.jpg";

        mainPhoto.style.width = "100%";
        mainPhoto.style.height = "100%";
        mainPhoto.style.borderBottom = "1px solid white";

        this.imageSectionIntroduction.appendChild(mainPhoto);
    }

    DisplayHairstylesPhoto() {
        let firstImage = document.createElement("img");
        firstImage.style.width = "100%";
        firstImage.style.height = "100%";
        firstImage.style.borderRadius = "50%";
        this.hairstylesPhotos.appendChild(firstImage);

        setInterval(() => {
            if (this.hairstylesPhotos.firstChild) {
                this.hairstylesPhotos.removeChild(this.hairstylesPhotos.firstChild);
            }
            let newImage = document.createElement("img");
            newImage.src = this.hairStylesArray[this.currentImageIndex];
            newImage.style.width = "100%";
            newImage.style.height = "100%";
            newImage.style.borderRadius = "50%";
            this.hairstylesPhotos.appendChild(newImage);
            if (this.currentImageIndex < this.hairStylesArray.length - 1) {
                this.currentImageIndex++;
            } else {
                this.currentImageIndex = 0;
            }
        }, 2000);
    }

    DisplayOpinions() {
        this.arrayOpinions = [
            "Bardzo dobry fryzjer. Będę stałym klientem ;-)",
            "Polecam! Super fryzura, niskie ceny!",
            "Pełen profesjonalizm, fryzura spełnia wszystkie moje oczekiwania!"
        ];
        this.opinionsContent.innerHTML = this.arrayOpinions[this.cureentOpinion];
    }
}

let mainContent = new MainContent();
mainContent.Init();