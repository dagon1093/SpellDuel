namespace SpellDuel;

public class Hero
{
    private int Health { get; set; } = 100;
    private int MaxHealth { get; set; } = 100;
    private int Mana { get; set; } = 30;
    private int MaxMana { get; set; } = 30;
    private int SwordDamage { get; set; } = 18;
    
    private int SwordAttackManaRestore { get; set; } = 10;
    
    private int FireballDamage { get; set; } = 35;
    private int FireballManaCost { get; set; } = 20;
    private int Level { get; set; } = 1;
    private int Experience { get; set; } = 0;
    private int LvlUpExperience { get; set; } = 10;

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
    
    public Boolean CheckAvailableMana(int cost)
    {
        return cost <= Mana;
    }
    
    public int GetSpellFireballManaCost() => FireballManaCost;

    public void RestoreMana(int manaPoints)
    {
        if (manaPoints + Mana >= 30)
        {
            Mana = 30;
        }
        else
        {
            Mana += manaPoints;
        }
    }
    
    public int GetSwordAttackManaRestore() => SwordAttackManaRestore;

    public void TakeDamage(int damage)
    {
        if (Health - damage <= 0) Health = 0;
        else Health -= damage;
        
    }
    
    public int GetHealth() => Health;
    
    public int GetMaxHealth() => MaxHealth;
    public void FullRestoreHP() => Health = MaxHealth;
    public int GetMaxMana() => MaxMana;
    public void FullRestoreMana() => Mana = MaxMana;
    
    public int GetExperience() => Experience;
    public int GetLvlUpExperience() => LvlUpExperience;
    public int GetLevel() => Level;
    public void LvlUp()
    {
        Level += 1;  
        LvlUpExperience = (int)(LvlUpExperience * 1.5);
        SwordDamage = (int)(SwordDamage * 1.3);
    } 
    
    public void UpExperience(int experience)
    {
        if (GetLvlUpExperience() <= Experience + experience)
        {
            Experience = (Experience + experience) -  GetLvlUpExperience();
            LvlUp();
            
        } else Experience += experience;
    }

}