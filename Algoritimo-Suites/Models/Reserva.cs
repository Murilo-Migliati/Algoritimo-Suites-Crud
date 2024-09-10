using System.ComponentModel.DataAnnotations;

namespace Algoritimo_Suites.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        [Display(Name = "Número do Quarto")]
        public int NumQuarto { get; set; }
        [Display(Name = "Datas Reservadas")]
        public List<DateTime> DatasReservadas { get; set; }
        [Display(Name = "Preço")]
        public double Preco { get; set; }
        [Display(Name = "Id do Cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Id do Funcionario")]
        public int FuncionarioId { get; set; }
        [Display(Name = "Id da Filial")]
        public int FilialId { get; set; }
        [Display(Name = "Cliente")]
        public Cliente Cliente { get; set; }
        [Display(Name = "Funcionario")]
        public Funcionario Funcionario { get; set; }
        [Display(Name = "Filial")]
        public Filial Filial { get; set; }
    }
}
