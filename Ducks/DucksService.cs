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

    public void GetCompetition(string name)
    {
        
    }
}