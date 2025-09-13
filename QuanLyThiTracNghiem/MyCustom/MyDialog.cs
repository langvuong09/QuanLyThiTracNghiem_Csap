using System;


namespace QuanLyThiTracNghiem.MyCustom
{
    internal class MyDialog : Form
    {
        private string content;
        private int type;
        public const int ERROR_DIALOG = 1;
        public const int SUCCESS_DIALOG = 2;
        public const int INFO_DIALOG = 3;
        public const int WARNING_DIALOG = 4;

        private Panel pnMain, pnTop, pnBottom, pnButton, pnHeader;
        private Label lblIcon, lblContent, lblClose;
        private Button btnOK, btnCancel;
        private PictureBox iconPicture;

        public int Action { get; private set; }
        public const int OK_OPTION = 1;
        public const int CANCEL_OPTION = 2;

        public MyDialog(string content, int type)
        {
            this.content = content;
            this.type = type;
            InitializeComponents();
            AddEvents();
        }

        private void InitializeComponents()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;

            pnMain = new Panel() { Dock = DockStyle.Fill, BackColor = Color.White };
            pnTop = new Panel() { Dock = DockStyle.Top, Height = 50, BackColor = Color.White };
            pnBottom = new Panel() { Dock = DockStyle.Fill, BackColor = Color.White };
            pnButton = new Panel() { Dock = DockStyle.Bottom, Height = 50, BackColor = Color.White };
            pnHeader = new Panel() { Dock = DockStyle.Top, Height = 25 };

            lblClose = new Label()
            {
                Text = "X",
                ForeColor = Color.White,
                Dock = DockStyle.Right,
                Cursor = Cursors.Hand,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Width = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblContent = new Label()
            {
                Text = content,
                Font = new Font("Arial", 12),
                ForeColor = Color.Black,
                AutoSize = false,
                Size = new Size(350, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(25, 50) // Đưa dòng chữ lên trên
            };

            iconPicture = new PictureBox()
            {
                Size = new Size(70, 70),
                Location = new Point(165, 110), // Đưa icon xuống dưới dòng chữ
                SizeMode = PictureBoxSizeMode.Zoom
            };

            btnOK = new Button() { Text = "OK", Width = 80, Height = 30 };
            btnCancel = new Button() { Text = "Cancel", Width = 80, Height = 30, Visible = false };

            btnOK.Location = new Point(160, 10);
            btnCancel.Location = new Point(250, 10);

            // Thiết lập icon và màu sắc theo loại thông báo
            Color headerColor = Color.Gray;
            switch (type)
            {
                case ERROR_DIALOG:
                    headerColor = Color.FromArgb(220, 53, 69);
                    iconPicture.Image = Image.FromFile("image/icons8_cancel_70px.png");
                    break;
                case SUCCESS_DIALOG:
                    headerColor = Color.FromArgb(40, 167, 69);
                    iconPicture.Image = Image.FromFile("image/icons8_checkmark_70px.png");
                    break;
                case INFO_DIALOG:
                    headerColor = Color.FromArgb(0, 123, 255);
                    iconPicture.Image = Image.FromFile("image/icons8_info_70px.png");
                    break;
                case WARNING_DIALOG:
                    headerColor = Color.FromArgb(255, 193, 7);
                    iconPicture.Image = Image.FromFile("image/icons8_warning_shield_70px.png");
                    btnCancel.Visible = true;
                    break;
            }

            pnHeader.BackColor = headerColor;
            lblClose.BackColor = headerColor;

            // Thêm các thành phần vào form
            pnHeader.Controls.Add(lblClose);
            pnBottom.Controls.Add(lblContent);
            pnBottom.Controls.Add(iconPicture);
            pnButton.Controls.Add(btnOK);
            pnButton.Controls.Add(btnCancel);

            pnMain.Controls.Add(pnHeader);
            pnMain.Controls.Add(pnButton);
            pnMain.Controls.Add(pnBottom);
            this.Controls.Add(pnMain);
        }

        private void AddEvents()
        {
            lblClose.Click += (s, e) => CloseDialog();
            btnOK.Click += (s, e) => { Action = OK_OPTION; CloseDialog(); };
            btnCancel.Click += (s, e) => { Action = CANCEL_OPTION; CloseDialog(); };

            // Kéo cửa sổ bằng chuột
            pnHeader.MouseDown += (s, e) => { xMouse = e.X; yMouse = e.Y; dragging = true; };
            pnHeader.MouseMove += (s, e) => { if (dragging) MoveForm(e.X, e.Y); };
            pnHeader.MouseUp += (s, e) => { dragging = false; };
        }

        private int xMouse, yMouse;
        private bool dragging = false;

        private void MoveForm(int x, int y)
        {
            this.Left += x - xMouse;
            this.Top += y - yMouse;
        }

        private void CloseDialog()
        {
            this.Close();
        }
    }
}
