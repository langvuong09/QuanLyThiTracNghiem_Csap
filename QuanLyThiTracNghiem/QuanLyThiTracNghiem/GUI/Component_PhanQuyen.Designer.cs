using QuanLyThiTracNghiem.Properties;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    partial class Component_PhanQuyen
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnTaoNhomQuyen;
        private System.Windows.Forms.DataGridView dgvNhomQuyen;

        private System.Windows.Forms.DataGridViewTextBoxColumn colMaQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenQuyen;
        private System.Windows.Forms.DataGridViewImageColumn colView;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;

        private System.Windows.Forms.Panel pnlPopup;
        private System.Windows.Forms.Label lblTenNhomQuyen;
        private System.Windows.Forms.TextBox txtTenNhomQuyen; 
        private System.Windows.Forms.DataGridView dgvPopupChucNang; 
        private System.Windows.Forms.Button btnLuuPopup;
        private System.Windows.Forms.Button btnHuyPopup;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Component_PhanQuyen));
            txtSearch = new TextBox();
            btnTaoNhomQuyen = new Button();
            dgvNhomQuyen = new DataGridView();
            colMaQuyen = new DataGridViewTextBoxColumn();
            colTenQuyen = new DataGridViewTextBoxColumn();
            colView = new DataGridViewImageColumn();
            colEdit = new DataGridViewImageColumn();
            colDelete = new DataGridViewImageColumn();
            pnlPopup = new Panel();
            lblTenNhomQuyen = new Label();
            txtTenNhomQuyen = new TextBox();
            dgvPopupChucNang = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
            dataGridViewCheckBoxColumn3 = new DataGridViewCheckBoxColumn();
            dataGridViewCheckBoxColumn4 = new DataGridViewCheckBoxColumn();
            btnLuuPopup = new Button();
            btnHuyPopup = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNhomQuyen).BeginInit();
            pnlPopup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPopupChucNang).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm nhóm quyền theo mã/ tên ...";
			txtSearch.Font = new Font("Segoe UI", 12F);
			txtSearch.Size = new Size(400, 30);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;

            // 
            // btnTaoNhomQuyen
            // 
            btnTaoNhomQuyen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTaoNhomQuyen.BackColor = Color.LightSkyBlue;
            btnTaoNhomQuyen.FlatStyle = FlatStyle.Flat;
			btnTaoNhomQuyen.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnTaoNhomQuyen.ForeColor = Color.White;
            btnTaoNhomQuyen.Location = new Point(1350, 15);
            btnTaoNhomQuyen.Name = "btnTaoNhomQuyen";
			btnTaoNhomQuyen.Size = new Size(170, 42);
            btnTaoNhomQuyen.TabIndex = 1;
            btnTaoNhomQuyen.Text = "TẠO NHÓM QUYỀN";
            btnTaoNhomQuyen.UseVisualStyleBackColor = false;
            btnTaoNhomQuyen.Click += btnTaoNhomQuyen_Click;
            // 
            // dgvNhomQuyen
            // 
            dgvNhomQuyen.AllowUserToAddRows = false;
            dgvNhomQuyen.AllowUserToDeleteRows = false;
            dgvNhomQuyen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhomQuyen.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhomQuyen.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(155, 188, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvNhomQuyen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNhomQuyen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhomQuyen.Columns.AddRange(new DataGridViewColumn[] { colMaQuyen, colTenQuyen, colView, colEdit, colDelete });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhomQuyen.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(155, 188, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvNhomQuyen.DefaultCellStyle = dataGridViewCellStyle2;
            dgvNhomQuyen.Location = new Point(20, 70);
            dgvNhomQuyen.Name = "dgvNhomQuyen";
            dgvPopupChucNang.AutoGenerateColumns = false;
            dgvNhomQuyen.ReadOnly = true;
            dgvNhomQuyen.RowHeadersVisible = false;
			dgvNhomQuyen.RowTemplate.Height = 32;
            dgvNhomQuyen.Size = new Size(1500, 830);
            dgvNhomQuyen.TabIndex = 2;
            dgvNhomQuyen.CellClick += dgvNhomQuyen_CellClick;
            // 
            // colMaQuyen
            // 
            colMaQuyen.DataPropertyName = "maQuyen";
            colMaQuyen.HeaderText = "Mã quyền";
            colMaQuyen.Name = "colMaQuyen";
            colMaQuyen.ReadOnly = true;
            colMaQuyen.Width = 200;
            // 
            // colTenQuyen
            // 
            colTenQuyen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTenQuyen.DataPropertyName = "tenQuyen";
            colTenQuyen.HeaderText = "Tên nhóm quyền";
            colTenQuyen.Name = "colTenQuyen";
            colTenQuyen.ReadOnly = true;
            // 
            // colView
            // 
            colView.HeaderText = "Xem";
            colView.Image = Resources.view;
            colView.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colView.Name = "View";
            colView.ReadOnly = true;
            colView.Width = 60;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Sửa";
            colEdit.Image = Resources.edit;
            colEdit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colEdit.Name = "Edit";
            colEdit.ReadOnly = true;
            colEdit.Width = 60;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Xóa";
            colDelete.Image = Resources.delete;
            colDelete.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colDelete.Name = "Delete";
            colDelete.ReadOnly = true;
            colDelete.Width = 60;
            /**************************************************************/
            // 
            // pnlPopup
            // 
            pnlPopup.Anchor = AnchorStyles.None;
            pnlPopup.BackColor = Color.WhiteSmoke;
            pnlPopup.BorderStyle = BorderStyle.FixedSingle;
            pnlPopup.Controls.Add(lblTenNhomQuyen);
            pnlPopup.Controls.Add(txtTenNhomQuyen);
            pnlPopup.Controls.Add(dgvPopupChucNang);
            pnlPopup.Controls.Add(btnLuuPopup);
            pnlPopup.Controls.Add(btnHuyPopup);
            pnlPopup.Location = new Point(354, 226);
            pnlPopup.Name = "pnlPopup";
            pnlPopup.Size = new Size(700, 565);
            pnlPopup.TabIndex = 0;
            pnlPopup.Visible = false;
            // 
            // lblTenNhomQuyen
            // 
            lblTenNhomQuyen.AutoSize = true;
			lblTenNhomQuyen.Font = new Font("Segoe UI", 12F);
            lblTenNhomQuyen.Location = new Point(20, 20);
            lblTenNhomQuyen.Name = "lblTenNhomQuyen";
			lblTenNhomQuyen.Size = new Size(97, 15);
            lblTenNhomQuyen.TabIndex = 0;
            lblTenNhomQuyen.Text = "Tên nhóm quyền";
            // 
            // txtTenNhomQuyen
            // 
			txtTenNhomQuyen.Location = new Point(150, 18);
			txtTenNhomQuyen.Font = new Font("Segoe UI", 12F);
            txtTenNhomQuyen.Name = "txtTenNhomQuyen";
            txtTenNhomQuyen.PlaceholderText = "VD: Giảng viên";
			txtTenNhomQuyen.Size = new Size(300, 30);
            txtTenNhomQuyen.TabIndex = 1;
            // 
            // dgvPopupChucNang
            // 
            dgvPopupChucNang.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPopupChucNang.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(155, 188, 255);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPopupChucNang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPopupChucNang.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewCheckBoxColumn1, dataGridViewCheckBoxColumn2, dataGridViewCheckBoxColumn3, dataGridViewCheckBoxColumn4 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvPopupChucNang.DefaultCellStyle = dataGridViewCellStyle4;
            dgvPopupChucNang.Location = new Point(20, 64);
            dgvPopupChucNang.Name = "dgvPopupChucNang";
            dgvPopupChucNang.RowHeadersVisible = false;
            dgvPopupChucNang.Size = new Size(656, 450);
            dgvPopupChucNang.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "maChucNang";
            dataGridViewTextBoxColumn1.HeaderText = "Mã chức năng";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.DataPropertyName = "tenChucNang";
            dataGridViewTextBoxColumn2.HeaderText = "Chức năng";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "xem";
            dataGridViewCheckBoxColumn1.FalseValue = 0;
            dataGridViewCheckBoxColumn1.HeaderText = "Xem";
            dataGridViewCheckBoxColumn1.IndeterminateValue = resources.GetObject("dataGridViewCheckBoxColumn1.IndeterminateValue");
            dataGridViewCheckBoxColumn1.Name = "viewcheckbox";
            dataGridViewCheckBoxColumn1.TrueValue = 1;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            dataGridViewCheckBoxColumn2.DataPropertyName = "them";
            dataGridViewCheckBoxColumn2.FalseValue = 0;
            dataGridViewCheckBoxColumn2.HeaderText = "Thêm";
            dataGridViewCheckBoxColumn2.IndeterminateValue = resources.GetObject("dataGridViewCheckBoxColumn2.IndeterminateValue");
            dataGridViewCheckBoxColumn2.Name = "addcheckbox";
            dataGridViewCheckBoxColumn2.TrueValue = 1;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            dataGridViewCheckBoxColumn3.DataPropertyName = "capNhat";
            dataGridViewCheckBoxColumn3.FalseValue = 0;
            dataGridViewCheckBoxColumn3.HeaderText = "Sửa";
            dataGridViewCheckBoxColumn3.IndeterminateValue = resources.GetObject("dataGridViewCheckBoxColumn3.IndeterminateValue");
            dataGridViewCheckBoxColumn3.Name = "editcheckbox";
            dataGridViewCheckBoxColumn3.TrueValue = 1;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            dataGridViewCheckBoxColumn4.DataPropertyName = "xoa";
            dataGridViewCheckBoxColumn4.FalseValue = 0;
            dataGridViewCheckBoxColumn4.HeaderText = "Xóa";
            dataGridViewCheckBoxColumn4.IndeterminateValue = resources.GetObject("dataGridViewCheckBoxColumn4.IndeterminateValue");
            dataGridViewCheckBoxColumn4.Name = "deletecheckbox";
            dataGridViewCheckBoxColumn4.TrueValue = 1;
            // 
            // btnLuuPopup
            // 
            btnLuuPopup.BackColor = Color.LightSkyBlue;
            btnLuuPopup.FlatStyle = FlatStyle.Flat;
            btnLuuPopup.ForeColor = Color.White;
			btnLuuPopup.Location = new Point(319, 520);
			btnLuuPopup.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLuuPopup.Name = "btnLuuPopup";
			btnLuuPopup.Size = new Size(96, 36);
            btnLuuPopup.TabIndex = 3;
            //btnLuuPopup.Text = "Lưu";
            btnLuuPopup.UseVisualStyleBackColor = false;
            btnLuuPopup.Click += btnLuuPopup_Click;
            // 
            // btnHuyPopup
            // 
			btnHuyPopup.Location = new Point(609, 20);
			btnHuyPopup.Font = new Font("Segoe UI", 12F);
            btnHuyPopup.Name = "btnHuyPopup";
			btnHuyPopup.Size = new Size(80, 30);
            btnHuyPopup.TabIndex = 4;
            btnHuyPopup.Text = "Hủy";
            btnHuyPopup.Click += btnHuyPopup_Click;
            // 
            // Component_PhanQuyen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlPopup);
            Controls.Add(dgvNhomQuyen);
            Controls.Add(btnTaoNhomQuyen);
            Controls.Add(txtSearch);
            Name = "Component_PhanQuyen";
            Size = new Size(1541, 934);
            ((System.ComponentModel.ISupportInitialize)dgvNhomQuyen).EndInit();
            pnlPopup.ResumeLayout(false);
            pnlPopup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPopupChucNang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
    }
}
