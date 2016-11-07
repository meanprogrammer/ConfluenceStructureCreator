namespace ConfluenceAutomator.WinForms
{
    partial class CleanUpForm
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.LogTextbox = new System.Windows.Forms.TextBox();
            this.DeleteAllbutton = new System.Windows.Forms.Button();
            this.KeyTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(266, 257);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 37);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(266, 12);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 37);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // LogTextbox
            // 
            this.LogTextbox.BackColor = System.Drawing.SystemColors.Control;
            this.LogTextbox.Enabled = false;
            this.LogTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogTextbox.Location = new System.Drawing.Point(13, 55);
            this.LogTextbox.Multiline = true;
            this.LogTextbox.Name = "LogTextbox";
            this.LogTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextbox.Size = new System.Drawing.Size(329, 196);
            this.LogTextbox.TabIndex = 4;
            // 
            // DeleteAllbutton
            // 
            this.DeleteAllbutton.Location = new System.Drawing.Point(185, 257);
            this.DeleteAllbutton.Name = "DeleteAllbutton";
            this.DeleteAllbutton.Size = new System.Drawing.Size(75, 37);
            this.DeleteAllbutton.TabIndex = 5;
            this.DeleteAllbutton.Text = "Delete All";
            this.DeleteAllbutton.UseVisualStyleBackColor = true;
            this.DeleteAllbutton.Click += new System.EventHandler(this.DeleteAllbutton_Click);
            // 
            // KeyTextbox
            // 
            this.KeyTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyTextbox.Location = new System.Drawing.Point(60, 11);
            this.KeyTextbox.Name = "KeyTextbox";
            this.KeyTextbox.Size = new System.Drawing.Size(188, 38);
            this.KeyTextbox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Key";
            // 
            // CleanUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeyTextbox);
            this.Controls.Add(this.DeleteAllbutton);
            this.Controls.Add(this.LogTextbox);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CleanUpForm";
            this.Text = "CleanUpForm";
            this.Load += new System.EventHandler(this.CleanUpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox LogTextbox;
        private System.Windows.Forms.Button DeleteAllbutton;
        private System.Windows.Forms.TextBox KeyTextbox;
        private System.Windows.Forms.Label label1;
    }
}