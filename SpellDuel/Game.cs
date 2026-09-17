namespace SpellDuel;

public class Game
{
    public Hero Hero { get; set; }
    public Golem Golem { get; set; }
    public BattleStatus BattleStatus { get; set; }
    

    public Game()
    {
        Hero = new Hero();
        Golem = new Golem(100);
        BattleStatus = BattleStatus.inProgress;
    }

    public void StartGame()
    {
        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("You must defeat a golem");
        GameCycle();
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

    public void HandleEnding()
    {
        if (BattleStatus == BattleStatus.Victory)
        {
            Console.WriteLine("You defeated a golem, got 1 xp");
            Console.WriteLine("Do you want to train again? y/n");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Y)
            {
                CreateEnemy();
                Hero.FullRestoreHP();
                Hero.FullRestoreMana();
                GameCycle();
            }
            if (key.Key == ConsoleKey.N)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        } else if (BattleStatus == BattleStatus.Defeat)
        {
            Console.WriteLine("You dead.. Killed by a training golem? ha..");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
    public void CheckGameStatus()
    {
        if (Golem.GetHealth() <= 0)
        {
            BattleStatus =  BattleStatus.Victory;
        } else if (Hero.GetHealth() <= 0)
        {
            BattleStatus = BattleStatus.Defeat;
        }
        else BattleStatus = BattleStatus.inProgress;
    }
    
    public void GolemTurn()
    {
        Hero.TakeDamage(Golem.GetAttack());
    }

    public void CreateEnemy()
    {
        Golem = new Golem(100);
    }

    public void PrintHeroAndEnemyStat()
    {
        Console.WriteLine($"Golem health: {Golem.GetHealth()}");
        Console.WriteLine($"Your health: {Hero.GetHealth()} Your mana: {Hero.GetMana()}");
    }

    public void SetBattleStatus(BattleStatus battleStatus)
    {
        BattleStatus = battleStatus;
    }

    public void GameCycle()
    {
        BattleStatus = BattleStatus.inProgress;
        
        Console.WriteLine("Choose your action:");
        Console.WriteLine("1. Sword Attack - deal 18 damage and get 10 mana");
        Console.WriteLine("2. Fireball - deal 35 damage, cost 20 mana");
        
        while (BattleStatus == BattleStatus.inProgress)
        {
            PrintHeroAndEnemyStat();
            
            var action = Console.ReadLine();
            bool userAction;
            if (action is null) break;
            if (BattleStatus == BattleStatus.inProgress)
                userAction = Action(action);
            else break;
            
            CheckGameStatus();
            if (BattleStatus == BattleStatus.inProgress && userAction) GolemTurn();
            CheckGameStatus();
        }

        HandleEnding();
    }

    
}