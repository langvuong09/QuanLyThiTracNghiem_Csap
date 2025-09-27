using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_PhanQuyen : UserControl
    {

        private NhomQuyenBUS rolebus = new NhomQuyenBUS();
        private ChucNangBUS molbus = new ChucNangBUS();
        CTNhomQuyenBUS cTNhomQuyen = new CTNhomQuyenBUS();

        public Component_PhanQuyen()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            ArrayList list = rolebus.GetListNhomQuyen();
            dgvNhomQuyen.DataSource = list;
        }

        private void btnTaoNhomQuyen_Click(object sender, EventArgs e)
        {
            txtTenNhomQuyen.Text = "";
            ArrayList list = molbus.GetListChucNang();
            dgvPopupChucNang.DataSource = list;
            editMode();
        }

        private void btnHuyPopup_Click(object sender, EventArgs e)
        {
            pnlPopup.Visible = false;
        }

        private void btnLuuPopup_Click(object sender, EventArgs e)
        {
            if (txtTenNhomQuyen.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhóm quyền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenNhomQuyen = txtTenNhomQuyen.Text.Trim();
            Dictionary<int, int[]> permissions = new Dictionary<int, int[]>();
            foreach (DataGridViewRow row in dgvPopupChucNang.Rows)
            {
                int view = Convert.ToInt32(row.Cells["viewcheckbox"].Value);
                int add = Convert.ToInt32(row.Cells["addcheckbox"].Value);
                int edit = Convert.ToInt32(row.Cells["editcheckbox"].Value);
                int delete = Convert.ToInt32(row.Cells["deletecheckbox"].Value);

                if (view == 1 || add == 1 || edit == 1 || delete == 1)
                {
                    int maChucNang = Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn1"].Value);

                    permissions[maChucNang] = new int[] { view, add, edit, delete };

                    //MessageBox.Show(maChucNang.ToString(), "test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (permissions.Count == 0)
            {
                MessageBox.Show("Phải chọn ít nhất một quyền cho nhóm quyền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NhomQuyen? role = rolebus.ThemQuyen(tenNhomQuyen);
            if (role == null)
            {
                MessageBox.Show("Thêm nhóm quyền thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var perm in permissions)
            {
                bool success = cTNhomQuyen.ThemCTNhomQuyen(role.maQuyen,
                                                           perm.Key,
                                                           perm.Value[0],
                                                           perm.Value[1],
                                                           perm.Value[2],
                                                           perm.Value[3]);
                if (!success)
                {
                    MessageBox.Show("Thêm chi tiết nhóm quyền thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Thêm nhóm quyền thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pnlPopup.Visible = false;
        }
        private void dgvNhomQuyen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvNhomQuyen.Columns[e.ColumnIndex].Name == "View")
            {   
                int maQuyen = Convert.ToInt32(dgvNhomQuyen.Rows[e.RowIndex].Cells["colMaQuyen"].Value);
                string tenQuyen = dgvNhomQuyen.Rows[e.RowIndex].Cells["colTenQuyen"].Value.ToString() ?? "";
                txtTenNhomQuyen.Text = tenQuyen;
                List<CTNhomQuyen> listCTNhomQuyen = cTNhomQuyen.FindByMaQuyen(maQuyen);
                dgvPopupChucNang.DataSource = listCTNhomQuyen;
                viewMode();
            }
        }
        private void viewMode()
        {
            txtTenNhomQuyen.ReadOnly = true;
            dgvPopupChucNang.ReadOnly = true;
            btnLuuPopup.Visible = false;
            btnHuyPopup.Text = "Đóng";
            pnlPopup.Visible = true;
            pnlPopup.BringToFront();
            //dgvPopupChucNang.Columns.Remove("maQuyen");

        }
        private void editMode()
        {
            txtTenNhomQuyen.ReadOnly = false;
            dgvPopupChucNang.ReadOnly = false;
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn2.ReadOnly = true;
            btnLuuPopup.Visible = true;
            btnHuyPopup.Text = "Hủy";
            pnlPopup.Visible = true;
            pnlPopup.BringToFront();
            //if (dgvPopupChucNang.Columns["maQuyen"] != null)
            //{
            //    dgvPopupChucNang.Columns.Remove("maQuyen");
            //}
        }
    }
}
