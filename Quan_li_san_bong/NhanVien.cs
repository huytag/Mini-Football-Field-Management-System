using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_san_bong
{
    public partial class NhanVien : UserControl
    {
        Connect ketNoi = new Connect();
        public NhanVien()
        {
            InitializeComponent();
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            KhachHang.tenKH = txtTenKH.Text;
            KhachHang.diaChi = txtDiaChi.Text;
            KhachHang.sDT = txtSDT.Text;
            this.ParentForm.Hide();
            ChonSan cs = new ChonSan();
            cs.ShowDialog();
            this.ParentForm.Close();
        }
    }
}
