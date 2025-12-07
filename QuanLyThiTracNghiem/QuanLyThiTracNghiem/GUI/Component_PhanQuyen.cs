using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Data;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_PhanQuyen : UserControl
    {
        private NhomQuyenBUS rolebus = new NhomQuyenBUS();
        private ChucNangBUS molbus = new ChucNangBUS();
        private CTNhomQuyenBUS cTNhomQuyenBUS = new CTNhomQuyenBUS();
         
        public Component_PhanQuyen()
        {
            InitializeComponent();
            CheckPhanQuyen();
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
                MyDialog dlg = new MyDialog("Tên nhóm quyền không được để trống!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
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
                        MyDialog dlg = new MyDialog("Tên nhóm quyền đã tồn tại!", MyDialog.ERROR_DIALOG);
                        dlg.ShowDialog();
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
                MyDialog dlg2 = new MyDialog("Phải chọn ít nhất một quyền cho nhóm quyền!", MyDialog.ERROR_DIALOG);
                dlg2.ShowDialog();
                return;
            }
            // get maQuyen from selected row in dgvNhomQuyen
            int selectedRowIndex = dgvNhomQuyen.CurrentCell.RowIndex;
            int maQuyen = Convert.ToInt32(dgvNhomQuyen.Rows[selectedRowIndex].Cells["colMaQuyen"].Value);
            // update tenNhomQuyen
            bool updateRoleNameSuccess = rolebus.CapNhatQuyen(maQuyen, tenNhomQuyen);
            if (!updateRoleNameSuccess)
            {
                MyDialog dlg3 = new MyDialog("Cập nhật tên nhóm quyền thất bại!", MyDialog.ERROR_DIALOG);
                dlg3.ShowDialog();
                return;
            }
            // delete all existing permissions for the role
            bool deleteSuccess = cTNhomQuyenBUS.XoaCTNhomQuyen(maQuyen);
            if (!deleteSuccess)
            {
                MyDialog dlg3 = new MyDialog("Lỗi khi xóa các chi tiết quyền đã tồn tại!", MyDialog.ERROR_DIALOG);
                dlg3.ShowDialog();
                return;
            }
            // add new permissions
            foreach (var perm in permissions)
            {
                bool success = cTNhomQuyenBUS.ThemCTNhomQuyen(maQuyen,
                                                           perm.Key,
                                                           perm.Value[0],
                                                           perm.Value[1],
                                                           perm.Value[2],
                                                           perm.Value[3]);
                if (!success)
                {
                    MyDialog dlg1 = new MyDialog("Cập nhật chi tiết nhóm quyền thất bại!", MyDialog.ERROR_DIALOG);
                    dlg1.ShowDialog();
                    return;
                }
            }
            MyDialog dlg = new MyDialog("Cập nhật quyền thành công!", MyDialog.SUCCESS_DIALOG);
            dlg.ShowDialog();
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
                MyDialog dlg2 = new MyDialog("Phải chọn ít nhất một quyền cho nhóm quyền!", MyDialog.ERROR_DIALOG);
                dlg2.ShowDialog();
                return;
            }

            NhomQuyen? role = rolebus.ThemQuyen(tenNhomQuyen);
            if (role == null)
            {
                MyDialog dlg2 = new MyDialog("Thêm nhóm quyền thất bại!", MyDialog.ERROR_DIALOG);
                dlg2.ShowDialog();
                return;
            }

            foreach (var perm in permissions)
            {
                bool success = cTNhomQuyenBUS.ThemCTNhomQuyen(role.maQuyen,
                                                           perm.Key,
                                                           perm.Value[0],
                                                           perm.Value[1],
                                                           perm.Value[2],
                                                           perm.Value[3]);
                if (!success)
                {
                    MyDialog dlg = new MyDialog("Thêm chi tiết nhóm quyền thất bại!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return;
                }
            }
            MyDialog dlg1 = new MyDialog("Thêm quyền thành công!", MyDialog.SUCCESS_DIALOG);
            dlg1.ShowDialog();
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
                dgvPopupChucNang.DataSource = cTNhomQuyenBUS.FindByMaQuyen(maQuyen);
                viewMode();
            }
            else if (colName == "Delete")
            {
                if (tenQuyen == "admin")
                {
                    MyDialog dlg = new MyDialog("Không thể xóa quyền này!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return;
                }
                var confirmResult = MessageBox.Show("Bạn có chắc chắn xóa nhóm quyền này?",
                                     "Xác nhận xóa",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult != DialogResult.Yes) return;

                if (rolebus.XoaNhomQuyen(maQuyen))
                {
                    MyDialog dlg1 = new MyDialog("Xóa nhóm quyền thành công!", MyDialog.SUCCESS_DIALOG);
                    dlg1.ShowDialog();
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
                    MyDialog dlg = new MyDialog("Không thể sửa quyền này!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return;
                }
                List<CTNhomQuyen> listCTNhomQuyen = cTNhomQuyenBUS.FindByMaQuyen(maQuyen);
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

        private void CheckPhanQuyen()
        {
            ArrayList dspq = cTNhomQuyenBUS.GetListCTNhomQuyen(UserSession.Quyen);
            foreach(CTNhomQuyen pq in dspq)
            {
                if(pq.maChucNang == 7)
                {
                    if(pq.them == 0)
                    {
                        btnTaoNhomQuyen.Visible = false;
                    }
                    if(pq.xoa == 0)
                    {
                        dgvNhomQuyen.Columns["Xóa"].Visible = false;
                    }
                    if(pq.capNhat == 0)
                    {
                        dgvNhomQuyen.Columns["Sửa"].Visible = false;
                    }
                    if(pq.xem == 0)
                    {
                        dgvNhomQuyen.Columns["Xem"].Visible = false;
                    }
                }                    
            }
        }
    }
}
