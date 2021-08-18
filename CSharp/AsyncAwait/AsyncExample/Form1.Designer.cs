
namespace AsyncExample
{
    partial class Form1
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
            this.SyncDownload = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.TextBox();
            this.AsyncDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SyncDownload
            // 
            this.SyncDownload.Location = new System.Drawing.Point(117, 54);
            this.SyncDownload.Name = "SyncDownload";
            this.SyncDownload.Size = new System.Drawing.Size(600, 58);
            this.SyncDownload.TabIndex = 0;
            this.SyncDownload.Text = "SyncDownload";
            this.SyncDownload.UseVisualStyleBackColor = true;
            this.SyncDownload.Click += new System.EventHandler(this.SyncDownload_Click);
            // 
            // Result
            // 
            this.Result.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Result.Location = new System.Drawing.Point(117, 262);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(600, 571);
            this.Result.TabIndex = 1;
            this.Result.TextChanged += new System.EventHandler(this.Result_TextChanged);
            // 
            // AsyncDownload
            // 
            this.AsyncDownload.Location = new System.Drawing.Point(117, 156);
            this.AsyncDownload.Name = "AsyncDownload";
            this.AsyncDownload.Size = new System.Drawing.Size(600, 55);
            this.AsyncDownload.TabIndex = 2;
            this.AsyncDownload.Text = "AsyncDownload";
            this.AsyncDownload.UseVisualStyleBackColor = true;
            this.AsyncDownload.Click += new System.EventHandler(this.AsyncDownload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 860);
            this.Controls.Add(this.AsyncDownload);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.SyncDownload);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SyncDownload;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Button AsyncDownload;
    }
}

