namespace Models.Enums.StatutAlerte
{
    /// <summary>
    /// Statut d'une alerte dans son cycle de vie
    /// </summary>
    public enum StatutAlerte
    {
        NOUVELLE,           // Alerte créée
        NOTIFIEE,          // Notification envoyée
        EN_COURS,          // Prise en charge Niveau 0
        ESCALADE_N1,       // Escaladée vers Niveau 1
        EN_COURS_N1,       // Prise en charge Niveau 1
        ESCALADE_N2,       // Escaladée vers Niveau 2
        EN_COURS_N2,       // Prise en charge Niveau 2
        RESOLUE,           // Alerte résolue
        FERMEE             // Alerte fermée
    }
}