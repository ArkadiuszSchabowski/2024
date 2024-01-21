class UserDecision {
    constructor() {
        this.host = "http://localhost:5050";
    }
    ResignOption() {
        buttons.btnResign.addEventListener("click", () => {

            game.HideQuestion();
            buttons.LockButtons();

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

            game.questionWindow.appendChild(div);

            buttonYes.addEventListener("click", () => {

                game.ShowQuestion();
                game.questionWindow.removeChild(div);
                game.questionText.style.backgroundColor = "transparent";

                if (game.balance === 0) {
                    this.stateGameInformation = `\nJeszcze nie zaczeliśmy gry, a juz sie wycofałeś? Mimo wszystko dziekuję za udział w grze!`;
                }
                else if ((game.balance !== 0) && (game.balance !== 2000) && (game.balance !== 40000)) {
                    game.stateGameInformation = `\nTo dobra decyzja, żeby sie wycofać. Gratulacje wygrywasz ${game.balance} zł!`;
                }
                else if ((game.balance === 2000) || (game.balance === 40000)) {
                    game.stateGameInformation = `\nZrezygnowałeś na progu gwarantowanym. Wygrywasz ${game.balance} zł!`;
                }
                game.questionText.innerHTML = game.explainCorrectAnswer + game.stateGameInformation;
                this.SaveScoreOption();
                buttons.SetDefaultTextForButtons();
            });

            buttonNo.addEventListener("click", () => {
                game.ShowQuestion();
                game.questionWindow.removeChild(div);
                buttons.UnlockButtons();
            })
        })
    }
    SaveScoreOption() {

        game.SetBackground();
        if (game.balance === 0) {
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

        game.questionWindow.appendChild(div);

        button.addEventListener("click", () => {
            let name = input.value;
            let object = {
                Name: name,
                Result: game.balance
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

        game.questionWindow.removeChild(oldDiv);

        game.questionText.innerHTML = "Gratulacje wspaniałego wyniku!";

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
            game.questionText.innerHTML = "Dziękujemy za grę!";
            game.EndGame();
            buttons.SetDefaultTextForButtons();
            game.questionWindow.removeChild(div);
        })

        div.append(label, buttonDiv);

        game.questionWindow.appendChild(div);
    }
}
let userDecision = new UserDecision();