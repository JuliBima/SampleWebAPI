﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Domain
{
    public class Element
    {
        public int ElementId { get; set; }
        public string Name { get; set; }
        public List<Sword> Swords { get; set; } = new List<Sword>();

    }
}
