using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL2;
using DALL;

namespace WindowsFormsApp1
{
    public partial class FormLogin : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        BALGV bALGV = new BALGV();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnDN_Click(object sender, EventArgs e)
        {
           if (txtID == null || txtPass == null)
            {
                MessageBox.Show("Mời bạn nhập đủ thông tin");
                txtID.ResetText();
                txtPass.ResetText();
                txtID.Focus();
            }
            else
            {
                GiaoVien giaoVien = new GiaoVien();
                giaoVien = bALGV.getGiaoVien(txtID.Text.Trim(), txtPass.Text.Trim());
                if (giaoVien!= null)
                {
                    this.Hide();
                    FormMain1 frmmain = new FormMain1(giaoVien);
                    frmmain.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!!!");
                    txtID.ResetText();
                    txtPass.ResetText();
                    txtID.Focus();
                }
            } 
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Muốn Thoát???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
