using BUS;
using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySach
{
    public partial class QuanLySach : Form
    {
        int index = -1; 
        public QuanLySach()
        {
            InitializeComponent();
        }

        private void fillDGV()
        {
            dataGridView1.DataSource = SachService.getAllSach();
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }
        private void fillCategorySach()
        {
            cbbCategory.DataSource = LoaiSachService.getAllLoaiSach();
            cbbCategory.DisplayMember = "TenLoai";
            cbbCategory.ValueMember = "MaLoai";
        }
        bool KTInput()
        {
            if (txtID.Text == "" || txtName.Text == "" || txtYear.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách!");
                return false;
            }
            if (txtID.Text.Length != 6)
            {
                MessageBox.Show("Mã số phải có 6 kí tự!");
                txtID.Focus();
                return false;
            }
            
            if(!int.TryParse(txtYear.Text, out int result))
            {
                MessageBox.Show("Nhập đúng định dạng năm");
                txtYear.Focus();
                return false;
            }
           
            return true;
        }

        void ClearInput()
        {
            txtID.Clear(); ; txtName.Clear(); ; txtYear.Clear(); cbbCategory.SelectedIndex = 0;
        }
        private void QuanLySach_Load(object sender, EventArgs e)
        {
            fillCategorySach();
            fillDGV();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                return;
            }
            txtID.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtYear.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            cbbCategory.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!KTInput())
            {
                return;
            }
            string id = txtID.Text;
            string name = txtName.Text; 
            int year = Convert.ToInt32(txtYear.Text);   
            int theloai = Convert.ToInt32(cbbCategory.SelectedValue);

            Sach sach = new Sach()
            {
                MaSach = id,
                TenSach = name,
                NamXB = year,
                MaLoai = theloai,
            };
            if (SachService.addSach(sach))
            {
                MessageBox.Show("Thêm thành công!","Thông báo");
                fillDGV();
            }
            else
            {
                MessageBox.Show("Mã số sách đã tồn tại!", "Thông báo");

            }
            ClearInput();
        }

        private void bntFix_Click(object sender, EventArgs e)
        {
            if (!KTInput())
            {
                return;
            }
            string id = txtID.Text;
            string name = txtName.Text;
            int year = Convert.ToInt32(txtYear.Text);
            int theloai = Convert.ToInt32(cbbCategory.SelectedValue);
            Sach sach = new Sach()
            {
                MaSach = id,
                TenSach = name,
                NamXB = year,
                MaLoai = theloai,
            };
            if (SachService.fixSach(sach))
            {
                MessageBox.Show("Update thành công!", "Thông báo");
                fillDGV();
            }
            else
            {
                MessageBox.Show("Lỗi!", "Thông báo");

            }
            ClearInput();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(SachService.deleteSach(txtID.Text))
            {
                MessageBox.Show("Xóa thành công");
                fillDGV();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xóa", "Thông báo");

            }
            ClearInput();
        }

        private void thốngKêSáchTheoNămToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReportQLSach formReportQLSach = new FormReportQLSach();
            formReportQLSach.ShowDialog();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string key = txtFind.Text;
            if(!string.IsNullOrWhiteSpace(key))
            {
                List<Sach> listSach = SachRepo.SearchListSach(key);
                dataGridView1.DataSource = listSach;
            }
            else
            {
                dataGridView1.DataSource = SachService.getAllSach();
            }
        }
    }
}
