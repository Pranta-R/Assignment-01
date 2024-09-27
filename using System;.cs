using System;
using System.Collections.Generic;

public class GameWorld
{
    // Static field to hold the single instance of GameWorld
    private static GameWorld instance = null;

    // Lock for thread safety when creating the instance
    private static readonly object lockObject = new object();

    // Private constructor to prevent instantiation
    private GameWorld()
    {
        InitializeWorld();
    }

    // Public method to provide access to the single instance
    public static GameWorld Instance
    {
        get
        {
            // Double-check locking for thread safety
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new GameWorld();
                    }
                }
            }
            return instance;
        }
    }

    // World map (basic grid)
    private string[,] worldMap;
    
    // List of NPCs
    private List<NPC> npcList;

    // Global Game State Variables
    public string TimeOfDay { get; private set; }
    public string WeatherCondition { get; private set; }

    // Method to initialize the game world
    private void InitializeWorld()
    {
        // Initialize world map (5x5 grid for simplicity)
        worldMap = new string[5, 5]
        {
            {"Forest", "Desert", "Mountain", "Village", "River"},
            {"Cave", "Castle", "Farm", "Town", "Lake"},
            {"Swamp", "Beach", "Hill", "Dungeon", "Plains"},
            {"City", "Tower", "Field", "Temple", "Ruins"},
            {"Camp", "Fortress", "Bridge", "Island", "Woods"}
        };

        // Initialize NPC list
        npcList = new List<NPC>
        {
            new NPC("Guard", "Protector"),
            new NPC("Merchant", "Trader"),
            new NPC("Villager", "Farmer")
        };

        // Initialize game state
        TimeOfDay = "Morning";
        WeatherCondition = "Sunny";
    }

    // Public method to get the world map
    public void DisplayWorldMap()
    {
        for (int i = 0; i < worldMap.GetLength(0); i++)
        {
            for (int j = 0; j < worldMap.GetLength(1); j++)
            {
                Console.Write(worldMap[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Public method to list all NPCs
    public void DisplayNPCs()
    {
        Console.WriteLine("List of NPCs:");
        foreach (var npc in npcList)
        {
            Console.WriteLine($"Name: {npc.Name}, Role: {npc.Role}");
        }
    }

    // Public method to change the game state
    public void UpdateGameState(string timeOfDay, string weatherCondition)
    {
        TimeOfDay = timeOfDay;
        WeatherCondition = weatherCondition;
        Console.WriteLine($"Game state updated: Time of Day - {TimeOfDay}, Weather - {WeatherCondition}");
    }
}

// NPC class representing a non-player character
public class NPC
{
    public string Name { get; private set; }
    public string Role { get; private set; }

    public NPC(string name, string role)
    {
        Name = name;
        Role = role;
    }
}

// Main program to demonstrate the Singleton pattern
public class Program
{
    public static void Main()
    {
        // Access the singleton instance of GameWorld
        GameWorld world = GameWorld.Instance;

        // Display the world map
        Console.WriteLine("Game World Map:");
        world.DisplayWorldMap();
        
        // Display the NPCs
        world.DisplayNPCs();

        // Modify global game state
        world.UpdateGameState("Evening", "Rainy");

        // Attempt to create another instance (will return the same instance)
        GameWorld anotherWorld = GameWorld.Instance;
        Console.WriteLine(Object.ReferenceEquals(world, anotherWorld) 
            ? "Same instance" : "Different instances");
    }
}
