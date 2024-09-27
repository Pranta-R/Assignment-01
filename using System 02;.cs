using System;

// Base Character Class
public abstract class Character
{
    // Common Attributes
    public string Name { get; protected set; }
    public int Health { get; protected set; }
    public int Mana { get; protected set; }
    public int Strength { get; protected set; }
    public int Agility { get; protected set; }
    public int Defense { get; protected set; }

    // Constructor to initialize the character's name
    public Character(string name)
    {
        Name = name;
    }

    // Abstract method for character's unique ability
    public abstract void SpecialAbility();

    // Display character stats
    public void DisplayStats()
    {
        Console.WriteLine($"Character: {Name}");
        Console.WriteLine($"Health: {Health}");
        Console.WriteLine($"Mana: {Mana}");
        Console.WriteLine($"Strength: {Strength}");
        Console.WriteLine($"Agility: {Agility}");
        Console.WriteLine($"Defense: {Defense}");
        Console.WriteLine();
    }
}

// Warrior Class
public class Warrior : Character
{
    public Warrior(string name) : base(name)
    {
        Health = 150;
        Mana = 20;
        Strength = 100;
        Agility = 50;
        Defense = 80;
    }

    // Warrior's special ability
    public override void SpecialAbility()
    {
        Console.WriteLine($"{Name} uses 'Power Strike'!");
    }
}

// Mage Class
public class Mage : Character
{
    public Mage(string name) : base(name)
    {
        Health = 80;
        Mana = 150;
        Strength = 40;
        Agility = 60;
        Defense = 30;
    }

    // Mage's special ability
    public override void SpecialAbility()
    {
        Console.WriteLine($"{Name} casts 'Fireball'!");
    }
}

// Archer Class
public class Archer : Character
{
    public Archer(string name) : base(name)
    {
        Health = 100;
        Mana = 50;
        Strength = 60;
        Agility = 120;
        Defense = 40;
    }

    // Archer's special ability
    public override void SpecialAbility()
    {
        Console.WriteLine($"{Name} uses 'Arrow Storm'!");
    }
}

// Factory Method Pattern - Character Factory
public class CharacterFactory
{
    // Factory method to create characters based on the type
    public Character CreateCharacter(string type, string name)
    {
        switch (type.ToLower())
        {
            case "warrior":
                return new Warrior(name);
            case "mage":
                return new Mage(name);
            case "archer":
                return new Archer(name);
            default:
                throw new ArgumentException("Invalid character type");
        }
    }
}

// Main program to demonstrate Factory Method Pattern
public class Program
{
    public static void Main()
    {
        // Create the factory instance
        CharacterFactory factory = new CharacterFactory();

        // Create different characters using the factory
        Character warrior = factory.CreateCharacter("warrior", "Thorin");
        Character mage = factory.CreateCharacter("mage", "Gandalf");
        Character archer = factory.CreateCharacter("archer", "Legolas");

        // Display their stats and abilities
        warrior.DisplayStats();
        warrior.SpecialAbility();

        mage.DisplayStats();
        mage.SpecialAbility();

        archer.DisplayStats();
        archer.SpecialAbility();
    }
}
