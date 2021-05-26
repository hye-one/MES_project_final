
namespace MES_project
{
    partial class FormStaff
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
            this.ListView_Staff = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ListView_Staff
            // 
            this.ListView_Staff.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView_Staff.HideSelection = false;
            this.ListView_Staff.Location = new System.Drawing.Point(65, 31);
            this.ListView_Staff.Name = "ListView_Staff";
            this.ListView_Staff.Size = new System.Drawing.Size(848, 455);
            this.ListView_Staff.TabIndex = 3;
            this.ListView_Staff.UseCompatibleStateImageBehavior = false;
            // 
            // FormStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 513);
            this.Controls.Add(this.ListView_Staff);
            this.Name = "FormStaff";
            this.Text = "FormStaff";
            this.Load += new System.EventHandler(this.FormStaff_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView ListView_Staff;
    }
}