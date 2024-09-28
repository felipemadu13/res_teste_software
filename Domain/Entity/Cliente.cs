using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Domain.Entity
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)] // Definindo um limite de caracteres para o nome
        public string Nome { get; set; }

        [Required]
        [MaxLength(200)] // Definindo um limite de caracteres para o endereço
        public string Endereco { get; set; }

        [Required]
        [EnumDataType(typeof(TipoCliente))] // Armazenar o enum como string no banco
        public TipoCliente Tipo { get; set; }

        public Cliente() {}

        public Cliente(long id, string nome, string endereco, TipoCliente tipo)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Tipo = tipo;
        }
    }
}