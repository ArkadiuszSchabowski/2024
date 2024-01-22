class UserDecision {
    constructor() {
        this.host = "http://localhost:5050";
    }
    ResignOption() {
        buttons.btnResign.addEventListener("click", () => {

            index.HideQuestion();
            buttons.LockIndexButtons();

            let div = document.createElement("div");
            div.classList.add("endGameDiv");

            let label = document.createElement("label");
            label.classList.add("endGameLabel");
            label.innerText = "Definitywnie chcesz się wycofać?";

            let buttonDiv = document.createElement("buttonDiv");
            buttonDiv.classList.add("buttonsRow");

            let buttonYes = document.createElement("button");
            buttonYes.classList.add("endGameButton");
            buttonYes.innerText = "TAK";

            let buttonNo = document.createElement("button");
            buttonNo.id = "btnResignNo";
            buttonNo.classList.add("endGameButton");
            buttonNo.innerText = "NIE";

            buttonDiv.append(buttonYes, buttonNo);


            div.append(label, buttonDiv);

            index.questionWindow.appendChild(div);

            buttonYes.addEventListener("click", () => {

                index.ShowQuestion();
                index.questionWindow.removeChild(div);
                index.questionText.style.backgroundColor = "transparent";

                if (index.balance === 0) {
                    this.stateGameInformation = `\nJeszcze nie zaczeliśmy gry, a juz sie wycofałeś? Mimo wszystko dziekuję za udział w grze!`;
                }
                else if ((index.balance !== 0) && (index.balance !== 2000) && (index.balance !== 40000)) {
                    index.stateGameInformation = `\nTo dobra decyzja, żeby sie wycofać. Gratulacje wygrywasz ${index.balance} zł!`;
                }
                else if ((index.balance === 2000) || (index.balance === 40000)) {
                    index.stateGameInformation = `\nZrezygnowałeś na progu gwarantowanym. Wygrywasz ${index.balance} zł!`;
                }
                index.questionText.innerHTML = index.explainCorrectAnswer + index.stateGameInformation;
                this.SaveScoreOption();
                buttons.SetDefaultTextForButtons();
            });

            buttonNo.addEventListener("click", () => {
                index.ShowQuestion();
                index.questionWindow.removeChild(div);
                buttons.UnlockIndexButtons();
            })
        })
    }
    SaveScoreOption() {

        index.SetBackground();
        if (index.balance === 0) {
            return;
        }

        let div = document.createElement("div");
        div.classList.add("endGameDiv");

        let label = document.createElement("label");
        label.classList.add("endGameLabel");
        label.style.width = "100%";
        label.innerText = "Podaj swoje imię";

        let input = document.createElement("input");
        input.classList.add("endGameInput");

        let button = document.createElement("button");
        button.classList.add("endGameButton");
        button.innerText = "OK";


        div.append(label, input, button);

        index.questionWindow.appendChild(div);

        button.addEventListener("click", () => {
            let name = input.value;
            let object = {
                Name: name,
                Result: index.balance
            };

            const path = `${this.host}/api/game`;
            fetch(path, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(object)
            }).then(response => {
                if (response.ok) {
                    this.RestartGameOption(div);
                }
            });
        });
    }

    RestartGameOption(oldDiv) {

        index.questionWindow.removeChild(oldDiv);

        index.questionText.innerHTML = "Gratulacje wspaniałego wyniku!";

        let div = document.createElement("div");
        div.classList.add("endGameDiv");

        let label = document.createElement("label");
        label.classList.add("endGameLabel");
        label.innerText = "Czy chcesz zagrać jeszcze raz?";

        let buttonDiv = document.createElement("buttonDiv");

        let buttonYes = document.createElement("button");
        buttonYes.classList.add("endGameButton");
        buttonYes.innerText = "TAK";

        let buttonNo = document.createElement("button");
        buttonNo.id = "btnResignNo";
        buttonNo.classList.add("endGameButton");
        buttonNo.innerText = "NIE";

        buttonDiv.append(buttonYes, buttonNo);

        buttonYes.addEventListener("click", () => {
            window.location.href = "/Home/Index";
        })
        buttonNo.addEventListener("click", () => {
            index.questionText.innerHTML = "Dziękujemy za grę!";
            index.EndGame();
            buttons.SetDefaultTextForButtons();
            index.questionWindow.removeChild(div);
        })

        div.append(label, buttonDiv);

        index.questionWindow.appendChild(div);
    }
}
let userDecision = new UserDecision();