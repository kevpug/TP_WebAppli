namespace TP01_Web.Models
{
    public sealed class Utilisateur : ReadMe
    {
        public enum TypeUtilisateur {Administrateur, Gérant, Commis }

        public string NomUtilisateur { get; set; }

        public string MotDePasse { get; set; }
        public TypeUtilisateur Rôle { get; set; }
    }
}
