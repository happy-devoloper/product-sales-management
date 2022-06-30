namespace SalesWinApp
{
    partial class frmUserOrder
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
            this.lbOrders = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvOrdersList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbOrders
            // 
            this.lbOrders.AutoSize = true;
            this.lbOrders.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbOrders.Location = new System.Drawing.Point(193, 38);
            this.lbOrders.Name = "lbOrders";
            this.lbOrders.Size = new System.Drawing.Size(219, 40);
            this.lbOrders.TabIndex = 0;
            this.lbOrders.Text = "History Orders";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnExit.Location = new System.Drawing.Point(267, 325);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 31);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // dgvOrdersList
            // 
            this.dgvOrdersList.AllowUserToAddRows = false;
            this.dgvOrdersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdersList.Location = new System.Drawing.Point(12, 109);
            this.dgvOrdersList.Name = "dgvOrdersList";
            this.dgvOrdersList.RowTemplate.Height = 25;
            this.dgvOrdersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdersList.Size = new System.Drawing.Size(603, 210);
            this.dgvOrdersList.TabIndex = 3;
            this.dgvOrdersList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdersList_CellDoubleClick);
            // 
            // frmUserOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 368);
            this.Controls.Add(this.dgvOrdersList);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lbOrders);
            this.Name = "frmUserOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUserOrder";
            this.Load += new System.EventHandler(this.frmUserOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOrders;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvOrdersList;
    }
}