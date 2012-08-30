using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using d2d.Models.repositorios;

namespace d2d.Models
{
    [Table("Clientes")]
    public class Cliente : ActiveRecord<Cliente>
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Referencia { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
    }
}