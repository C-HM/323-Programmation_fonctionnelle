# Exercice C# LINQ Zip - Organisation d'Événements

## Contexte
Vous organisez différents événements pour votre école et devez **associer des éléments ensemble**, comme on "zippe" une fermeture éclair ! La méthode `Zip()` permet d'associer les éléments de deux listes un par un.

---

## **Étape 1 - Niveau Débutant**
### Formation de binômes pour un projet

**Objectif :** Utiliser `Zip()` pour former des binômes d'étudiants.

**Situation :** Vous avez une liste d'étudiants et vous voulez les associer deux par deux automatiquement.

**Données de départ :**
```csharp
var group1 = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Eve" };
var group2 = new List<string> { "Felix", "Grace", "Hugo", "Iris", "Jack" };
```

**Consigne :**
1. Utiliser `Zip()` pour créer des binômes (un étudiant du groupe 1 avec un du groupe 2)
2. Afficher les équipes formées
3. Compter le nombre total d'équipes

**Résultat attendu :**
```
Répartition:
-------------------------
Team 1: Alice & Felix
Team 2: Bob & Grace
Team 3: Charlie & Hugo
Team 4: Diana & Iris
Team 5: Eve & Jack

Total: 5 équipes
```

---

## **Étape 2 - Niveau Intermédiaire**
### Organisation d'un tournoi de ping-pong

**Objectif :** Utiliser `Zip()` pour synthétiser des matchs avec scores et déterminer les gagnants.

**Classes nécessaires :**
```csharp
public class Match
{
    public string Player1 { get; set; }
    public string Player2 { get; set; }
    public int Score1 { get; set; }
    public int Score2 { get; set; }
    public string Winner => Score1 > Score2 ? Player1 : Player2;
    public string Result => $"{Player1} {Score1}-{Score2} {Player2}";
    public bool IsCloseMatch => Math.Abs(Score1 - Score2) <= 2;
}
```

**Données de départ :**
```csharp
var playersA = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Eve", "Felix" };
var playersB = new List<string> { "Grace", "Hugo", "Iris", "Jack", "Kim", "Leo" };
var scoresA = new List<int> { 21, 18, 21, 15, 21, 19 };
var scoresB = new List<int> { 19, 21, 16, 21, 17, 21 };
```

**Consignes :**
1. Utiliser `Zip()` pour créer les matchs avec les scores
2. Afficher tous les résultats
3. Identifier les matchs les plus serrés (différence ≤ 2 points)
4. Créez un classement des gagnants

** Résultat attendu: **

```
Tournoi de Ping-Pong
==============================
Match 1: Alice 21-19 Grace → Gagnante: Alice
Match 2: Bob 18-21 Hugo → Gagnant: Hugo
Match 3: Charlie 21-16 Iris → Gagnant: Charlie
Match 4: Diana 15-21 Jack → Gagnant: Jack
Match 5: Eve 21-17 Kim → Gagnante: Eve
Match 6: Felix 19-21 Leo → Gagnant: Leo

Matchs serrés (2):
   • Alice 21-19 Grace
   • Felix 19-21 Leo
   
Classement:
   Alice: 1 victoire(s)
   Hugo: 1 victoire(s)
   Charlie: 1 victoire(s)
   Jack: 1 victoire(s)
   Eve: 1 victoire(s)
   Leo: 1 victoire(s)
```

---

## **Étape 3 - Niveau Avancé**
### Organisation complète d'une soirée dansante

**Objectif :** Utiliser `Zip()` multiple pour organiser une soirée avec partenaires, musiques et horaires.

**Classes nécessaires :**
```csharp
public class DanceSession
{
    public string MalePartner { get; set; }
    public string FemalePartner { get; set; }
    public string DanceStyle { get; set; }
    public string Song { get; set; }
    public TimeSpan StartTime { get; set; }
    public int DurationMinutes { get; set; }
    public string Couple => $"{MalePartner} & {FemalePartner}";
    public TimeSpan EndTime => StartTime.Add(TimeSpan.FromMinutes(DurationMinutes));
    public string Schedule => $"{StartTime:hh\\:mm} - {EndTime:hh\\:mm} : {DanceStyle} to '{Song}'";
}

public enum DanceLevel { Beginner, Intermediate, Advanced }
```

**Données de départ :**
```csharp
var malePartners = new List<string> { "Antoine", "Bruno", "Camille", "David", "Etienne", "Fabien" };
var femalePartners = new List<string> { "Amelie", "Beatrice", "Celine", "Delphine", "Elise", "Fanny" };
var danceStyles = new List<string> { "Waltz", "Tango", "Salsa", "Rock", "Bachata", "Cha-cha" };
var songs = new List<string> { 
    "La Vie en Rose", "Por una Cabeza", "Bamboleo", 
    "Johnny B. Goode", "Corazon Espinado", "Sway" 
};
var schedules = new List<TimeSpan> { 
    new(20, 00, 0), new(20, 15, 0), new(20, 30, 0), 
    new(20, 45, 0), new(21, 00, 0), new(21, 15, 0) 
};
var durations = new List<int> { 12, 10, 15, 8, 12, 10 };
```

**Consignes :**
1. Utiliser `Zip()` multiple pour créer le programme complet
2. Organiser les danses par ordre chronologique
3. Détecter les chevauchements d'horaires
4. Créer des statistiques sur la soirée
5. Proposer un système de rotation des partenaires

