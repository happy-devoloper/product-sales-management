namespace SalesWinApp
{
    partial class frmUserOrderDetail
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
            this.lbOrderDetail = new System.Windows.Forms.Label();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.lbRequiredDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbShippedDate = new System.Windows.Forms.Label();
            this.lsvOrderDetail = new System.Windows.Forms.ListView();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.txtRequiredDate = new System.Windows.Forms.TextBox();
            this.txtShippedDate = new System.Windows.Forms.TextBox();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.cboCompanyName = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFreight = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lbOrderDetail
            // 
            this.lbOrderDetail.AutoSize = true;
            this.lbOrderDetail.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbOrderDetail.Location = new System.Drawing.Point(214, 20);
            this.lbOrderDetail.Name = "lbOrderDetail";
            this.lbOrderDetail.Size = new System.Drawing.Size(224, 47);
            this.lbOrderDetail.TabIndex = 0;
            this.lbOrderDetail.Text = "Order Detail";
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbOrderDate.Location = new System.Drawing.Point(364, 192);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(80, 17);
            this.lbOrderDate.TabIndex = 1;
            this.lbOrderDate.Text = "Order Date:";
            // 
            // lbRequiredDate
            // 
            this.lbRequiredDate.AutoSize = true;
            this.lbRequiredDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbRequiredDate.Location = new System.Drawing.Point(364, 153);
            this.lbRequiredDate.Name = "lbRequiredDate";
            this.lbRequiredDate.Size = new System.Drawing.Size(100, 17);
            this.lbRequiredDate.TabIndex = 2;
            this.lbRequiredDate.Text = "Required Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(32, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Company Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(32, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Member ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(253, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "Order";
            // 
            // lbShippedDate
            // 
            this.lbShippedDate.AutoSize = true;
            this.lbShippedDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbShippedDate.Location = new System.Drawing.Point(364, 231);
            this.lbShippedDate.Name = "lbShippedDate";
            this.lbShippedDate.Size = new System.Drawing.Size(95, 17);
            this.lbShippedDate.TabIndex = 6;
            this.lbShippedDate.Text = "Shipped Date:";
            // 
            // lsvOrderDetail
            // 
            this.lsvOrderDetail.BackColor = System.Drawing.SystemColors.Control;
            this.lsvOrderDetail.FullRowSelect = true;
            this.lsvOrderDetail.GridLines = true;
            this.lsvOrderDetail.HideSelection = false;
            this.lsvOrderDetail.Location = new System.Drawing.Point(12, 280);
            this.lsvOrderDetail.Name = "lsvOrderDetail";
            this.lsvOrderDetail.Size = new System.Drawing.Size(624, 107);
            this.lsvOrderDetail.TabIndex = 7;
            this.lsvOrderDetail.UseCompatibleStateImageBehavior = false;
            this.lsvOrderDetail.View = System.Windows.Forms.View.Details;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(474, 403);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "Freight:";
            // 
            // txtMemberID
            // 
            this.txtMemberID.BackColor = System.Drawing.SystemColors.Control;
            this.txtMemberID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMemberID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMemberID.Location = new System.Drawing.Point(169, 159);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.ReadOnly = true;
            this.txtMemberID.Size = new System.Drawing.Size(159, 18);
            this.txtMemberID.TabIndex = 12;
            // 
            // txtRequiredDate
            // 
            this.txtRequiredDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtRequiredDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRequiredDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRequiredDate.Location = new System.Drawing.Point(474, 148);
            this.txtRequiredDate.Name = "txtRequiredDate";
            this.txtRequiredDate.ReadOnly = true;
            this.txtRequiredDate.Size = new System.Drawing.Size(150, 18);
            this.txtRequiredDate.TabIndex = 13;
            // 
            // txtShippedDate
            // 
            this.txtShippedDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtShippedDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtShippedDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtShippedDate.Location = new System.Drawing.Point(474, 230);
            this.txtShippedDate.Name = "txtShippedDate";
            this.txtShippedDate.ReadOnly = true;
            this.txtShippedDate.Size = new System.Drawing.Size(150, 18);
            this.txtShippedDate.TabIndex = 14;
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.BackColor = System.Drawing.SystemColors.Control;
            this.txtOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrderDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOrderDate.Location = new System.Drawing.Point(474, 191);
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(150, 18);
            this.txtOrderDate.TabIndex = 15;
            // 
            // txtOrderID
            // 
            this.txtOrderID.BackColor = System.Drawing.SystemColors.Control;
            this.txtOrderID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrderID.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOrderID.Location = new System.Drawing.Point(325, 96);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(113, 32);
            this.txtOrderID.TabIndex = 19;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(265, 450);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 32);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cboCompanyName
            // 
            this.cboCompanyName.BackColor = System.Drawing.SystemColors.Control;
            this.cboCompanyName.Enabled = false;
            this.cboCompanyName.FormattingEnabled = true;
            this.cboCompanyName.Location = new System.Drawing.Point(169, 192);
            this.cboCompanyName.Name = "cboCompanyName";
            this.cboCompanyName.Size = new System.Drawing.Size(159, 23);
            this.cboCompanyName.TabIndex = 21;
            this.cboCompanyName.SelectedIndexChanged += new System.EventHandler(this.cboCompanyName_SelectedIndexChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 251);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(66, 23);
            this.btnEdit.TabIndex = 22;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(12, 403);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 36);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(536, 402);
            this.txtFreight.Mask = "0000000";
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(100, 23);
            this.txtFreight.TabIndex = 24;
            this.txtFreight.Text = "0";
            // 
            // frmUserOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 494);
            this.Controls.Add(this.txtFreight);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.cboCompanyName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.txtOrderDate);
            this.Controls.Add(this.txtShippedDate);
            this.Controls.Add(this.txtRequiredDate);
            this.Controls.Add(this.txtMemberID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lsvOrderDetail);
            this.Controls.Add(this.lbShippedDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbRequiredDate);
            this.Controls.Add(this.lbOrderDate);
            this.Controls.Add(this.lbOrderDetail);
            this.Name = "frmUserOrderDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Detail";
            this.Load += new System.EventHandler(this.frmUserOrderDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOrderDetail;
        private System.Windows.Forms.Label lbOrderDate;
        private System.Windows.Forms.Label lbRequiredDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbShippedDate;
        private System.Windows.Forms.ListView lsvOrderDetail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.TextBox txtRequiredDate;
        private System.Windows.Forms.TextBox txtShippedDate;
        private System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cboCompanyName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.MaskedTextBox txtFreight;
    }
}