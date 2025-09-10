//Auteur   : JMY
//Date     : 03.9.2024
//Révision : 2025
//Lieu     : ETML
//Descr.   : programmation fonctionnelle

using System.Text.RegularExpressions;

void A()
{
    Console.WriteLine("\n*PARTIE 1A\n");
    /*
    ne contiennent pas la lettre x
    ont 4 caractères ou plus
    ont autant de caractères que la moyenne du nombre de caractères de la liste

    */

    //Donnée
    string[] words = { "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };

    //Fonctions de filtrage
    Func<string, bool> noX = word => !word.Contains("x");
    Func<string, bool> noX2 = word => !Regex.IsMatch(word, "x");

    Func<string, bool> fourOrMore = word => word.Length >= 4;

    Func<string, bool> sameAsAvg =
        word => word.Length == words.Average(wordForAverage => wordForAverage.Length);

    //Recueil de fonctions
    var filters = new List<Func<string, bool>>();
    filters.Add(noX);
    filters.Add(noX2);
    filters.Add(fourOrMore);
    filters.Add(sameAsAvg);

    //Menu
    Console.WriteLine($"Liste de mots : {String.Join(',', words)}");
    Console.WriteLine("1. Pas de x v1");
    Console.WriteLine("2. Pas de x v2 (regexp)");
    Console.WriteLine("3. >= 4");
    Console.WriteLine("4. = moyenne de longueur dans la liste");
    Console.Write("\nChoix: ");

    int choice = Convert.ToInt32(Console.ReadLine()) - 1;

    var filtered = words.Where(filters[choice]);
    Console.WriteLine($"Résultat: {String.Join(',', filtered)}");
    /*
        dans l’ordre inverse de celui naturellement calculé
        triés a-z
        triés z-a
     */

    Console.WriteLine("\n--------------\nTri\n");
    Console.WriteLine("1. Inverse");
    Console.WriteLine("2. triés a-z");
    Console.WriteLine("3. triés z-a");
    choice = Convert.ToInt32(Console.ReadLine());

    IEnumerable<string> Sort(int choice) => /*Lambda ou pas lambda...*/
        choice switch
        {
            1 => filtered.Reverse(),
            2 => filtered.OrderBy(word => word),
            3 => filtered.OrderByDescending(word => word),
            _ => throw new NotImplementedException($"Valid choices are 1,2,3 but not {choice}")
        };

    Console.WriteLine($"Résultat: {String.Join(',', Sort(choice))}");

}

Action b = ()=>
{
    Console.WriteLine("\n*PARTIE 1B\n");
    string[] words = { "whatThe!!!", "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune", "My kingdom for a horse !", "Ooops I did it again" };
    Console.WriteLine(String.Join(',',words.Skip(1).SkipLast(2)));

};

Func<IEnumerable<string>> c = () =>
{
    Console.WriteLine("\n*PARTIE 1C\n");
    string[] words = { "+++++", "<<<<<", ">>>>>", "bonjour", "hello", "@@@@", "vert", "rouge", "bleu", "jaune", "#####", "%%%%%%%" };

    var clean = words.Where(word => word.All(letter => char.IsLetterOrDigit(letter)));

    return clean;
};

Func<object?> d = () =>
{
    Console.WriteLine("\n*PARTIE 1D\n");
    string[] words = { "i am the winner", "hello", "monde", "vert", "rouge", "bleu", "i am the looser" };
    Console.WriteLine($"Winner: {words.First()}, Looser: {words.Last()}");
    return null;
};

Action epsilon = () =>
{
    Console.WriteLine("\n*PARTIE 2\n");
    string[] words = { "aba", "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };

    //source de stat: https://www.apprendre-en-ligne.net/crypto/stat/francais.html
    var stats = new List<double>() { 8.15, 0.97, 3.15, 3.73, 17.39, 1.12, 0.97, 0.85, 7.31, 0.45, 0.02, 5.69, 2.87, 7.12, 5.28, 2.8, 1.21, 6.64, 8.14, 7.22, 6.38, 1.64, 0.03, 0.41, 0.28, 0.15 };

    words.Select(
    //Transformation sous forme de tuple pour l’affichage à la fin
    word => Tuple.Create(word,
    word
                //Calcul de Epsilon
                .GroupBy(character => character)
                .Sum(group => stats[(int)group.Key - 97] / 100 / group.Count()))
        )
        //Filter
        .Where(tuple => tuple.Item2 >= 0.0 && tuple.Item2 <= 10.95)

        //Print
        .ToList().ForEach(tuple => Console.WriteLine($"Epsilon de {tuple.Item1}: {tuple.Item2}")
    );
};

void Dictionary()
{
    Console.WriteLine("\n*PARTIE 3\n");
    List<string> frenchWords = new List<string>() {"Merci","Hotdog","Oui","Non","Désolé","Réunion","Manger","Boire","Téléphone","Ordinateur","Internet","Email","Sandwich","Hello","Taxi","Hotel","Gare","Train","Bus","Métro","Tramway","Vélo","Voiture","Piéton","Feu rouge","Cédez","Ralentir","gauche","droite","Continuer","Sandwich","Retourner","Arrêter","Stationnement","Parking","Interdit","Péage","Trafic","Route","Rond-point","Football","Carrefour","Feu","Panneau","Vitesse","Tramway","Aéroport","Héliport","Port","Ferry","Bateau","Canot","Kayak","Paddle","Surf","Plage","Mer","Océan","Rivière","Lac","Étang","Marais","Forêt","Hello","Montagne","Vallée","Plaine","Désert","Jungle","Savane","Volleyball","Tundra","Glacier","Neige","Pluie","Soleil","Nuage","Vent","Tempête","Ouragan","Tornade","Séisme","Tsunami","Volcan","Éruption","Ciel"};
    //source: https://www.cs.rit.edu/~jsb/2135/ProgSkills/Labs/Phone/english-words.txt
    var source = "words.txt";
    const int maxParent = 5;
    int parent = 0;
    while(!File.Exists(source) && parent<maxParent)
    {
        //handles start from ide
        source = $"../{source}";
        parent++;
    }
    var englishWordsLC = File.ReadAllLines(source).Select(word=>word.ToLower());

    var same = frenchWords.Where(word => englishWordsLC.Contains(word.ToLower()));
    Console.WriteLine(String.Join(',',same));
}

Console.WriteLine("+--------------------------+");
Console.WriteLine("|WORDS: JOUER AVEC LES MOTS|");
Console.WriteLine("+--------------------------+");

A();
b();
Console.WriteLine(String.Join(',',c()));
epsilon.Invoke();
Dictionary();
