using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL2;
using DALL;

namespace WindowsFormsApp
{
    public partial class GiaoVienForm : Form
    {
        MemoryStream ms;
        byte[] arrImage = null;// mang dung de doc du lieu hinh anh
        bool them = false;
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
                         select new { gv.MaGV, gv.TenGV, gv.BoMon, gv.Hinh };
                dataGridView1.DataSource = cb.ToList();
                dataGridView1_CellClick(null, null);
                ChucNang();
                txtTen.ResetText();
                txtMa.ResetText();
                txtBoMon.ResetText();
                //chuyen len pannel
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            // chuyen len panel
            txtMa.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            txtTen.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            txtBoMon.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            pictureBox1.Image = (System.Drawing.Image)dataGridView1.Rows[r].Cells[3].FormattedValue;
        }

        private void GiaoVienForm_Load(object sender, EventArgs e)
        {
            if (giaoVien.Quyen <= 2)
            {
                load();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền coi thông tin này!!!");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(giaoVien.Quyen ==1)
            {
                them = true;
                txtMa.ResetText();
                txtTen.ResetText();
                txtBoMon.ResetText();
                txtMa.Enabled = true;
                LuuHuy();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa thông tin giáo viên");
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (giaoVien.Quyen == 1)
            {
                them = false;
                txtMa.ResetText();
                LuuHuy();
                txtMa.Enabled = false;
            }
            else
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa thông tin giáo viên");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (giaoVien.Quyen == 1)
            {
                // lay dong hien hanh 
                int r = dataGridView1.CurrentCell.RowIndex;
                // lấy giao vien
                GiaoVien fv = bALGV.getGVien(dataGridView1.Rows[r].Cells[0].ToString());
                bALGV.Delte(fv);
                MessageBox.Show("Bạn đã xóa thành công");

            }
            else
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa thông tin giáo viên");
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            load();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtFind.Text.Trim()!= null)
            {
                List<object> gVien = bALGV.getGiaoVien(txtFind.Text.Trim());

                    dataGridView1.DataSource = bALGV.getGiaoVien(txtFind.Text.Trim());
                    txtFind.ResetText();
                if(dataGridView1.RowCount > 0)
                { 
                    dataGridView1_CellClick(null, null);

                }
                else MessageBox.Show("Không Tìm thấy giáo viên");
            }
            else
            {
                MessageBox.Show("Moi bạn nhập mã giáo viên cần tìm!!!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
           DialogResult result = MessageBox.Show("Bạn muốn hủy chỉnh sửa???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                load();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn lưu thông tin ??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if(them)
                {
                    GiaoVien gv = new GiaoVien();
                    gv.MaGV = txtMa.Text.Trim();
                    gv.TenGV = txtTen.Text.Trim();
                    gv.Hinh = arrImage;
                    bALGV.Insert(gv);
                    MessageBox.Show("Thêm thành công!!!");
                    load();
                }
                else
                {
                    GiaoVien gv = new GiaoVien();
                    gv = bALGV.getGVien(txtMa.Text.Trim());
                    gv.TenGV = txtTen.Text.Trim();
                    gv.BoMon = txtBoMon.Text.Trim();
                    gv.Hinh = arrImage;
                    bALGV.Update(gv);
                    MessageBox.Show("Cập nhập thành công!!!");
                    load();
                }
            }
        }
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog odlgOpenFile = new OpenFileDialog();
            odlgOpenFile.InitialDirectory = "C:\\";
            odlgOpenFile.Title = "Open File";
            odlgOpenFile.Filter = "Image files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp|All files (*.*)|*.*";
            if (odlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(odlgOpenFile.FileName);
                //
                ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                arrImage = ms.GetBuffer();
                ms.Close();
            }
        }
    }
}
