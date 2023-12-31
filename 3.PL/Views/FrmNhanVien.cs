﻿using _1.DAL.DomainClass;
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModels;
using _3.PL.CustomControlls;
using _3.PL.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace _3.PL.Views
{
    public partial class FrmNhanVien : Form
    {
        private INhanVienServices _iNhanVien;
        private IChucVuServices _iChucVu;
        private NhanVienView _nvv;
        public FrmNhanVien()
        {
            InitializeComponent();
            _iChucVu = new ChucVuServices();
            _iNhanVien = new NhanVienServices();
            loadData();
            loadComboBox();
        }
        public void loadData()
        {
            dtgv_show.Rows.Clear();
            dtgv_show.ColumnCount = 13;
            dtgv_show.Columns[0].Name = "Id";
            dtgv_show.Columns[0].Visible = false;
            dtgv_show.Columns[1].Name = "Mã";
            dtgv_show.Columns[2].Name = "Tên";
            dtgv_show.Columns[3].Name = "Tài khoản";
            dtgv_show.Columns[4].Name = "Mật khẩu";
            dtgv_show.Columns[5].Name = "Giới tính";
            dtgv_show.Columns[6].Name = "Chức vụ";
            dtgv_show.Columns[7].Name = "Ngày sinh";
            dtgv_show.Columns[8].Name = "CCCD";
            dtgv_show.Columns[9].Name = "SĐT";
            dtgv_show.Columns[10].Name = "Email";
            dtgv_show.Columns[11].Name = "Địa chỉ";
            dtgv_show.Columns[12].Name = "Trạng thái";
            var lstViewNV = _iNhanVien.GetAll();
            if (tb_timkiem.Text != "")
            {
                lstViewNV = lstViewNV.Where(x => x.Ma.ToLower().Contains(tb_timkiem.Text.ToLower()) || x.Ten.ToLower().Contains(tb_timkiem.Text.ToLower())).ToList();
            }
            foreach (var item in lstViewNV)
            {
                dtgv_show.Rows.Add(
                    item.Id,
                    item.Ma,
                    item.HoVaTen,
                    item.TaiKhoan,
                    item.MatKhau,
                    item.GioiTinh,
                    item.TenCV,
                    item.NgaySinh.ToString(),
                    item.Cccd,
                    item.Sdt,
                    item.Email,
                    item.DiaChi,
                    item.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
                    );
            }
        }
        public void loadComboBox()
        {
            _iChucVu = new ChucVuServices();
            _iNhanVien = new NhanVienServices();
            cbb_chucvu.Items.Clear();
            cbb_gioitinh.Items.Clear();
            cbb_loc.Items.Clear();
            foreach (var item in _iChucVu.GetAll().Where(c => c.TrangThai == 0))
            {

                cbb_chucvu.Items.Add(item.Ten);

            }
            cbb_gioitinh.Items.Add("Nam");
            cbb_gioitinh.Items.Add("Nữ");
            cbb_loc.Items.Add("Tất cả");
            cbb_loc.Items.Add("Nam");
            cbb_loc.Items.Add("Nữ");
            cbb_gioitinh.Text = "";
            cbb_chucvu.Text = "";
            cbb_gioitinh.SelectedIndex = -1;
            cbb_chucvu.SelectedIndex = -1;
            cbb_loc.SelectedIndex = 0;
            rdb_hoatdong.Checked = true;
        }

        public NhanVienView GetData()
        {
            NhanVienView cvv = new NhanVienView()
            {
                Id = new Guid(),
                IdCv = _iChucVu.GetAll().FirstOrDefault(c => c.Ten == cbb_chucvu.Text).Id,
                Ten = XoaDauCach(tb_ten.Text.Trim()),
                TenDem = XoaDauCach(tb_tendem.Text).Trim(),
                Ho = XoaDauCach(tb_ho.Text.Trim()),
                GioiTinh = cbb_gioitinh.Text,
                NgaySinh = dtp_ngaysinh.Value,
                DiaChi = tb_diachi.Text,
                Sdt = tb_sdt.Text,
                Cccd = tb_cccd.Text,
                MatKhau = tb_matkhau.Text,
                Email = tb_email.Text,
                TaiKhoan = XoaDauCach(tb_taikhoan.Text).Trim(),
                TrangThai = rdb_hoatdong.Checked ? 0 : 1
            };
            return cvv;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            DialogResult dialog = RJMessageBox.Show("Bạn có muốn thêm không!", "Thông báo", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (tb_cccd.Text.Length < 12)
                {
                    RJMessageBox.Show("Nhập đúng căn cước công dân");
                }
                else if (_iNhanVien.GetAll().Any(c => c.Cccd == tb_cccd.Text))
                {
                    RJMessageBox.Show("Căn cước đã bị trùng");
                }
                else if (ValidateInput.IsValidVietNamPhoneNumber(tb_sdt.Text) == false)
                {
                    RJMessageBox.Show("Nhập đúng số điện thoại");
                }
                else if (_iNhanVien.GetAll().Any(c => c.Sdt == tb_sdt.Text))
                {
                    RJMessageBox.Show("Số điện thoại đã bị trùng");
                }
                else if (ValidateInput.IsEmail(tb_email.Text) == false)
                {
                    RJMessageBox.Show("Nhập đúng email");
                }
                else if (_iNhanVien.GetAll().Any(c => c.Email == tb_email.Text))
                {
                    RJMessageBox.Show("Email đã bị trùng");
                }
                else if (string.IsNullOrWhiteSpace(cbb_chucvu.Text))
                {
                    RJMessageBox.Show("Chọn chức vụ");
                }
                else if (string.IsNullOrWhiteSpace(tb_matkhau.Text))
                {
                    RJMessageBox.Show("Không được để trống mật khẩu");
                }
                else if (string.IsNullOrWhiteSpace(tb_ten.Text) || string.IsNullOrWhiteSpace(tb_ho.Text))
                {
                    RJMessageBox.Show("Không được để trống họ và tên");
                }
                else if (string.IsNullOrWhiteSpace(cbb_gioitinh.Text))
                {
                    RJMessageBox.Show("Chọn giới tính");
                }
                else if (DateTime.Now.Year - dtp_ngaysinh.Value.Year < 18)
                {
                    RJMessageBox.Show("Ngày sinh không đủ");
                }
                else if (tb_nhaplai.Text != tb_matkhau.Text)
                {
                    RJMessageBox.Show("Mật khẩu không đúng");
                }
                else if (string.IsNullOrWhiteSpace(tb_taikhoan.Text))
                {
                    RJMessageBox.Show("không được để tài khoản");
                }
                else if (rdb_hoatdong.Checked == false && rdb_khonghd.Checked == false)
                {
                    RJMessageBox.Show("không được để trống trạng thái");
                }
                else if (hasSpecialChar(tb_ten.Text) || hasSpecialChar(tb_ho.Text))
                {
                    RJMessageBox.Show("Họ Tên không hợp lệ");
                }
                else
                {
                    _iNhanVien.Add(GetData());
                    RJMessageBox.Show("thêm thành công");
                    loadData();
                    clear();
                }
            }
            else
            {
                RJMessageBox.Show("bạn đã hủy thêm");
            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

            DialogResult dialog = RJMessageBox.Show("Bạn có muốn sửa không!", "Thông báo", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (_nvv == null)
                {
                    RJMessageBox.Show("Chọn nhân viên cần sửa");
                }
                else if (_iNhanVien.GetAll().FirstOrDefault(c => c.TaiKhoan == tb_taikhoan.Text && c.Id != _nvv.Id) != null)
                {
                    RJMessageBox.Show("Tài khoản bị trùng");
                }
                else if (DateTime.Now.Year - dtp_ngaysinh.Value.Year < 18)
                {
                    RJMessageBox.Show("Ngày sinh không đủ");
                }
                else if (_iNhanVien.GetAll().FirstOrDefault(c => c.Cccd == tb_cccd.Text && c.Id != _nvv.Id) != null)
                {
                    RJMessageBox.Show("Căn cước bị trùng");
                }
                else if (_iNhanVien.GetAll().FirstOrDefault(c => c.Email == tb_email.Text && c.Id != _nvv.Id) != null)
                {
                    RJMessageBox.Show("Email bị trùng");
                }
                else if (_iNhanVien.GetAll().FirstOrDefault(c => c.Sdt == tb_sdt.Text && c.Id != _nvv.Id) != null)
                {
                    RJMessageBox.Show("Số điện thoại bị trùng");
                }
                else if (string.IsNullOrWhiteSpace(tb_matkhau.Text))
                {
                    RJMessageBox.Show("Không được để trống mật khẩu");
                }
                else if (tb_nhaplai.Text != tb_matkhau.Text)
                {
                    RJMessageBox.Show("Mật khẩu không đúng");
                }
                else if (hasSpecialChar(tb_ten.Text) || hasSpecialChar(tb_ho.Text))
                {
                    RJMessageBox.Show("Họ Tên không hợp lệ");
                }
                else
                {
                    NhanVienView cvv = new NhanVienView()
                    {
                        Id = Guid.Parse(dtgv_show.CurrentRow.Cells[0].Value.ToString()),
                        IdCv = _iChucVu.GetAll().FirstOrDefault(c => c.Ten == cbb_chucvu.Text).Id,
                        Ma = dtgv_show.CurrentRow.Cells[1].Value.ToString(),
                        Ten = XoaDauCach(tb_ten.Text.Trim()),
                        TenDem = XoaDauCach(tb_tendem.Text).Trim(),
                        Ho = XoaDauCach(tb_ho.Text.Trim()),
                        GioiTinh = cbb_gioitinh.Text,
                        NgaySinh = dtp_ngaysinh.Value,
                        DiaChi = tb_diachi.Text,
                        Sdt = tb_sdt.Text,
                        Cccd = tb_cccd.Text,
                        MatKhau = tb_matkhau.Text,
                        Email = tb_email.Text,
                        TaiKhoan = XoaDauCach(tb_taikhoan.Text).Trim(),
                        TrangThai = rdb_hoatdong.Checked ? 0 : 1
                    };
                    _iNhanVien.Update(cvv);
                    RJMessageBox.Show("sửa thành công");
                    loadData();
                    clear();
                }
            }
            else
            {
                RJMessageBox.Show("bạn đã hủy sửa");
            }

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = RJMessageBox.Show("Bạn có muốn xóa không", "thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (_nvv == null)
                {
                    RJMessageBox.Show("vui lòng chọn nhân viên");
                }
                else
                {
                    _iNhanVien.Delete(_nvv);
                    RJMessageBox.Show("xóa thành công");
                    loadData();
                    clear();
                }
            }
            else
            {
                RJMessageBox.Show("bạn đã hủy xóa");
            }
        }

        public void clear()
        {
            tb_ho.Text = "";
            tb_tendem.Text = "";
            tb_ten.Text = "";
            dtp_ngaysinh.Value = DateTime.Now;
            tb_diachi.Text = "";
            tb_sdt.Text = "";
            tb_cccd.Text = "";
            tb_matkhau.Text = "";
            tb_email.Text = "";
            tb_taikhoan.Text = "";
            tb_nhaplai.Text = "";
            rdb_hoatdong.Checked = false;
            rdb_khonghd.Checked = false;
        }

        private void dtgv_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _nvv = _iNhanVien.GetAll().FirstOrDefault(c => c.Id == Guid.Parse(dtgv_show.CurrentRow.Cells[0].Value.ToString()));
            cbb_chucvu.Text = _iChucVu.GetAll().FirstOrDefault(c => c.Id == _nvv.IdCv).Ten;
            tb_ho.Text = _nvv.Ho;
            tb_tendem.Text = _nvv.TenDem;
            tb_ten.Text = _nvv.Ten;
            cbb_gioitinh.Text = dtgv_show.CurrentRow.Cells[5].Value.ToString();
            dtp_ngaysinh.Value = Convert.ToDateTime(dtgv_show.CurrentRow.Cells[7].Value.ToString());
            tb_diachi.Text = dtgv_show.CurrentRow.Cells[11].Value.ToString();
            tb_sdt.Text = dtgv_show.CurrentRow.Cells[9].Value.ToString();
            tb_cccd.Text = dtgv_show.CurrentRow.Cells[8].Value.ToString();
            tb_matkhau.Text = dtgv_show.CurrentRow.Cells[4].Value.ToString();
            tb_email.Text = dtgv_show.CurrentRow.Cells[10].Value.ToString();
            tb_taikhoan.Text = dtgv_show.CurrentRow.Cells[3].Value.ToString();
            rdb_hoatdong.Checked = _nvv.TrangThai == 0;
            rdb_khonghd.Checked = _nvv.TrangThai == 1;
        }
        private void tb_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void cbb_loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_loc.Text == "Tất cả")
            {
                loadData();
            }
            else if (cbb_loc.Text == "Nam")
            {
                dtgv_show.Rows.Clear();
                dtgv_show.ColumnCount = 13;
                dtgv_show.Columns[0].Name = "Id";
                dtgv_show.Columns[0].Visible = false;
                dtgv_show.Columns[1].Name = "Mã";
                dtgv_show.Columns[2].Name = "Tên";
                dtgv_show.Columns[3].Name = "Tài khoản";
                dtgv_show.Columns[4].Name = "Mật khẩu";
                dtgv_show.Columns[5].Name = "Giới tính";
                dtgv_show.Columns[6].Name = "Chức vụ";
                dtgv_show.Columns[7].Name = "Ngày sinh";
                dtgv_show.Columns[8].Name = "CCCD";
                dtgv_show.Columns[9].Name = "SĐT";
                dtgv_show.Columns[10].Name = "Email";
                dtgv_show.Columns[11].Name = "Địa chỉ";
                dtgv_show.Columns[12].Name = "Trạng thái";
                var lstViewNV = _iNhanVien.GetAll().Where(c => c.GioiTinh == "Nam").ToList();
                if (tb_timkiem.Text != "")
                {
                    lstViewNV = lstViewNV.Where(x => x.Ma.ToLower().Contains(tb_timkiem.Text.ToLower()) || x.Ten.ToLower().Contains(tb_timkiem.Text.ToLower())).ToList();
                }
                foreach (var item in lstViewNV)
                {
                    dtgv_show.Rows.Add(
                        item.Id,
                        item.Ma,
                        item.HoVaTen,
                        item.TaiKhoan,
                        item.MatKhau,
                        item.GioiTinh,
                        item.TenCV,
                        item.NgaySinh.ToString(),
                        item.Cccd,
                        item.Sdt,
                        item.Email,
                        item.DiaChi,
                        item.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
                        );
                }
            }
            else
            {
                dtgv_show.Rows.Clear();
                dtgv_show.ColumnCount = 13;
                dtgv_show.Columns[0].Name = "Id";
                dtgv_show.Columns[0].Visible = false;
                dtgv_show.Columns[1].Name = "Mã";
                dtgv_show.Columns[2].Name = "Tên";
                dtgv_show.Columns[3].Name = "Tài khoản";
                dtgv_show.Columns[4].Name = "Mật khẩu";
                dtgv_show.Columns[5].Name = "Giới tính";
                dtgv_show.Columns[6].Name = "Chức vụ";
                dtgv_show.Columns[7].Name = "Ngày sinh";
                dtgv_show.Columns[8].Name = "CCCD";
                dtgv_show.Columns[9].Name = "SĐT";
                dtgv_show.Columns[10].Name = "Email";
                dtgv_show.Columns[11].Name = "Địa chỉ";
                dtgv_show.Columns[12].Name = "Trạng thái";
                var lstViewNV = _iNhanVien.GetAll().Where(c => c.GioiTinh == "Nữ").ToList();
                if (tb_timkiem.Text != "")
                {
                    lstViewNV = lstViewNV.Where(x => x.Ma.ToLower().Contains(tb_timkiem.Text.ToLower()) || x.Ten.ToLower().Contains(tb_timkiem.Text.ToLower())).ToList();
                }
                foreach (var item in lstViewNV)
                {
                    dtgv_show.Rows.Add(
                        item.Id,
                        item.Ma,
                        item.HoVaTen,
                        item.TaiKhoan,
                        item.MatKhau,
                        item.GioiTinh,
                        item.TenCV,
                        item.NgaySinh.ToString(),
                        item.Cccd,
                        item.Sdt,
                        item.Email,
                        item.DiaChi,
                        item.TrangThai == 0 ? "Hoạt động" : "Không hoạt động"
                        );
                }
            }
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            FrmChucVu frmChucVu = new FrmChucVu();
            frmChucVu.ShowDialog();
            loadData();
            loadComboBox();
        }

        private void tb_cccd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }
        private string XoaDauCach(string s)
        {

            while (s.Trim().Contains("  "))
            {
                s = s.Replace("  ", " "); // Xóa 2 dấu cách thành 1 dấu cho đến khi hết
            }
            return s;
        }

        private void tb_ten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_tendem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tb_ho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int one = random.Next(0, 255);
            int two = random.Next(0, 255);
            int three = random.Next(0, 255);
            int four = random.Next(0, 255);

            lb_nv.ForeColor = Color.FromArgb(one, two, three, four);
        }
    }
}
