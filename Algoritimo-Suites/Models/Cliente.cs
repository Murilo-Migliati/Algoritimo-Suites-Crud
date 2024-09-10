using System.ComponentModel.DataAnnotations;

namespace Algoritimo_Suites.Models
{
    public class Cliente
    {
        [Display(Name = "Id do Cliente")]
        public int Id { get; set; }
        [Display(Name = "Nome do Cliente")]
        public string Name { get; set; } 

    }
}
