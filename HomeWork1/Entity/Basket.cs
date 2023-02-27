using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1.Entity
{
    public class Basket : IEntity
    {
        public virtual int ID { get; set; }
        public virtual int GoodsId { get; set; }
        public virtual int UserId { get; set; }

    }
}
