using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBridge.Models
{
    [Table("clientes")]
    public class ClienteNovo
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("nome_completo")]
        public string NomeCompleto { get; set; } = string.Empty;

        [MaxLength(20)]
        [Column("telefone")]
        public string? Telefone { get; set; }

        [MaxLength(9)]
        [Column("cep")]
        public string? CEP { get; set; }

        [MaxLength(200)]
        [Column("endereco")]
        public string? Endereco { get; set; }

        [MaxLength(100)]
        [Column("cidade")]
        public string? Cidade { get; set; }

        [MaxLength(2)]
        public string? Estado { get; set; }

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("data_alteracao")]
        public DateTime DataAlteracao { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }
    }
}