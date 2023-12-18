class Balance {
    constructor() {
        this.startedBalance = 0;
    }
    SetStartBalance() {
        return this.startedBalance;
    }
    SetCurrentBalance(number) {
        return number;
    }
    SetBalanceToFirstCheckpoint() {
        return 2000;
    }
    SetBalanceToSecondCheckpoint() {
        return 40000;
    }
}
let balance = new Balance();