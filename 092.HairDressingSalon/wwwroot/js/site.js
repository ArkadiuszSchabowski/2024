class MainContent {
    constructor() {

        this.newsContent = document.getElementById("newsContent");

        this.leftImage = document.getElementById("leftImage");
        this.centerImage = document.getElementById("centerImage");
        this.rightImage = document.getElementById("rightImage");
    }
    Init() {
        this.DisplayNews();
        this.DisplayTeamMebers();
    }
    DisplayNews() {
        let news1 = document.createElement("img");

        news1.src = "../images/news/news1.png";

        news1.style.width = "100%";
        news1.style.height = "100%";

        this.newsContent.appendChild(news1);
    }
    DisplayTeamMebers() {
        let asian1 = document.createElement("img");

        asian1.src = "../images/team/asian1.jpg";
        asian1.style.width = "100%";
        asian1.style.height = "100%";

        let asian2 = document.createElement("img");

        asian2.src = "../images/team/asian2.jpg";
        asian2.style.width = "100%";
        asian2.style.height = "100%";

        let asian3 = document.createElement("img");

        asian3.src = "../images/team/asian3.jpg";
        asian3.style.width = "100%";
        asian3.style.height = "100%";

        let asian4 = document.createElement("img");

        asian4.src = "../images/team/asian3.jpg";
        asian4.style.width = "100%";
        asian4.style.height = "100%";

        this.leftImage.appendChild(asian1);
        this.centerImage.appendChild(asian2);
        this.rightImage.appendChild(asian3);
    }
}
let mainContent = new MainContent();
mainContent.Init();