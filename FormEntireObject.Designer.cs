
namespace MES_project
{
    partial class FormEntireObject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEntireObject));
            this.btn_registerObj = new System.Windows.Forms.Button();
            this.ListView_EnObj = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btn_registerObj
            // 
            this.btn_registerObj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_registerObj.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_registerObj.Location = new System.Drawing.Point(828, 11);
            this.btn_registerObj.Name = "btn_registerObj";
            this.btn_registerObj.Size = new System.Drawing.Size(94, 33);
            this.btn_registerObj.TabIndex = 1;
            this.btn_registerObj.Text = "품목 추가";
            this.btn_registerObj.UseVisualStyleBackColor = true;
            this.btn_registerObj.Click += new System.EventHandler(this.btn_registerObj_Click);
            // 
            // ListView_EnObj
            // 
            this.ListView_EnObj.HideSelection = false;
            this.ListView_EnObj.Location = new System.Drawing.Point(41, 50);
            this.ListView_EnObj.Name = "ListView_EnObj";
            this.ListView_EnObj.Size = new System.Drawing.Size(881, 451);
            this.ListView_EnObj.TabIndex = 2;
            this.ListView_EnObj.UseCompatibleStateImageBehavior = false;
            // 
            // FormEntireObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 513);
            this.Controls.Add(this.ListView_EnObj);
            this.Controls.Add(this.btn_registerObj);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEntireObject";
            this.Text = "FormEntireObject";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEntireObject_FormClosed);
            this.Load += new System.EventHandler(this.FormEntireObject_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_registerObj;
        private System.Windows.Forms.ListView ListView_EnObj;
    }
}