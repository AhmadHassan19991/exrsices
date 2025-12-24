using System;

public static class SavingsAccount
{
        public static float InterestRate(decimal balance)
    {
        if (balance < 0)
        {
            return 3.213f; // Negative balance
        }
        else if (balance < 1000)
        {
            return 0.5f; // Balance less than 1000
        }
        else if (balance < 5000)
        {
            return 1.621f; // Balance less than 5000
        }
        else
        {
            return 2.475f; // Balance 5000 or greater
        }
    }

    public static decimal Interest(decimal balance)
    {
    float rate = InterestRate(balance);
        return balance * (decimal)(rate / 100.0f);    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

       public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        decimal currentBalance = balance;
        while (currentBalance < targetBalance)
        {
            currentBalance = AnnualBalanceUpdate(currentBalance);
            years++;
        }
        return years;
    }
}
