﻿using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface ILichSuTichDiemRepos
    {
        bool Add(LstichDiem obj);
        bool Update(LstichDiem obj);
        bool Delete(LstichDiem obj);
        LstichDiem GetById(Guid id);
        List<LstichDiem> GetAll();
    }
}
