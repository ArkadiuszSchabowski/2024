
class Game {

    constructor(prizeTableDiv, randomNumber, balance, questionWindow, buttons) {

        this.prizeTable = prizeTableDiv;
        this.randomNumber;
        this.lifelines = new Lifelines(this);
        this.questionWindow = questionWindow.mainWindow;
        this.buttons;
        this.balance = 0;
        this.correctAnswer;

        this.btnA = buttons.btnA;
        this.btnB = buttons.btnB;
        this.btnC = buttons.btnC;
        this.btnD = buttons.btnD;
        this.btnResign = buttons.btnResign;
        this.correctedIndex;

        this.questionNumber = 1;
        this.data;

        this.myListener = () => this.SetQuestionOnArrays(this.data);

        lifelines.AddLifelines();

        this.Init();
    }

    Init = () => {
        document.addEventListener("DOMContentLoaded", () => {

        this.GetContent();
        })
    }

    GetContent = async () => {
        try {
            let path = "/Question/GetQuestions"
            let response = await fetch(path);
            this.data = await response.json();
            this.SetQuestionOnArrays(this.data);
        } catch (error) {
            this.questionWindow = questionWindow.FetchError();
        }
    }
    SetQuestionOnArrays = (data) => {
        this.questions1 = [this.data[0], this.data[1]];
        this.questions2 = [this.data[2], this.data[3]];
        this.questions3 = [this.data[4], this.data[5]];
        this.questions4 = [this.data[6], this.data[7]];
        this.questions5 = [this.data[8], this.data[9]];
        this.questions6 = [this.data[10], this.data[11]];
        this.questions7 = [this.data[12], this.data[13]];
        this.questions8 = [this.data[14], this.data[15]];
        this.questions9 = [this.data[16], this.data[17]];
        this.questions10 = [this.data[18], this.data[19]];

        switch (this.questionNumber) {
            case 1:
                this.SetQuestion(this.questions1);
                break;

            case 2:
                this.SetQuestion(this.questions2);
                this.prizeTable.childNodes[9].classList.add("correctColor");
                break;


            case 3:
                this.SetQuestion(this.questions3);
                this.prizeTable.childNodes[8].classList.add("guaranteedPrizeColor");
                break;

            case 4:
                this.SetQuestion(this.questions4);
                this.prizeTable.childNodes[7].classList.add("correctColor");
                break;

            case 5:
                this.SetQuestion(this.questions5);
                this.prizeTable.childNodes[6].classList.add("correctColor");
                break;

            case 6:
                this.SetQuestion(this.questions6);
                this.prizeTable.childNodes[5].classList.add("guaranteedPrizeColor");
                break;

            case 7:
                this.SetQuestion(this.questions7);
                this.prizeTable.childNodes[4].classList.add("correctColor");
                break;

            case 8:
                this.SetQuestion(this.questions8);
                this.prizeTable.childNodes[3].classList.add("correctColor");
                break;

            case 9:
                this.SetQuestion(this.questions9);
                this.prizeTable.childNodes[2].classList.add("correctColor");
                break;

            case 10:
                this.SetQuestion(this.questions10);
                this.prizeTable.childNodes[1].classList.add("correctColor");
                break;

            case 11:
                this.prizeTable.childNodes[0].classList.add("correctColor");
                this.AllCorrectAnswers();
                break;
        }
    }
    SetListneres(correctAnswer) {
        switch (correctAnswer) {
            case "A":
                this.TheCorrectAnswerIsA();
                break;

            case "B":
                this.TheCorrectAnswerIsB();
                break;

            case "C":
                this.TheCorrectAnswerIsC();
                break;

            case "D":
                this.TheCorrectAnswerIsD();
                break;
        }
    }
    SetQuestion = (questionData) => {

        buttons.SetButtonsAsVisible();

        switch (this.questionNumber) {
            case 1:
                this.balance = balance.SetStartBalance();
                this.SetQuestionContent(questionData);
                /*                this.SetFirstQuestionListeners();*/

                this.correctAnswer = "B";

                this.SetListneres(this.correctAnswer);
                this.SetTheResignListener();
                break;
            case 2:
                this.RemoveFirstQuestionListeners();
                this.balance = balance.SetCurrentBalance(500);
                this.SetQuestionContent(questionData);
                this.correctAnswer = "C";
                this.SetListneres(this.correctAnswer);
                break;
            case 3:
                this.RemoveSecondQuestionListeners();
                this.balance = balance.SetCurrentBalance(2000);
                this.SetQuestionContent(questionData);
                this.correctAnswer = "A";
                this.SetListneres(this.correctAnswer);
                break;
            case 4:
                this.RemoveThirdQuestionListeners();
                this.balance = balance.SetCurrentBalance(5000);
                this.SetQuestionContent(questionData);
                this.correctAnswer = "D";
                this.SetListneres(this.correctAnswer);
                break;
            case 5:
                this.RemoveFourthQuestionListeners();
                this.balance = balance.SetCurrentBalance(10000);
                this.SetQuestionContent(questionData);
                this.correctAnswer = "A";
                this.SetListneres(this.correctAnswer);
                break;
            case 6:
                this.RemoveFifthQuestionListeners();
                this.balance = balance.SetCurrentBalance(40000);
                this.SetQuestionContent(questionData);
                this.correctAnswer = "A";
                this.SetListneres(this.correctAnswer);
                break;
            case 7:
                this.RemoveSixthQuestionListeners();
                this.balance = balance.SetCurrentBalance(75000);
                this.SetQuestionContent(questionData);
                this.correctAnswer = "C";
                this.SetListneres(this.correctAnswer);
                break;
            case 8:
                this.RemoveSeventhQuestionListeners();
                this.balance = balance.SetCurrentBalance(150000);
                this.SetQuestionContent(questionData);
                this.correctAnswer = "B";
                this.SetListneres(this.correctAnswer);
                break;
            case 9:
                this.RemoveEighthQuestionListeners();
                this.balance = balance.SetCurrentBalance(250000);
                this.SetQuestionContent(questionData);
                this.correctAnswer = "D";
                this.SetListneres(this.correctAnswer);
                break;
            case 10:
                this.RemoveNinethQuestionListeners();
                this.balance = balance.SetCurrentBalance(500000);
                this.SetQuestionContent(questionData);
                this.correctAnswer = "C";
                this.SetListneres(this.correctAnswer);
                break;
        }
    }
    AllCorrectAnswers() {

        buttons.LockButtons();
        buttons.SetDefaultTextForButtons();

        this.balance = balance.SetCurrentBalance(1000000);

        this.questionWindow.innerHTML = ` Odpowiedziales poprawnie na wszystkie pytania! Wygrywasz ${this.balance} zl!!!`;

    }
    SetColorRowsWhenAnswerIsIncorrect() {
        switch (this.questionNumber) {
            case 3:
                this.balance = balance.SetStartBalance();
                this.prizeTable.childNodes[9].classList.remove("correctColor");
                break;
            //case 4 - pierwszy prog gwarantowany
            case 5:
            case 6:
                this.balance = balance.SetBalanceToFirstCheckpoint();
                for (let i = 6; i < 8; i++) {
                    this.prizeTable.childNodes[i].classList.remove("correctColor");
                }
                break;
            //case 7 - drugi prog gwarantowany
            case 8:
            case 9:
            case 10:
            case 11:
                this.balance = balance.SetBalanceToSecondCheckpoint();
                for (let i = 1; i < 5; i++) {
                    this.prizeTable.childNodes[i].classList.remove("correctColor");
                }
                break;
        }

        this.questionWindow.innerHTML = `Dziekujemy za gre! Twoj wynik to ${this.balance} zl!`;
    }

