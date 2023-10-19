namespace DDB.ComputerWorld.UI
{
    partial class frmComputerWorld
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvChildren = new DataGridView();
            lbxEquipment = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dgvChildren).BeginInit();
            SuspendLayout();
            // 
            // dgvChildren
            // 
            dgvChildren.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChildren.Location = new Point(217, 267);
            dgvChildren.Name = "dgvChildren";
            dgvChildren.RowTemplate.Height = 25;
            dgvChildren.Size = new Size(482, 156);
            dgvChildren.TabIndex = 0;
            // 
            // lbxEquipment
            // 
            lbxEquipment.FormattingEnabled = true;
            lbxEquipment.ItemHeight = 15;
            lbxEquipment.Location = new Point(12, 12);
            lbxEquipment.Name = "lbxEquipment";
            lbxEquipment.Size = new Size(199, 409);
            lbxEquipment.TabIndex = 1;
            // 
            // frmComputerWorld
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbxEquipment);
            Controls.Add(dgvChildren);
            Name = "frmComputerWorld";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Computer World";
            Load += frmComputerWorld_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChildren).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvChildren;
        private ListBox lbxEquipment;
    }
}