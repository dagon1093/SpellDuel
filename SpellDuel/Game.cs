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
        Console.WriteLine("1. Sword Atack - deal 18 damage and get 10-30 mana");
        Console.WriteLine("2. Fireball - deal 35 damage, cost 20 mana");
        while (isActive)
        {
            Console.WriteLine($"Golem health: {Golem.GetHealth()}, Your mana: {Hero.GetMana()}");
            Action(Console.ReadLine());
            checkGameStatus();

            if (!isActive)
            {
                Console.WriteLine("You defeated a golem");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            
            

            
        }
    }

    public void Action(String action)
    {
        switch (action)
        {
            case "1": 
                Hero.RestoreMana(Hero.GetSwordAttackManaRestore()); 
                Golem.GetDamage(Hero.SwordAttack());
                if (Golem.GetHealth() <= 0) EndGame();
                break;
            case "2":
                if (Hero.CheckAvailableMana(Hero.GetSpellFireballManaCost()))
                {
                    Hero.SetMana(Hero.GetMana() - Hero.GetSpellFireballManaCost());
                    Golem.GetDamage(Hero.FireballAttack());
                    if (Golem.GetHealth() <= 0) EndGame();
                }
                else
                {
                    Console.WriteLine("Not enough mana");
                }
                break;
            default:
                Console.WriteLine("Invalid action");
                break;
        }
    }

    public void EndGame()
    {
        isActive = false;
    }

    public void checkGameStatus()
    {
        if (Golem.GetHealth() <= 0) EndGame();
    }
}