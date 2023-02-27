﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1.Entity
{
    public class Goods : IEntity
    {
        public virtual int ID { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
