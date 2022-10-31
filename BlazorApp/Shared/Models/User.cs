using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Shared.Models
{
    public class User
    {
        public int Userid { get; set; }

        [Required(ErrorMessage = "Имя не должно быть пустым")]
        [RegularExpression(@"^([а-яА-ЯёЁ\s\-]|[a-zA-Z\s\-])+$",
            ErrorMessage = @"Имя пользователя может содержать только буквы, пробел и дефис")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Фамилия не должна быть пустой")]
        [RegularExpression(@"^([а-яА-ЯёЁ\s\-]|[a-zA-Z\s\-])+$",
            ErrorMessage = @"Фамилия пользователя может содержать только буквы, пробел и дефис")]
        public string LastName { get; set; } = "";

        public string Patronymic { get; set; } = string.Empty;

        [Required(ErrorMessage = "Доменное имя не должно быть пустым")]
        [RegularExpression(@"^[\w]+(\.?\-?[\w]+)*\\[\w]+(\.?\-?[\w]+)*\.?\-?[^\d\W]+$", ErrorMessage = @"Доменное имя должно быть в формате Домен\Логин")]
        public string LoginActiveDirectory { get; set; } = string.Empty;

        public int IsActive { get; set; }
    }
}