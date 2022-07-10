# Changelog
**Tous les changements notables apportés à ce projet seront documentés dans ce fichier.**

*Le format est basé sur [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),*
*et ce projet adhère à [Semantic Versioning](https://semver.org/spec/v2.0.0.html).*

# [Non publié]

### A ajouter
- Ajout d'un menu pour sélectionner son vaisseau.
- Ajout d'un tableau de score, et possibilité d'inscrire, supprimer, remplacer un score.

### A corriger
- Le scale du vaisseau (modèle A) est incorrect. [100 → 1]
- Quand le joueur retourne à l'écran titre après au moins une partie, le bouton Mute/Unmute n'est plus assigné.

# [Publié]

## [0.1.12] - 2022-07-10

### Ajouté
- Ajout d'objets de références pour le projet.

### Modifié
- Changement du nom de la compagnie dans les paramètres du projet Unity. *[Edit > Project Settings > Player]*
- Changement de l'espace de couleur. [Gamme → Linear]
- Changement des paramètres de résolution et de présentation de l'application :
  - Le jeu ne sera plus en arrière-plan une fois un retour au bureau opéré.
  - Une seule instance de l'application pourra être lancée.
  - Le 16:9 et 16:10 sont les seuls AR supportés.
  - Modification de l'environnemnet, le curseur est maintenant locker au centre de l'application et celui-ci est caché par défaut.
  - Le taux de rafraichissement est par défaut à 60 IPS.

### Supprimé
- Support Mac Retina retiré.


## [0.1.0] - 2022-07-09

### Ajouté
- Ajout des déplacements du joueur (horizontaux et verticaux).
- Ajout du premier vaisseau (modèle A).
- Ajout d'une musique d'ambiance.
- Ajout du Spawner d'objet.
- Ajout des animations des déplacements horizontaux du joueur.
- Ajout d'un score de fin de partie. (Calculé en fonction du temps passé en vie dans la partie (t*5 = score)).
- Ajout d'un menu principal.
- Ajout de la possibilité de couper le son du jeu.

<!--
Cette partie du CHANGELOG n'est pas affichée par défaut.

Comment mettre à jour le CHANGELOG ?
Ajouter vos changements dans les versions disponibles ou alors créer une nouvelle version depuis le modèle à copier ci-dessous.

Modèle [1.0.0] - 2022-07-09
****************************************************************
## [major.minor.patch] - <(y-m-d)>

### Ajouté
- Ajouté pour les nouvelles fonctionnalités.


### Modifié
- Modifié pour les changements aux fonctionnalités préexistantes.


### Déprécié
- Déprécié pour les fonctionnalités qui seront bientôt supprimées.


### Supprimé
- Supprimé pour les fonctionnalités désormais supprimées.


### Corrigé
- Corrigé pour les corrections de bugs.


### Sécurité
- Sécurité en cas de vulnérabilités.


****************************************************************
-->