namespace Models.Enums.Criticite
{
    /// <summary>
    /// Niveau de criticité d'une alerte
    /// </summary>
    public enum Criticite
    {
        CRITIQUE,   // Action immédiate requise
        HAUTE,      // Action rapide nécessaire
        MOYENNE,    // Attention nécessaire
        BASSE,      // Peut attendre
        INFO        // Information uniquement
    }
}