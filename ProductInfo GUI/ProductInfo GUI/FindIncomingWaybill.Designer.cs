namespace ProductInfo_UI
{
    partial class FindIncomingWaybill
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
            this.btnSelectWaybill_ID = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectWaybill_ID
            // 
            this.btnSelectWaybill_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectWaybill_ID.Location = new System.Drawing.Point(184, 463);
            this.btnSelectWaybill_ID.Name = "btnSelectWaybill_ID";
            this.btnSelectWaybill_ID.Size = new System.Drawing.Size(148, 42);
            this.btnSelectWaybill_ID.TabIndex = 0;
            this.btnSelectWaybill_ID.Text = "ზედნადების არჩევა";
            this.btnSelectWaybill_ID.UseVisualStyleBackColor = true;
            this.btnSelectWaybill_ID.Click += new System.EventHandler(this.btnSelectWaybill_ID_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(548, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "TODO: filtering controls for selecting all get_waybills()-matched zeds into a lis" +
                "tview";
            // 
            // FindIncomingWaybill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 517);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectWaybill_ID);
            this.Name = "FindIncomingWaybill";
            this.Text = "FindIncomingWaybill";
            this.Load += new System.EventHandler(this.FindIncomingWaybill_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectWaybill_ID;
        private System.Windows.Forms.Label label1;
    }
}