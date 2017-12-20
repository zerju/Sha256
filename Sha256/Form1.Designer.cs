namespace Sha256
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
            this.selectFile = new System.Windows.Forms.Button();
            this.checksumInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.outputHash = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hashBtn = new System.Windows.Forms.Button();
            this.hashSpeed = new System.Windows.Forms.Label();
            this.checksumOK = new System.Windows.Forms.Label();
            this.filePath = new System.Windows.Forms.TextBox();
            this.saveHash = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectFile
            // 
            this.selectFile.Location = new System.Drawing.Point(26, 24);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(75, 23);
            this.selectFile.TabIndex = 0;
            this.selectFile.Text = "Select File";
            this.selectFile.UseVisualStyleBackColor = true;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // checksumInput
            // 
            this.checksumInput.Location = new System.Drawing.Point(26, 83);
            this.checksumInput.Name = "checksumInput";
            this.checksumInput.Size = new System.Drawing.Size(275, 20);
            this.checksumInput.TabIndex = 1;
            this.checksumInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input checksum (optional)";
            // 
            // outputHash
            // 
            this.outputHash.Location = new System.Drawing.Point(26, 135);
            this.outputHash.Name = "outputHash";
            this.outputHash.ReadOnly = true;
            this.outputHash.Size = new System.Drawing.Size(275, 20);
            this.outputHash.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output hash";
            // 
            // hashBtn
            // 
            this.hashBtn.Location = new System.Drawing.Point(26, 214);
            this.hashBtn.Name = "hashBtn";
            this.hashBtn.Size = new System.Drawing.Size(91, 23);
            this.hashBtn.TabIndex = 5;
            this.hashBtn.Text = "Check hashes";
            this.hashBtn.UseVisualStyleBackColor = true;
            this.hashBtn.Click += new System.EventHandler(this.hashBtn_Click);
            // 
            // hashSpeed
            // 
            this.hashSpeed.AutoSize = true;
            this.hashSpeed.Location = new System.Drawing.Point(104, 239);
            this.hashSpeed.Name = "hashSpeed";
            this.hashSpeed.Size = new System.Drawing.Size(63, 13);
            this.hashSpeed.TabIndex = 6;
            this.hashSpeed.Text = "HashSpeed";
            // 
            // checksumOK
            // 
            this.checksumOK.AutoSize = true;
            this.checksumOK.Location = new System.Drawing.Point(29, 176);
            this.checksumOK.Name = "checksumOK";
            this.checksumOK.Size = new System.Drawing.Size(0, 13);
            this.checksumOK.TabIndex = 7;
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(107, 27);
            this.filePath.Name = "filePath";
            this.filePath.ReadOnly = true;
            this.filePath.Size = new System.Drawing.Size(194, 20);
            this.filePath.TabIndex = 8;
            // 
            // saveHash
            // 
            this.saveHash.Location = new System.Drawing.Point(209, 214);
            this.saveHash.Name = "saveHash";
            this.saveHash.Size = new System.Drawing.Size(75, 23);
            this.saveHash.TabIndex = 9;
            this.saveHash.Text = "Save hash";
            this.saveHash.UseVisualStyleBackColor = true;
            this.saveHash.Click += new System.EventHandler(this.saveHash_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 261);
            this.Controls.Add(this.saveHash);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.checksumOK);
            this.Controls.Add(this.hashSpeed);
            this.Controls.Add(this.hashBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputHash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checksumInput);
            this.Controls.Add(this.selectFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.TextBox checksumInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outputHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button hashBtn;
        private System.Windows.Forms.Label hashSpeed;
        private System.Windows.Forms.Label checksumOK;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button saveHash;
    }
}

