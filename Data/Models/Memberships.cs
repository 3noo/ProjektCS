using ProjecktC.Data.Base;


namespace ProjecktC.Data.Models;

public class Memberships:ModelBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    
    public bool Status { get; set; }
    
}