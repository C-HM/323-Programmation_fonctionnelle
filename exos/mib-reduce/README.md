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

## Reduce

À partir du [résultat précédent](#1-chiffre-daffaire-international-anonyme), déterminer et afficher, **à l’aide [d’aggrégateurs](../../supports/source/03-MapReduce.md#accumulateur--aggrégateur--reduce)**:

0. La quantité de groseilles disponibles sur le marché
1. Le chiffre d’affaire possible **total** pour chaque marchand (tout produit confondu)
2. Le plus grand, le plus petit et la moyenne de ces chiffres d’affaire
3. Le marchand ayant le plus de noix à vendre
4. Le marchand ayant le plus d’affinités avec ses produits

### Fonction d’affinité
L’affinité est déterminée par la somme des lettres présentes chez le marchand et sa marchandise...

```csharp
int Affinity(string name, string product)
{
    return name.GroupBy(letter => letter)
        .Union(product.GroupBy(letter => letter))
        .Sum(group=>group.Count());
}
```
