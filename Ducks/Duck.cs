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
        
    public Duck(string name, int id)
    {
        Name = name;
        Tonus = 0;
        Sleeping = 0;
        Age = 0;
        Weight = 0;
        ID = id;
    }

    public void ShowDuck()
    {
        if (!IsAlive)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        
        Console.Write($"[{ID}]");
        
        if (StatusSuper)
        {
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.Write($"[{Name}]");
            Console.ResetColor();
        }
        else
        {
            Console.Write(Name);
        }
        
        Console.WriteLine($" Sleeping: {Sleeping} Weight: {Weight} Tonus: {Tonus} Age: {Age}");
        
        Console.ResetColor();
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

    public void Competition()
    {
        CheckLackOfSleep();
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

    public double GetCoefficient()
    {
        int percents = 0;
        
        if (Age > 7)
        {
            percents += -15;
        }

        if (Weight > 10)
        {
            percents += -30;
        }

        if (StatusSuper)
        {
            percents += 10;
        }

        return Tonus + Tonus * percents;
    }
    
}