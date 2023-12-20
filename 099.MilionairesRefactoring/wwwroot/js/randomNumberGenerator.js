class RandomNumberGenerator {
    constructor() {
        this.arrayRandomNumbers = [];
        this.randomNumber;
    }
    SetRandomNumberForQuestion() {
        return Math.floor(Math.random() * 2);
    }
    SetRandomNumberForAudience() {
        let numberA = Math.floor(Math.random() * 100);
        let numberB = Math.floor(Math.random() * (100 - numberA));
        let numberC = Math.floor(Math.random() * (100 - (numberA + numberB)));
        let numberD = 100 - (numberA + numberB + numberC);
        let audience = [numberA, numberB, numberC, numberD]
        return audience;
    }
    SetRandomMessageForFriend() {
        this.randomNumber = Math.floor(Math.random() * 5);
        switch (this.randomNumber) {
            case 0:
                return "Przyjaciel: Wydaje mi si?, ?e poprawn? odpowiedzi? mo?e by? A lub C";
            case 1:
                return "Przyjaciel: Stawia?bym na B, ale nie jestem pewny";
            case 2:
                return "Przyjaciel: Zrezygnowa?bym na tym etapie, ale je?li mia?bym gra? to zaznaczy?bym D";
            case 3:
                return "Przyjaciel: Obstawia?bym C lub D";
            case 4:
                return "Przyjaciel: Odrzuci?bym B. Jednak mo?e to czas, by sie wycofa??";
        }
    }
    SetRandomNumberForFiftyFifty(correctedIndex) {
        while (this.arrayRandomNumbers.length < 2) {

            this.randomNumber = Math.floor(Math.random() * 4);
            if (!this.arrayRandomNumbers.includes(this.randomNumber) && this.randomNumber !== correctedIndex) {
                this.arrayRandomNumbers.push(this.randomNumber);
            }
        }
        return this.arrayRandomNumbers;
    }
}
let randomNumberGenerator = new RandomNumberGenerator();