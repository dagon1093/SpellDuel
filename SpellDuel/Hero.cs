namespace SpellDuel;

public class Hero
{
    private int Health { get; set; } = 100;
    private int Mana { get; set; } = 30;
    private int SwordDamage { get; set; } = 18;
    
    private int FireballDamage { get; set; } = 35;
    private int FireballManaCost { get; set; } = 20;

    public Hero(int health, int mana)
    {
        Health = health;
        Mana = mana;
    }

    public Hero()
    {
        
    }

    public int SwordAttack()
    {
        return SwordDamage; 
    }

    public int FireballAttack()
    {
        return FireballDamage;
    }
    
    public void SetMana(int mana) => Mana = mana;
    public int GetMana() => Mana;

    public int SwordAttackManaCharge()
    {
        Random rnd = new Random();
        return rnd.Next(10, 31);
    }
    
    public Boolean CheckAvailableMana(int cost)
    {
        return cost <= Mana;
    }
    
    public int GetSpellFireballManaCost() => FireballManaCost;


}