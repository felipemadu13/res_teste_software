
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerce.Domain.Entity;

namespace Ecommerce.Entity
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public int Peso { get; set; }

        [Required]
        public TipoProduto Tipo { get; set; }

        public Produto() {}

        public Produto(long id, string nome, string descricao, decimal preco, int peso, TipoProduto tipo)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Peso = peso;
            Tipo = tipo;
        }
    }
}
