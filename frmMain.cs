using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_04
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void ResetValue()
        {
            txtSoTaiKhoan.Text = "";
            txtTenKhachHang.Text = "";
            txtDiaChiKhachHang.Text = "";
            txtSoTienTrongTaiKhoan.Text = "";
        }

        private int GetSelectedRow(string stk)
        {
            for (int i = 0; i < lvTTTK.Items.Count; i++)
            {
                if (lvTTTK.Items[i].SubItems[1].Text == stk)
                {
                    return i;
                }
            }
            return -1;
        }

        private void btnThemCapNhat_Click(object sender, EventArgs e)
        {
            if (txtSoTaiKhoan.Text == "" || txtTenKhachHang.Text == "" || txtDiaChiKhachHang.Text == "" || txtSoTienTrongTaiKhoan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int selectedRow = GetSelectedRow(txtSoTaiKhoan.Text);
                if (selectedRow == -1)
                {
                    ThemItem();

                    MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CapNhatItem(selectedRow);

                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ThemItem()
        {
            int i = lvTTTK.Items.Count;

            lvTTTK.Items.Add((i + 1).ToString());
            lvTTTK.Items[i].SubItems.Add(txtSoTaiKhoan.Text);
            lvTTTK.Items[i].SubItems.Add(txtTenKhachHang.Text);
            lvTTTK.Items[i].SubItems.Add(txtDiaChiKhachHang.Text);
            lvTTTK.Items[i].SubItems.Add(txtSoTienTrongTaiKhoan.Text);;

            i++;

            ResetValue();

            CapNhatTongTien();
        }

        private void CapNhatItem(int selectedRow)
        {
            lvTTTK.Items.Insert(selectedRow, (selectedRow + 1).ToString());
            lvTTTK.Items[selectedRow].SubItems.Add(txtSoTaiKhoan.Text);
            lvTTTK.Items[selectedRow].SubItems.Add(txtTenKhachHang.Text);
            lvTTTK.Items[selectedRow].SubItems.Add(txtDiaChiKhachHang.Text);
            lvTTTK.Items[selectedRow].SubItems.Add(txtSoTienTrongTaiKhoan.Text);

            lvTTTK.Items.RemoveAt(selectedRow + 1);

            ResetValue();

            CapNhatTongTien();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lvTTTK_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            txtSoTaiKhoan.Text = e.Item.SubItems[1].Text;
            txtTenKhachHang.Text = e.Item.SubItems[2].Text;
            txtDiaChiKhachHang.Text = e.Item.SubItems[3].Text;
            txtSoTienTrongTaiKhoan.Text = e.Item.SubItems[4].Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int selectedRow = GetSelectedRow(txtSoTaiKhoan.Text);
            if (MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                lvTTTK.Items.RemoveAt(selectedRow);
            }

            ResetValue();

            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            long tongTien = 0;

            for (int i = 0; i < lvTTTK.Items.Count; i++)
            {
                tongTien += long.Parse(lvTTTK.Items[i].SubItems[4].Text);
            }

            txtTongTien.Text = tongTien.ToString();
        }
    }
}
