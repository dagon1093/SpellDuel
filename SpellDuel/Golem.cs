namespace SpellDuel;

public class Golem
{
    int Health  { get; set; }
    
    public Golem(int health)
    {
        Health = health;
    }
    
    public void SetHealth(int health) => Health = health;

    public int GetHealth() => Health;

    public void GetDamage(int points)
    {
        if (Health - points <= 0) Health = 0;
        else  Health -= points;
    }
}