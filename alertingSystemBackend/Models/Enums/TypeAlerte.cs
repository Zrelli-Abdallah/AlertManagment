namespace Models.Enums.TypeAlerte
{
    /// <summary>
    /// Type d'alerte selon la source
    /// </summary>
    public enum TypeAlerte
    {
        INCIDENT,       // Incident système
        WARNING,        // Avertissement
        ERROR,          // Erreur
        PERFORMANCE,    // Problème de performance
        SECURITY,       // Alerte sécurité
        AVAILABILITY    // Disponibilité
    }
}