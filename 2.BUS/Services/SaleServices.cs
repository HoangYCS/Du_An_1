﻿using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class SaleServices : ISaleServices
    {
        private ISaleRepos _saleRepos;
        private List<SaleView> _lstSale;
        private IChiTietSaleRepos _chiTietSaleRepos;
        public SaleServices()
        {
            _saleRepos = new SaleRepos();
            _lstSale = new List<SaleView>();
            _chiTietSaleRepos = new ChiTietSaleRepos();
        }
        public string Add(SaleView sale)
        {
            if (sale == null) return "Thêm thất bại";
            Sale x = new Sale()
            {
                Id = sale.Id,
                Ma = MaTS(),
                Ten = sale.Ten,
                NgayBatDau = sale.NgayBatDau,
                NgayKetThuc = sale.NgayKetThuc,
                LoaiHinhKm = sale.LoaiHinhKm,
                MucGiam = sale.MucGiam,
                MoTa = sale.MoTa,
                TrangThai = sale.TrangThai,
            };
            if (_saleRepos.Add(x)) return "Thêm thành công";
            return "Thêm thất bại";
        }
        public string MaTS()
        {
            if (_saleRepos.GetAll().Count == 0) return "KM0001";
            return "KM000" + (_saleRepos.GetAll().Max(x => Convert.ToInt32(x.Ma.Substring(5, x.Ma.Length - 5))) + 1);
        }
        public string Delete(Guid id)
        {
            var x = _saleRepos.GetAll().FirstOrDefault(c => c.Id == id);
            if (_saleRepos.Delete(x)) return "Xóa thành công";
            return "Xóa thất bại";
        }

        public List<SaleView> GetAll()
        {
            _lstSale = (from a in _saleRepos.GetAll()
                        select new SaleView
                        {
                            Id = a.Id,
                            Ma = a.Ma,
                            Ten = a.Ten,
                            NgayBatDau = a.NgayBatDau,
                            NgayKetThuc = a.NgayKetThuc,
                            LoaiHinhKm = a.LoaiHinhKm,
                            MucGiam = a.MucGiam,
                            MoTa = a.MoTa,
                            TrangThai = a.TrangThai,
                        }).OrderByDescending(c => c.Ma).ToList();
            return _lstSale;
        }

        public string Update(SaleView sale)
        {
            var x = _saleRepos.GetAll().FirstOrDefault(c => c.Id == sale.Id);
            x.Id = sale.Id;
            x.Ma = sale.Ma;
            x.Ten = sale.Ten;
            x.NgayBatDau = sale.NgayBatDau;
            x.NgayKetThuc = sale.NgayKetThuc;
            x.LoaiHinhKm = sale.LoaiHinhKm;
            x.MucGiam = sale.MucGiam;
            x.MoTa = sale.MoTa;
            x.TrangThai = sale.TrangThai;
            if (_saleRepos.Update(x)) return "Sửa thành công";
            return "Không thành công";
        }

        public Guid GetIdByName(string name)
        {
            return GetAll().FirstOrDefault(x => x.Ten == name).Id;
        }

        public string Delete(SaleView sale)
        {
            if (sale == null) return "Xóa thất bại";
            var a = _chiTietSaleRepos.GetAll().Find(c => c.IdSale == sale.Id);
            if (a == null)
            {

                Sale sale1 = new Sale()
                {
                    Id = sale.Id,
                    Ma = sale.Ma,
                    Ten = sale.Ten,
                    NgayBatDau = sale.NgayBatDau,
                    NgayKetThuc = sale.NgayKetThuc,
                    LoaiHinhKm = sale.LoaiHinhKm,
                    MucGiam = sale.MucGiam,
                    MoTa = sale.MoTa,
                    TrangThai = sale.TrangThai,
                };
                if (_saleRepos.Delete(sale1))
                {
                    return "Thành công";
                }
                else return "Thất bại";
            }
            return "Sale đã được liên kết với một bảng khác";
        }

    }
}
