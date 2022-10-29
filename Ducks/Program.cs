using Ducks;

DucksService ducksService = new DucksService();
Console.WriteLine(
    "Choose action with your duck: 1 - Create new duck \n2 - Show all ducks \n3 - Show duck \n4 - Competition \n5 - Swimming  \n6 - Training \n7 - Sleep \n8 - Eat");
Console.ReadLine();
int playerChoice = Convert.ToInt32(Console.ReadLine());
switch (playerChoice)
{
    case 1:
        Console.WriteLine("Choose name of your duck");
        string name = Console.ReadLine();
        ducksService.CreateNewDuck(name);
        break;
    case 2:
        if (CheckDucksInCollection())
        {
            foreach (var duck in ducksService.Ducks)
            {
                duck.ShowDuck();
            }
        }
        else
        {
            NotFound();
        }

        break;
    case 3:
        GetDuck().ShowDuck();
        break;
    case 4:
        if (ducksService.Ducks.Count > 1)
        {
            Console.WriteLine("This duck winner: ");
            ducksService.GetCompetition().ShowDuck();
        }
        else
        {
            NotFound();
        }

        break;
    case 5:
        if (ducksService.Ducks.Count > 1)
        {
            foreach (var duck in ducksService.Ducks)
            {
                duck.Swimming();
            }

            Console.WriteLine("Ducks are swimming...");
        }
        else
        {
            NotFound();
        }

        break;
    case 6:
        if (CheckDucksInCollection())
        {
            GetDuck().Training();
            Console.WriteLine("Duck is training...");
        }

        break;
    case 7:
        if (CheckDucksInCollection())
        {
            GetDuck().Sleep();
            Console.WriteLine("Duck are sleeping...");
        }

        break;
    case 8:
        var duckToEat = GetDuck();
        
        if (duckToEat != null)
        {
            duckToEat.Eat();
            Console.WriteLine("Duck is eating...");
        }
        break;
}


Duck GetDuck()
{
    Console.WriteLine("Enter duck's id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    return ducksService.GetDuckById(id);
}

bool CheckDucksInCollection()
{
    return ducksService.Ducks.Count > 0;
}

void NotFound()
{
    Console.WriteLine("Not found duck :(");
}

void CheckNull()
{
    if (GetDuck() null)
    {
        
    }
}