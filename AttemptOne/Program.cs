using System.Drawing;
using KaimiraGames;
using Microsoft.VisualBasic;




//player placeholder stuff
int playerHealth = 20;
int playerMaxHealth = 20;
int playerLevel = 1;
int playerExperience = 0;
int playerX = 4;
int playerY = 15;

// room dimensions
int roomWidth = 30;
int roomHeight = 10;

List<string> playerInventory = new();
playerInventory.Add("Common Strike");
playerInventory.Add("Common Strike");
playerInventory.Add("Common Strike");
int p = 0;

bool isGameOver = false;

while (!isGameOver)
{
    // Game logic for when i like. do anything.


    // health check
    if (playerHealth <= 0)
    {
        Console.WriteLine("Game over!");
        isGameOver = true;
    }

    // updating le ui although there's really no user interface since its a console app.....
    Console.Clear();
    drawUI(playerExperience, playerLevel, playerHealth, playerInventory, playerX, playerY, roomHeight, roomWidth);
     Console.WriteLine("\n\n");
     Thread.Sleep(1000);
}

static void drawUI(int playerExperience, int playerLevel, int playerHealth, List<string> playerInventory, int playerY, int playerX, int roomHeight, int roomWidth)
{
    if (playerX < 0 || playerX >= roomWidth || playerY < 0 || playerY >= roomHeight)
    {
        Console.WriteLine("Invalid player position!");
        return;
    }

    // stats
    Console.WriteLine("Player Health: " + playerHealth);
    Console.WriteLine("Player Level: " + playerLevel);
    Console.WriteLine("Player Experience: " + playerExperience);
    Console.WriteLine("Current Inventory:");
    foreach (string item in playerInventory)
    {
        Console.WriteLine(item);
    }


// array to represent room
char[,] room = new char[roomWidth, roomWidth];

// initalizing
for (int i = 0; i < roomHeight; i++)
{
    for (int j = 0; j < roomWidth; j++)
    {
        room[i, j] = ' ';
    }
}

// room borders
for (int i = 0; i < roomWidth; i++)
{
    room[0, i] = '-';
    room[roomHeight - 1, i] = '-';
}
for (int i = 1; i < roomHeight - 1; i++)
{
    room[i, 0] = '|';
    room[i, roomWidth - 1] = '|';
}

// player pos
room[playerY, playerX] = '*';

// the actual room
for (int i = 0; i < roomHeight; i++)
{
    for (int j = 0; j < roomWidth; j++)
    {
        Console.Write(room[i, j]);
    }
    Console.WriteLine();
}
}



//Card Gen
var rand = new Random();
generateStrikeCard(playerLevel, playerInventory);

 static void generateStrikeCard(int playerLevel, List<string> playerInventory) 
{
    WeightedList<string> myWL = new();
    if(playerLevel >= 1 && playerLevel <= 5)
    {
        myWL.Add("Common", 85);
        myWL.Add("Uncommon", 75);
        myWL.Add("Rare", 35);
        myWL.Add("Epic", 20);
        myWL.Add("Legendary", 10);
        myWL.Add("Mythic", 5);
        myWL.Add("Godly", 1);
    }
    else if(playerLevel >= 6 && playerLevel <= 10)
    {
        myWL.Add("Common", 65);
        myWL.Add("Uncommon", 55);
        myWL.Add("Rare", 45);
        myWL.Add("Epic", 30);
        myWL.Add("Legendary", 12);
        myWL.Add("Mythic", 7);
        myWL.Add("Godly", 2);
    }
    else if(playerLevel >= 11 && playerLevel <= 15)
    {
        myWL.Add("Common", 45);
        myWL.Add("Uncommon", 45);
        myWL.Add("Rare", 45);
        myWL.Add("Epic", 35);
        myWL.Add("Legendary", 18);
        myWL.Add("Mythic", 10);
        myWL.Add("Godly", 5);
    }
    else if(playerLevel >= 16 && playerLevel <= 20)
    {
        myWL.Add("Common", 25);
        myWL.Add("Uncommon", 25);
        myWL.Add("Rare", 35);
        myWL.Add("Epic", 45);
        myWL.Add("Legendary", 25);
        myWL.Add("Mythic", 15);
        myWL.Add("Godly", 10);
    }
    else
    {
        Console.WriteLine("How");
    }

    String rolledStrikeRarity = myWL.Next();
    Console.WriteLine("You obtained a " + rolledStrikeRarity + " strike card!");
    playerInventory.Add(rolledStrikeRarity + " Strike");
    drawCard(   rolledStrikeRarity + " Strike");
    Console.Write("Current Inventory:  \n");
    foreach(String k in playerInventory)
        {
            Console.WriteLine(k);
        }
              Console.WriteLine(" ");
     }
    



//Drawing The Card
static void drawCard(string text) {
    Rectangle rect = new Rectangle(10, 10, 20, 10);

    if (rect.X + rect.Width > Console.WindowWidth) {
        rect.X = Console.WindowWidth - rect.Width;
    }
    if (rect.Y + rect.Height > Console.WindowHeight) {
        rect.Y = Console.WindowHeight - rect.Height;
    }

    for (int y = rect.Y; y < rect.Y + rect.Height; y++)
    {
        for (int x = rect.X; x < rect.X + rect.Width; x++)
        {
            if (y == rect.Y || y == rect.Y + rect.Height - 1)
            {
                Console.Write("-");
            }
            else if (x == rect.X || x == rect.X + rect.Width - 1)
            {
                Console.Write("|");
            }
            else if (y == rect.Y + 1 && x > rect.X + 1 && x < rect.X + rect.Width - 1)
            {
                int textIndex = x - rect.X - 2;
                if (textIndex < text.Length)
                {
                    Console.Write(text[textIndex]);
                }
                else
                {
                    Console.Write(" ");
                }
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}
