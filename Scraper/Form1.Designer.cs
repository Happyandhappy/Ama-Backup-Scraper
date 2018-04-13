namespace Scraper
{
    partial class Form1
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
            this.scrapDataView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.scrapUrl = new System.Windows.Forms.TextBox();
            this.scrapbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scrapDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // scrapDataView
            // 
            this.scrapDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scrapDataView.Location = new System.Drawing.Point(12, 132);
            this.scrapDataView.Name = "scrapDataView";
            this.scrapDataView.Size = new System.Drawing.Size(1110, 160);
            this.scrapDataView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Subheading", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Url";
            // 
            // scrapUrl
            // 
            this.scrapUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrapUrl.Location = new System.Drawing.Point(77, 52);
            this.scrapUrl.Name = "scrapUrl";
            this.scrapUrl.Size = new System.Drawing.Size(699, 29);
            this.scrapUrl.TabIndex = 2;
            // 
            // scrapbutton
            // 
            this.scrapbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrapbutton.Location = new System.Drawing.Point(860, 49);
            this.scrapbutton.Name = "scrapbutton";
            this.scrapbutton.Size = new System.Drawing.Size(262, 32);
            this.scrapbutton.TabIndex = 3;
            this.scrapbutton.Text = "Start Scrap";
            this.scrapbutton.UseVisualStyleBackColor = true;
            this.scrapbutton.Click += new System.EventHandler(this.scrapbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 300);
            this.Controls.Add(this.scrapbutton);
            this.Controls.Add(this.scrapUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scrapDataView);
            this.Name = "Form1";
            this.Text = "Scrapper";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scrapDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView scrapDataView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox scrapUrl;
        private System.Windows.Forms.Button scrapbutton;
    }
}

