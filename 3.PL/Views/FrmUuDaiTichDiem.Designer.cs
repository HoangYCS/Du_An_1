﻿namespace _3.PL.Views
{
    partial class FrmUuDaiTichDiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_clear = new System.Windows.Forms.Button();
            this.dtg_show = new System.Windows.Forms.DataGridView();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.tb_sodiem = new System.Windows.Forms.TextBox();
            this.lb_sodiem = new System.Windows.Forms.Label();
            this.cbb_loaihinhkm = new System.Windows.Forms.ComboBox();
            this.rdb_khd = new System.Windows.Forms.RadioButton();
            this.rdb_hd = new System.Windows.Forms.RadioButton();
            this.tb_ma = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_mucuudai = new System.Windows.Forms.Label();
            this.lb_loaihinhkm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_locloaihinhkm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbb_loctrangthai = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_timkiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_ud = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_mucuudai = new System.Windows.Forms.TextBox();
            this.lb_doi = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_congthuc = new System.Windows.Forms.Button();
            this.lb_km = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.lb3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_clear.BackColor = System.Drawing.Color.Red;
            this.btn_clear.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_clear.ForeColor = System.Drawing.Color.White;
            this.btn_clear.Location = new System.Drawing.Point(435, 760);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(189, 52);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // dtg_show
            // 
            this.dtg_show.AllowUserToAddRows = false;
            this.dtg_show.AllowUserToDeleteRows = false;
            this.dtg_show.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_show.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.dtg_show.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg_show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_show.GridColor = System.Drawing.Color.White;
            this.dtg_show.Location = new System.Drawing.Point(15, 20);
            this.dtg_show.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtg_show.Name = "dtg_show";
            this.dtg_show.ReadOnly = true;
            this.dtg_show.RowHeadersVisible = false;
            this.dtg_show.RowHeadersWidth = 62;
            this.dtg_show.RowTemplate.Height = 33;
            this.dtg_show.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_show.Size = new System.Drawing.Size(731, 490);
            this.dtg_show.TabIndex = 0;
            this.dtg_show.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_show_CellClick);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_xoa.BackColor = System.Drawing.Color.Red;
            this.btn_xoa.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_xoa.ForeColor = System.Drawing.Color.White;
            this.btn_xoa.Location = new System.Drawing.Point(628, 760);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(100, 52);
            this.btn_xoa.TabIndex = 2;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = false;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(122)))), ((int)(((byte)(83)))));
            this.btn_them.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_them.ForeColor = System.Drawing.Color.White;
            this.btn_them.Location = new System.Drawing.Point(222, 698);
            this.btn_them.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(506, 56);
            this.btn_them.TabIndex = 0;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = false;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_sua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(122)))), ((int)(((byte)(83)))));
            this.btn_sua.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_sua.ForeColor = System.Drawing.Color.White;
            this.btn_sua.Location = new System.Drawing.Point(222, 760);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(209, 52);
            this.btn_sua.TabIndex = 1;
            this.btn_sua.Text = "Cập nhật";
            this.btn_sua.UseVisualStyleBackColor = false;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // tb_sodiem
            // 
            this.tb_sodiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_sodiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.tb_sodiem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tb_sodiem.ForeColor = System.Drawing.Color.White;
            this.tb_sodiem.Location = new System.Drawing.Point(412, 556);
            this.tb_sodiem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_sodiem.Name = "tb_sodiem";
            this.tb_sodiem.Size = new System.Drawing.Size(307, 31);
            this.tb_sodiem.TabIndex = 12;
            this.tb_sodiem.TextChanged += new System.EventHandler(this.tb_sodiem_TextChanged);
            this.tb_sodiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_sodiem_KeyPress);
            // 
            // lb_sodiem
            // 
            this.lb_sodiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_sodiem.AutoSize = true;
            this.lb_sodiem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_sodiem.ForeColor = System.Drawing.Color.White;
            this.lb_sodiem.Location = new System.Drawing.Point(222, 558);
            this.lb_sodiem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_sodiem.Name = "lb_sodiem";
            this.lb_sodiem.Size = new System.Drawing.Size(146, 25);
            this.lb_sodiem.TabIndex = 11;
            this.lb_sodiem.Text = "Số điểm thưởng";
            // 
            // cbb_loaihinhkm
            // 
            this.cbb_loaihinhkm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbb_loaihinhkm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.cbb_loaihinhkm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_loaihinhkm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbb_loaihinhkm.ForeColor = System.Drawing.Color.White;
            this.cbb_loaihinhkm.FormattingEnabled = true;
            this.cbb_loaihinhkm.Location = new System.Drawing.Point(416, 406);
            this.cbb_loaihinhkm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbb_loaihinhkm.Name = "cbb_loaihinhkm";
            this.cbb_loaihinhkm.Size = new System.Drawing.Size(303, 33);
            this.cbb_loaihinhkm.TabIndex = 19;
            this.cbb_loaihinhkm.SelectedIndexChanged += new System.EventHandler(this.cbb_loaihinhkm_SelectedIndexChanged);
            // 
            // rdb_khd
            // 
            this.rdb_khd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdb_khd.AutoSize = true;
            this.rdb_khd.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rdb_khd.ForeColor = System.Drawing.Color.White;
            this.rdb_khd.Location = new System.Drawing.Point(550, 632);
            this.rdb_khd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdb_khd.Name = "rdb_khd";
            this.rdb_khd.Size = new System.Drawing.Size(178, 29);
            this.rdb_khd.TabIndex = 18;
            this.rdb_khd.TabStop = true;
            this.rdb_khd.Text = "Không hoạt động";
            this.rdb_khd.UseVisualStyleBackColor = true;
            // 
            // rdb_hd
            // 
            this.rdb_hd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdb_hd.AutoSize = true;
            this.rdb_hd.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rdb_hd.ForeColor = System.Drawing.Color.White;
            this.rdb_hd.Location = new System.Drawing.Point(415, 632);
            this.rdb_hd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdb_hd.Name = "rdb_hd";
            this.rdb_hd.Size = new System.Drawing.Size(122, 29);
            this.rdb_hd.TabIndex = 17;
            this.rdb_hd.TabStop = true;
            this.rdb_hd.Text = "Hoạt động";
            this.rdb_hd.UseVisualStyleBackColor = true;
            // 
            // tb_ma
            // 
            this.tb_ma.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_ma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.tb_ma.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tb_ma.ForeColor = System.Drawing.Color.White;
            this.tb_ma.Location = new System.Drawing.Point(416, 336);
            this.tb_ma.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_ma.Name = "tb_ma";
            this.tb_ma.Size = new System.Drawing.Size(303, 31);
            this.tb_ma.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(222, 636);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Trạng thái";
            // 
            // lb_mucuudai
            // 
            this.lb_mucuudai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_mucuudai.AutoSize = true;
            this.lb_mucuudai.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_mucuudai.ForeColor = System.Drawing.Color.White;
            this.lb_mucuudai.Location = new System.Drawing.Point(222, 488);
            this.lb_mucuudai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_mucuudai.Name = "lb_mucuudai";
            this.lb_mucuudai.Size = new System.Drawing.Size(105, 25);
            this.lb_mucuudai.TabIndex = 2;
            this.lb_mucuudai.Text = "Mức ưu đãi";
            // 
            // lb_loaihinhkm
            // 
            this.lb_loaihinhkm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_loaihinhkm.AutoSize = true;
            this.lb_loaihinhkm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_loaihinhkm.ForeColor = System.Drawing.Color.White;
            this.lb_loaihinhkm.Location = new System.Drawing.Point(222, 412);
            this.lb_loaihinhkm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_loaihinhkm.Name = "lb_loaihinhkm";
            this.lb_loaihinhkm.Size = new System.Drawing.Size(120, 25);
            this.lb_loaihinhkm.TabIndex = 1;
            this.lb_loaihinhkm.Text = "Loại hình KM";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(222, 342);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã";
            // 
            // cbb_locloaihinhkm
            // 
            this.cbb_locloaihinhkm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbb_locloaihinhkm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.cbb_locloaihinhkm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_locloaihinhkm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbb_locloaihinhkm.ForeColor = System.Drawing.Color.White;
            this.cbb_locloaihinhkm.FormattingEnabled = true;
            this.cbb_locloaihinhkm.Location = new System.Drawing.Point(938, 265);
            this.cbb_locloaihinhkm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbb_locloaihinhkm.Name = "cbb_locloaihinhkm";
            this.cbb_locloaihinhkm.Size = new System.Drawing.Size(160, 33);
            this.cbb_locloaihinhkm.TabIndex = 23;
            this.cbb_locloaihinhkm.SelectedIndexChanged += new System.EventHandler(this.cbb_locloaihinhkm_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(793, 268);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "Loại hình KM";
            // 
            // cbb_loctrangthai
            // 
            this.cbb_loctrangthai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbb_loctrangthai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.cbb_loctrangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_loctrangthai.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbb_loctrangthai.ForeColor = System.Drawing.Color.White;
            this.cbb_loctrangthai.FormattingEnabled = true;
            this.cbb_loctrangthai.Location = new System.Drawing.Point(1296, 265);
            this.cbb_loctrangthai.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbb_loctrangthai.Name = "cbb_loctrangthai";
            this.cbb_loctrangthai.Size = new System.Drawing.Size(169, 33);
            this.cbb_loctrangthai.TabIndex = 25;
            this.cbb_loctrangthai.SelectedIndexChanged += new System.EventHandler(this.cbb_loctrangthai_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1166, 268);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Lọc trạng thái";
            // 
            // tb_timkiem
            // 
            this.tb_timkiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_timkiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.tb_timkiem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tb_timkiem.Location = new System.Drawing.Point(938, 209);
            this.tb_timkiem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_timkiem.Name = "tb_timkiem";
            this.tb_timkiem.Size = new System.Drawing.Size(527, 31);
            this.tb_timkiem.TabIndex = 27;
            this.tb_timkiem.TextChanged += new System.EventHandler(this.tb_timkiem_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(825, 212);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 25);
            this.label5.TabIndex = 26;
            this.label5.Text = "Tìm kiếm";
            // 
            // lb_ud
            // 
            this.lb_ud.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_ud.AutoSize = true;
            this.lb_ud.Font = new System.Drawing.Font("Segoe UI", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lb_ud.ForeColor = System.Drawing.Color.White;
            this.lb_ud.Location = new System.Drawing.Point(696, 86);
            this.lb_ud.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_ud.Name = "lb_ud";
            this.lb_ud.Size = new System.Drawing.Size(535, 81);
            this.lb_ud.TabIndex = 28;
            this.lb_ud.Text = "Ưu Đãi Tích Điểm";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.dtg_show);
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(763, 316);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 535);
            this.panel1.TabIndex = 29;
            // 
            // tb_mucuudai
            // 
            this.tb_mucuudai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_mucuudai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.tb_mucuudai.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tb_mucuudai.ForeColor = System.Drawing.Color.White;
            this.tb_mucuudai.Location = new System.Drawing.Point(416, 483);
            this.tb_mucuudai.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_mucuudai.Name = "tb_mucuudai";
            this.tb_mucuudai.Size = new System.Drawing.Size(303, 31);
            this.tb_mucuudai.TabIndex = 30;
            this.tb_mucuudai.TextChanged += new System.EventHandler(this.tb_mucuudai_TextChanged);
            this.tb_mucuudai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_mucuudai_KeyPress);
            // 
            // lb_doi
            // 
            this.lb_doi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_doi.AutoSize = true;
            this.lb_doi.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_doi.ForeColor = System.Drawing.Color.White;
            this.lb_doi.Location = new System.Drawing.Point(222, 273);
            this.lb_doi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_doi.Name = "lb_doi";
            this.lb_doi.Size = new System.Drawing.Size(101, 25);
            this.lb_doi.TabIndex = 31;
            this.lb_doi.Text = "Công thức:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(327, 273);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 25);
            this.label8.TabIndex = 32;
            // 
            // btn_congthuc
            // 
            this.btn_congthuc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_congthuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(122)))), ((int)(((byte)(83)))));
            this.btn_congthuc.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_congthuc.ForeColor = System.Drawing.Color.White;
            this.btn_congthuc.Location = new System.Drawing.Point(614, 265);
            this.btn_congthuc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_congthuc.Name = "btn_congthuc";
            this.btn_congthuc.Size = new System.Drawing.Size(105, 40);
            this.btn_congthuc.TabIndex = 33;
            this.btn_congthuc.Text = "Đổi CT";
            this.btn_congthuc.UseVisualStyleBackColor = false;
            this.btn_congthuc.Click += new System.EventHandler(this.btn_congthuc_Click);
            // 
            // lb_km
            // 
            this.lb_km.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_km.AutoSize = true;
            this.lb_km.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.lb_km.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_km.ForeColor = System.Drawing.Color.White;
            this.lb_km.Location = new System.Drawing.Point(696, 486);
            this.lb_km.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_km.Name = "lb_km";
            this.lb_km.Size = new System.Drawing.Size(19, 25);
            this.lb_km.TabIndex = 34;
            this.lb_km.Text = "_";
            // 
            // lb1
            // 
            this.lb1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb1.AutoSize = true;
            this.lb1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(122)))), ((int)(((byte)(83)))));
            this.lb1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb1.ForeColor = System.Drawing.Color.White;
            this.lb1.Location = new System.Drawing.Point(439, 273);
            this.lb1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(51, 25);
            this.lb1.TabIndex = 35;
            this.lb1.Text = "VNĐ";
            // 
            // lb2
            // 
            this.lb2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb2.AutoSize = true;
            this.lb2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.lb2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb2.ForeColor = System.Drawing.Color.White;
            this.lb2.Location = new System.Drawing.Point(498, 273);
            this.lb2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(37, 25);
            this.lb2.TabIndex = 36;
            this.lb2.Text = "= 1";
            // 
            // lb3
            // 
            this.lb3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb3.AutoSize = true;
            this.lb3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lb3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb3.ForeColor = System.Drawing.Color.White;
            this.lb3.Location = new System.Drawing.Point(539, 273);
            this.lb3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(56, 25);
            this.lb3.TabIndex = 37;
            this.lb3.Text = "Điểm";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmUuDaiTichDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.lb3);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.lb_km);
            this.Controls.Add(this.btn_congthuc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lb_doi);
            this.Controls.Add(this.tb_mucuudai);
            this.Controls.Add(this.lb_ud);
            this.Controls.Add(this.tb_timkiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbb_loctrangthai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbb_locloaihinhkm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.tb_sodiem);
            this.Controls.Add(this.lb_sodiem);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.cbb_loaihinhkm);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.rdb_khd);
            this.Controls.Add(this.rdb_hd);
            this.Controls.Add(this.tb_ma);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_loaihinhkm);
            this.Controls.Add(this.lb_mucuudai);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FrmUuDaiTichDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUuDaiTichDiem";
            this.Load += new System.EventHandler(this.FrmUuDaiTichDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_show)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtg_show;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.RadioButton rdb_khd;
        private System.Windows.Forms.RadioButton rdb_hd;
        private System.Windows.Forms.TextBox tb_ma;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_mucuudai;
        private System.Windows.Forms.Label lb_loaihinhkm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_loaihinhkm;
        private System.Windows.Forms.TextBox tb_sodiem;
        private System.Windows.Forms.Label lb_sodiem;
        private System.Windows.Forms.ComboBox cbb_locloaihinhkm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb_loctrangthai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_timkiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_ud;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_mucuudai;
        private System.Windows.Forms.Label lb_doi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_congthuc;
        private System.Windows.Forms.Label lb_km;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.Timer timer1;
    }
}