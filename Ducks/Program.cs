using Ducks;

DucksService ducksService = new DucksService();

bool isAlive = true;

while (isAlive)
{
    int playerChoice = GetPlayerChoice();

    Duck duck = null;

    if (playerChoice is 2 or 5 or 6 or 7)
    {
        if (TrueIfOneDuck())
        {
            duck = GetDuck();

            if (duck is null)
            {
                Console.WriteLine("Duck not found");

                continue;
            }

            if (!duck.IsAlive)
            {
                Console.WriteLine("Duck died.... :(");

                continue;
            }
        }
    }

    Process(playerChoice, duck);
}

void Process(int playerChoice, Duck duck = null)
{
    switch (playerChoice)
    {
        case 1:
            CreateDuck();
            break;
        case 2:
            Show(duck);
            break;
        case 3:
            Competition();
            break;
        case 4:
            Swiming();
            break;
        case 5:
            Training(duck);
            break;
        case 6:
            Sleep(duck);
            break;
        case 7:
            Eat(duck);
            break;
        case 8:
            isAlive = false;
            break;
        default:
            Console.WriteLine("Unknown value");
            break;
    }
}

int GetPlayerChoice()
{
    int playerChoice;

    if (!ducksService.Ducks.Any())
    {
        Console.WriteLine("Enter 1 to create duck. Enter 8 to shut down");

        playerChoice = Convert.ToInt32(Console.ReadLine());

        if (playerChoice is not 1 or 8)
        {
            Console.WriteLine("ENTER 1 OR 8!!!");

            playerChoice = 0;
        }
    }
    else
    {
        Console.WriteLine(
            "Choose action with your duck: \n1 - Create new duck \n2 - Show duck \n3 - Competition \n4 - Swimming  \n5 - Training \n6 - Sleep \n7 - Eat \n8 - Shutdown");

        playerChoice = Convert.ToInt32(Console.ReadLine());
    }

    return playerChoice;
}

void CreateDuck()
{
    Console.WriteLine("Choose name of your duck");
    string name = Console.ReadLine();
    ducksService.CreateNewDuck(name);
}

Duck GetDuck()
{
    foreach (var duck in ducksService.Ducks)
    {
        duck.ShowDuck();
    }

    Console.WriteLine("Enter duck's id: ");
    int id = Convert.ToInt32(Console.ReadLine());
    return ducksService.GetDuckById(id);
}


bool TrueIfOneDuck()
{
    Console.WriteLine("One(1) or all(2) ducks?");
    int playerChoiceCountDucks = Convert.ToInt32(Console.ReadLine());

    if (playerChoiceCountDucks == 1)
    {
        return true;
    }
    else
    {
        return false;
    }
}

void Show(Duck duckToShow = null)
{
    if (duckToShow is null)
    {
        foreach (var duck in ducksService.Ducks)
        {
            duck.ShowDuck();
        }
    }
    else
    {
        duckToShow.ShowDuck();
    }
}

void Competition()
{
    if (ducksService.Ducks.Count > 1)
    {
        Console.WriteLine("This duck winner: " + ducksService.GetCompetition().Name);
    }
    else
    {
        Console.WriteLine("Duck's count must be biggest than 1 for competition");
    }
}

void Training(Duck duckToTraining = null)
{
    if (duckToTraining is null)
    {
        foreach (var duck in ducksService.Ducks)
        {
            duck.Training();
        }
    }
    else
    {
        duckToTraining.Training();
    }
}

void Sleep(Duck duckToSleep = null)
{
    if (duckToSleep is null)
    {
        foreach (var duck in ducksService.Ducks)
        {
            duck.Sleep();
        }
    }
    else
    {
        duckToSleep.Eat();
    }
}

void Eat(Duck duckToEat = null)
{
    if (duckToEat is null)
    {
        foreach (var duck in ducksService.Ducks)
        {
            duck.Eat();
        }
    }
    else
    {
        duckToEat.Eat();
    }
}

void Swiming()
{
    foreach (var duck in ducksService.Ducks)
    {
        duck.Swimming();
    }

    Console.WriteLine("Ducks are swimming...");
}