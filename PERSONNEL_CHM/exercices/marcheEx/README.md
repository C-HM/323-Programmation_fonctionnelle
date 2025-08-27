# Exercice: La place du marché

Cet exercice sert tout d'abord à reprendre contact avec l'environnement de développement et le langage C#.
Il va ensuite  vous emmener faire vos premiers pas dans LinQ en exerçant la syntaxe requête.

Commencez par faire une copie du dossier `exo\marché` complet dans votre espace personnel. Ouvrez ensuite `place du marché.xlsx`.

Ce classeur contient deux onglets
1. La disposition des divers stands de la place du marché
2. La liste de tous les produits qui sont mis en vente sur cette place.

## Étape 1

Utilisez les connaissances acquises l'année passée en programmation pour créer un programme en mode console qui donne les réponses aux questions suivantes :

1. Combien y a-t-il de vendeurs de pêche dans ce marché ?
2. Quel producteur a le plus de pastèques à vendre ? Où est-il ? Combien en a-t-il ?

### DoD (Definition Of Done)

1. Votre programme affiche très exactement ceci
    ```
    Il y a 5 vendeurs de pêches
    C'est Bovay qui a le plus de pastèques (stand 9, 20 pièces)
    ```
    (bien entendu, il s'agit de valeurs calculées et non pas hard codées)
2. Votre code est commit/push dans votre repo

Lorsque vous avez terminé, comparez votre stratégie avec celle de l'un ou l'autre de vos camarades.
Quelle(s) technologie(s) avez-vous vu précédemment vous permettrait de répondre simplement à ce type de question ?

### Débrief 1

Mise en commun et comparaison des stratégies choisies par les uns ou les autres.
Rappel de divers trucs et astuces qu'on a oublié durant les vacances (Ctrl-A-K-F)

## Étape 2 (après découverte de la [cheatsheet](../../supports/linq-cheatsheet.pdf))

Refactorisez votre programme avec LinQ

### DoD

1. Votre programme donne le même résultat
2. Votre code est commit/push

S'il vous reste du temps, explorez les diverses possibilités offerte par LinQ. Inventez de nouvelles questions et trouvez la manière d'y répondre avec cette syntaxe élégante.

### Débrief 2

- Avec Git, comparez votre code avant et après la refactorisation.
- Dette technique : définition et manière de la gérer. (`// TODO`)
- Nommage du commit
