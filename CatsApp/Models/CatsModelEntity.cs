using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatsApp.Models
{
    [Table("CatsModelEntity")] // Zmiana nazwy tabeli na "CatsModelEntity"
    public class CatsModelEntity
    {
        [Key]
        public int Id { get; set; } // Klucz główny dla CatsModel

        // Lista wszystkich obrazów kotów pobranych z API
        public List<CatImage> AllImages { get; set; }

        // Lista obrazów kotów zapisanych w galerii użytkownika
        public List<UserGalleryImage> UserGallery { get; set; }
    }

    // Klasa reprezentująca obraz kota
    public class CatImage
    {
        public string Id { get; set; } // Identyfikator obrazu
        public string Url { get; set; } // URL obrazu
    }

    // Klasa reprezentująca obraz kota w galerii użytkownika
    public class UserGalleryImage
    {
        public int Id { get; set; } // Identyfikator rekordu w bazie danych
        public string UserId { get; set; } // Identyfikator użytkownika, który zapisał obraz w galerii
        public string CatImageId { get; set; } // Identyfikator obrazu kota
        public CatImage CatImage { get; set; } // Obiekt obrazu kota
    }
}
