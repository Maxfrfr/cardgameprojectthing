using System.Drawing;
using KaimiraGames;
using Microsoft.VisualBasic;


//player placeholder stuff
int playerHealth = 20;
int playerMaxHealth = 20;
int playerLevel = 1;
int playerExperience = 0;
List<string> playerInventory = new();
playerInventory.Add("Common Strike");
playerInventory.Add("Common Strike");
playerInventory.Add("Common Strike");
int p = 0;
foreach(String k in playerInventory)
{
    Console.Write("{0}: ", p);
    Console.WriteLine(k);
    p++;
}
        Console.WriteLine(" ");
string text = "   Hello World"; // Testing Purposes

drawCard(text);


//Generating Cards
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
    Console.WriteLine(rolledStrikeRarity);
    if(rolledStrikeRarity == "Common")
    {
        Console.WriteLine("You obtained a Common Strike");
        playerInventory.Add("Common Strike");
        Console.Write("Current Inventory:  \n");
        foreach(String k in playerInventory)
        {
            Console.WriteLine(k);
        }
                Console.WriteLine(" ");

            }
    

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