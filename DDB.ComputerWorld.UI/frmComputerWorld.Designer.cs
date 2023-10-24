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
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtManufacturer = new TextBox();
            txtModel = new TextBox();
            txtCost = new TextBox();
            txtHardDriveSize = new TextBox();
            txtMemory = new TextBox();
            txtProcessor = new TextBox();
            cbxEquipmentType = new ComboBox();
            btnMakeComputer = new Button();
            btnFakeData = new Button();
            btnUpdate = new Button();
            btnDeleteComputer = new Button();
            btnAddApplication = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvChildren).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvChildren
            // 
            dgvChildren.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChildren.Location = new Point(217, 267);
            dgvChildren.MultiSelect = false;
            dgvChildren.Name = "dgvChildren";
            dgvChildren.RowTemplate.Height = 25;
            dgvChildren.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            lbxEquipment.SelectedIndexChanged += lbxEquipment_SelectedIndexChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 17);
            lblStatus.Text = "Status";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(217, 12);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 3;
            label1.Text = "Manufacturer:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(217, 47);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 4;
            label2.Text = "Model:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(217, 82);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 5;
            label3.Text = "Cost:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(217, 117);
            label4.Name = "label4";
            label4.Size = new Size(89, 15);
            label4.TabIndex = 6;
            label4.Text = "Hard Drive Size:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(217, 152);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 7;
            label5.Text = "Memory:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(217, 187);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 8;
            label6.Text = "Processor:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(217, 222);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 9;
            label7.Text = "Type:";
            // 
            // txtManufacturer
            // 
            txtManufacturer.Location = new Point(314, 9);
            txtManufacturer.Name = "txtManufacturer";
            txtManufacturer.Size = new Size(166, 23);
            txtManufacturer.TabIndex = 10;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(314, 44);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(166, 23);
            txtModel.TabIndex = 11;
            // 
            // txtCost
            // 
            txtCost.Location = new Point(314, 79);
            txtCost.Name = "txtCost";
            txtCost.Size = new Size(166, 23);
            txtCost.TabIndex = 12;
            // 
            // txtHardDriveSize
            // 
            txtHardDriveSize.Location = new Point(314, 114);
            txtHardDriveSize.Name = "txtHardDriveSize";
            txtHardDriveSize.Size = new Size(166, 23);
            txtHardDriveSize.TabIndex = 13;
            // 
            // txtMemory
            // 
            txtMemory.Location = new Point(314, 149);
            txtMemory.Name = "txtMemory";
            txtMemory.Size = new Size(166, 23);
            txtMemory.TabIndex = 14;
            // 
            // txtProcessor
            // 
            txtProcessor.Location = new Point(314, 184);
            txtProcessor.Name = "txtProcessor";
            txtProcessor.Size = new Size(166, 23);
            txtProcessor.TabIndex = 15;
            // 
            // cbxEquipmentType
            // 
            cbxEquipmentType.FormattingEnabled = true;
            cbxEquipmentType.Location = new Point(314, 219);
            cbxEquipmentType.Name = "cbxEquipmentType";
            cbxEquipmentType.Size = new Size(166, 23);
            cbxEquipmentType.TabIndex = 16;
            // 
            // btnMakeComputer
            // 
            btnMakeComputer.Location = new Point(640, 12);
            btnMakeComputer.Name = "btnMakeComputer";
            btnMakeComputer.Size = new Size(148, 23);
            btnMakeComputer.TabIndex = 17;
            btnMakeComputer.Text = "Make Computer";
            btnMakeComputer.UseVisualStyleBackColor = true;
            btnMakeComputer.Click += btnMakeComputer_Click;
            // 
            // btnFakeData
            // 
            btnFakeData.Location = new Point(640, 35);
            btnFakeData.Name = "btnFakeData";
            btnFakeData.Size = new Size(148, 23);
            btnFakeData.TabIndex = 18;
            btnFakeData.Text = "Fake Data";
            btnFakeData.UseVisualStyleBackColor = true;
            btnFakeData.Click += btnFakeData_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(640, 58);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(148, 23);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Update Computer";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDeleteComputer
            // 
            btnDeleteComputer.Location = new Point(640, 81);
            btnDeleteComputer.Name = "btnDeleteComputer";
            btnDeleteComputer.Size = new Size(148, 23);
            btnDeleteComputer.TabIndex = 20;
            btnDeleteComputer.Text = "Delete Computer";
            btnDeleteComputer.UseVisualStyleBackColor = true;
            btnDeleteComputer.Click += btnDeleteComputer_Click;
            // 
            // btnAddApplication
            // 
            btnAddApplication.Location = new Point(640, 104);
            btnAddApplication.Name = "btnAddApplication";
            btnAddApplication.Size = new Size(148, 23);
            btnAddApplication.TabIndex = 21;
            btnAddApplication.Text = "Add Application";
            btnAddApplication.UseVisualStyleBackColor = true;
            btnAddApplication.Click += btnAddApplication_Click;
            // 
            // frmComputerWorld
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAddApplication);
            Controls.Add(btnDeleteComputer);
            Controls.Add(btnUpdate);
            Controls.Add(btnFakeData);
            Controls.Add(btnMakeComputer);
            Controls.Add(cbxEquipmentType);
            Controls.Add(txtProcessor);
            Controls.Add(txtMemory);
            Controls.Add(txtHardDriveSize);
            Controls.Add(txtCost);
            Controls.Add(txtModel);
            Controls.Add(txtManufacturer);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(statusStrip1);
            Controls.Add(lbxEquipment);
            Controls.Add(dgvChildren);
            Name = "frmComputerWorld";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Computer World";
            Load += frmComputerWorld_Load;
            ((System.ComponentModel.ISupportInitialize)dgvChildren).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvChildren;
        private ListBox lbxEquipment;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtManufacturer;
        private TextBox txtModel;
        private TextBox txtCost;
        private TextBox txtHardDriveSize;
        private TextBox txtMemory;
        private TextBox txtProcessor;
        private ComboBox cbxEquipmentType;
        private Button btnMakeComputer;
        private Button btnFakeData;
        private Button btnUpdate;
        private Button btnDeleteComputer;
        private Button btnAddApplication;
    }
}