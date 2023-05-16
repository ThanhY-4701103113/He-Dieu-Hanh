using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace Hệ_Điều_Hành_LRU
{
    public partial class FrmLRU : Form
    {
        public static int tg = 0;
        public FrmLRU()
        {
            InitializeComponent();
        }

        private void txtSoTrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // 8 là phím backspace
            {
                e.Handled = true; // Không cho phép ký tự được nhập vào
            }
        }

        private void txtSoTrangAo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // 8 là phím backspace
            {
                e.Handled = true; // Không cho phép ký tự được nhập vào
            }
        }

        private void pRun_Paint(object sender, PaintEventArgs e)
        {
            int x = 50, y = 50, s = 40;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Font font = new Font("Times New Romen", 16);
            SolidBrush br_MauTrang = new SolidBrush(Color.White);
            SolidBrush br_MauXanhDuong = new SolidBrush(Color.Blue);
            SolidBrush br_MauDen = new SolidBrush(Color.Black);
            SolidBrush br_MauVang = new SolidBrush(Color.Yellow);
            SolidBrush br_MauDo = new SolidBrush(Color.Red);
            SolidBrush br_MauTim = new SolidBrush(Color.Purple);
            List<SolidBrush> colorsbrush = new List<SolidBrush>() { new SolidBrush(Color.Red), new SolidBrush(Color.Blue), new SolidBrush(Color.Yellow), new SolidBrush(Color.Purple), new SolidBrush(Color.Green), new SolidBrush(Color.BurlyWood), new SolidBrush(Color.DarkCyan), new SolidBrush(Color.DarkOliveGreen), new SolidBrush(Color.DarkSlateBlue), new SolidBrush(Color.DarkKhaki), new SolidBrush(Color.CadetBlue), new SolidBrush(Color.Chocolate), new SolidBrush(Color.HotPink), new SolidBrush(Color.Indigo), new SolidBrush(Color.MediumSeaGreen), new SolidBrush(Color.PapayaWhip), new SolidBrush(Color.SkyBlue), new SolidBrush(Color.WhiteSmoke), new SolidBrush(Color.YellowGreen), new SolidBrush(Color.Tomato) };
            List<Pen> colorspen = new List<Pen>() { new Pen(Color.Red, 3), new Pen(Color.Blue, 3), new Pen(Color.Yellow, 3), new Pen(Color.Purple, 3), new Pen(Color.Green), new Pen(Color.BurlyWood), new Pen(Color.DarkCyan), new Pen(Color.DarkOliveGreen), new Pen(Color.DarkSlateBlue), new Pen(Color.DarkKhaki) };
            Pen pen_Black = new Pen(Color.White, 2);
            Pen pen_Red = new Pen(Color.Red, 3);
            Pen pen_Yellow = new Pen(Color.Yellow, 3);
            Pen pen_Blue = new Pen(Color.Blue, 3);
            string[] str;
            str = txtChuoiTrang.Text.Split(new char[] { ' ' });
            
            List<string> Khung = new List<string>();
            List<int> Dem = new List<int>();
            if (txtSoTrangAo.Text != "" && txtSoKhungTrang.Text != "")
            {
                if (int.Parse(txtSoTrangAo.Text) > str.Length)
                {
                    return;
                }
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != "")
                    {
                        g.DrawLine(pen_Black, x, y, x + s, y);
                        g.DrawLine(pen_Black, x, y, x, y + s);
                        g.DrawLine(pen_Black, x + s, y, x + s, y + s);
                        g.DrawLine(pen_Black, x, y + s, x + s, y + s);
                        g.FillRectangle(br_MauXanhDuong, x + 2, y + 2, s - 4, s - 4);
                        g.DrawString(str[i].ToString(), font, br_MauVang, x + 4, y + 5);
                        x += s;
                    }
                }

                x = 50;
                for (int j = 0; j < str.Length; j++)
                {
                    y = 3 * s;
                    for (int i = 0; i < int.Parse(txtSoKhungTrang.Text); i++)
                    {
                        g.DrawLine(pen_Black, x, y, x + s, y);
                        g.DrawLine(pen_Black, x, y, x, y + s);
                        g.DrawLine(pen_Black, x + s, y, x + s, y + s);
                        g.DrawLine(pen_Black, x, y + s, x + s, y + s);
                        y += s;
                    }
                    x += s;
                }
                x = 50;
                y = (int.Parse(txtSoKhungTrang.Text) + 4) * s;
                for (int i = 0; i < str.Length; i++)
                {
                    g.DrawLine(pen_Black, x, y, x + s, y);
                    g.DrawLine(pen_Black, x, y, x, y + s);
                    g.DrawLine(pen_Black, x + s, y, x + s, y + s);
                    g.DrawLine(pen_Black, x, y + s, x + s, y + s);
                    g.FillRectangle(br_MauTrang, x + 2, y+2, s - 4, s - 4);
                    x += s;

                }
                int kq = 0;
                y = 2*s;
                x = 50;
                List<string> Loi = new List<string>();
                List<int> DanhDau = new List<int>();
                for (int i = 0; i < str.Length; i++)
                {
                    string trang = str[i];
                    int kt = 1000;
                    if (!Khung.Contains(trang))
                    {
                        if (Khung.Count < int.Parse(txtSoKhungTrang.Text))
                        {
                            Khung.Add(trang);
                            Dem.Add(i);
                            DanhDau.Add(Khung.Count-1);
                        }
                        else
                        {
                            int minIndex = 0;
                            for (int j = 1; j < int.Parse(txtSoKhungTrang.Text); j++)
                            {
                                if (Dem[j] < Dem[minIndex])
                                {
                                    minIndex = j;
                                }
                            }
                            Khung[minIndex] = trang;
                            Dem[minIndex] = i;
                            DanhDau.Add(minIndex);
                        }
                        Loi.Add("F");
                        kq++;
                    }
                    else
                    {
                        int index = Khung.IndexOf(trang);
                        Dem[index] = i;
                        DanhDau.Add(index);
                        Loi.Add(" ");
                    }
                    if (i < int.Parse(txtSoKhungTrang.Text))
                    {
                        kt = int.Parse(txtSoKhungTrang.Text) + i;
                    }
                    int vt = y;
                    g.FillRectangle(br_MauDo, x + 2, (DanhDau[i]+1)*s + vt + 2, s - 4, s - 4);
                    for (int n = 0; n < Khung.Count; n++)
                    {
                        if (kt >= int.Parse(txtSoKhungTrang.Text))
                        {
                            //g.FillRectangle(br_MauDo, x + 2, vt + s, s - 2, s - 2);
                            g.DrawString(Khung[n].ToString(), font, br_MauTrang, x + 4, vt + 5 + s);
                            kt--;
                        }
                        vt += s;
                        Thread.Sleep(tg*1600/str.Length/ int.Parse(txtSoKhungTrang.Text)/2);
                    }
                    g.DrawString(Loi[i], font, br_MauDo, x + 10, (int.Parse(txtSoKhungTrang.Text) + 4) * s + 5);
                    Thread.Sleep(tg*1600/str.Length/ int.Parse(txtSoKhungTrang.Text)/2);
                    x += s;
                }
                btnKiemTra.Enabled = true;
                txtKetQua.Text = kq + " lỗi trang";
                tg = 0;
                btnKiemTra.Focus();
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (txtSoTrangAo.Text == "")
            {
                txtSoTrangAo.Focus();
                return;
            }
            if (txtSoKhungTrang.Text == "")
            {
                txtSoKhungTrang.Focus();
                return;
            }
            btnKiemTra.Enabled = false;
            if (txtThoiGian.Text == "")
            {
                tg = 0;
            }
            else
            {
                tg =int.Parse(txtThoiGian.Text);
            }
            pRun.Refresh();
        }

        private void txtThoiGian_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) // 8 là phím backspace
            {
                e.Handled = true; // Không cho phép ký tự được nhập vào
            }
        }

        private void FrmLRU_Load(object sender, EventArgs e)
        {
            txtKetQua.ReadOnly = true;
        }
    }
}
