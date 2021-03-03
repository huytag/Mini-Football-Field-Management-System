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
    public partial class QLNV : UserControl
    {
        Connect ketNoi = new Connect();
        DataTable a = new DataTable();
        public QLNV()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ketNoi.DbConnection();
            txtTNV.Enabled = true;
            txtDC.Enabled = true;
            txtSDT.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            if (txtTNV.Text=="")
            {
                return;
            }
            string sql = "select count(*) from nhanvien where TENNV='" + txtTNV.Text + "'";
            if (ketNoi.getCount(sql) == 0)
            {
                ketNoi.updateToDataBase("insert into nhanvien values('" + txtTNV.Text + "','" + txtDC.Text + "','" + txtSDT.Text + "','"+txtTK.Text+"','"+txtPass.Text+"')");
                QLNV_Load(sender, e);
            }
            else
            {
                MessageBox.Show("đã có nhân viên này");
            }
        }

        private void QLNV_Load(object sender, EventArgs e)
        {
            ketNoi.DbConnection();
            string sql = "select * from nhanvien";
            a = ketNoi.getDataTable(sql);
            dataGridView1.DataSource = a;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txtTNV.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            txtDC.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            txtTK.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            txtPass.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
            button2.Enabled = true;
            button3.Enabled = true;
            txtTNV.Enabled = false;
            txtDC.Enabled = false;
            txtSDT.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ketNoi.DbConnection();
            string sql = "select count(*) from nhanvien where TENNV='" + txtTNV.Text + "'";
            if (ketNoi.getCount(sql) >0)
            {
                ketNoi.updateToDataBase("delete nhanvien where tennv='"+txtTNV.Text+"'");
                QLNV_Load(sender, e);
            }
            else
            {
                MessageBox.Show("không có nhân viên này");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ketNoi.DbConnection();
            string sql = "select count(*) from nhanvien where TENNV='" + txtTNV.Text + "'";
            if (ketNoi.getCount(sql) > 0)
            {
                ketNoi.updateToDataBase("update nhanvien set tk='"+txtTK.Text+"', pass='"+txtPass.Text+"' where tennv='"+txtTNV.Text+"';");
                QLNV_Load(sender, e);
            }
            else
            {
                MessageBox.Show("không có nhân viên này");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
