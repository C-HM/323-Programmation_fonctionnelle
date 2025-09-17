# Exercice: RandoReduce

Voir un tracé de randonnée sur une carte, c'est un bon début, mais un randonneur aime aussi savoir quel est le dénivelé ainsi que la longueur du tracé.

## Réduction

1. Calculer la longueur du tracé, son dénivelé positif et négatif, affichez ces valeurs dans un coin de la fenêtre.  
   Indices:
   - Utilisez `.Skip()` et `.Zip()` pour pouvoir faire un calcul avec deux points consécutifs de votre liste
   - La méthode `GetDistanceFrom` de la classe `GpxPoint` fait tout les calculs trigonométriques pour vous 😉
2. Ajouter un bouton pour réduire le nombre de points: on ne garde qu'un point sur cinq.  
   Indice:
   - Utilisez une transformation pour numéroter les points, il ne vous reste plus qu'à filtrer avec `% 5 == 0`
3. Ajouter un autre bouton pour une réduction plus intelligente: au lieu de ne garder que un point tout les 5 points (ce qui peut représenter 12m comme 100m selon le tracé), on ne garde que un point tous les 100m.  
   Indices:
   - Commencer par une transformation qui ajoute à chaque point la distance qui le sépare du début de la rando.
   - Diviser cette distance par 100
   - Grouper par cette valeur
   - Ne garder que le premier point de chaque groupe
