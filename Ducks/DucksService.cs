using System.Net.Sockets;

namespace Ducks;

public class DucksService
{
    public int NumberId;
    public List<Duck> Ducks = new List<Duck>();

    public void CreateNewDuck(string name)
    {
        Duck newDuck = new Duck(name, NumberId);
        Ducks.Add(newDuck);
        NumberId++;
    }

    public Duck GetCompetition()
    {
        int winnerId = 0;
        double max = 0;
        
        foreach (var duck in Ducks)
        {
            duck.Age++;
            double coefficient = duck.GetCoefficient();
            if (coefficient > max)
            {
                max = coefficient;
                winnerId = duck.ID;
            }
        }
        Duck winnerDuck =GetDuckById(winnerId);
        winnerDuck.StatusSuper = true;
        return winnerDuck;

    }

    private Duck GetDuckById(int id)
    {
        foreach (var duck in Ducks)
        {
            if (duck.ID == id)
            {
                return duck;
            }
        }

        return null;
    }
}