using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL2;
using DALL;

namespace WindowsFormsApp1
{
    public partial class GiaoVienForm : Form
    {
        QLKHHTMNEntities db = new QLKHHTMNEntities();
        private BALGV bALGV = new BALGV();
        private GiaoVien giaoVien = new GiaoVien();

        public GiaoVienForm()
        {
            InitializeComponent();
        }
        public GiaoVienForm(GiaoVien giaoVien)
        {
            this.giaoVien = giaoVien;
            InitializeComponent();
        }
        public void ChucNang()
        {
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnTimKiem.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
        }
        public void LuuHuy()
        {
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnSua.Enabled = false;
            btnThem.Enabled = false;
            btnTimKiem.Enabled = false;
            btnXoa.Enabled = false;
        }
        public void load()
        {
            var cb = from gv in db.GiaoViens
                     select new { gv.MaGV };
            dataGridView1.DataSource = cb.ToList();
            dataGridView1_CellClick(null, null);
            ChucNang();
            
            //chuyen len pannel
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            // chuyen len panel
            txtMa.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            txtTen.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            txtBoMon.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            pictureBox1.Image = (System.Drawing.Image)dataGridView1.Rows[r].Cells[4].FormattedValue;
        }

        private void GiaoVienForm_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
