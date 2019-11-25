﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class HistoryKH : Form
    {
        FormManager frmmng = new FormManager();

        private int i = -1;
        public HistoryKH()
        {
            InitializeComponent();
        }

        private void HistoryKH_Load(object sender, EventArgs e)
        {
            frmmng.Data.ArrLS = new List<CHistory>();
            frmmng.Data.OpenKH("dskh.txt");
            frmmng.Data.OpenDP("dsdp.txt");
            frmmng.Data.OpenLSKH("dslskh.txt");
            if (frmmng.Data.ArrLS.Count>0)
            {
                hienthi();
            }
            cbxLoaiphong.SelectedIndex = -1;
        }

        public void hienthi()
        {
            lvwLS.Items.Clear();
            foreach (CHistory ls  in frmmng.Data.ArrLS)
            {
                ListViewItem li = lvwLS.Items.Add(ls.Dp.Kh.Hoten);
                li.SubItems.Add(ls.Dp.Kh.CMND.ToString());
                if (ls.Kh.Gioitinh == true)
                {
                    li.SubItems.Add("Nam");
                }
                else li.SubItems.Add("Nu");
                li.SubItems.Add(ls.Kh.Tuoi.ToString());
                li.SubItems.Add(ls.Kh.Quoctich);
                li.SubItems.Add(ls.Kh.Sdt.ToString());
                li.SubItems.Add(ls.Dp.Phong.Loaiphong);
                li.SubItems.Add(ls.Dp.Phong.Sophong.ToString());
                li.SubItems.Add(ls.Dp.Ngayden.ToShortDateString());
                li.SubItems.Add(ls.Dp.Ngaydi.ToShortDateString());
                li.SubItems.Add(ls.Dp.SoNgayO().ToString());
                li.SubItems.Add(ls.Dp.ThanhTien().ToString());
            }
        }

        public void hienthiLS(int j)
        {
            CHistory ls = (CHistory)frmmng.Data.ArrLS[j];
            txtTenKH.Text = ls.Kh.Hoten;
            cbxLoaiphong.Text = ls.Dp.Phong.Loaiphong;
            txtQuoctich.Text = ls.Kh.Quoctich;
        }

        public void clearLSKH()
        {
            txtTenKH.Text = "";
            cbxLoaiphong.SelectedIndex = -1;
            txtQuoctich.Text = "";
        }

        public bool ChonTheo1TieuChi()
        {
            bool kq = false;
            int d = 0;
            d += (txtTenKH.Text == "") ? 0 : 1;
            d += (cbxLoaiphong.SelectedIndex == -1) ? 0 : 1;
            d += (txtQuoctich.Text == "") ? 0 : 1;
            if (d < 1)
            {
                MessageBox.Show("Bạn chưa chọn 1 trong 3 tiêu chí");
            }
            else if (d > 1)
            {
                clearLSKH();
                MessageBox.Show("Bạn chỉ có thể chọn 1 tiêu chí");
            }
            else kq = true;
            return kq;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!(ChonTheo1TieuChi()))
            {
                return;
            }
            lvwLS.Items.Clear();
            if (txtTenKH.Text!="")
            {
                foreach (CHistory ls in frmmng.Data.ArrLS)
                {
                    if (string.Compare(ls.Kh.Hoten,txtTenKH.Text)==0)
                    {
                        ListViewItem li = lvwLS.Items.Add(ls.Kh.Hoten);
                        li.SubItems.Add(ls.Kh.CMND.ToString());
                        li.SubItems.Add(ls.Kh.Gioitinh ? "Nam" : "Nữ");
                        li.SubItems.Add(ls.Kh.Tuoi.ToString());
                        li.SubItems.Add(ls.Kh.Quoctich);
                        li.SubItems.Add(ls.Kh.Sdt.ToString());
                        li.SubItems.Add(ls.Dp.Phong.Loaiphong);
                        li.SubItems.Add(ls.Dp.Phong.Sophong.ToString());
                        li.SubItems.Add(ls.Dp.Ngayden.ToShortDateString());
                        li.SubItems.Add(ls.Dp.Ngaydi.ToShortDateString());
                        li.SubItems.Add(ls.Dp.SoNgayO().ToString());
                        li.SubItems.Add(ls.Dp.ThanhTien().ToString());
                    }
                }
            }
            if (cbxLoaiphong.SelectedIndex >=0)
            {
                foreach(CHistory ls in frmmng.Data.ArrLS)
                {
                    if (string.Compare(ls.Dp.Phong.Loaiphong,cbxLoaiphong.Text)==0)
                    {
                        ListViewItem li = lvwLS.Items.Add(ls.Kh.Hoten);
                        li.SubItems.Add(ls.Kh.CMND.ToString());
                        li.SubItems.Add(ls.Kh.Gioitinh ? "Nam" : "Nữ");
                        li.SubItems.Add(ls.Kh.Tuoi.ToString());
                        li.SubItems.Add(ls.Kh.Quoctich);
                        li.SubItems.Add(ls.Kh.Sdt.ToString());
                        li.SubItems.Add(ls.Dp.Phong.Loaiphong);
                        li.SubItems.Add(ls.Dp.Phong.Sophong.ToString());
                        li.SubItems.Add(ls.Dp.Ngayden.ToShortDateString());
                        li.SubItems.Add(ls.Dp.Ngaydi.ToShortDateString());
                        li.SubItems.Add(ls.Dp.SoNgayO().ToString());
                        li.SubItems.Add(ls.Dp.ThanhTien().ToString());
                    }
                }
            }
            if (txtQuoctich.Text!="")
            {
                foreach (CHistory ls  in frmmng.Data.ArrLS)
                {
                    if (string.Compare(ls.Kh.Quoctich,txtQuoctich.Text)==0)
                    {
                        ListViewItem li = lvwLS.Items.Add(ls.Kh.Hoten);
                        li.SubItems.Add(ls.Kh.CMND.ToString());
                        li.SubItems.Add(ls.Kh.Gioitinh ? "Nam" : "Nữ");
                        li.SubItems.Add(ls.Kh.Tuoi.ToString());
                        li.SubItems.Add(ls.Kh.Quoctich);
                        li.SubItems.Add(ls.Kh.Sdt.ToString());
                        li.SubItems.Add(ls.Dp.Phong.Loaiphong);
                        li.SubItems.Add(ls.Dp.Phong.Sophong.ToString());
                        li.SubItems.Add(ls.Dp.Ngayden.ToShortDateString());
                        li.SubItems.Add(ls.Dp.Ngaydi.ToShortDateString());
                        li.SubItems.Add(ls.Dp.SoNgayO().ToString());
                        li.SubItems.Add(ls.Dp.ThanhTien().ToString());
                    }
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            clearLSKH();
            hienthi();
        }

        private void lvwLS_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int j in lvwLS.SelectedIndices)
            {
                i = j;
                hienthiLS(j);
                break;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmmng.Data.SaveLSKH("dslskh.txt");
            this.Hide();
            frmmng.ShowDialog();
            this.Close();
        }

        private void HistoryKH_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearLSKH();
        }
    }
}
