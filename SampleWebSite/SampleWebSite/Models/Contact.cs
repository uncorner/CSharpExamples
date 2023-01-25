using System.ComponentModel.DataAnnotations;

namespace SampleWebSite.Models
{
    public class Contact
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }

        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Введите возраст")]
        public int Age { get; set; }

        [Display(Name = "Почта")]
        [Required(ErrorMessage = "Введите почту")]
        public string Email { get; set;}

        [Display(Name = "Сообщение")]
        [Required(ErrorMessage = "Введите сообщение")]
        [StringLength(30, ErrorMessage = "Сообщение не должно содержать более 30 символов")]
        public string Message { get; set;}

        
    }
}