    EndGameWhenAnswerIsIncorrect = () => {

        buttons.LockButtons();
        buttons.SetDefaultTextForButtons();

        this.SetColorRowsWhenAnswerIsIncorrect();
    }

    SetQuestionContent(questionData) {

        this.randomNumber = randomNumberGenerator.SetRandomNumberForQuestion();

        this.questionWindow.innerHTML = questionData[this.randomNumber].question;
        this.btnA.innerHTML = questionData[this.randomNumber].answers[0];
        this.btnB.innerHTML = questionData[this.randomNumber].answers[1];
        this.btnC.innerHTML = questionData[this.randomNumber].answers[2];
        this.btnD.innerHTML = questionData[this.randomNumber].answers[3];

        this.correctedIndex = questionData[this.randomNumber].correctAnswerIndex;

        this.questionNumber++;
    }
    SetTheResignListener() {
        this.btnResign.addEventListener("click", () => {
            if (this.balance === 0) {
                this.questionWindow.innerHTML = 'Jeszcze nie zaczelismy gry, a juz sie wycofales. Mimo wszystko dziekuje za udzial w grze!';
            }
            else if ((this.balance !== 0) && (this.balance !== 2000) && (this.balance !== 40000)) {
                this.questionWindow.innerHTML = `To dobra decyzja, zeby sie wycofac. Gratulacje wygrywasz ${this.balance} zl !!!`;
            }
            else if ((this.balance === 2000) || (this.balance === 40000)){
                this.questionWindow.innerHTML = `Zrezygnowales na progu gwarantowanym. Wygrywasz ${this.balance} zl!`;
            }
            buttons.SetDefaultTextForButtons();
            buttons.LockButtons();
        })
    }

