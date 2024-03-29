﻿using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public interface IElement : ICrud<Element>
    {
        Task<IEnumerable<Element>> GetByName(string name);
        Task DeleteElementinSword(int id);

        Task AddElementToExistingSword(int elemenID, int swordID);

    }
}
