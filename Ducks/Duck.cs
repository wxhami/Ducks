namespace Ducks;

public class Duck
{
    public double Tonus;
    public double Sleeping;
    public int Age;
    public bool StatusSuper;
    public double Weight;
    public string Name;
    public int ID;

    public bool IsAlive => CheckAlive();
        
    public Duck(string name)
    {
        Name = name;
        Tonus = 0;
        Sleeping = 0;
        Age = 0;
        Weight = 0;
        
    }

    public void ShowDuck()
    {
        Console.WriteLine($"Name: {Name} Sleeping: {Sleeping} Weight: {Weight} Tonus: {Tonus} Age: {Age} ID: {ID}");
    }

    public void Eat()
    {
        Weight += 0.2;
        Tonus += 1;
        CheckLackOfSleep();
    }

    public void Sleep()
    {
        Tonus++;
        CheckLackOfSleep();
    }

    public void Training()
    {
        Tonus++;
        Sleeping -= 1;
        Weight -= 0.1;
        CheckLackOfSleep();
    }

    public void Swimming()
    {
        Tonus++;
        Sleeping++;
        CheckLackOfSleep();
    }

    public void Competicion()
    {
        Tonus -= 2;
        Sleeping -= 2;
        Weight -= 0.2;
    }

    private void CheckLackOfSleep()
    {
        if (Sleeping < 0)
        {
            Tonus -= 0.5;
        }
    }

    private bool CheckAlive()
    {
        if (Age >= 10 || Weight < 0)
        {
            return false;
        }

        return true;
    }
    
    
}