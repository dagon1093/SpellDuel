namespace SpellDuel;

public class Game
{
    public Hero Hero { get; set; }
    public Golem Golem { get; set; }
    
    private bool isActive;

    public Game()
    {
        Hero = new Hero();
        Golem = new Golem(100);
        isActive = true;
    }

    public void StartGame()
    {
        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("You must defeat a golem");
        Console.WriteLine("Choose your action:");
        Console.WriteLine("1. Sword Attack - deal 18 damage and get 10 mana");
        Console.WriteLine("2. Fireball - deal 35 damage, cost 20 mana");
        while (isActive)
        {
            Console.WriteLine($"Golem health: {Golem.GetHealth()}");
            Console.WriteLine($"Your health: {Hero.GetHealth()} Your mana: {Hero.GetMana()}");
            var action = Console.ReadLine();
            if (action is null) break;
            if (!Action(action)) continue;
            

            if (isActive) checkGameStatus();
            if (isActive) GolemTurn();
            if (isActive) checkGameStatus();
            
        }
    }

    public bool Action(String action)
    {
        switch (action)
        {
            case "1": 
                Hero.RestoreMana(Hero.GetSwordAttackManaRestore());
                Golem.GetDamage(Hero.SwordAttack());
                return true;
            case "2":
                if (Hero.CheckAvailableMana(Hero.GetSpellFireballManaCost()))
                {
                    Hero.SetMana(Hero.GetMana() - Hero.GetSpellFireballManaCost());
                    Golem.GetDamage(Hero.FireballAttack());
                    
                }
                else
                {
                    Console.WriteLine("Not enough mana");
                    return  false;
                }
                return  true;
            default:
                Console.WriteLine("Invalid action");
                return  false;
        }
    }

    public void EndGame()
    {
        isActive = false;
    }

    public void checkGameStatus()
    {
        if (Golem.GetHealth() <= 0)
        {
            EndGame();
            Console.WriteLine("You defeated a golem");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        } else if (Hero.GetHealth() <= 0)
        {
            EndGame();
            Console.WriteLine("You dead.. Killed by a training golem? ha..");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        
    }
    
    public void GolemTurn()
    {
        Hero.TakeDamage(Golem.GetAttack());
    }
}