using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerreteAPI.Domain
{
    //campo común para todas las clases de las entidades que se enviarán como migration
    public abstract class Base
    {
        public Guid Id { get; set; }
        public string FriendlyId => Id.ToString().Split('.')[0];

        public Base()
        {
            Id = Guid.NewGuid();
        }
    }
}
