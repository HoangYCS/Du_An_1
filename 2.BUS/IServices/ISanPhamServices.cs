﻿using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface ISanPhamServices
    {
        string Add(SanPhamViews obj);
        string Update(SanPhamViews obj);
        string Delete(SanPhamViews obj);
        List<SanPhamViews> GetAll();
    }
}
