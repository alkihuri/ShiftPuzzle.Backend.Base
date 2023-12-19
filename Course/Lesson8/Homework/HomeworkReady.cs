public static string LoanApproval(double balance)
{
    if (balance <= 0)
    {
        return "Кредит одобрен!";
    }
    else
    {
        return "У вас достаточно средств, кредит не нужен.";
    }
}


public static double InterestCalculation(double amountToWithdraw, double balance)
{
    double interest = amountToWithdraw * 0.05;
    return balance - interest;
}



public static double DepositWithdrawal(double deposit, double balance)
{
    return balance - deposit;
}

public static double CalculateCompoundInterest(double principal, double rate, int years)
{
    for (int year = 0; year < years; year++)
    {
        principal += principal * (rate / 100);
    }
    return principal;
}

double balance = 100;

string loanStatus = LoanApproval(balance);
Console.WriteLine(loanStatus);

double bankProfit;balance = InterestCalculation(50, balance);
Console.WriteLine($"Баланс после снятия: {balance}");

balance = DepositWithdrawal(50, balance);
Console.WriteLine($"Баланс после вклада: {balance}");


double finalAmount = CalculateCompoundInterest(1000, 5, 3);
Console.WriteLine($"Конечная сумма после 3 лет: {finalAmount:F2}");