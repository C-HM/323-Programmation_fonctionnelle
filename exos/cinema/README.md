# Cinéma
## Selon la liste de films suivants

```csharp
List<Movie> frenchMovies = new List<Movie>() {
new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
};
```


## Réaliser les filtres suivants (**un lambda assigné à une variable par filtre**):

1. Filtrer les films qui ne sont pas du genre "Comédie" or "Drame".
2. Identifier les films dont le rating est inférieur à 7.
3. Afficher les films réalisés avant 2000.
4. Trouver les films qui n'ont pas de doublage en français.
5. Identifier les films non présents sur netflix


> Note: La classe `Movie` devrait avoir les propriétés suivantes: `Title`, `Genre`, `Rating`, `Year`, `LanguageOptions` (qui est un tableau de string), et `StreamingPlatforms` (qui est aussi un tableau de string).

### Version 2 : Cumul
Réaliser désormais un filtre qui cumule tous les filtres précédents sur le cinéma.

### Version 3: Dynamique
Pour chaque filtre, laisser l'utilisateur choisir le ou les valeurs de critères (console ou GUI à choix) en **utilisant des types Action/Func** :

``` csharp
Func<List<Movie>,List<Movie>>
```

