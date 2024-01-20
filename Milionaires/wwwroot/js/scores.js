class Score {
    constructor() {
        this.host = "http://localhost:5050";
        this.scoreName = document.getElementById("scoreNameRow");
        this.scoreResult = document.getElementById("scoreResultRow");
        this.scoreDate = document.getElementById("scoreDateRow");

        this.pageSize = 10;
        this.pageNumber = 1;

        this.counterResult;
        this.counterSide;

        this.pageSize5 = document.getElementById("pageSize5");
        this.pageSize10 = document.getElementById("pageSize10");
        this.pageSize25 = document.getElementById("pageSize25");
        this.pageSize50 = document.getElementById("pageSize50");
        this.pageNumberDecrement = document.getElementById("pageNumberDecrement");
        this.pageNumberIncrement = document.getElementById("pageNumberIncrement");
        this.pageCurrentNumber = document.getElementById("pageCurrentNumber");
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
        this.pageNumberDecrement.addEventListener("click", () => this.PageNumberDecrement());
        this.pageNumberIncrement.addEventListener("click", () => this.PageNumberIncrement());
    }
    PageNumberDecrement() {
        if (this.pageNumber <= 1) {
            return;
        }
        this.pageNumber--;
        this.pageCurrentNumber.innerText = this.pageNumber;
        this.GetMainPage();
    }
    PageNumberIncrement() {
        if (this.pageSize * this.pageNumber >= 100) {
            return;
        }
        this.pageNumber++;
        this.pageCurrentNumber.innerText = this.pageNumber;
        this.GetMainPage();
    }

    async GetMainPage() {
        const path = `${this.host}/api/game/scores?pageSize=${this.pageSize}&pageNumber=${this.pageNumber}`;
        const response = await fetch(path);
        const data = await response.json();
        console.log(data);
        this.ClearScores();
        this.CreateNewTable(data.listScores);
    }
    ClearScores() {
        this.scoreName.innerHTML = "";
        this.scoreResult.innerHTML = "";
        this.scoreDate.innerHTML = "";
    }
    SetPageSize5() {
        this.pageSize5.classList.add("currentPage");
        this.pageSize10.classList.remove("currentPage");
        this.pageSize25.classList.remove("currentPage");
        this.pageSize50.classList.remove("currentPage");
        this.pageNumber = 1;
        this.pageCurrentNumber.innerText = this.pageNumber;
        this.pageSize = 5;
        this.GetMainPage();
    }
    SetPageSize10() {
        this.pageSize5.classList.remove("currentPage");
        this.pageSize10.classList.add("currentPage");
        this.pageSize25.classList.remove("currentPage");
        this.pageSize50.classList.remove("currentPage");
        this.pageNumber = 1;
        this.pageCurrentNumber.innerText = this.pageNumber;
        this.pageSize = 10;
        this.GetMainPage();
    }
    SetPageSize25() {
        this.pageSize5.classList.remove("currentPage");
        this.pageSize10.classList.remove("currentPage");
        this.pageSize25.classList.add("currentPage");
        this.pageSize50.classList.remove("currentPage");
        this.pageNumber = 1;
        this.pageCurrentNumber.innerText = this.pageNumber;
        this.pageSize = 25;
        this.GetMainPage();
    }
    SetPageSize50() {
        this.pageSize5.classList.remove("currentPage");
        this.pageSize10.classList.remove("currentPage");
        this.pageSize25.classList.remove("currentPage");
        this.pageSize50.classList.add("currentPage");
        this.pageNumber = 1;
        this.pageCurrentNumber.innerText = this.pageNumber;
        this.pageSize = 50;
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