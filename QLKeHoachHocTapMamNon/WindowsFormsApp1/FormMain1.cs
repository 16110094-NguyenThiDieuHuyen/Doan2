using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DALL;

namespace WindowsFormsApp1
{
    public partial class FormMain1 : Form
    {
        private GiaoVien giaoVien;
        public FormMain1()
        {
            InitializeComponent();
        }
        public FormMain1(GiaoVien giaovien)
        {
           this.giaoVien = giaovien;
            InitializeComponent();
            labelten.Text = "Chào " + giaoVien.TenGV;
        }

        private void btnChangePass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangePass changePass = new ChangePass(giaoVien);
            changePass.MdiParent = this;
            changePass.Show();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban Muon Thoat Khoi Chuong Trinh ?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDanhSachHS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HienToanBoDanhSach hienToanBoDanhSach = new HienToanBoDanhSach();
            hienToanBoDanhSach.MdiParent = this;
            hienToanBoDanhSach.Show();
        }

        private void btnTimKiemHS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThongTinHocSinhForm thongTinHocSinhForm = new ThongTinHocSinhForm();
            thongTinHocSinhForm.MdiParent = this;
            thongTinHocSinhForm.Show();
        }

        private void btnGiaoVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GiaoVienForm giaoVienForm = new GiaoVienForm(giaoVien);
            giaoVienForm.MdiParent = this;
            giaoVienForm.Show();
        }
    }
}
