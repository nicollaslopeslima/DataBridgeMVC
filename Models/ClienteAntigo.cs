using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBridge.Models
{
    [Table("Clientes")]
    public class ClienteAntigo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string NomeCompleto { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Telefone { get; set; }

        [MaxLength(9)]
        public string? CEP { get; set; }

        [MaxLength(200)]
        public string? Endereco { get; set; }

        [MaxLength(100)]
        public string? Cidade { get; set; }

        [MaxLength(2)]
        public string? Estado { get; set; }

        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
