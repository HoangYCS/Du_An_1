﻿using _1.DAL.DomainClass;
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModels;
using _3.PL.Utilities;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Ink;
using System.Data.SqlClient;
using System.Configuration;
using _1.DAL.IRepositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using _3.PL.Properties;
using System.Threading;
using System.IO;

namespace _3.PL.Views
{
    public partial class FrmChiTietSale : Form
    {
        private IChiTietSaleServices _IchiTietSaleServices;
        private IChiTietSpServices _chiTietSpServices;
        private ISaleServices _SaleServices;
        private List<ChiTietSaleView> _lstCtsle;
        private List<SaleView> lstSale;
        private List<ChiTietSpViews> _ChiTietSpViews;

        private Guid IDCtsp;
        private Guid IDsale;
        private ChiTietSpViews chiTietSpViews;

        public FrmChiTietSale()
        {
            InitializeComponent();
            _IchiTietSaleServices = new ChiTietSaleServices();
            _chiTietSpServices = new ChiTietSpServices();
            _SaleServices = new SaleServices();
            _lstCtsle = new List<ChiTietSaleView>();
            lstSale = new List<SaleView>();
            _ChiTietSpViews = new List<ChiTietSpViews>();
            tbTrangthai();
        }

        private void loadlb()
        {

            if (cbb_loaiKM.Texts == "%")
            {
                lb_mucgiam.Text = "% giảm";
            }
            if (cbb_loaiKM.Texts == "Tiền mặt")
            {
                lb_mucgiam.Text = "Số tiền giảm";
            }
        }


