

class Lifelines {
    constructor(randomNumberGenerator, game) {
        this.game = game;
        this.randomNumber = randomNumberGenerator;
        this.result;

        this.questionWindow = document.querySelector("#questionWindow");

        this.audience = true;
        this.phone = true;
        this.fiftyFifty = true;
    }
    AddLifelines() {
        this.PhoneFriend();
        this.Audience();
        this.FiftyFifty()
    }
    PhoneFriend() {
        buttons.btnPhone.addEventListener("click", () => {
            if (this.phone) {
                if (this.fiftyFifty) {
                    this.result = randomNumberGenerator.SetRandomMessageForFriend();
                    this.questionWindow.innerHTML = `${game.questionWindow.innerHTML} <br><br>${this.result}`
                }
                if (!this.fiftyFifty) {
                    this.questionWindow.innerHTML = `${game.questionWindow.innerHTML} <br><br>Przyjaciel: Niestety nie wiem, nie pomogę. Moze spróbuj zaryzkować.`
                }
                this.phone = false;
                buttons.btnPhone.classList.add("redColor");
            }
        }
        )
    };
    FiftyFifty() {
        buttons.btnFiftyFifty.addEventListener("click", () => {
            if (this.fiftyFifty) {
                this.result = randomNumberGenerator.SetRandomNumberForFiftyFifty(game.correctedIndex);
                if (this.result.includes(0)) {
                    buttons.btnA.style.visibility = "hidden";
                }
                if (this.result.includes(1)) {
                    buttons.btnB.style.visibility = "hidden";
                }
                if (this.result.includes(2)) {
                    buttons.btnC.style.visibility = "hidden";
                }
                if (this.result.includes(3)) {
                    buttons.btnD.style.visibility = "hidden";
                }

                buttons.btnFiftyFifty.classList.add("redColor");
                this.fiftyFifty = false;
            }
        }
        )
    };
    Audience() {
        buttons.btnAudience.addEventListener("click", () => {
            if (this.audience) {
                if (this.fiftyFifty) {

                    this.result = randomNumberGenerator.SetRandomNumberForAudience();
                    this.questionWindow.innerHTML = `${game.questionWindow.innerHTML} <br><br> A: ${this.result[0]}%, B: ${this.result[1]}%, C: ${this.result[2]}%, D: ${this.result[3]}%.`;
                }
                else {
                    this.questionWindow.innerHTML = `${game.questionWindow.innerHTML} <br><br> Tym razem głosy publiczności dla każdego przypadku wynoszą dokładnie tyle samo %. Przed Tobą ciężka decyzja.`
                }
                buttons.btnAudience.classList.add("redColor");
                this.audience = false;
            }
        }
        )
    };
}
let lifelines = new Lifelines(randomNumberGenerator, buttons);