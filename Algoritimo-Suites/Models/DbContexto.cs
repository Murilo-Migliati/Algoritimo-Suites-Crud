using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace Algoritimo_Suites.Models
{
    public class DbContexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Reserva> Reservas  { get; set; }


        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { 
        
        
        }
    }
}
