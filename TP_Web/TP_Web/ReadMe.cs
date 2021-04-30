namespace TP_Web
{
    public interface ReadMe
    {
        /*
         * Créateurs
         * Arnaud Labrecque : 1679694
         * Kevin Pugliese : 1793507
         * SDK ASP.Net Core 3.1.407 
         * Bootstrap 4.6.0
         * FontAwesome 4.7.0
         * Entity FrameWork Core 3.1.12
         * Entity FrameWork Core Design 3.1.12
         * Entity FrameWork Core SqlServer 3.1.12
         * AspNetCore Identity 2.20
         * AspNetCore Identity Entity FrameWork Core 3.1.12
         * 
         * Cette application web est le squelette pour une compagnie de location de voitures. Un utilisateur se connecte
         * et selon ses permissions, peut ajouter un autre utilisateur à l'application (réservé aux gérants), ajouter une succursale ou 
         * une voiture à une succursale particulière. Le projet est migré sur une base de donnée Code First, implémentant le contexte AutoLoco et ayant
         * pour tables Voitures et Surccursale. L'application se sert aussi de l'API de Microsoft Identity afin de connecter et valider les Utilisateurs.
         * 
         * Le projet est en développement en ce moment; la vérification de connexion est basée sur une variable static booléenne 
         * et devrait changer dans le futur.
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
         * Lors de l'ouverture du programme, pour se connecter en tant que Gérant, il faut entrer le nom d'utilisateur : AdminI et le mot de passe InimdA23.
         * Pour se connecter en tant que Commis, il faut entrer le nom d'utilisateur : CommisI et le mot de passe SimmoC23.
         * Pour se connecter en tant qu'Utilisateur, il faut entrer le nom d'utilisateur : UtilisateurI et le mot de passe RuetasilitU23.
         * 
         * 
         */
    }
}
