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
    public class LichSuTichDiemServices : ILichSuTichDiemServices
    {
        ILichSuTichDiemRepos _iLichSuTichDiemRepos;
        ITichDiemRepos _iTichDiemRepos;
        ICtTichDiemRepos _iCtTichDiemRepos;
        IHoaDonRepos _iHoaDonRepos;
        IKhachHangRepos _iKhachHangRepos;
        INhanVienRepos _iNhanVienRepos;
        public LichSuTichDiemServices()
        {
            _iLichSuTichDiemRepos = new LichSuTichDiemRepos();
            _iTichDiemRepos = new TichDiemRepos();
            _iCtTichDiemRepos = new CtTichDiemRepos();
            _iHoaDonRepos = new HoaDonRepos();
            _iNhanVienRepos = new NhanVienRepos();
            _iKhachHangRepos = new KhachHangRepos();
        }
        public string Add(LichSuTichDiemView obj)
        {
            try
            {
                var x = new LstichDiem()
                {
                    Id = obj.Id,
                    IdCttichDiem = obj.IdCttichDiem,
                    IdHoaDon = obj.IdHoaDon,
                    IdTichDiem = obj.IdTichDiem,
                    SoDiemDung = obj.SoDiemDung,
                    NgayTichDiem = obj.NgayTichDiem,
                    TrangThai = obj.TrangThai
                };
                if (_iLichSuTichDiemRepos.Add(x)) return "Thành Công";
                return "Không Thành Công";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public string Delete(LichSuTichDiemView obj)
        {
            try
            {
                var x = new LstichDiem()
                {
                    Id = obj.Id
                };
                if (_iLichSuTichDiemRepos.Delete(x)) return "Thành Công";
                return "Không Thành Công";
            }
            catch (Exception e)
            {

                return e.Message.ToString();
            }
        }

        public List<LichSuTichDiemView> GetAll()
        {
            var lst = (from lstd in _iLichSuTichDiemRepos.GetAll()
                       join td in _iTichDiemRepos.GetAll() on lstd.IdTichDiem equals td.Id
                       join hd in _iHoaDonRepos.GetAll() on lstd.IdHoaDon equals hd.Id
                       //join c in (from hd in _iHoaDonRepos.GetAll()
                       //           join kh in _iKhachHangRepos.GetAll() on hd.Id equals kh.Id
                       //           select new HoaDonViews()
                       //           {
                       //               Id = hd.Id,
                       //               TenKh = kh.Ten,
                       //               MaHD = hd.Ma,
                       //               TrangThai = hd.TrangThai
                       //           }).ToList() on lstd.IdHoaDon equals c.Id
                       select new LichSuTichDiemView()
                       {
                           Id = lstd.Id,
                           IdHoaDon = hd.Id,
                           //TenKH = _iKhachHangRepos.GetAll().Find(c => c.Id == hd.IdKh).Ten,
                           //MaNV = hd.m,
                           MaHD = hd.Ma,
                           SoDiemDung = lstd.SoDiemDung,
                           NgayTichDiem = lstd.NgayTichDiem,
                           TrangThai = lstd.TrangThai
                       }).OrderByDescending(c => c.MaHD).OrderByDescending(c=>c.MaHD.Length).ToList();
            return lst;
        }

        public LichSuTichDiemView GetByID(Guid id)
        {
            var a = _iLichSuTichDiemRepos.GetById(id);
            var x = new LichSuTichDiemView()
            {
                Id = a.Id,
                SoDiemDung = a.SoDiemDung,
                NgayTichDiem = a.NgayTichDiem,
                TrangThai = a.TrangThai
            };
            return x;
        }

        //public List<LichSuTichDiemView> Search(string obj)
        //{
        //    var lst = (from a in _iLichSuTichDiemRepos.GetLstichDiems()
        //               select new LichSuTichDiemView()
        //               {
        //                   Id = a.Id,
        //                   HeSoTich = a.HeSoTich,
        //                   TrangThai = a.TrangThai
        //               }).ToList();
        //    return lst.Where(c => c.Ma.ToLower().Contains(obj.ToLower()) || c.Ten.ToLower().Contains(obj.ToLower())).OrderBy(c => c.Ma).ToList();
        //}

        public string Update(LichSuTichDiemView obj)
        {
            try
            {
                var x = new LstichDiem()
                {
                    Id = obj.Id,
                    IdHoaDon = obj.IdHoaDon,
                    IdCttichDiem = obj.IdCttichDiem,
                    IdTichDiem = obj.IdTichDiem,
                    SoDiemDung = obj.SoDiemDung,
                    NgayTichDiem = obj.NgayTichDiem,
                    TrangThai = obj.TrangThai
                };
                if (_iLichSuTichDiemRepos.Update(x)) return "Thành Công";
                return "Không Thành Công";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