        private void loadKM()
        {
            dtg_show.Rows.Clear();
            dtg_show.ColumnCount = 9;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "Mã";
            dtg_show.Columns[2].Name = "Tên";
            dtg_show.Columns[3].Name = "Ngày bắt đầu";
            dtg_show.Columns[4].Name = "Ngày kết thúc";
            dtg_show.Columns[5].Name = "Loại hình KM";
            dtg_show.Columns[6].Name = "Mức giảm";
            dtg_show.Columns[7].Name = "Mô tả";
            dtg_show.Columns[8].Name = "Trạng thái";
            lstSale = _SaleServices.GetAll();
            if (tb_timkiemkm.Text != "")
            {
                lstSale = lstSale.Where(c => c.Ten.ToLower().Contains(tb_timkiemkm.Text.ToLower())).ToList();
            }
            foreach (var item in lstSale.Where(c => c.TrangThai == 0))
            {
                dtg_show.Rows.Add(item.Id, item.Ma, item.Ten, item.NgayBatDau, item.NgayKetThuc, item.LoaiHinhKm,
                    item.MucGiam, item.MoTa, item.TrangThai == 0 ? "Đang áp dụng" : item.TrangThai == 1 ? "Ngừng áp dụng" : item.TrangThai == 2 ? "Chưa áp dụng" : "Lỗi");
            }
        }
        private void loadKM1()
        {
            dtg_show.Rows.Clear();
            dtg_show.ColumnCount = 9;
            dtg_show.Columns[0].Name = "ID";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "Mã";
            dtg_show.Columns[2].Name = "Tên";
            dtg_show.Columns[3].Name = "Ngày bắt đầu";
            dtg_show.Columns[4].Name = "Ngày kết thúc";
            dtg_show.Columns[5].Name = "Loại hình KM";
            dtg_show.Columns[6].Name = "Mức giảm";
            dtg_show.Columns[7].Name = "Mô tả";
            dtg_show.Columns[8].Name = "Trạng thái";
            lstSale = _SaleServices.GetAll();
            if (tb_timkiemkm.Text != "")
            {
                lstSale = lstSale.Where(c => c.Ten.ToLower().Contains(tb_timkiemkm.Text.ToLower())).ToList();
            }
            foreach (var item in lstSale)
            {
                dtg_show.Rows.Add(item.Id, item.Ma, item.Ten, item.NgayBatDau, item.NgayKetThuc, item.LoaiHinhKm,
                    item.MucGiam, item.MoTa, item.TrangThai == 0 ? "Đang áp dụng" : item.TrangThai == 1 ? "Ngừng áp dụng" : item.TrangThai == 2 ? "Chưa áp dụng" : "Lỗi");
            }
        }
        private void loadCTsale()
        {
            List<SPSelected> selcted = new List<SPSelected>();
            foreach (var item in _chiTietSpServices.GetAll().Where(c => c.TrangThaiKhuyenMai == 0))
            {
                //dtg_sp.Rows.Add(item.Id, item.TenSP, item.TenMauSac, item.TenTeam);
                if (_IchiTietSaleServices.GetAll().FirstOrDefault(c => c.IdSale == IDsale && c.IdChiTietSp == item.Id) != null)
                {
                    SPSelected sPSelected = new SPSelected()
                    {
                        Id = item.Id.ToString(),
                        TenSanPham = item.TenSP,
                        MauSac = item.TenMauSac,
                        Team = item.TenTeam,
                        KieuSp = "Mũ thời trang",
                        Selected = true,
                    };
                    selcted.Add(sPSelected);

                }
                else
                {
                    SPSelected sPSelected = new SPSelected()
                    {
                        Id = item.Id.ToString(),
                        TenSanPham = item.TenSP,
                        MauSac = item.TenMauSac,
                        Team = item.TenTeam,
                        KieuSp = "Mũ thời trang",
                        Selected = false,
                    };
                    selcted.Add(sPSelected);
                }

            }
            dtg_sp.DataSource = selcted;

        }
        private void loadCTSP()
        {
            //dtg_sp.Rows.Clear();
            List<SPSelected> selcted = new List<SPSelected>();
            _ChiTietSpViews = _chiTietSpServices.GetAll().Where(c => c.TrangThaiKhuyenMai == 0).ToList();
            if (tb_timkiemSp.Text != "")
            {
                _ChiTietSpViews = _ChiTietSpViews.Where(c => c.TenSP.ToLower().Contains(tb_timkiemSp.Text.ToLower())
                || c.TenMauSac.ToLower().Contains(tb_timkiemSp.Text.ToLower()) || c.TenTeam.ToLower().Contains(tb_timkiemSp.Text.ToLower())).ToList();
            }
            foreach (var item in _ChiTietSpViews)
            {
                //dtg_sp.Rows.Add(item.Id, item.TenSP, item.TenMauSac, item.TenTeam);
                if (_IchiTietSaleServices.GetAll().FirstOrDefault(c => c.IdSale == IDsale && c.IdChiTietSp == item.Id) != null)
                {
                    SPSelected sPSelected = new SPSelected()
                    {
                        Id = item.Id.ToString(),
                        TenSanPham = item.TenSP,
                        MauSac = item.TenMauSac,
                        Team = item.TenTeam,
                        KieuSp = "Mũ thời trang",
                        Selected = true,
                    };
                    selcted.Add(sPSelected);

                }
                else
                {
                    SPSelected sPSelected = new SPSelected()
                    {
                        Id = item.Id.ToString(),
                        TenSanPham = item.TenSP,
                        MauSac = item.TenMauSac,
                        Team = item.TenTeam,
                        KieuSp = "Mũ thời trang",
                        Selected = false,
                    };
                    selcted.Add(sPSelected);
                }


            }

            dtg_sp.DataSource = selcted;

        }

        private void cbb_loaiKM_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            loadlb();
        }
        private int? addTrangThai()
        {
            int? a;
            //if (cbb_trangthai.Texts == "Đang áp dụng")
            //{
            //    a = 0;
            //    return a;
            //}
            //if (cbb_trangthai.Texts == "Ngừng áp dụng")
            //{
            //    a = 1;
            //    return a;
            //}
            //if (cbb_trangthai.Texts == "Chưa bắt đầu")
            //{
            //    return a = 2;
            //}
            //else return a = 0;
            if (dtp_start.Value < DateTime.Now && dtp_end.Value > DateTime.Now)
            {
                a = 0;
                return a;

            }
            if (dtp_start.Value < DateTime.Now && dtp_end.Value < DateTime.Now)
            {
                a = 1;
                return a;
            }
            if (dtp_start.Value > DateTime.Now && dtp_end.Value > DateTime.Now)
            {
                a = 2;
                return a;

            }
            else
            {
                return a = 3;
            }


        }
        private string XoaDauCach(string s)
        {

            while (s.Trim().Contains("  "))
            {
                s = s.Replace("  ", " "); // Xóa 2 dấu cách thành 1 dấu cho đến khi hết
            }
            return s;
        }
        private void bt_them_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có muốn thêm ?", "Cảnh báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (_SaleServices.GetAll().Any(c => c.Ten == tb_ten.Texts))
                {
                    MessageBox.Show("Tên bị trùng");
                }
                else if (tb_ten.Texts == "")
                {
                    MessageBox.Show("Không được bỏ trống tên");
                }
                else if (ValidateInput.hasSpecialChar(tb_ten.Text))
                {
                    MessageBox.Show("Tên không hợp lệ");
                }
                else if (cbb_loaiKM.Texts == "")
                {
                    MessageBox.Show("Vui lòng chọn hình thức giảm");
                }

