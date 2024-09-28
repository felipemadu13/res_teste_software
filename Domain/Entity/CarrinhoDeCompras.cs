using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Entity;

namespace eCommerce.Domain.Entity
{
    public class CarrinhoDeCompras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public Cliente Cliente { get; set; }

        [Required]
        [ForeignKey("CarrinhoId")]
        public List<ItemCompra> Itens { get; set; } = new List<ItemCompra>();

        [Required]
        public DateTime Data { get; set; }

        public CarrinhoDeCompras() {}

        public CarrinhoDeCompras(long id, Cliente cliente, List<ItemCompra> itens, DateTime data)
        {
            Id = id;
            Cliente = cliente;
            Itens = itens;
            Data = data;
        }
    }
}