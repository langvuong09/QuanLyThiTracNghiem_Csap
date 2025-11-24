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
            btnLuuPopup.Text = "Thêm";

            foreach (DataGridViewRow row in dgvPopupChucNang.Rows)
            {
                row.Cells["viewcheckbox"].Value = 0;
                row.Cells["addcheckbox"].Value = 0;
                row.Cells["editcheckbox"].Value = 0;
                row.Cells["deletecheckbox"].Value = 0;
            }

            btnLuuPopup.Text = "Thêm";
            editMode();
        }

        private void btnHuyPopup_Click(object sender, EventArgs e)
        {
            pnlPopup.Visible = false;
        }

        private void btnLuuPopup_Click(object sender, EventArgs e)
        {
            string tenNhomQuyen = txtTenNhomQuyen.Text.Trim();

            if (tenNhomQuyen == "")
            {
                MessageBox.Show("Tên nhóm quyền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (btnLuuPopup.Text)
            {
                case "Cập nhật":
                    updateRole(tenNhomQuyen);
                    break;
                case "Thêm":
                    if (rolebus.FindByName(tenNhomQuyen) != null)
                    {
                        MessageBox.Show("Tên nhóm quyền đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    addNewRole(tenNhomQuyen);
                    break;
            }
        }

        private void updateRole(string tenNhomQuyen)
        {
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
            // get maQuyen from selected row in dgvNhomQuyen
            int selectedRowIndex = dgvNhomQuyen.CurrentCell.RowIndex;
            int maQuyen = Convert.ToInt32(dgvNhomQuyen.Rows[selectedRowIndex].Cells["colMaQuyen"].Value);
            // update tenNhomQuyen
            bool updateRoleNameSuccess = rolebus.CapNhatQuyen(maQuyen, tenNhomQuyen);
            if (!updateRoleNameSuccess)
            {
                MessageBox.Show("Cập nhật tên nhóm quyền thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // delete all existing permissions for the role
            bool deleteSuccess = cTNhomQuyen.XoaCTNhomQuyen(maQuyen);
            if (!deleteSuccess)
            {
                MessageBox.Show("Lỗi khi xóa các chi tiết quyền đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // add new permissions
            foreach (var perm in permissions)
            {
                bool success = cTNhomQuyen.ThemCTNhomQuyen(maQuyen,
                                                           perm.Key,
                                                           perm.Value[0],
                                                           perm.Value[1],
                                                           perm.Value[2],
                                                           perm.Value[3]);
                if (!success)
                {
                    MessageBox.Show("Cập nhật chi tiết nhóm quyền thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("Cập nhật quyền thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pnlPopup.Visible = false;
        }
        private void addNewRole(String tenNhomQuyen)
        {
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
            MessageBox.Show("Thêm quyền thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pnlPopup.Visible = false;
        }
        private void dgvNhomQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var colName = dgvNhomQuyen.Columns[e.ColumnIndex].Name;
            int maQuyen = Convert.ToInt32(dgvNhomQuyen.Rows[e.RowIndex].Cells["colMaQuyen"].Value);

            string tenQuyen = dgvNhomQuyen.Rows[e.RowIndex].Cells["colTenQuyen"].Value?.ToString() ?? "";
            if (colName == "View")
            {
                txtTenNhomQuyen.Text = tenQuyen;
                dgvPopupChucNang.DataSource = cTNhomQuyen.FindByMaQuyen(maQuyen);
                viewMode();
            }
            else if (colName == "Delete")
            {
                if (tenQuyen == "admin")
                {
                    MessageBox.Show("Không thể xóa quyền này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var confirmResult = MessageBox.Show("Bạn có chắc chắn xóa nhóm quyền này?",
                                     "Xác nhận xóa",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult != DialogResult.Yes) return;

                if (rolebus.XoaNhomQuyen(maQuyen))
                {
                    MessageBox.Show("Xóa nhóm quyền thành công!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnlPopup.Visible = false;
                    loadData();
                }
            }
            else if (colName == "Edit")
            {
                //string tenQuyen = dgvNhomQuyen.Rows[e.RowIndex].Cells["colTenQuyen"].Value?.ToString() ?? "";
                txtTenNhomQuyen.Text = tenQuyen;
                if (tenQuyen == "admin")
                {
                    MessageBox.Show("Không thể sửa quyền này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                List<CTNhomQuyen> listCTNhomQuyen = cTNhomQuyen.FindByMaQuyen(maQuyen);
                ArrayList list = molbus.GetListChucNang();
                dgvPopupChucNang.DataSource = list;

                foreach (DataGridViewRow row in dgvPopupChucNang.Rows)
                {
                    int maChucNang = Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn1"].Value);
                    var perm = listCTNhomQuyen.FirstOrDefault(p => p.maChucNang == maChucNang);

                    row.Cells["viewcheckbox"].Value = perm?.xem ?? 0;
                    row.Cells["addcheckbox"].Value = perm?.them ?? 0;
                    row.Cells["editcheckbox"].Value = perm?.capNhat ?? 0;
                    row.Cells["deletecheckbox"].Value = perm?.xoa ?? 0;
                }

                btnLuuPopup.Text = "Cập nhật";
                editMode();
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                dgvNhomQuyen.DataSource = rolebus.GetListNhomQuyen(); // reload all
            }
            else
            {
                var allRoles = rolebus.GetListNhomQuyen()
                                      .Cast<NhomQuyen>() // ArrayList → List<NhomQuyen>
                                      .ToList();

                var filtered = allRoles.Where(r =>
                                    r.tenQuyen.ToLower().Contains(keyword) ||
                                    r.maQuyen.ToString().Contains(keyword)
                                )
                                .ToList();

                dgvNhomQuyen.DataSource = filtered;
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
        }
    }
}
