//Auteur : JMY
//Date   : 25.9.2025
//Lieu   : ETML
//Descr. : Entraînement au test 323
//         Cet outil permet de comparer 2 fichiers (avec le même nombre de lignes) ligne par ligne et indiquer les différences... Il permet aussi de faire du chiffrement

///MENU
Console.WriteLine("+--------------------------------+");
Console.WriteLine("|DIFFIT : A very limited DIFFTOOL|");
Console.WriteLine("+--------------------------------+");

Console.Write("Fichier A: ");
string? pathA = Console.ReadLine();

Console.Write("Fichier B: ");
string? pathB = Console.ReadLine();

// Vérification des entrées utilisateur
var paths = new string?[] { pathA, pathB };
bool filesAreValid = paths.Aggregate(true, (a, b) => a && b != null && File.Exists(b));
if (!filesAreValid)
{
    Console.WriteLine("Erreur: les fichiers doivent être existants et accessibles !");
    Environment.Exit(-2);
}

/// CHARGEMENT DES DONNÉES
// TODO: 01 Charger le contenu texte du fichier A (indice: File.ReadAllLines...)
string[] linesA = { "..." };

// TODO: 02 Charger le contenu texte du fichier B (indice: File.ReadAllLines...)
string[] linesB = { "..." };

// TODO: 03 Vérifier que les fichier ont le même nombre de lignes
if (true)
{
    Console.WriteLine("Erreur: les fichiers n'ont pas le même nombre de ligne");
    Environment.Exit(-2);
}

Console.WriteLine(">Fichiers chargés avec succés");

// TODO: 04 Définir les fonctions de nettoyage
// Une fonction de nettoyage reçoit un texte (une ligne de fichier) et renvoie cette même ligne adaptée
// Il existe la fonction Replace sur les string...
// Le caractère tabulation s’écrit \t
Func<string, string> cleanSpaces = text => text;
Func<string, string> cleanTabs = text => text;
Func<string, string> enforceCase = text => text;

/// OPTIONS DE NETTOYAGE
Console.WriteLine("Choisir les options:");

Console.Write("-Ignorer les espaces [o/n]: ");
bool ignoreSpaces = Console.ReadLine() == "o";

Console.Write("-Ignorer les tabulations [o/n]: ");
bool ignoreTabs = Console.ReadLine() == "o";

Console.Write("-Ignorer la casse [o/n]: ");
bool ignoreCase = Console.ReadLine() == "o";

// TODO:  05 Appliquer le nettoyage selon la demande utilisateur


// TODO: 06 Créer et remplir une liste de LinesComparison à partir de linesA et linesB
List<LinesComparison> comparisons = new();

// TODO: 07 Sélectionner les lignes qui ont des différences
var diffLines = new Liste<LinesComparison>();

// TODO: 08 Afficher le nombre de lignes identiques et différentes entre les 2 fichiers

// TODO: 09 Définir une fonction qui compte les différences (caractères différents) entre deux textes (sera utilisé pour les 2 lignes de A et B...)
// Pour info/rappel, la fonction Zip (comme une fermeture éclair) permet d’associer deux listes.
// Et pour info/rappel, un string est une liste de char...
// Ainsi "12345".Zip("ABCDE", (a, b) => $"{a}{b}").ToList().ForEach(Console.Write);//1A2B3C4D5E
// ATTENTION: zip ne prend que le nombre d’éléments minimum commun entre 2 listes...
// Ceci implique une correction: en plus du nombre de différences, il faut ajouter la différence du nombre de caractères entre les deux...
Func<LinesComparison, int> countVariations = _ => -1;

// TODO: 10 Afficher pour chaque ligne différente, le nombre de variations

/// Diff coloré
// TODO: 11 Colorier les différences
// Pour chaque ligne où il y a des différences:
// On affiche ainsi:
// Les lettres similaires sont en vert
// Les lettres différentes sont en rouge (options entre[a/b])
// On n’indique rien sur les caractères en plus ou en moins

/// Chiffrement
// TODO: 11 Créer une fonction qui chiffre le 1er fichier en décalant les caratères d’un nombre
//saisi par l’utilisateur (clé)
// Le contenu chiffré est enregistré sur le disque dans le fichier "cipheredA.txt"
// Le pendant de ReadAllLines est WriteAllLines
Console.Write("\n\nSPECIAL FEATURE: Clé de chiffrement [1-25]: ");
byte key = Convert.ToByte(Console.ReadLine());

public class LinesComparison
{
    public int Number { get; set; }
    public string ContentA { get; set; } = "";
    public string ContentB { get; set; } = "";

    /// <summary>
    /// Ajuste le numéro de ligne...
    /// </summary>
    public int NumberHuman
    {
        get => Number + 1;
    }

    public int LengthVariation { get => Math.Abs(ContentA.Length - ContentB.Length); }
}
