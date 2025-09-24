# Exercice: Rando

_(Copiez ce dossier dans votre espace personnel **sans** `RandoSol.zip` et faite un commit de début)_

Dans cet exercice, vous allez manipuler des tracés de parcours de randonnée sous format GPX.

plusieurs fichiers vous sont fournis, certains ont été générés par le site [SuisseMobile](https://schweizmobil.ch/fr/ete).

Commencez avec `gemmikandersteg.gpx`.

## Lecture 

Trouvez un moyen de lire un [fichier `.gpx`](./gpx/) pour le stocker dans une liste d'objets `Trackpoint` dont voici la classe dans son expression la plus simple possible:

```csharp
    class Trackpoint
    {
        private double _latitude;
        private double _longitude;
        private double _elevation;
    }
```

Si vous ne trouvez pas la lib de vos rêves, vous pouvez toujours vous rabattre sur celle-ci:
<details>
<summary>Cliquer ici pour voir la suggestion</summary>

[C# Gpx Reader/Writer](http://dlg.krakow.pl/gpx/?i=1)
</details>

Servez-vous du debugger pour vérifier que votre programme lit correctement tous les points.

_(commit)_

## Transformation

Vous allez maintenant devoir représenter graphiquement ce tracé.
Commencez par ouvrir et lancer `RandoBase.zip`, qui vous montre comment tracer des lignes.

Vous constaterez que le traçage utilise la classe `Point`.

Transformez votre `List<Trackpoint>` en `List<Point>` de manière judicieuse et affichez le tracé.

_(commit)_

Transformez maintenant votre `List<Trackpoint>` en une liste de tuples (ou d'objets anonymes) dans laquelle une couleur est associée à l'altitude du point.

Calculez la centaine de l'altitude (i.e: 1734m => 17) et servez-vous de ce tableau:

```csharp
Color[] gradient = new Color[]
{
    Color.FromArgb(255, 144, 238, 144), // Vert clair
    Color.FromArgb(255, 162, 216, 128),
    Color.FromArgb(255, 180, 194, 112),
    Color.FromArgb(255, 198, 172, 96),
    Color.FromArgb(255, 216, 150, 80),
    Color.FromArgb(255, 234, 128, 64),
    Color.FromArgb(255, 244, 106, 48),
    Color.FromArgb(255, 248,  84, 36),
    Color.FromArgb(255, 252,  62, 24),
    Color.FromArgb(255, 254,  48, 18),
    Color.FromArgb(255, 255,  32, 12),
    Color.FromArgb(255, 255,  16,  6),
    Color.FromArgb(255, 255,   0,  0)  // Rouge vif
};
```

Dessinez maintenant le tracé en couleur!

_(commit)_

## Ecriture

Avant d'aller plus loin et de manipuler plusieurs traces, mettez en place le code nécessaire pour sauver les modifications.

Créez une méthode qui permet de sauvegardez votre `List<Trackpoint>` dans un fichier en format `.gpx`, le fichier doit être lisible dans [GPX Studio](https://gpx.studio/app#11.66/46.4303/7.6373).

## Concaténer

Le défi est maintenant de lire deux fichiers et les fusionner en un seul tracé. Attention à ne pas faire n'importe quoi: on refuse de fusionner deux fichiers si le point d'arrivée d'un fichier est trop loin du point de départ de l'autre ou vice versa.
