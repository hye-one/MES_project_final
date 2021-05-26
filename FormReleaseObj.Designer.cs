
namespace MES_project
{
    partial class FormReleaseObj
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
            this.ListView_ReleaseObj = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ListView_ReleaseObj
            // 
            this.ListView_ReleaseObj.HideSelection = false;
            this.ListView_ReleaseObj.Location = new System.Drawing.Point(60, 36);
            this.ListView_ReleaseObj.Name = "ListView_ReleaseObj";
            this.ListView_ReleaseObj.Size = new System.Drawing.Size(747, 402);
            this.ListView_ReleaseObj.TabIndex = 1;
            this.ListView_ReleaseObj.UseCompatibleStateImageBehavior = false;
            // 
            // FormReleaseObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(890, 491);
            this.Controls.Add(this.ListView_ReleaseObj);
            this.Name = "FormReleaseObj";
            this.Text = "FormReleaseObj";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormReleaseObj_FormClosed);
            this.Load += new System.EventHandler(this.FormReleaseObj_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListView_ReleaseObj;
    }
}