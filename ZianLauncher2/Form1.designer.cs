namespace ZianLauncher2
{
    partial class LauncherForm2
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm2));
            this.textBoxJava = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxRAM = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonF = new System.Windows.Forms.Button();
            this.buttonO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxJava
            // 
            this.textBoxJava.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxJava.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxJava.Enabled = false;
            this.textBoxJava.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxJava.Location = new System.Drawing.Point(8, 12);
            this.textBoxJava.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxJava.Multiline = true;
            this.textBoxJava.Name = "textBoxJava";
            this.textBoxJava.Size = new System.Drawing.Size(198, 55);
            this.textBoxJava.TabIndex = 0;
            this.textBoxJava.Text = "C:\\Program Files\\Java\\jre1.8.0_181\\bin\\javaw.exe";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(212, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Search Java";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxID
            // 
            this.textBoxID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxID.Location = new System.Drawing.Point(36, 75);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxID.Multiline = true;
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(97, 24);
            this.textBoxID.TabIndex = 2;
            this.textBoxID.Text = "zian1";
            this.textBoxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxRAM
            // 
            this.textBoxRAM.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxRAM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxRAM.Location = new System.Drawing.Point(222, 75);
            this.textBoxRAM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxRAM.Multiline = true;
            this.textBoxRAM.Name = "textBoxRAM";
            this.textBoxRAM.Size = new System.Drawing.Size(74, 24);
            this.textBoxRAM.TabIndex = 3;
            this.textBoxRAM.Text = "4096";
            this.textBoxRAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(142, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "RAM(MB)";
            // 
            // buttonF
            // 
            this.buttonF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonF.Location = new System.Drawing.Point(139, 107);
            this.buttonF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonF.Name = "buttonF";
            this.buttonF.Size = new System.Drawing.Size(158, 44);
            this.buttonF.TabIndex = 11;
            this.buttonF.Text = "StartForge";
            this.buttonF.UseVisualStyleBackColor = false;
            this.buttonF.Click += new System.EventHandler(this.buttonF_Click);
            // 
            // buttonO
            // 
            this.buttonO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonO.Location = new System.Drawing.Point(8, 107);
            this.buttonO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonO.Name = "buttonO";
            this.buttonO.Size = new System.Drawing.Size(125, 44);
            this.buttonO.TabIndex = 18;
            this.buttonO.Text = "Start";
            this.buttonO.UseVisualStyleBackColor = false;
            this.buttonO.Click += new System.EventHandler(this.buttonO_Click);
            // 
            // LauncherForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 159);
            this.Controls.Add(this.buttonO);
            this.Controls.Add(this.buttonF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRAM);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxJava);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "LauncherForm2";
            this.Text = "Launcher 1.16";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxJava;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxRAM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonF;
        private System.Windows.Forms.Button buttonO;
    }
}