                else if (ValidateInput.CheckIntInput(tb_mucgiam.Texts) == false || Convert.ToDecimal(tb_mucgiam.Texts) < 0)
                {
                    MessageBox.Show("Nhập đúng mức giảm");
                }
                else if (cbb_loaiKM.Texts == "%" && Convert.ToDecimal(tb_mucgiam.Texts) > 100)
                {
                    MessageBox.Show("Không được giảm quá 100%");
                }
                else if (dtp_end.Value < dtp_start.Value)
                {
                    MessageBox.Show("Ngày kết thúc sale không được bé hơn ngày bắt đầu");
                }
                else
                {
                    SaleView saleView = new SaleView()
                    {
                        Id = Guid.Empty,
                        Ma = tb_ma.Texts,
                        Ten = XoaDauCach(tb_ten.Texts.Trim()),
                        NgayBatDau = dtp_start.Value,
                        NgayKetThuc = dtp_end.Value,
                        LoaiHinhKm = cbb_loaiKM.Texts,
                        MucGiam = Convert.ToDecimal(tb_mucgiam.Texts),
                        MoTa = tb_mota.Texts,
                        TrangThai = addTrangThai(),
                    };
                    MessageBox.Show(_SaleServices.Add(saleView));
                    ClearForm();
                    loadKM();
                }
            }
            else
            {
                MessageBox.Show("Bạn đã hủy thêm");
            }
        }
        private void ClearForm()
        {
            tb_ten.Texts = "";
            tb_timkiemkm.Text = "";
            tb_ma.Text = "";
            tb_trangthai.Texts = "";
            dtp_end.Value = DateTime.Now;
            dtp_start.Value = DateTime.Now;
            tb_mucgiam.Texts = "";
            tb_mota.Texts = "";
            tb_mucgiam.Text = "0";
            cbb_loaiKM.Texts = "%";
            IDCtsp = Guid.Empty;
            IDsale = Guid.Empty;
        }


        private void tb_timkiemkm_TextChanged(object sender, EventArgs e)
        {
            loadKM();
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn sửa ?", "Cảnh báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (IDsale == Guid.Empty)
                {
                    MessageBox.Show("Vui lòng chọn mã sale cần sửa");
                }
                else if (_SaleServices.GetAll().FirstOrDefault(c => c.Ten == tb_ten.Texts && c.Id != IDsale) != null)
                {
                    MessageBox.Show("Tên sale được trùng");
                }
                else if (ValidateInput.hasSpecialChar(tb_ten.Text))
                {
                    MessageBox.Show("Tên không hợp lệ");
                }
                else if (tb_ten.Texts == "")
                {
                    MessageBox.Show("Không được bỏ trống tên");
                }
                else if (cbb_loaiKM.Texts == "")
                {
                    MessageBox.Show("Vui lòng chọn hình thức giảm");
                }

                else if (ValidateInput.CheckIntInput(tb_mucgiam.Texts) == false || Convert.ToDecimal(tb_mucgiam.Texts) < 0)
                {
                    MessageBox.Show("Nhập đúng mức giảm");
                }
                else if (cbb_loaiKM.Texts == "%" && Convert.ToDecimal(tb_mucgiam.Texts) > 100)
                {
                    MessageBox.Show("Không được giảm quá 100%");
                }
                else if (dtp_end.Value < dtp_start.Value)
                {
                    MessageBox.Show("Ngày kết thúc sale không được bé hơn ngày bắt đầu");
                }

                else
                {
                    SaleView saleView = new SaleView()
                    {
                        Id = IDsale,
                        Ma = tb_ma.Texts,
                        Ten = XoaDauCach(tb_ten.Texts.Trim()),
                        NgayBatDau = dtp_start.Value,
                        NgayKetThuc = dtp_end.Value,
                        LoaiHinhKm = cbb_loaiKM.Texts,
                        MucGiam = Convert.ToDecimal(tb_mucgiam.Texts),
                        MoTa = tb_mota.Texts,
                        TrangThai = addTrangThai(),
                    };
                    MessageBox.Show(_SaleServices.Update(saleView));
                    ClearForm();
                    loadKM();

                }
            }
            else
            {
                MessageBox.Show("Bạn đã hủy sửa");
            }
        }



        private void cbb_locTrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbb_locTrangthai.Text == "Tất cả")
            {
                dtg_show.Rows.Clear();
                dtg_show.ColumnCount = 9;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "Mã";
                dtg_show.Columns[2].Name = "Tên";
                dtg_show.Columns[3].Name = "Ngày bắt đầu";
                dtg_show.Columns[4].Name = "Ngày kết thúc";
                dtg_show.Columns[5].Name = "Loại hình KM";
                dtg_show.Columns[6].Name = "Mức giảm";
                dtg_show.Columns[7].Name = "Mô tả";
                dtg_show.Columns[8].Name = "Trạng thái";
                lstSale = _SaleServices.GetAll().ToList();
                foreach (var item in lstSale)
                {
                    dtg_show.Rows.Add(item.Id, item.Ma, item.Ten, item.NgayBatDau, item.NgayKetThuc, item.LoaiHinhKm,
                        item.MucGiam, item.MoTa, item.TrangThai == 0 ? "Đang áp dụng" : item.TrangThai == 1 ? "Ngừng áp dụng" : item.TrangThai == 2 ? "Chưa áp dụng" : "Lỗi");
                }
            }
            else if (cbb_locTrangthai.Text == "Đang áp dụng")
            {
                dtg_show.Rows.Clear();
                dtg_show.ColumnCount = 9;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "Mã";
                dtg_show.Columns[2].Name = "Tên";
                dtg_show.Columns[3].Name = "Ngày bắt đầu";
                dtg_show.Columns[4].Name = "Ngày kết thúc";
                dtg_show.Columns[5].Name = "Loại hình KM";
                dtg_show.Columns[6].Name = "Mức giảm";
                dtg_show.Columns[7].Name = "Mô tả";
                dtg_show.Columns[8].Name = "Trạng thái";
                lstSale = _SaleServices.GetAll().Where(c => c.TrangThai == 0).ToList();
                foreach (var item in lstSale)
                {
                    dtg_show.Rows.Add(item.Id, item.Ma, item.Ten, item.NgayBatDau, item.NgayKetThuc, item.LoaiHinhKm,
                        item.MucGiam, item.MoTa, item.TrangThai == 0 ? "Đang áp dụng" : item.TrangThai == 1 ? "Ngừng áp dụng" : item.TrangThai == 2 ? "Chưa áp dụng" : "Lỗi");
                }
            }
            else if (cbb_locTrangthai.Text == "Ngừng áp dụng")
            {

                dtg_show.Rows.Clear();
                dtg_show.ColumnCount = 9;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "Mã";
                dtg_show.Columns[2].Name = "Tên";
                dtg_show.Columns[3].Name = "Ngày bắt đầu";
                dtg_show.Columns[4].Name = "Ngày kết thúc";
                dtg_show.Columns[5].Name = "Loại hình KM";
                dtg_show.Columns[6].Name = "Mức giảm";
                dtg_show.Columns[7].Name = "Mô tả";
                dtg_show.Columns[8].Name = "Trạng thái";
                lstSale = _SaleServices.GetAll().Where(c => c.TrangThai == 1).ToList();
                foreach (var item in lstSale)
                {
                    dtg_show.Rows.Add(item.Id, item.Ma, item.Ten, item.NgayBatDau, item.NgayKetThuc, item.LoaiHinhKm,
                        item.MucGiam, item.MoTa, item.TrangThai == 0 ? "Đang áp dụng" : item.TrangThai == 1 ? "Ngừng áp dụng" : item.TrangThai == 2 ? "Chưa áp dụng" : "Lỗi");
                }
            }
            else
            {
                dtg_show.Rows.Clear();
                dtg_show.ColumnCount = 9;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "Mã";
                dtg_show.Columns[2].Name = "Tên";
                dtg_show.Columns[3].Name = "Ngày bắt đầu";
                dtg_show.Columns[4].Name = "Ngày kết thúc";
                dtg_show.Columns[5].Name = "Loại hình KM";
                dtg_show.Columns[6].Name = "Mức giảm";
                dtg_show.Columns[7].Name = "Mô tả";
                dtg_show.Columns[8].Name = "Trạng thái";
                lstSale = _SaleServices.GetAll().Where(c => c.TrangThai == 2).ToList();
                foreach (var item in lstSale)
                {
                    dtg_show.Rows.Add(item.Id, item.Ma, item.Ten, item.NgayBatDau, item.NgayKetThuc, item.LoaiHinhKm,
                        item.MucGiam, item.MoTa, item.TrangThai == 0 ? "Đang áp dụng" : item.TrangThai == 1 ? "Ngừng áp dụng" : item.TrangThai == 2 ? "Chưa áp dụng" : "Lỗi");
                }
            }
        }

        private void cbb_trangthai_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void auto()
        {
            if (cbb_locTrangthai.Text == "Tất cả")
            {
                dtg_show.Rows.Clear();
                dtg_show.ColumnCount = 9;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "Mã";
                dtg_show.Columns[2].Name = "Tên";
                dtg_show.Columns[3].Name = "Ngày bắt đầu";
                dtg_show.Columns[4].Name = "Ngày kết thúc";
                dtg_show.Columns[5].Name = "Loại hình KM";
                dtg_show.Columns[6].Name = "Mức giảm";
                dtg_show.Columns[7].Name = "Mô tả";
                dtg_show.Columns[8].Name = "Trạng thái";
                lstSale = _SaleServices.GetAll().ToList();
                foreach (var item in lstSale)
                {
                    dtg_show.Rows.Add(item.Id, item.Ma, item.Ten, item.NgayBatDau, item.NgayKetThuc, item.LoaiHinhKm,
                        item.MucGiam, item.MoTa, item.TrangThai == 0 ? "Đang áp dụng" : item.TrangThai == 1 ? "Ngừng áp dụng" : item.TrangThai == 2 ? "Chưa áp dụng" : "Lỗi");
                }
            }
            else if (cbb_locTrangthai.Text == "Đang áp dụng")
            {
                dtg_show.Rows.Clear();
                dtg_show.ColumnCount = 9;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "Mã";
                dtg_show.Columns[2].Name = "Tên";
                dtg_show.Columns[3].Name = "Ngày bắt đầu";
                dtg_show.Columns[4].Name = "Ngày kết thúc";
                dtg_show.Columns[5].Name = "Loại hình KM";
                dtg_show.Columns[6].Name = "Mức giảm";
                dtg_show.Columns[7].Name = "Mô tả";
                dtg_show.Columns[8].Name = "Trạng thái";
                lstSale = _SaleServices.GetAll().Where(c => c.TrangThai == 0).ToList();
                foreach (var item in lstSale)
                {
                    dtg_show.Rows.Add(item.Id, item.Ma, item.Ten, item.NgayBatDau, item.NgayKetThuc, item.LoaiHinhKm,
                        item.MucGiam, item.MoTa, item.TrangThai == 0 ? "Đang áp dụng" : item.TrangThai == 1 ? "Ngừng áp dụng" : item.TrangThai == 2 ? "Chưa áp dụng" : "Lỗi");
                }
            }
            else if (cbb_locTrangthai.Text == "Ngừng áp dụng")
            {

                dtg_show.Rows.Clear();
                dtg_show.ColumnCount = 9;
                dtg_show.Columns[0].Name = "ID";
                dtg_show.Columns[0].Visible = false;
                dtg_show.Columns[1].Name = "Mã";
                dtg_show.Columns[2].Name = "Tên";
                dtg_show.Columns[3].Name = "Ngày bắt đầu";
                dtg_show.Columns[4].Name = "Ngày kết thúc";
                dtg_show.Columns[5].Name = "Loại hình KM";
                dtg_show.Columns[6].Name = "Mức giảm";
                dtg_show.Columns[7].Name = "Mô tả";
                dtg_show.Columns[8].Name = "Trạng thái";
                lstSale = _SaleServices.GetAll().Where(c => c.TrangThai == 1).ToList();
                foreach (var item in lstSale)
                {
                    dtg_show.Rows.Add(item.Id, item.Ma, item.Ten, item.NgayBatDau, item.NgayKetThuc, item.LoaiHinhKm,
                        item.MucGiam, item.MoTa, item.TrangThai == 0 ? "Đang áp dụng" : item.TrangThai == 1 ? "Ngừng áp dụng" : item.TrangThai == 2 ? "Chưa áp dụng" : "Lỗi");
                }
            }
            //----        


        }
        private void dtg_show_CellClick(object sender, EventArgs e)
        {
            IDsale = (Guid)(dtg_show.CurrentRow.Cells[0].Value);
            tb_ma.Texts = dtg_show.CurrentRow.Cells[1].Value.ToString();
            tb_ten.Texts = dtg_show.CurrentRow.Cells[2].Value.ToString();
            dtp_start.Value = Convert.ToDateTime(dtg_show.CurrentRow.Cells[3].Value);
            dtp_end.Value = Convert.ToDateTime(dtg_show.CurrentRow.Cells[4].Value);
            cbb_loaiKM.Texts = dtg_show.CurrentRow.Cells[5].Value.ToString();
            tb_mucgiam.Texts = dtg_show.CurrentRow.Cells[6].Value.ToString();
            tb_mota.Texts = dtg_show.CurrentRow.Cells[7].Value.ToString();
            tb_trangthai.Texts = dtg_show.CurrentRow.Cells[8].Value.ToString();

            //loadCTsale();

        }

        private void tb_timkiemkm_TextChanged_1(object sender, EventArgs e)
        {
            loadKM();
        }




        private void tb_mucgiam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

        }

        private void tb_mucgiam__TextChanged(object sender, EventArgs e)
        {
            if (cbb_loaiKM.Texts == "%" && tb_mucgiam.Texts != "")
            {
                if (Convert.ToDecimal(tb_mucgiam.Texts) > 100)
                {
                    tb_mucgiam.Texts = "100";
                }
            }
        }

        private void dtg_sp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //IDCtsp = (Guid)(dtg_sp.CurrentRow.Cells[0].Value);
            //DataGridViewCheckBoxCell dataGridViewCheckBoxCell = (DataGridViewCheckBoxCell)dtg_sp.CurrentRow.Cells[5];

            //var sanpham = _chiTietSpServices.GetAll().FirstOrDefault(c => c.Id == (Guid)(dtg_sp.CurrentRow.Cells[0].Value));
            //if (dataGridViewCheckBoxCell.Value == ckb.TrueValue)
            //{
            //    _lstCtspAdd.Add(sanpham);
            //    MessageBox.Show("1");
            //}
            //else
            //{
            //    _lstCtspEdit.Add(sanpham);
            //    MessageBox.Show("2");

            //}
        }

        private void ck_all_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtg_sp.Rows) ((DataGridViewCheckBoxCell)row.Cells["Selected"]).Value = ck_all.Checked;
            dtg_sp.RefreshEdit();
        }




        private List<ChiTietSpViews> _lstCtspAdd = new List<ChiTietSpViews>();
        private List<ChiTietSpViews> _lstCtspEdit = new List<ChiTietSpViews>();

        private void cbb_locSp_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbb_locSp.SelectedIndex == 0)
            {
                loadCTSP();
            }
            else if (cbb_locSp.SelectedIndex == 1)
            {
                List<SPSelected> selcted = new List<SPSelected>();
                _ChiTietSpViews = _chiTietSpServices.GetAll().Where(c => c.TrangThaiKhuyenMai == 0).ToList();
                if (tb_timkiemSp.Text != "")
                {
                    _ChiTietSpViews = _ChiTietSpViews.Where(c => c.TenSP.ToLower().Contains(tb_timkiemSp.Text.ToLower())).ToList();
                }
                foreach (var x in _ChiTietSpViews)
                {
                    //dtg_sp.Rows.Add(item.Id, item.TenSP, item.TenMauSac, item.TenTeam);
                    if (_IchiTietSaleServices.GetAll().FirstOrDefault(c => c.IdSale == IDsale && c.IdChiTietSp == x.Id) == null)
                    {
                        SPSelected sPSelected = new SPSelected()
                        {
                            Id = x.Id.ToString(),
                            TenSanPham = x.TenSP,
                            MauSac = x.TenMauSac,
                            Team = x.TenTeam,
                            KieuSp = "Mũ thời trang",
                            Selected = false,
                        };
                        selcted.Add(sPSelected);

                    }

                }
                dtg_sp.DataSource = selcted;
            }
            else if (cbb_locSp.SelectedIndex == 2)
            {
                List<SPSelected> selcted = new List<SPSelected>();
                _ChiTietSpViews = _chiTietSpServices.GetAll().Where(c => c.TrangThaiKhuyenMai == 0).ToList();
                if (tb_timkiemSp.Text != "")
                {
                    _ChiTietSpViews = _ChiTietSpViews.Where(c => c.TenSP.ToLower().Contains(tb_timkiemSp.Text.ToLower())).ToList();
                }
                foreach (var x in _ChiTietSpViews)
                {
                    //dtg_sp.Rows.Add(item.Id, item.TenSP, item.TenMauSac, item.TenTeam);
                    if (_IchiTietSaleServices.GetAll().FirstOrDefault(c => c.IdSale == IDsale && c.IdChiTietSp == x.Id) != null)
                    {
                        SPSelected sPSelected = new SPSelected()
                        {
                            Id = x.Id.ToString(),
                            TenSanPham = x.TenSP,
                            MauSac = x.TenMauSac,
                            Team = x.TenTeam,
                            KieuSp = "Mũ thời trang",
                            Selected = true,
                        };
                        selcted.Add(sPSelected);

                    }

                }
                dtg_sp.DataSource = selcted;

            }




        }

        private void FrmChiTietSale_Load(object sender, EventArgs e)
        {
            tb_ma.Enabled = false;
            tb_trangthai.Enabled = false;
            cbb_loaiKM.Items.Add("%");
            cbb_loaiKM.Items.Add("Tiền mặt");

            dtp_end.Value = DateTime.Now;
            dtp_start.Value = DateTime.Now;

            cbb_locTrangthai.Items.Add("Tất cả");
            cbb_locTrangthai.Items.Add("Đang áp dụng");
            cbb_locTrangthai.Items.Add("Ngừng áp dụng");
            cbb_locTrangthai.Items.Add("Chưa bắt đầu");
            label12.Text = DateTime.Now.ToLongTimeString();
            loadKM();
            loadCTSP();


            cbb_locTrangthai.SelectedIndex = 1;
            cbb_loaiKM.SelectedIndex = 0;
            dtp_start.CustomFormat = " HH:mm:ss  dd/MM/yyyy";
            dtp_end.CustomFormat = " HH:mm:ss  dd/MM/yyyy";
            cbb_locSp.Items.Add("Tất cả");
            cbb_locSp.Items.Add("Chưa áp dụng");
            cbb_locSp.Items.Add("Đã áp dụng");
            timer1.Start();
            //loadlaiform();
        }

        private void bt_them2_Click(object sender, EventArgs e)
        {
            int d = 0;
            DialogResult result = MessageBox.Show("Bạn có muốn áp dụng thay đổi không ?", "Cảnh báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (IDsale != Guid.Empty)
                {
                    List<SPSelected> selcted = ((List<SPSelected>)dtg_sp.DataSource).Where(c => c.Selected).ToList();
                    List<ChiTietSaleView> chiTietSaleViews = _IchiTietSaleServices.GetAll().Where(c => c.IdSale == IDsale).ToList();
                    if (_SaleServices.GetAll().FirstOrDefault(c => c.Id == IDsale).NgayKetThuc < DateTime.Now)
                    {
                        MessageBox.Show("Mã sale đã hết hạn sử dụng vui lòng chọn mã khác");
                    }
                    else if (_SaleServices.GetAll().FirstOrDefault(c => c.Id == IDsale).TrangThai == 1)
                    {
                        MessageBox.Show("Mã sale đã không còn khả dụng");
                    }

                    else
                    {
                        foreach (var item in chiTietSaleViews)
                        {
                            _IchiTietSaleServices.Delete(item);
                        }

                        foreach (var item in selcted)
                        {
                            var x = _IchiTietSaleServices.GetAll().FirstOrDefault(c => c.IdChiTietSp == Guid.Parse(item.Id) && c.TrangThai == 0);
                            if (x == null)
                            {
                                ChiTietSaleView chiTietSaleView = new ChiTietSaleView()
                                {
                                    Id = Guid.NewGuid(),
                                    IdChiTietSp = Guid.Parse(item.Id),
                                    IdSale = IDsale,

                                };
                                _IchiTietSaleServices.Add(chiTietSaleView);
                            }
                            else
                            {
                                d++;
                            }
                        }
                        if (d == 0)
                        {
                            MessageBox.Show("Áp dụng thành công");
                        }
                        else
                        {
                            MessageBox.Show(d.ToString() + "  sản phẩm không được áp dụng do nó đã được giảm giá bằng 1 mã khác");
                        }
                    }
                }
                else MessageBox.Show("Chọn sale trước");
            }
            else
            {
                MessageBox.Show("Bạn đã hủy sửa");
            }


        }

        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDsale = (Guid)(dtg_show.CurrentRow.Cells[0].Value);
            tb_ma.Texts = dtg_show.CurrentRow.Cells[1].Value.ToString();
            tb_ten.Texts = dtg_show.CurrentRow.Cells[2].Value.ToString();
            dtp_start.Value = Convert.ToDateTime(dtg_show.CurrentRow.Cells[3].Value);
            dtp_end.Value = Convert.ToDateTime(dtg_show.CurrentRow.Cells[4].Value);
            cbb_loaiKM.Texts = dtg_show.CurrentRow.Cells[5].Value.ToString();
            tb_mucgiam.Texts = dtg_show.CurrentRow.Cells[6].Value.ToString();
            tb_mota.Texts = dtg_show.CurrentRow.Cells[7].Value.ToString();
            tb_trangthai.Texts = dtg_show.CurrentRow.Cells[8].Value.ToString();

            loadCTsale();

        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label12.Text = DateTime.Now.ToLongTimeString();
            var a = _SaleServices.GetAll();
            Random random = new Random();
            int one = random.Next(0, 255);
            int two = random.Next(0, 255);
            int three = random.Next(0, 255);
            int four = random.Next(0, 255);

            label4.ForeColor = Color.FromArgb(one, two, three, four);
            foreach (var item in a)
            {

                if (item.NgayKetThuc < DateTime.Now)
                {
                    var b = _IchiTietSaleServices.GetAll().Where(c => c.IdSale == item.Id);

                    if (b != null)
                    {
                        foreach (var x in b)
                        {
                            ChiTietSaleView view = new ChiTietSaleView()
                            {
                                Id = x.Id,
                                IdChiTietSp = x.IdChiTietSp,
                                IdSale = x.IdSale,
                                TrangThai = 1
                            };
                            _IchiTietSaleServices.Delete(view);
                        }

                    }

                    item.TrangThai = 1;
                    _SaleServices.Update(item);
                    //auto();
                }
                if (item.NgayBatDau > DateTime.Now)
                {
                    var b = _IchiTietSaleServices.GetAll().Where(c => c.IdSale == item.Id);
                    if (b != null)
                    {
                        foreach (var x in b)
                        {
                            ChiTietSaleView view = new ChiTietSaleView()
                            {
                                Id = x.Id,
                                IdChiTietSp = x.IdChiTietSp,
                                IdSale = x.IdSale,
                                TrangThai = 1
                            };
                            _IchiTietSaleServices.Update(view);
                        }
                    }
                    item.TrangThai = 2;
                    _SaleServices.Update(item);
                    //auto();

                }

                if (item.NgayBatDau <= DateTime.Now && item.NgayKetThuc >= DateTime.Now)
                {
                    var b = _IchiTietSaleServices.GetAll().Where(c => c.IdSale == item.Id);
                    if (b != null)
                    {

                        foreach (var x in b)
                        {
                            var hieutre2k3 = _IchiTietSaleServices.GetAll().FirstOrDefault(c => c.IdChiTietSp == x.IdChiTietSp && c.TrangThai == 0);
                            if (hieutre2k3 == null)
                            {
                                ChiTietSaleView view = new ChiTietSaleView()
                                {
                                    Id = x.Id,
                                    IdChiTietSp = x.IdChiTietSp,
                                    IdSale = x.IdSale,
                                    TrangThai = 0
                                };

                                _IchiTietSaleServices.Update(view);
                            }

                        }
                        item.TrangThai = 0;
                        _SaleServices.Update(item);
                    }
                }

                if (tb_timkiemkm.Text != "")
                {
                    loadKM1();
                }
            }
        }

        private void tb_timkiemSp_TextChanged(object sender, EventArgs e)
        {
            loadCTSP();
        }

        private void dtp_start_ValueChanged(object sender, EventArgs e)
        {
            tbTrangthai();
        }
        private void tbTrangthai()
        {
            if (dtp_start.Value < DateTime.Now && dtp_end.Value > DateTime.Now)
            {
                tb_trangthai.Texts = "Đang áp dụng";
            }
            if (dtp_start.Value < DateTime.Now && dtp_end.Value < DateTime.Now)
            {

                tb_trangthai.Texts = "Ngừng áp dụng";

            }
            if (dtp_start.Value > DateTime.Now && dtp_end.Value > DateTime.Now)
            {

                tb_trangthai.Texts = "Chưa bắt đầu";
            }

        }
        private void dtp_end_ValueChanged(object sender, EventArgs e)
        {
            tbTrangthai();
        }

        private void btloadlai_Click(object sender, EventArgs e)
        {
            auto();
        }
    }
}
