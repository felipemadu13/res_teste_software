using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity
{
    public class ItemCompra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        public long Quantidade { get; set; }

        public ItemCompra() {}

        public ItemCompra(long id, Produto produto, long quantidade)
        {
            Id = id;
            Produto = produto;
            Quantidade = quantidade;
        }
    }
}