**Résultat attendu**
```
Programme de dance
===============================
🎵 20:00 - 20:12 : Waltz to 'La Vie en Rose'
   Couple: Antoine & Amelie

🎵 20:15 - 20:25 : Tango to 'Por una Cabeza'
   Couple: Bruno & Beatrice

🎵 20:30 - 20:45 : Salsa to 'Bamboleo'
   Couple: Camille & Celine

🎵 20:45 - 20:53 : Rock to 'Johnny B. Goode'
   Couple: David & Delphine

🎵 21:00 - 21:12 : Bachata to 'Corazon Espinado'
   Couple: Etienne & Elise

🎵 21:15 - 21:25 : Cha-cha to 'Sway'
   Couple: Fabien & Fanny

Vérification du planning
Statistiques:
   • Durée totale: 67 minutes
   • Nombre de dances: 6
   • Début: 20:00
   • Fin: 21:25

Styles:
   • Waltz: 1x
   • Tango: 1x
   • Salsa: 1x
   • Rock: 1x
   • Bachata: 1x
   • Cha-cha: 1x

Prochaine session:
   Suggestion:
   Bruno & Amelie
   Camille & Beatrice
   David & Celine
   Etienne & Delphine
   Fabien & Elise
   Antoine & Fanny
```

---

## Théorie : ** Quand NE PAS utiliser Zip()**

### **1. Collections de tailles différentes avec logique métier complexe**
```csharp
//  MAUVAIS - Zip() ignore les éléments supplémentaires
var questions = new List<string> { "Q1", "Q2", "Q3", "Q4", "Q5" };
var answers = new List<string> { "A1", "A2", "A3" }; // 2 réponses manquantes !
var qa = questions.Zip(answers, (q, a) => $"{q}: {a}"); // Perd Q4 et Q5 !

//  BON - Utiliser une boucle for ou Select avec index
var qaComplete = questions.Select((q, index) => 
    $"{q}: {(index < answers.Count ? answers[index] : "No answer")}");
```

### **2. Relations Many-to-Many**
```csharp
//  MAUVAIS - Zip() pour des relations complexes
var students = new List<string> { "Alice", "Bob" };
var subjects = new List<string> { "Math", "Physics", "Chemistry" };
// Chaque étudiant peut avoir plusieurs matières !

//  BON - Utiliser SelectMany ou des jointures
var enrollments = students.SelectMany(student => 
    subjects.Select(subject => new { Student = student, Subject = subject }));
```

### **3. Transformations conditionnelles**
```csharp
//  MAUVAIS - Logique conditionnelle complexe
var temperatures = new List<int> { -5, 0, 15, 25, 35 };
var activities = new List<string> { "Skiing", "Walking", "Hiking", "Swimming", "Beach" };
// L'activité dépend de la température, pas juste de la position !

//  BON - Utiliser Where et des conditions
var suitableActivities = temperatures
    .Select((temp, index) => new { temp, activity = activities[index] })
    .Where(x => (x.temp < 0 && x.activity == "Skiing") || 
                (x.temp >= 20 && x.activity.Contains("Swimming")));
```

### **4. Agrégations ou calculs cumulatifs**
```csharp
//  MAUVAIS - Zip() ne gère pas les agrégations
var sales = new List<decimal> { 100, 200, 150, 300 };
var months = new List<string> { "Jan", "Feb", "Mar", "Apr" };
// Si on veut des totaux cumulés, Zip() ne suffit pas

//  BON - Utiliser Aggregate ou des calculs séquentiels
var cumulativeSales = sales
    .Select((sale, index) => new { 
        Month = months[index], 
        MonthlySale = sale, 
        CumulativeTotal = sales.Take(index + 1).Sum() 
    });
```

---

## Théorie:  **Concepts Clés à Retenir**

### **Pourquoi "Zip" ?**
Comme une fermeture éclair (zip), on associe les éléments **un par un** :
```
Liste A: [A1, A2, A3, A4]
Liste B: [B1, B2, B3, B4]
         ↓   ↓   ↓   ↓
Résultat: [(A1,B1), (A2,B2), (A3,B3), (A4,B4)]
```

### **Utilisez Zip() quand :**
- Les collections ont **la même logique de taille**
- Vous voulez **apparier élément par élément**
- La relation est **1:1** et **positionnelle**
- Pas de logique conditionnelle complexe

### **N'utilisez PAS Zip() quand :**
- Les tailles peuvent différer avec logique métier
- Relations **Many-to-Many** ou **One-to-Many**
- Transformations **conditionnelles**
- **Agrégations** ou calculs dépendants

### **Alternatives à considérer :**
- `SelectMany()` pour les relations multiples
- `Select()` avec index pour un contrôle total
- `GroupJoin()` ou `Join()` pour des jointures réelles
- `Aggregate()` pour les calculs cumulatifs

---

## **Questions de Réflexion**

1. **Intuition :** Pourquoi dit-on que `Zip()` fonctionne comme une fermeture éclair ?

2. **Limitations :** Que se passe-t-il si une liste a 5 éléments et l'autre 3 ?

3. **Alternative :** Comment feriez-vous la même chose avec une boucle `for` classique ?

4. **Choix technique :** Dans quel cas préféreriez-vous `SelectMany()` à `Zip()` ?
