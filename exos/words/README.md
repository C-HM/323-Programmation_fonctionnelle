# Words...
Créer un nouveau dossier dans le dossier personnel pour stocker les solutions de l'exercice.

## Partie 1 : Recherche par critère

### A. Filtrage basique

#### Selon une liste de mots

```c#
string[] words = { "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };
```

#### Filtres possibles des mots
 - ne contiennent pas la lettre `x`
 - ont 4 caractères ou plus
 - ont autant de caractères que la moyenne du nombre de caractères de la liste


> Pour chaque filtre, assigner un lambda à une variable de type Func

> Ajouter un menu (en console simple) pour choisir quel filtre appliquer (0..N)

#### Affichage des résultats
Ajouter dans le menu (ou demander à l’utilisateur une fois le filtre réalisé) les options suivantes d’affichage:

- dans l’ordre inverse de celui naturellement calculé
- triés a-z
- triés z-a

### B. Données parasites 1

Il arrive des situations où les données ne sont pas parfaites. Par exemple, on pourrait imaginer que le flux de génération des données contient des éléments aberrants
au début et à la fin:

```c#
string[] words = {"whatThe!!!", "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune","My kingdom for a horse !", "Ooops I did it again" };
```

Admettons pour l’instant que le flux amène toujours une donnée parasite au début et 2 à la fin. Dans ce cas, **implémenter** un filtrage en utilisant des fonctions décrites dans la cheatsheet
qui permettent un code très sobre et facile à lire. 

### C. Données parasites 2

Cette fois-ci les données parasites ont une empreinte particulière :

```c#
string[] words = {"+++++","<<<<<",">>>>>", "bonjour", "hello", "@@@@", "vert", "rouge", "bleu", "jaune","#####", "%%%%%%%" };
```

#### SkipWhile
Peut-on s’en sortir avec un SkipWhile ?
Si oui comment ?
Sinon pourquoi ?

#### Aide

##### Expression régulière
Les expressions régulières (regex) sont populaires lorsqu’il s’agit d’analyser du texte.
Elles ne sont pas forcément facile à composer parfois mais elles sont extrêmement efficaces.
Voici un exemple pour s’inspirer:

``` csharp
var startsWithALetter = Regex.IsMatch("test","^[a-zA-Z]");
```

### D. Élitisme
Admettons qu’on ne s’intéresse qu’au premier résultat d’une longue liste ou alors qu’au dernier.

Comment peut-on facilement extraire ces éléments à partir de la collection suivante:

```c#
string[] words = { "i am the winner", "hello", "monde", "vert", "rouge", "bleu", "i am the looser" };
```

Résultat:
- The winner is : i am the winner 
- The looser is : i am the looser

## Partie 2: Epsilon

Trouver une source fiable sur la répartition des lettres en français (A:8.15%, B:0.97%,...) et afficher les mots avec leur valeur Epsilon et **uniquement ceux dont la valeur Epsilon est comprise entre 0.5 et 0.95**. 

*La valeur Epsilon correspond à la somme des probabilités (pourcentage=probabilité\*100) d'apparation de chaque lettre d'un mot si les lettres sont toute différentes. En cas de lettre présente 2x dans le mots, par exemple, la probabilité est divisée par le nombre de lettres*

### Exemple de calcul pour Epsilon ###

| Source | Epsilon           |
|:-------|:------------------|
| ABA    | 0.0815/2 + 0.0097 |

-> La probabilité d’apparition de A dans un texte est identifiée à 0.0815
-> A apparaît 2x dans la source, il faut donc réduire son epsilon : 0.0815/nombre d’apparitions = 0.0815/2
-> La probabilité d’apparation de B est de 0.0097 et B n’apparaît qu’une fois dans la source...

> Si vous ne savez pas par quel bout prendre ce problème, regardez [ça](steps.md).

## Partie 3: Dictionnaire ##

Filtrer désormais dynamiquement les mots qui s'écrivent de la même manière en français et en anglais avec cette liste source:

```csharp
List<string> frenchWords = new List<string>() {
    "Merci",
    "Hotdog",
    "Oui",
    "Non",
    "Désolé",
    "Réunion",
    "Manger",
    "Boire",
    "Téléphone",
    "Ordinateur",
    "Internet",
    "Email",
    "Sandwich",
    "Hello",
    "Taxi",
    "Hotel",
    "Gare",
    "Train",
    "Bus",
    "Métro",
    "Tramway",
    "Vélo",
    "Voiture",
    "Piéton",
    "Feu rouge",
    "Cédez",
    "Ralentir",
    "gauche",
    "droite",
    "Continuer",
    "Sandwich",
    "Retourner",
    "Arrêter",
    "Stationnement",
    "Parking",
    "Interdit",
    "Péage",
    "Trafic",
    "Route",
    "Rond-point",
    "Football",
    "Carrefour",
    "Feu",
    "Panneau",
    "Vitesse",
    "Tramway",
    "Aéroport",
    "Héliport",
    "Port",
    "Ferry",
    "Bateau",
    "Canot",
    "Kayak",
    "Paddle",
    "Surf",
    "Plage",
    "Mer",
    "Océan",
    "Rivière",
    "Lac",
    "Étang",
    "Marais",
    "Forêt",
    "Hello",
    "Montagne",
    "Vallée",
    "Plaine",
    "Désert",
    "Jungle",
    "Savane",
    "Volleyball",
    "Tundra",
    "Glacier",
    "Neige",
    "Pluie",
    "Soleil",
    "Nuage",
    "Vent",
    "Tempête",
    "Ouragan",
    "Tornade",
    "Séisme",
    "Tsunami",
    "Volcan",
    "Éruption",
    "Ciel"
};
```

Par exemple, le mot HotDog est le même dans les 2 langues...
