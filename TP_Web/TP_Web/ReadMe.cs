namespace TP_Web
{
    public interface ReadMe
    {
        /*
         * Créateurs:
         * Arnaud Labrecque : 1679694
         * Kevin Pugliese : 1793507
         * 
         * Exigences:
         * SDK ASP.Net Core 3.1.407 
         * Bootstrap 4.6.0
         * FontAwesome 4.7.0
         * Entity FrameWork Core 3.1.12
         * Entity FrameWork Core Design 3.1.12
         * Entity FrameWork Core SqlServer 3.1.12
         * AspNetCore Identity 2.20
         * AspNetCore Identity Entity FrameWork Core 3.1.12
         * 
         * Description:
         * Dans le cadre du cours 420-4DW-HY Développement d'application Web, nous développons une application web qui 
         * sert de squelette pour une compagnie de location de voitures. Dans cette application, un commis peut ajouter une voiture, louer une voiture,
         * créer un client, effectuer un retour ainsi que ouvrir et fermer un dossier d'accident. Pour le gérant, il a peut faire tous ce qu'un commis peut faire
         * et en plus peut créer des succursales et ajouter des utilisateurs. Le projet est migré sur une base de donnée Code First, implémentant le contexte AutoLoco et ayant
         * pour tables Voitures, Clients, Locations, DossierAccidents  et Surccursale. L'application se sert aussi de l'API de Microsoft Identity afin de connecter et valider les Utilisateurs.
         * 
         * Status du projet est terminé pour les TPs et en cours pour les versions futures.
         * 
         * Cette application est remis en format compressé .zip. Il faut le décompresser et ouvrir la solution afin de voir 
         * et tester le code. Touche F5 pour partir en mode debug une fois la solution ouverte.
         * Il est recommender pour les phases de tests, de faire ces commandes-ci dans votre PowerShell Developper afin de migrer les bases de données sur votre machine :
         * 
         *      dotnet ef migrations Initiale --project TP_Web --context ContexteAutoLoco
         *      dotnet ef database update --project TP_Web --context ContexteAutoLoco
         *      dotnet ef migrations Initiale --project TP_Web --context ContexteIdentité
         *      dotnet ef database update --project TP_Web --context ContexteIdentité
         * 
         * Dans le cas où il y avait une base de donnée qui empêchait celles du haut de bien fonctionner, je recommende de détruire le dossier migration et faire 
         * la commande ci-bas afin de pouvoir bien refaire les commandes juste haut-dessus.
         * 
         *      dotnet ef database drop --project 'nom du projet' --context 'nom du contexte'
         * 
         * Usagers de base pour l'application :
         * Gérant: AdminI - InimdA23.
         * Commis : CommisI - SimmoC23.
         * Utilisateur : UtilisateurI - RuetasilitU23.
         * 
         */
    }
}
