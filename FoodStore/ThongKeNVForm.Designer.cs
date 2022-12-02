
namespace CoffeShop_DBMS
{
    partial class ThongKeNVForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtThongKeNVName = new System.Windows.Forms.TextBox();
            this.btnThongKeNV = new System.Windows.Forms.Button();
            this.dtpkToNV = new System.Windows.Forms.DateTimePicker();
            this.dtpkFromNV = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTongDoanhThuNV = new System.Windows.Forms.TextBox();
            this.dtgvThongKeNV = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeNV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SandyBrown;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtThongKeNVName);
            this.panel1.Controls.Add(this.btnThongKeNV);
            this.panel1.Controls.Add(this.dtpkToNV);
            this.panel1.Controls.Add(this.dtpkFromNV);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 87);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(521, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tên Nhân Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đến ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Từ Ngày";
            // 
            // txtThongKeNVName
            // 
            this.txtThongKeNVName.Location = new System.Drawing.Point(468, 44);
            this.txtThongKeNVName.Name = "txtThongKeNVName";
            this.txtThongKeNVName.Size = new System.Drawing.Size(216, 22);
            this.txtThongKeNVName.TabIndex = 3;
            // 
            // btnThongKeNV
            // 
            this.btnThongKeNV.Location = new System.Drawing.Point(702, 17);
            this.btnThongKeNV.Name = "btnThongKeNV";
            this.btnThongKeNV.Size = new System.Drawing.Size(143, 50);
            this.btnThongKeNV.TabIndex = 2;
            this.btnThongKeNV.Text = "Thống kê";
            this.btnThongKeNV.UseVisualStyleBackColor = true;
            this.btnThongKeNV.Click += new System.EventHandler(this.btnThongKeNV_Click);
            // 
            // dtpkToNV
            // 
            this.dtpkToNV.Location = new System.Drawing.Point(245, 45);
            this.dtpkToNV.Name = "dtpkToNV";
            this.dtpkToNV.Size = new System.Drawing.Size(200, 22);
            this.dtpkToNV.TabIndex = 1;
            this.dtpkToNV.Value = new System.DateTime(2022, 5, 8, 0, 0, 0, 0);
            // 
            // dtpkFromNV
            // 
            this.dtpkFromNV.Location = new System.Drawing.Point(18, 45);
            this.dtpkFromNV.Name = "dtpkFromNV";
            this.dtpkFromNV.Size = new System.Drawing.Size(200, 22);
            this.dtpkFromNV.TabIndex = 0;
            this.dtpkFromNV.Value = new System.DateTime(2022, 5, 8, 0, 0, 0, 0);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTongDoanhThuNV);
            this.panel2.Controls.Add(this.dtgvThongKeNV);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(12, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(867, 356);
            this.panel2.TabIndex = 2;
            // 
            // txtTongDoanhThuNV
            // 
            this.txtTongDoanhThuNV.Location = new System.Drawing.Point(690, 318);
            this.txtTongDoanhThuNV.Name = "txtTongDoanhThuNV";
            this.txtTongDoanhThuNV.Size = new System.Drawing.Size(146, 22);
            this.txtTongDoanhThuNV.TabIndex = 4;
            this.txtTongDoanhThuNV.Text = "0";
            this.txtTongDoanhThuNV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtgvThongKeNV
            // 
            this.dtgvThongKeNV.BackgroundColor = System.Drawing.Color.LightSalmon;
            this.dtgvThongKeNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongKeNV.Location = new System.Drawing.Point(4, 4);
            this.dtgvThongKeNV.Name = "dtgvThongKeNV";
            this.dtgvThongKeNV.RowHeadersWidth = 51;
            this.dtgvThongKeNV.RowTemplate.Height = 24;
            this.dtgvThongKeNV.Size = new System.Drawing.Size(860, 303);
            this.dtgvThongKeNV.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(562, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tổng doanh thu:";
            // 
            // ThongKeNVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 469);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ThongKeNVForm";
            this.Text = "Thống kê cho nhân viên";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKeNV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThongKeNV;
        private System.Windows.Forms.DateTimePicker dtpkToNV;
        private System.Windows.Forms.DateTimePicker dtpkFromNV;
        private System.Windows.Forms.TextBox txtThongKeNVName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvThongKeNV;
        private System.Windows.Forms.TextBox txtTongDoanhThuNV;
        private System.Windows.Forms.Label label6;
    }
}