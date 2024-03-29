﻿using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public interface ISamurai : ICrud<Samurai>
    {
        Task<IEnumerable<Samurai>> GetByName(string name);
        Task<IEnumerable<Samurai>> GetSamuraiWithQuotes();

        Task<IEnumerable<Samurai>> GetSamuraiWithSwordTypeElement();

        Task<Samurai> InsertWithSword(Samurai samurai);
       
    }
}
