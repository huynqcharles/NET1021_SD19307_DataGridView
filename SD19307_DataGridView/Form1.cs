using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SD19307_DataGridView
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        private int indexHienTai = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // them cac cot cho DataGridView
            //dgvDSSinhVien.Columns.Add("ID", "ID");
            //dgvDSSinhVien.Columns.Add("HoTen", "Ho Ten");
            //dgvDSSinhVien.Columns.Add("MonHoc", "Mon Hoc");
            //dgvDSSinhVien.Columns.Add("GioiTinh", "Gioi Tinh");

            // them cac cot cho DataTable dt
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("MonHoc", typeof(string));
            dt.Columns.Add("GioiTinh", typeof(bool));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // lay thong tin tu form 
            int id = Convert.ToInt32(txtID.Text);
            string hoTen = txtHoTen.Text;
            string monHoc = txtMonHoc.Text;
            bool gioiTinh = true;
            if (rdoNam.Checked == true)
            {
                gioiTinh = true;
            }
            if (rdoNu.Checked == true)
            {
                gioiTinh = false;
            }

            // co 2 cach de them 1 row vao DataGridView
            // cach 1
            //dgvDSSinhVien.Rows.Add(id, hoTen, monHoc, gioiTinh);

            // cach 2
            //DataGridViewRow dr = new DataGridViewRow();
            //dr.CreateCells(dgvDSSinhVien);
            //dr.Cells[0].Value = id;
            //dr.Cells[1].Value = hoTen;
            //dr.Cells[2].Value = monHoc;
            //dr.Cells[3].Value = gioiTinh;

            //dgvDSSinhVien.Rows.Add(dr);

            // them 1 row vao DataTable dt
            DataRow dataRow = dt.NewRow();
            dataRow["ID"] = id;
            dataRow["HoTen"] = hoTen;
            dataRow["MonHoc"] = monHoc;
            dataRow["GioiTinh"] = gioiTinh;
            dt.Rows.Add(dataRow);

            dgvDSSinhVien.DataSource = dt;
        }

        private void dgvDSSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvDSSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgvDSSinhVien.Rows[e.RowIndex];
            txtID.Text = selectedRow.Cells[0].Value.ToString();
            txtHoTen.Text = selectedRow.Cells[1].Value.ToString();
            txtMonHoc.Text = selectedRow.Cells[2].Value.ToString();
            if (selectedRow.Cells[3].Value.ToString() == "True")
            {
                rdoNam.Checked = true;
            }
            if (selectedRow.Cells[3].Value.ToString() == "False")
            {
                rdoNu.Checked = true;
            }

            indexHienTai = e.RowIndex;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataRow rowHientai = dt.Rows[indexHienTai];
            rowHientai["ID"] = Convert.ToInt32(txtID.Text);
            rowHientai["HoTen"] = txtHoTen.Text;
            rowHientai["MonHoc"] = txtMonHoc.Text;
            if (rdoNam.Checked == true)
            {
                rowHientai["GioiTinh"] = true;
            }
            if (rdoNu.Checked == true)
            {
                rowHientai["GioiTinh"] = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dt.Rows.RemoveAt(indexHienTai);
        }
    }
}
