using System;

public struct CurrencyAmount : IEquatable<CurrencyAmount>
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    private static void EnsureSameCurrency(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency) throw new ArgumentException("Currencies must match.");
    }

    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount == b.amount;
    }

    public static bool operator !=(CurrencyAmount a, CurrencyAmount b) => !(a == b);

    public bool Equals(CurrencyAmount other)
    {
        EnsureSameCurrency(this, other);
        return amount == other.amount;
    }

    public override bool Equals(object obj) => obj is CurrencyAmount other && Equals(other);

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + amount.GetHashCode();
            hash = hash * 23 + (currency?.GetHashCode() ?? 0);
            return hash;
        }
    }

    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount > b.amount;
    }

    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount < b.amount;
    }

    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount a, decimal multiplier)
        => new CurrencyAmount(a.amount * multiplier, a.currency);

    public static CurrencyAmount operator /(CurrencyAmount a, decimal divisor)
        => new CurrencyAmount(a.amount / divisor, a.currency);

    public static explicit operator double(CurrencyAmount a) => (double)a.amount;

    public static implicit operator decimal(CurrencyAmount a) => a.amount;
}
