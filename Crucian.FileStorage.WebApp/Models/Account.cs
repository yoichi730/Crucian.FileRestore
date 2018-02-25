using Crucian.FileStorage.CORE.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Crucian.FileStorage.WebApp.Models
{
    public class Account : IUsers
    {
        [Display(Name = "День рожденья")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ошибка")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Идентификатор")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ошибка")]
        public double Id { get; set; }

        [Display(Name = "Пользователь")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "такой пользователь не найден")]
        public string Login { get; set; }

        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ошибка")]
        public string Name { get; set; }

        [Display(Name = "Пароль")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "* обязательно заполните")]
        public string Password { get; set; }

        [Display(Name = "Роль")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ошибка")]
        public int Role { get; set; }

        [Display(Name = "Статус")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ошибка")]
        public int Status { get; set; }
    }
}