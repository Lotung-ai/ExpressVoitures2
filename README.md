# ExpressVoitures

ExpressVoitures est une application de gestion de concessionnaire automobile développée en ASP.NET Core avec Entity Framework Core et une interface utilisateur personnalisée utilisant ASP.NET Core Identity. Ce projet a pour objectif de faciliter la gestion des véhicules, des ventes et de fournir une interface sécurisée pour l'authentification et l'autorisation des utilisateurs.

## Table des matières

- [Fonctionnalités](#fonctionnalités)
- [Prérequis](#prérequis)
- [Installation](#installation)
- [Utilisation](#utilisation)
- [Architecture](#architecture)
- [Contribution](#contribution)
- [Licence](#licence)
- [Auteurs](#auteurs)

## Fonctionnalités

- Gestion des véhicules : ajout, modification, suppression et affichage des véhicules.
- Gestion des ventes : création, mise à jour et suivi des ventes.
- Authentification et autorisation des utilisateurs avec ASP.NET Core Identity.
- Interface utilisateur personnalisée pour la page de login.

## Prérequis

Avant de commencer, assurez-vous d'avoir les éléments suivants installés sur votre machine :

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) ou un autre serveur de base de données compatible
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) ou [Visual Studio Code](https://code.visualstudio.com/)

## Installation

1. Clonez le dépôt :

    ```bash
    [git clone https://github.com/votre-utilisateur/ExpressVoitures.git](https://github.com/Lotung-ai/ExpressVoitures2.git)
    cd ExpressVoitures
    ```

2. Appliquez les migrations et mettez à jour la base de données :

    ```bash
    dotnet ef database update
    ```

3. Lancez l'application :

    ```bash
    dotnet run
    ```

## Utilisation

1. Ouvrez un navigateur et accédez à `https://localhost:5001` (ou l'URL appropriée) pour accéder à l'application.
2. Inscrivez-vous ou connectez-vous avec un compte existant.
3. Utilisez le menu de navigation pour accéder aux fonctionnalités de gestion des véhicules et des ventes.

## Contribution

Les contributions sont les bienvenues ! Veuillez suivre les étapes suivantes pour contribuer :

1. Fork le dépôt
2. Créez une branche pour votre fonctionnalité (`git checkout -b fonctionnalite/amazing-feature`)
3. Commitez vos modifications (`git commit -m 'Ajout d'une fonctionnalité incroyable'`)
4. Poussez votre branche (`git push origin fonctionnalite/amazing-feature`)
5. Ouvrez une Pull Request
