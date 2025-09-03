using cinema;

List<Movie> frenchMovies = new List<Movie>() {
new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
};

//Filtre 1
Console.WriteLine("1. Filtrer les films qui ne sont pas du genre \"Comédie\" or \"Drame\".");
List<Movie> notComedyOrDrama = frenchMovies
    .Where(m => m.Genre != "Comédie" && m.Genre != "Drame")
    .ToList();
notComedyOrDrama.ForEach(m => Console.WriteLine(m.Title + ", " + m.Genre));

//Filtre 2
Console.WriteLine("\n2. Identifier les films dont le rating est inférieur à 7.");
List<Movie> rating = frenchMovies
    .Where(m => m.Rating < 7)
    .ToList();
rating.ForEach(m => Console.WriteLine(m.Title + ", " + m.Rating));

//Filtre 3
Console.WriteLine("\n3. Afficher les films réalisés avant 2000.");
List <Movie> year = frenchMovies
    .Where(m => m.Year <2000 )
    .ToList();
year.ForEach(m => Console.WriteLine(m.Title + ", " + m.Year));

//Filtre 4
Console.WriteLine("\n4. Trouver les films qui n'ont pas de doublage en français.");
List <Movie> noFrench = frenchMovies
    .Where(m => !m.LanguageOptions.Contains("Français"))
    .ToList();
noFrench.ForEach(m => Console.WriteLine(m.Title + ", " + m.LanguageOptions));

//Filtre 5
Console.WriteLine("\n5. Identifier les films non présents sur netflix");
List <Movie> notOnNetflix = frenchMovies
    .Where(m => !m.StreamingPlatforms.Contains("Netflix"))
    .ToList();
notOnNetflix.ForEach(m => Console.WriteLine(m.Title));

//Version 2 Cumul
Console.WriteLine("\nVersion 2 Cumul. Réaliser désormais un filtre qui cumule tous les filtres précédents sur le cinéma.");
List<Movie> cumulFiltres = frenchMovies
    .Where(m => m.Genre != "Comédie" && m.Genre != "Drame")
    .Where(m => m.Rating < 7)
    .Where(m => m.Year < 2000)
    .Where(m => !m.LanguageOptions.Contains("Français"))
    .Where(m => !m.StreamingPlatforms.Contains("Netflix"))
    .ToList();
cumulFiltres.ForEach(m => Console.WriteLine(m.Title));

//Version 3 Dynamique
Console.WriteLine("\nVersion 3: Dynamique. Pour chaque filtre, laisser l'utilisateur choisir le ou les valeurs de critères (console ou GUI à choix) en utilisant des types Action/Func :");
Func<List<Movie>, List<Movie>> filterByGenre = (movies) =>
{
    Console.WriteLine("Enter genre to exclude:");
    string genre = Console.ReadLine();

    return movies.Where(m => m.Genre != genre).ToList();
};

var result = filterByGenre(frenchMovies);
result.ForEach(m => Console.WriteLine(m.Title));

Console.ReadLine();