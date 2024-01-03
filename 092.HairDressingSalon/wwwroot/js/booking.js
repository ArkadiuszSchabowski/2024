class Booking {
    constructor() {
        this.hairdresserName = document.getElementById("hairdresserName");
        this.leftImageTeam = document.getElementById("leftImageTeam");
        this.centerImageTeam = document.getElementById("centerImageTeam");
        this.rightImageTeam = document.getElementById("rightImageTeam");
        this.btnPreviousImage = document.getElementById("btnPreviousImage");
        this.btnNextImage = document.getElementById("btnNextImage");
        this.teamMembers = [
            "../images/team/araya.jpg",
            "../images/team/any.jpg",
            "../images/team/chen.jpg",
            "../images/team/kim.jpg",
            "../images/team/sanya.jpg"
        ];
        this.Araya = document.createElement("img");
        this.Any = document.createElement("img");
        this.Chen = document.createElement("img");
        this.Kim = document.createElement("img");
        this.Sanya = document.createElement("img");

        this.centerImageNumber = 1;

        this.Init();
    }
    Init() {
        this.SetPhotosHairdressers();
        this.SetButtonsAction();
    }
    SetButtonsAction() {
        this.btnNextImage.addEventListener("click", () => {
            this.centerImageNumber++;
            this.SetPhotosHairdressers();
        })
    }
    SetPhotosHairdressers() {

        this.Araya.src = this.teamMembers[this.centerImageTeam -1];
        this.Any.src = this.teamMembers[this.centerImageNumber];
        this.Chen.src = this.teamMembers[this.centerImageNumber +1];
        this.Kim.src = this.teamMembers[this.centerImageNumber + 2];
        this.Sanya.src = this.teamMembers[this.centerImageNumber + 3]

        this.SetImagesProperties()
    }
    SetImagesProperties() {
        let arrayMembers = [
            this.Araya,
            this.Any,
            this.Chen,
            this.Kim,
            this.Sanya
        ];

        for (let i = 0; i < arrayMembers.length; i++) {
            arrayMembers[i].style.position = "absolute";
            arrayMembers[i].style.width = "100%";
            arrayMembers[i].style.height = "100%";
            arrayMembers[i].style.borderRadius = "10px";
        }
        this.leftImageTeam.appendChild(arrayMembers[this.centerImageNumber-1]);
        this.centerImageTeam.appendChild(arrayMembers[this.centerImageNumber]);
        this.rightImageTeam.appendChild(arrayMembers[this.centerImageNumber+1]);
    }
}
let booking = new Booking();
booking.Init();