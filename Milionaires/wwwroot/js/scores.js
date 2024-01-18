class Score {
    constructor() {
        this.host = "http://localhost:5050";
        this.scoreName = document.getElementById("scoreNameRow");
        this.scoreResult = document.getElementById("scoreResultRow");
        this.scoreDate = document.getElementById("scoreDateRow");

        this.pageSize = 10;
        this.pageSize5 = document.getElementById("pageSize5");
        this.pageSize10 = document.getElementById("pageSize10");
        this.pageSize25 = document.getElementById("pageSize25");
        this.pageSize50 = document.getElementById("pageSize50");

    }
    Init() {
        this.GetMainPage();
        this.SetListeners();
    }
    SetListeners() {
        this.pageSize5.addEventListener("click", () => this.SetPageSize5());
        this.pageSize10.addEventListener("click", () => this.SetPageSize10());
        this.pageSize25.addEventListener("click", () => this.SetPageSize25());
        this.pageSize50.addEventListener("click", () => this.SetPageSize50());
    }
    async GetMainPage() {
        const path = `${this.host}/api/game/scores?pageSize=${this.pageSize}`
        const response = await fetch(path);
        const data = await response.json();

        this.ClearScores();
        this.CreateNewTable(data);
    }
    ClearScores() {
        this.scoreName.innerHTML = "";
        this.scoreResult.innerHTML = "";
        this.scoreDate.innerHTML = "";
    }
    SetPageSize5() {
        this.pageSize = 5;
        this.pageSize5.style.pointerEvents = "auto";
        this.GetMainPage();
    }
    SetPageSize10() {
        this.pageSize = 10;
        this.pageSize10.style.pointerEvents = "auto";
        this.GetMainPage();
    }
    SetPageSize25() {
        this.pageSize = 25;
        this.pageSize25.style.pointerEvents = "auto";
        this.GetMainPage();
    }
    SetPageSize50() {
        this.pageSize = 50;
        this.pageSize50.style.pointerEvents = "auto";
        this.GetMainPage();
    }

    CreateNewTable(data) {

        for (let i = 0; i < data.length; i++) {

            let name = document.createElement("div");
            let result = document.createElement("div");
            let date = document.createElement("div");

            name.innerHTML = data[i].name;
            result.innerHTML = data[i].result;
            date.innerHTML = data[i].date;

            this.scoreName.appendChild(name);
            this.scoreResult.appendChild(result);
            this.scoreDate.appendChild(date);
        }
    }
}
const score = new Score();
score.Init();