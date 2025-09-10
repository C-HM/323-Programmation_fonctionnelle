# Hardware

Faciliter la prise de décision pour l’achat d’un ordinateur en proposant différentes options d’affichage...

## Selon la liste `computerHardware` ci-dessous

```csharp
List<ComputerHardware> computerHardware = new List<ComputerHardware>() {
    new ComputerHardware() { Name = "Intel Core i7-9700K", Type = "CPU", Price = 400, ClockSpeed = 3.6, Cores = 8, Brand = "Intel" },
    new ComputerHardware() { Name = "AMD Ryzen 9 5950X", Type = "CPU", Price = 700, ClockSpeed = 3.4, Cores = 16, Brand = "AMD" },
    new ComputerHardware() { Name = "NVIDIA GeForce RTX 3080", Type = "GPU", Price = 700, ClockSpeed = 1.7, Cores = 8704, Brand = "NVIDIA" },
    new ComputerHardware() { Name = "AMD Radeon RX 6800 XT", Type = "GPU", Price = 650, ClockSpeed = 2.0, Cores = 72, Brand = "AMD" },
    new ComputerHardware() { Name = "Intel Core i5-10400", Type = "CPU", Price = 200, ClockSpeed = 2.9, Cores = 6, Brand = "Intel" },
    new ComputerHardware() { Name = "AMD Ryzen 5 5600X", Type = "CPU", Price = 300, ClockSpeed = 3.7, Cores = 6, Brand = "AMD" },
    new ComputerHardware() { Name = "NVIDIA GeForce RTX 3060 Ti", Type = "GPU", Price = 400, ClockSpeed = 1.6, Cores = 4864, Brand = "NVIDIA" },
    new ComputerHardware() { Name = "AMD Radeon RX 6700 XT", Type = "GPU", Price = 400, ClockSpeed = 2.4, Cores = 40, Brand = "AMD" },
    new ComputerHardware() { Name = "Intel Core i9-11900K", Type = "CPU", Price = 500, ClockSpeed = 3.2, Cores = 10, Brand = "Intel" },
    new ComputerHardware() { Name = "AMD Ryzen 7 5800X", Type = "CPU", Price = 350, ClockSpeed = 3.9, Cores = 8, Brand = "AMD" },
    new ComputerHardware() { Name = "NVIDIA GeForce RTX 3090", Type = "GPU", Price = 1500, ClockSpeed = 1.4, Cores = 10496, Brand = "NVIDIA" },
    new ComputerHardware() { Name = "AMD Radeon RX 6900 XT", Type = "GPU", Price = 1000, ClockSpeed = 2.0, Cores = 80, Brand = "AMD" },
    new ComputerHardware() { Name = "Intel Core i3-10100", Type = "CPU", Price = 150, ClockSpeed = 3.6, Cores = 4, Brand = "Intel" },
    new ComputerHardware() { Name = "AMD Ryzen 3 5600X", Type = "CPU", Price = 250, ClockSpeed = 3.6, Cores = 6, Brand = "AMD" },
    new ComputerHardware() { Name = "NVIDIA GeForce RTX 3070", Type = "GPU", Price = 500, ClockSpeed = 1.5, Cores = 5888, Brand = "NVIDIA" },
    new ComputerHardware() { Name = "AMD Radeon RX 6700", Type = "GPU", Price = 350, ClockSpeed = 2.3, Cores = 36, Brand = "AMD" },
    new ComputerHardware() { Name = "Intel Core i9-9900K", Type = "CPU", Price = 450, ClockSpeed = 3.2, Cores = 8, Brand = "Intel" },
    new ComputerHardware() { Name = "AMD Ryzen 7 3700X", Type = "CPU", Price = 300, ClockSpeed = 3.6, Cores = 8, Brand = "AMD" },
    new ComputerHardware() { Name = "NVIDIA GeForce RTX 3080 Ti", Type = "GPU", Price = 1200, ClockSpeed = 1.6, Cores = 5888, Brand = "NVIDIA" },
    new ComputerHardware() { Name = "AMD Radeon RX 6800", Type = "GPU", Price = 600, ClockSpeed = 1.8, Cores = 64, Brand = "AMD" }
};
```


## Filtrer

Avec un simple menu console, proposer à l’utilisateur d’afficher :

1. Les éléments n'étant pas un "central processing unit"
2. Les éléments qui dépassent un prix de X (X à saisir par l’utilisateur)
3. Les CPUs mauvais pour jouer (qui ont une horloge < 3ghz et moins que 4 coeurs).
4. Les configs "potables" : Les GPUs qui ont au moins 32 coeurs et les CPUs avec au moins 8 coeurs.
5. Les configs AMD

Ceci en utilisant intelligemment les types ‘Action’ et ‘Func<arg1,arg2,return>’

## Trier

Avant d’afficher le résultat, on demande à l’utilisateur s’il veut **trier par prix ou par vitesse d’horloge** et cela de manière **croissante ou 
décroissante**

### Contrainte
> Créer la classe `ComputerHardware` selon les données fournies et en suivant les bonnes pratiques OO

## Export CSV

Après affichage, on demande à l’utilisateur s’il veut exporter le résultat vers un fichier CSV.

### Défi
Éviter au maximum les boucles...

## Export Excel

Ajouter une option pour l’utilisateur afin qu’il puisse choisir le format de sortie et ajouter la version excel (librairie à choix)

## Mise à jour des données [Défi avancé]

Plutôt que d’utiliser une liste statique de données, créer une "moulinette" pour faire une requête http vers une source de données (par exemple digitec.ch),
convertir les données HTML vers CSV et modifier le programme initial pour qu’il charge les données depuis un CSV s’il existe dans le dossier...