    TheCorrectAnswerIsA() {
        this.btnA.addEventListener("click", this.myListener);
        this.btnB.addEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnC.addEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnD.addEventListener("click", this.EndGameWhenAnswerIsIncorrect);
    }
    TheCorrectAnswerIsB() {
        this.btnA.addEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnB.addEventListener("click", this.myListener);
        this.btnC.addEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnD.addEventListener("click", this.EndGameWhenAnswerIsIncorrect);
    }
    TheCorrectAnswerIsC() {
        this.btnA.addEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnB.addEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnC.addEventListener("click", this.myListener);
        this.btnD.addEventListener("click", this.EndGameWhenAnswerIsIncorrect);
    }
    TheCorrectAnswerIsD() {
        this.btnA.addEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnB.addEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnC.addEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnD.addEventListener("click", this.myListener);
    }

    RemoveListenersWhenTheCorrectAnswerWasA() {
        this.btnA.removeEventListener("click", this.myListener);
        this.btnB.removeEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnC.removeEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnD.removeEventListener("click", this.EndGameWhenAnswerIsIncorrect);
    }
    RemoveListenersWhenTheCorrectAnswerWasB() {
        this.btnA.removeEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnB.removeEventListener("click", this.myListener);
        this.btnC.removeEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnD.removeEventListener("click", this.EndGameWhenAnswerIsIncorrect);
    }
    RemoveListenersWhenTheCorrectAnswerWasC() {
        this.btnA.removeEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnB.removeEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnC.removeEventListener("click", this.myListener);
        this.btnD.removeEventListener("click", this.EndGameWhenAnswerIsIncorrect);
    }
    RemoveListenersWhenTheCorrectAnswerWasD() {
        this.btnA.removeEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnB.removeEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnC.removeEventListener("click", this.EndGameWhenAnswerIsIncorrect);
        this.btnD.removeEventListener("click", this.myListener);
    }

    RemoveFirstQuestionListeners() {
        this.RemoveListenersWhenTheCorrectAnswerWasB();
    }

    RemoveSecondQuestionListeners() {
        this.RemoveListenersWhenTheCorrectAnswerWasC();
    }

    RemoveThirdQuestionListeners() {
        this.RemoveListenersWhenTheCorrectAnswerWasA();
    }

    RemoveFourthQuestionListeners() {
        this.RemoveListenersWhenTheCorrectAnswerWasD();
    }

    RemoveFifthQuestionListeners() {
        this.RemoveListenersWhenTheCorrectAnswerWasA();
    }

    RemoveSixthQuestionListeners() {
        this.RemoveListenersWhenTheCorrectAnswerWasA();
    }

    RemoveSeventhQuestionListeners() {
        this.RemoveListenersWhenTheCorrectAnswerWasC();
    }

    RemoveEighthQuestionListeners() {
        this.RemoveListenersWhenTheCorrectAnswerWasB();
    }

    RemoveNinethQuestionListeners() {
        this.RemoveListenersWhenTheCorrectAnswerWasD();
    }

    RemoveTenthQuestionListeners() {
        this.RemoveListenersWhenTheCorrectAnswerWasC();
    }
}

const game = new Game(prizeTableDiv, randomNumberGenerator, balance, questionWindow, buttons);