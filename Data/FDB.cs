using ProjecktC.Data.Models;

namespace ProjecktC.Data
{
    public static class FDB
    {
        public static List<Books> BooksDb = new List<Books>()
        {
            new Books()
            {
                Id = 1,
                Title = "Crime and Punishment",
                Author = "Fyodor Dostoyevsky",
                Genre = "Novel",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Books()
            {
                Id = 2,
                Title = "A Tale of Two Cities",
                Author = "Charles Dickens",
                Genre = "Histrical fiction",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Books()
            {
                Id = 3,
                Title = "The Little Prince ",
                Author = "Antoine de Saint-Exupéry",
                Genre = "Fantasy",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Books()
            {
                Id = 4,
                Title = "Harry Potter and the Philosopher's Stone",
                Author = "J. K. Rowling",
                Genre = "Fantasy",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Books()
            {
                Id = 5,
                Title = "And Then There Were None",
                Author = "Agatha Christie",
                Genre = "Mystery",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Books()
            {
                Id = 6,
                Title = "Dream of the Red Chamber ",
                Author = "Cao Xueqin",
                Genre = "Family Saga",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Books()
            {
                Id = 7,
                Title = "The Hobbit",
                Author = "J. R. R. Tolkien",
                Genre = "Fantasy",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
        };

        public static List<Books> GetAllCompanies()
        {
            return BooksDb;
        }




        public static List<Library> LibraryDb = new List<Library>()
        {
            new Library()
            {
                Id = 1,
                City = "Tirana",
                OH = "08:00",
                CH = "20:00",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Library()
            {
                Id = 2,
                City = "Fier",
                OH = "08:10",
                CH = "20:12",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Library()
            {
                Id = 3,
                City = "Moske",
                OH = "06:10",
                CH = "22:10",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Library()
            {
                Id = 4,
                City = "Barcelone",
                OH = "07:30",
                CH = "21:00",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Library()
            {
                Id = 5,
                City = "Oslo",
                OH = "04:30",
                CH = "16:00",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Library()
            {
                Id = 6,
                City = "Palase",
                OH = "10:00",
                CH = "19:00",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Library()
            {
                Id = 7,
                City = "Vlore",
                OH = "08:00",
                CH = "16:20",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },

        };

        public static List<Library> GetAllLibraryes()
        {
            return LibraryDb;
        }
        
        
        
        
        public static List<Memberships> MembershipsDb = new List<Memberships>()
        {
            new Memberships()
            {
                Id = 1,
                FirstName = "Marko",
                LastName = "Polo",
                Address = "Fier",
                Status = true,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },
            new Memberships()
            {
                Id = 2,
                FirstName = "Klei",
                LastName = "White",
                Address = "Toroto",
                Status = false,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },            new Memberships()
            {
                Id = 3,
                FirstName = "Mikel",
                LastName = "Santos",
                Address = "Houston",
                Status = true,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },            new Memberships()
            {
                Id = 4,
                FirstName = "Kleviol",
                LastName = "Lana",
                Address = "Tirane",
                Status = false,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },            new Memberships()
            {
                Id = 5,
                FirstName = "Riko",
                LastName = "Po",
                Address = "Tokio",
                Status = true,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },            new Memberships()
            {
                Id = 6,
                FirstName = "Jack",
                LastName = "Nil",
                Address = "Fort Worth",
                Status = false,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },            new Memberships()
            {
                Id = 7,
                FirstName = "Klea",
                LastName = "Tasha",
                Address = "Berat",
                Status = false,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            },

        };

        public static List<Memberships> GetAllMemberships()
        {
            return MembershipsDb;
        }
    }
}