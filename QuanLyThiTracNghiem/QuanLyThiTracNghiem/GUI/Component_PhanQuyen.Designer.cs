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
            txtSearch = new TextBox();
            btnTaoNhomQuyen = new Button();
            dgvNhomQuyen = new DataGridView();
            colMaQuyen = new DataGridViewTextBoxColumn();
            colTenQuyen = new DataGridViewTextBoxColumn();
            colView = new DataGridViewImageColumn();
            colEdit = new DataGridViewImageColumn();
            colDelete = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)dgvNhomQuyen).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(20, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm nhóm quyền...";
            txtSearch.Size = new Size(400, 23);
            txtSearch.TabIndex = 0;
            // 
            // btnTaoNhomQuyen
            // 
            btnTaoNhomQuyen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTaoNhomQuyen.BackColor = Color.LightSkyBlue;
            btnTaoNhomQuyen.FlatStyle = FlatStyle.Flat;
            btnTaoNhomQuyen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTaoNhomQuyen.ForeColor = Color.White;
            btnTaoNhomQuyen.Location = new Point(1350, 15);
            btnTaoNhomQuyen.Name = "btnTaoNhomQuyen";
            btnTaoNhomQuyen.Size = new Size(170, 35);
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
            dgvNhomQuyen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhomQuyen.Columns.AddRange(new DataGridViewColumn[] { colMaQuyen, colTenQuyen, colView, colEdit, colDelete });
            dgvNhomQuyen.Location = new Point(20, 70);
            dgvNhomQuyen.Name = "dgvNhomQuyen";
            dgvNhomQuyen.RowHeadersVisible = false;
            dgvNhomQuyen.Size = new Size(1500, 830);
            dgvNhomQuyen.TabIndex = 2;
            // 
            // colMaQuyen
            // 
            colMaQuyen.DataPropertyName = "maQuyen";
            colMaQuyen.HeaderText = "Mã quyền";
            colMaQuyen.Name = "colMaQuyen";
            colMaQuyen.Width = 200;
            // 
            // colTenQuyen
            // 
            colTenQuyen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTenQuyen.DataPropertyName = "tenQuyen";
            colTenQuyen.HeaderText = "Tên nhóm quyền";
            colTenQuyen.Name = "colTenQuyen";
            // 
            // colView
            // 
            colView.HeaderText = "Xem";
            colView.Image = Properties.Resources.view;
            colView.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colView.Name = "colView";
            colView.Width = 60;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "Sửa";
            colEdit.Image = Properties.Resources.edit;
            colEdit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colEdit.Name = "colEdit";
            colEdit.Width = 60;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "Xóa";
            colDelete.Image = Properties.Resources.delete;
            colDelete.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colDelete.Name = "colDelete";
            colDelete.Width = 60;
            // 
            // Component_PhanQuyen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvNhomQuyen);
            Controls.Add(btnTaoNhomQuyen);
            Controls.Add(txtSearch);
            Name = "Component_PhanQuyen";
            Size = new Size(1541, 934);
            ((System.ComponentModel.ISupportInitialize)dgvNhomQuyen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        
        #endregion
    }
}
