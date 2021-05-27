namespace AtomicSeller.Helpers
{
    public abstract class ClaimConsts
    {
        public const string IsSiteDna = "IsSiteDna";
        public const string Id = "Id";
        public const string Area = "Area";
        public const string NumCaisse = "NumCaisse";
    }

    public abstract class SessionConsts
    {
        public const string DemandeLogin = "DemandeLoginViewModel";
        public const string SaisieDeclaration = "SaisieDeclarationViewModel";
        public const string DnaId = "DnaId";
        public const string SaisieConges = "SaisieCongesViewModel";
        public const string PremiereConnexion = "PremiereConnexionViewModel";
        public const string JaiOublieMonMotDePasse = "JAiOublieMonMotDePasseViewModel";
        public const string NombreEchecsConnexion = "NombreEchecsConnexion";
        public const string BaseSpecial = "BaseSpecial";
        public const string Prevoyance = "Prevoyance";
    }

    public abstract class Consts
    {
        public const string EmailRegex =
            @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$";
    }
}
