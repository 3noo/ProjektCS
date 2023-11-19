using ProjecktC.Data.Base;

namespace ProjecktC.Data.Models;

public class Books:ModelBase
{
    public string Title { get; set; }
    
    public string Author { get; set; }
    
    public string Genre { get; set; }
    
}