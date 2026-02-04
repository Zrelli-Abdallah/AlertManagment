using Models.Enums.RoleUtilisateur;

public class User
{
    public long Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public string MotDePasseHash { get; set; }  // BCrypt hashed
    public RoleUtilisateur Role { get; set; }
    public bool Actif { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateModification { get; set; }
}