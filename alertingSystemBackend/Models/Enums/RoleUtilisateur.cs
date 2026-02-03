namespace Models.Enums.RoleUtilisateur
{
    /// <summary>
    /// Rôles utilisateur dans le système hiérarchique
    /// </summary>
    public enum RoleUtilisateur
    {
        MEMBRE_UNITE,           // Membre d'unité
        CHEF_UNITE,             // Chef d'unité (Niveau 0)
        DIRECTEUR_UNITES,       // Directeur d'unités (Niveau 1)
        DIRECTEUR_GENERAL,      // Directeur général (Niveau 2)
        ADMINISTRATEUR          // Administrateur système
    }
}