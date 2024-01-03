class Booking {
    constructor() {
        this.hairdresserName = document.getElementById("hairdresserName");
        this.leftImageTeam = document.getElementById("leftImageTeam");
        this.centerImageTeam = document.getElementById("centerImageTeam");
        this.rightImageTeam = document.getElementById("rightImageTeam");
        this.btnPreviousImage = document.getElementById("btnPreviousImage");
        this.btnNextImage = document.getElementById("btnNextImage");
        this.teamMembersArray = [
            "../images/team/Araya.jpg",
            "../images/team/any.jpg",
            "../images/team/Chen.jpg",
            "../images/team/Kim.jpg",
            "../images/team/Sanya.jpg"
        ];

        this.Init();
    }
    Init() {
        this.SetPhotosHairdressers();
    }
    SetPhotosHairdressers() {
        let leftImage = document.createElement("img");
        let centerImage = document.createElement("img");
        let rightImage = document.createElement("img");

        leftImage.src = this.teamMembersArray[0];
        centerImage.src = this.teamMembersArray[1];
        rightImage.src = this.teamMembersArray[2];

        this.SetImagesProperties(leftImage, centerImage, rightImage)
    }
    SetImagesProperties(firstImage, secondImage, thirdImage) {
        let arrayImages = [
            firstImage,
            secondImage,
            thirdImage
        ];

        for (let i = 0; i < arrayImages.length; i++) {
            arrayImages[i].style.position = "absolute";
            arrayImages[i].style.width = "100%";
            arrayImages[i].style.height = "100%";
            arrayImages[i].style.borderRadius = "10px";
        }

        this.leftImageTeam.appendChild(arrayImages[0]);
        this.centerImageTeam.appendChild(arrayImages[1]);
        this.rightImageTeam.appendChild(arrayImages[2]);

    }
}
let booking = new Booking();
booking.Init();