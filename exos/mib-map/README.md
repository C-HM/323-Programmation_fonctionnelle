# Le retour du marché
À partir des données de [l’exercice marché](../marché/), réaliser les opérations suivantes:

> Vous êtes libre d’utiliser la forme que vous voulez pour les données mais le but est d’aller vite... Personnellement, je suis parti de
```csharp
List<Product> products = new List<Product>
{
    new Product { Location = 1, Producer = "Bornand", ProductName = "Pommes", Quantity = 20,Unit = "kg", PricePerUnit = 5.50 },
    new Product { Location = 1, Producer = "Bornand", ProductName = "Poires", Quantity = 16,Unit = "kg", PricePerUnit = 5.50 },
    new Product { Location = 1, Producer = "Bornand", ProductName = "Pastèques", Quantity = 14,Unit = "pièce", PricePerUnit = 5.50 },
    new Product { Location = 1, Producer = "Bornand", ProductName = "Melons", Quantity = 5,Unit = "kg", PricePerUnit = 5.50 },
    new Product { Location = 2, Producer = "Dumont", ProductName = "Noix", Quantity = 20,Unit = "sac", PricePerUnit = 5.50 },
    new Product { Location = 2, Producer = "Dumont", ProductName = "Raisin", Quantity = 6,Unit = "kg", PricePerUnit = 5.50 },
    new Product { Location = 2, Producer = "Dumont", ProductName = "Pruneaux", Quantity = 13,Unit = "kg", PricePerUnit = 5.50 },
    new Product { Location = 2, Producer = "Dumont", ProductName = "Myrtilles", Quantity = 12,Unit = "kg", PricePerUnit = 5.50 },

    //...
}
```
## Échauffement : transformation "simples"

### 1. Chiffre d’affaire international anonyme
En [transformant](../../supports/source/03a-Map.md#je-ne-veux-pas-transformer-je-veux-juste-sélectionner) la liste initiale en une liste contenant:

- Les 3 premières lettres du producteur suivies de "..." suivis de la dernière lettre du nom (Dumont --> Dum...t) [pseudo-anonymisation]
- Le nom de l’aliment en anglais [dictionnaire disponible ici](./i18n.cs)
- Le chiffre d’affaire maximum possible de la journée avec cet aliment (CA = Quantity * PricePerUnit)

#### Livrable 1
Afficher le résultat:

| Seller  | Product | CA  |
| :------ | :------ | :-- |
| Dum...t | Nuts    | 110 |
|         |         |     |

#### Livrable 2
Exporter le résultat dans un fichier CSV:

```csv
Seller,Product,CA
Dum...t,Nuts,110
```

## Dashboard

### Calcul
Certaines valeurs pourraient faciliter le pilotage du marché.

Transformer la liste pour obtenir :
- *Anonymisation renforcée* : Premier caractère + nombre de caractères + dernier caractère (ex: "Dumont" → "D5t")
- *Catégorisation automatique* : Classer chaque produit selon sa quantité
  - "Stock faible" (< 10)
  - "Stock normal" (10-15) 
  - "Stock élevé" (> 15)
- *Valeur unitaire ajustée* : Prix majoré de 15% si stock faible, 5% si normal, prix normal si élevé
- *Indicateur de rentabilité* : "Premium" si CA > 100, "Standard" sinon

### Export
Pour une meilleure interopérabilité, exporter maintenant ces résultats au format json:

``` json
[
	{
		"producer":"",
		...
	}...
	
]
```

## Mesures de performances

Le dashboard sera probablement vendu à des millions d’exemplaires, il faut peut-être l’optimiser.

Pour en avoir le coeur net, il faut comparer les différentes options possibles (lambda, méthodes, ...). Voici un squelette pour calculer des performances:

``` csharp
using System.Diagnostics;

static (long time, long memory) MesurePerf(Action action, int iterations = 1000)
{
    // Forcer le garbage collection avant mesure
    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();

    var memoryBefore = GC.GetTotalMemory(false);
    var stopwatch = Stopwatch.StartNew();

    for (int i = 0; i < iterations; i++)
    {
        action();
    }

    stopwatch.Stop();
    var memoryAfter = GC.GetTotalMemory(false);

    return (stopwatch.ElapsedMilliseconds, memoireAfter - memoireBefore);
}
```

Mesurer et comparer les performances de différentes approche :
- Select simple
- Select avec méthodes externes
- Select avec expressions lambda
- Select avec création d'objets anonymes vs classes typées
- ...

Synthètiser les résultats dans un fichier .md avec les recommandations.
