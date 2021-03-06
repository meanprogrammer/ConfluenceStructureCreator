﻿namespace ConfluenceAutomator.WinForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LogTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ParentSpaceComboBox = new System.Windows.Forms.ComboBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.KeyTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ConfluencetreeView = new System.Windows.Forms.TreeView();
            this.RunButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfluenceBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.CleanUpButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TargetSpaceTreeView = new System.Windows.Forms.TreeView();
            this.ColapseExpandButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.HasContributorcheckBox = new System.Windows.Forms.CheckBox();
            this.HasAttachmentcheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LogTextbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ParentSpaceComboBox);
            this.groupBox1.Controls.Add(this.DescriptionTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.KeyTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NameTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 476);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Space Information ";
            // 
            // LogTextbox
            // 
            this.LogTextbox.BackColor = System.Drawing.SystemColors.Control;
            this.LogTextbox.Enabled = false;
            this.LogTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogTextbox.Location = new System.Drawing.Point(5, 236);
            this.LogTextbox.Multiline = true;
            this.LogTextbox.Name = "LogTextbox";
            this.LogTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextbox.Size = new System.Drawing.Size(474, 234);
            this.LogTextbox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Parent Space";
            // 
            // ParentSpaceComboBox
            // 
            this.ParentSpaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParentSpaceComboBox.FormattingEnabled = true;
            this.ParentSpaceComboBox.Location = new System.Drawing.Point(129, 198);
            this.ParentSpaceComboBox.Name = "ParentSpaceComboBox";
            this.ParentSpaceComboBox.Size = new System.Drawing.Size(325, 32);
            this.ParentSpaceComboBox.TabIndex = 6;
            this.ParentSpaceComboBox.SelectedIndexChanged += new System.EventHandler(this.ParentSpaceComboBox_SelectedIndexChanged);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(129, 108);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(325, 84);
            this.DescriptionTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Space Key";
            // 
            // KeyTextbox
            // 
            this.KeyTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.KeyTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyTextbox.Location = new System.Drawing.Point(129, 73);
            this.KeyTextbox.MaxLength = 0;
            this.KeyTextbox.Name = "KeyTextbox";
            this.KeyTextbox.Size = new System.Drawing.Size(325, 29);
            this.KeyTextbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Space Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(129, 38);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(325, 29);
            this.NameTextBox.TabIndex = 0;
            // 
            // ConfluencetreeView
            // 
            this.ConfluencetreeView.CheckBoxes = true;
            this.ConfluencetreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfluencetreeView.Location = new System.Drawing.Point(16, 28);
            this.ConfluencetreeView.Name = "ConfluencetreeView";
            this.ConfluencetreeView.Size = new System.Drawing.Size(419, 442);
            this.ConfluencetreeView.TabIndex = 10;
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(499, 484);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(88, 40);
            this.RunButton.TabIndex = 1;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(593, 484);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(88, 40);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfluenceBackgroundWorker
            // 
            this.ConfluenceBackgroundWorker.WorkerReportsProgress = true;
            this.ConfluenceBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ConfluenceBackgroundWorker_DoWork);
            this.ConfluenceBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ConfluenceBackgroundWorker_RunWorkerCompleted);
            // 
            // CleanUpButton
            // 
            this.CleanUpButton.Location = new System.Drawing.Point(8, 483);
            this.CleanUpButton.Name = "CleanUpButton";
            this.CleanUpButton.Size = new System.Drawing.Size(89, 40);
            this.CleanUpButton.TabIndex = 11;
            this.CleanUpButton.Text = "Cleanup";
            this.CleanUpButton.UseVisualStyleBackColor = true;
            this.CleanUpButton.Click += new System.EventHandler(this.ExtractButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ConfluencetreeView);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(499, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 476);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Parent Space ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TargetSpaceTreeView);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(956, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(451, 476);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Target Space ";
            // 
            // TargetSpaceTreeView
            // 
            this.TargetSpaceTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetSpaceTreeView.HideSelection = false;
            this.TargetSpaceTreeView.Location = new System.Drawing.Point(16, 28);
            this.TargetSpaceTreeView.Name = "TargetSpaceTreeView";
            this.TargetSpaceTreeView.Size = new System.Drawing.Size(419, 442);
            this.TargetSpaceTreeView.TabIndex = 10;
            this.TargetSpaceTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TargetSpaceTreeView_AfterSelect);
            // 
            // ColapseExpandButton
            // 
            this.ColapseExpandButton.Location = new System.Drawing.Point(916, 485);
            this.ColapseExpandButton.Name = "ColapseExpandButton";
            this.ColapseExpandButton.Size = new System.Drawing.Size(33, 39);
            this.ColapseExpandButton.TabIndex = 14;
            this.ColapseExpandButton.Text = "<<";
            this.ColapseExpandButton.UseVisualStyleBackColor = true;
            this.ColapseExpandButton.Click += new System.EventHandler(this.ColapseExpandButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.HasContributorcheckBox);
            this.groupBox4.Controls.Add(this.HasAttachmentcheckBox);
            this.groupBox4.Location = new System.Drawing.Point(956, 478);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(451, 46);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            // 
            // HasContributorcheckBox
            // 
            this.HasContributorcheckBox.AutoSize = true;
            this.HasContributorcheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HasContributorcheckBox.Location = new System.Drawing.Point(188, 14);
            this.HasContributorcheckBox.Name = "HasContributorcheckBox";
            this.HasContributorcheckBox.Size = new System.Drawing.Size(211, 24);
            this.HasContributorcheckBox.TabIndex = 1;
            this.HasContributorcheckBox.Text = "Has Contributor Summary";
            this.HasContributorcheckBox.UseVisualStyleBackColor = true;
            this.HasContributorcheckBox.CheckedChanged += new System.EventHandler(this.HasContributorcheckBox_CheckedChanged);
            // 
            // HasAttachmentcheckBox
            // 
            this.HasAttachmentcheckBox.AutoSize = true;
            this.HasAttachmentcheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HasAttachmentcheckBox.Location = new System.Drawing.Point(16, 14);
            this.HasAttachmentcheckBox.Name = "HasAttachmentcheckBox";
            this.HasAttachmentcheckBox.Size = new System.Drawing.Size(144, 24);
            this.HasAttachmentcheckBox.TabIndex = 0;
            this.HasAttachmentcheckBox.Text = "Has Attachment";
            this.HasAttachmentcheckBox.UseVisualStyleBackColor = true;
            this.HasAttachmentcheckBox.CheckedChanged += new System.EventHandler(this.HasAttachmentcheckBox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(790, 485);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 36);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 530);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.ColapseExpandButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CleanUpButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KeyTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox LogTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ParentSpaceComboBox;
        private System.Windows.Forms.TreeView ConfluencetreeView;
        private System.ComponentModel.BackgroundWorker ConfluenceBackgroundWorker;
        private System.Windows.Forms.Button CleanUpButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView TargetSpaceTreeView;
        private System.Windows.Forms.Button ColapseExpandButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox HasAttachmentcheckBox;
        private System.Windows.Forms.CheckBox HasContributorcheckBox;
        private System.Windows.Forms.Button button1;
    }
}

