class RandomNumberGenerator {
    constructor() {
        this.arrayRandomNumbers =[];
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
                return "Przyjaciel: Wydaje mi sie, ze poprawna odpowiedzia moze byc A lub C";
                break;
            case 1:
                return "Przyjaciel: Stawialbym na B, ale nie jestem pewny";
                break;
            case 2:
                return "Przyjaciel: Zrezygnowalbym na tym etapie, ale jesli mialbyc grac zaznaczylbym D";
                break;
            case 3:
                return "Przyjaciel: Obstawialbym C lub D";
                break;
            case 4:
                return "Przyjaciel: Odrzucilbym B. Jednak moze to czas, by sie wycofac?";
                break;
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