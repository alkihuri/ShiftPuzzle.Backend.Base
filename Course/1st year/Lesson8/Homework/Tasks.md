### Привет! Предыдущий Python разработчик, чтото напутил.

 

``` Python
def loan_approval(balance):
    if balance <= 0:
        return "Кредит одобрен!"
    else:
        return "У вас достаточно средств, кредит не нужен."

def interest_calculation(amount_to_withdraw, balance):
    interest = amount_to_withdraw * 0.05
    new_balance = balance - interest
    bank_profit = interest
    return new_balance, bank_profit

def deposit_withdrawal(deposit, balance):
    return balance - deposit
 
balance = 100
balance, bank_profit = interest_calculation(50, balance)
print(f"Баланс после снятия: {balance}, прибыль банка: {bank_profit}")

balance = deposit_withdrawal(50, balance)
print(f"Баланс после вклада: {balance}")

loan_status = loan_approval(balance)
print(loan_status)
```

## Базовая (обычная часть): 
1. Создай проект консольного приложения
2. Перепиши функции `loan_approval` и `deposit_withdrawal` на язык C#

## Продвинутая часть: 

1. Созай функцию calculate_compound_interest: Эта функция принимает начальную сумму, годовую процентную ставку и количество лет, на протяжении которых начисляется сложный процент. Она рассчитывает конечную сумму, учитывая, что каждый год проценты добавляются к текущей сумме вклада.