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
    public partial class ChangePass : Form

    {
        private BALGV bALGV = new BALGV();
        private GiaoVien giaoVien = new GiaoVien();
        public ChangePass()
        {
            InitializeComponent();
        }
        public ChangePass(GiaoVien giaoVien)
        {
            this.giaoVien = giaoVien;
            InitializeComponent();
        }
        private void ChangePass_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban Muon Huy?", "Thong Bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
           if(txtPassold.Text.Trim() !=null && txtPassnew.Text.Trim() !=null && txtXacNhan.Text.Trim()!=null)
           {
                if(txtPassnew.Text.Trim() == txtXacNhan.Text.Trim())
                {
                    if(txtPassnew.Text.Trim()!=txtPassold.Text.Trim())
                    {
                        MessageBox.Show(txtPassold.Text.Trim()+"-"+giaoVien.Password);
                        if(txtPassold.Text.Trim() != giaoVien.Password)
                        {
                            MessageBox.Show("Bạn không thay đổi mật khẩu thành công!! Hãy thử kiểm tra lại mật khẩu cũ đúng chưa");
                            txtPassnew.ResetText();
                            txtPassold.ResetText();
                            txtXacNhan.ResetText();
                            txtPassold.Focus();
                        }
                        else
                        {
                            
                            bALGV.CapNhapPass(giaoVien, txtPassnew.Text.Trim());
                            MessageBox.Show("Bạn đã đổi mật khẩu thành công!!!", "Thông Báo");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Mời bạn mật khẩu mới khác với mật khẩu cũ!", "Thông Báo");
                        txtPassnew.ResetText();
                        txtPassold.ResetText();
                        txtXacNhan.ResetText();
                        txtPassold.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Mời bạn nhập mật khẩu mới cho đúng!", "Thông Báo");
                    txtPassnew.ResetText();
                    txtPassold.ResetText();
                    txtXacNhan.ResetText();
                    txtPassold.Focus();
                }
            }
           else
            {
                MessageBox.Show("Moi ban nhap day du thong tin", "Thong Bao");
                txtPassnew.ResetText();
                txtPassold.ResetText();
                txtXacNhan.ResetText();
                txtPassold.Focus();
            }
        }
    }
}
