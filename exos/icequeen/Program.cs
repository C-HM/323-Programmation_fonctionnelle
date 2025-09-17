using System;
using System.Collections.Generic;
using System.Linq;

// Base classes
public class Character
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Kingdom { get; set; }
    public bool HasMagicalPowers { get; set; }
    public string PowerType { get; set; }
}

public class Song
{
    public string Title { get; set; }
    public string Singer { get; set; }
    public int DurationInSeconds { get; set; }
    public bool IsFamous { get; set; }
}

class Program
{
    static void Main()
    {
        // Sample data - Frozen
        var characters = new List<Character>
        {
            new Character { Name = "Elsa", Age = 21, Kingdom = "Arendelle", HasMagicalPowers = true, PowerType = "Ice" },
            new Character { Name = "Anna", Age = 18, Kingdom = "Arendelle", HasMagicalPowers = false, PowerType = null },
            new Character { Name = "Kristoff", Age = 21, Kingdom = "Mountain", HasMagicalPowers = false, PowerType = null },
            new Character { Name = "Olaf", Age = 1, Kingdom = "Arendelle", HasMagicalPowers = true, PowerType = "Snow magic" },
            new Character { Name = "Hans", Age = 23, Kingdom = "Southern Isles", HasMagicalPowers = false, PowerType = null },
            new Character { Name = "Sven", Age = 8, Kingdom = "Mountain", HasMagicalPowers = false, PowerType = null }
        };

        var songs = new List<Song>
        {
            new Song { Title = "Let It Go", Singer = "Elsa", DurationInSeconds = 225, IsFamous = true },
            new Song { Title = "Do You Want to Build a Snowman", Singer = "Anna", DurationInSeconds = 180, IsFamous = true },
            new Song { Title = "Love Is an Open Door", Singer = "Anna", DurationInSeconds = 120, IsFamous = false },
            new Song { Title = "In Summer", Singer = "Olaf", DurationInSeconds = 95, IsFamous = false }
        };

        Console.WriteLine("=== LINQ SELECT EXERCISES - FROZEN ===\n");

        // TODO 1: Créer une classe anonyme en utilisant directement les noms des propriétés existantes
        // Sélectionner seulement les propriétés Name et Age en gardant leurs noms originaux
        Console.WriteLine("1. Anonymous class without names:");
        //var result1 = characters.Select...
	result1.ForEach(r => Console.WriteLine($"   {r.Name} ({r.Age} years old)"));

        // TODO 2: Créer une classe anonyme avec des noms de propriétés personnalisés
        // Renommer les propriétés et ajouter le champ "MagicStatus" qui retourne un string "Magical" ou "Normal" selon le HasMagicalPowers
        Console.WriteLine("\n2. Anonymous class with custom names:");
        //var result2 = characters.Select(c => new { 
        result2.ForEach(r => Console.WriteLine($"   {r.CharacterName} - {r.Years} years ({r.MagicStatus})"));

        // TODO 3: Créer une projection tuple simple sans champs nommés
        Console.WriteLine("\n3. Simple tuple:");
        //var result3 = songs.Select...
        result3.ForEach(r => Console.WriteLine($"   {r.Item1} - {r.Item2}s"));

        // TODO 4: Créer un tuple nommé avec noms de champs personnalisés et calculs
        Console.WriteLine("\n4. Named tuple:");
        //var result4 = songs.Select...
        result4.ForEach(r => Console.WriteLine($"   {r.SongTitle} by {r.Artist} ({r.Minutes}min) {r.PopularityLevel}"));

        // TODO 5: Créer une projection complexe avec logique métier et champs calculés
	//Identity : Nom suivi de "from" suivi du nom du Royaume
	//AgeCategory: Enfant, Ado, Adulte
	//InfluenceScore: Si le personnage a de la magie, son age est multiplié par 2
        Console.WriteLine("\n5. Projection with business logic:");
        //var result5 = characters.Select...
	result5.ForEach(r => Console.WriteLine($"   {r.Identity} | {r.AgeCategory} | {r.PowerDescription} | Score: {r.InfluenceScore}"));
    }
}
