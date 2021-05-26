
namespace MES_project
{
    partial class FormWarehouseObj
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
            this.ListView_WarehouseObj = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ListView_WarehouseObj
            // 
            this.ListView_WarehouseObj.HideSelection = false;
            this.ListView_WarehouseObj.Location = new System.Drawing.Point(52, 61);
            this.ListView_WarehouseObj.Name = "ListView_WarehouseObj";
            this.ListView_WarehouseObj.Size = new System.Drawing.Size(856, 419);
            this.ListView_WarehouseObj.TabIndex = 3;
            this.ListView_WarehouseObj.UseCompatibleStateImageBehavior = false;
            // 
            // FormWarehouseObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 513);
            this.Controls.Add(this.ListView_WarehouseObj);
            this.Name = "FormWarehouseObj";
            this.Text = "FormWarehouseObj";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormWarehouseObj_FormClosed);
            this.Load += new System.EventHandler(this.FormWarehouseObj_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView ListView_WarehouseObj;
    }
}