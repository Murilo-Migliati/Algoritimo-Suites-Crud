using System.ComponentModel.DataAnnotations;

namespace Algoritimo_Suites.Models
{
    public class Funcionario
    {
        [Display(Name = "Id do Funcionario")]
        public int Id { get; set; }
        [Display(Name = "Nome do Funcionario")]
        public string Name { get; set; }
    }
}
