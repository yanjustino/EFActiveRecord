using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using d2d.Models.repositorios;
using EFActiveRecord;

namespace d2d.Models
{
    [Table("Clientes")]
    public class Cliente : ActiveRecord<Cliente>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Cobranca> Cobrancas { get; set; }

        public Cliente() : base(new DataContext()) { }

        protected override void Binding()
        {
            Attach(this.Endereco);
        }
    }
}