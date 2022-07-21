using System;

public class Player
{
    public event EventHandler<HealedEventArg> OnHealed;
    public class HealedEventArg : EventArgs
    {
        public int Amount { get; private set; }

        public HealedEventArg(int amount)
        {
            Amount = amount;
        }
    }

    public event EventHandler<DamagedEventArg> OnDamaged;
    public class DamagedEventArg : EventArgs
    {
        public int Amount { get; private set; }

        public DamagedEventArg(int amount)
        {
            Amount = amount;
        }
    }


    public Player(int currentHealth, int maximumHealth = 10)
    {
        if (currentHealth < 0) throw new ArgumentOutOfRangeException("currentHealth");
        if (currentHealth > maximumHealth) throw new ArgumentOutOfRangeException("currentHealth");

        CurrentHealth = currentHealth;
        MaximumHealth = maximumHealth;
    }

    public int CurrentHealth { get; private set; }
    public int MaximumHealth { get; private set; }

    public void Heal(int amount)
    {
        if (amount < 0) throw new ArgumentOutOfRangeException("amount");
        var newHealth = Math.Min(CurrentHealth + amount, MaximumHealth);

        // raise event based on actual amount of heal
        OnHealed?.Invoke(this, new HealedEventArg(newHealth - CurrentHealth));

        CurrentHealth = newHealth;
    }

    public void Damage(int amount)
    {
        if (amount < 0) throw new ArgumentOutOfRangeException("amount");
        var newHealth = Math.Max(0, CurrentHealth - amount);

        // raise event based on actual amount of damage
        OnDamaged?.Invoke(this, new DamagedEventArg(CurrentHealth - newHealth));

        CurrentHealth = newHealth;
    }
}