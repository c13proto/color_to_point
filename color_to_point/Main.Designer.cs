namespace color_to_point
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_open = new System.Windows.Forms.Button();
            this.button_表示 = new System.Windows.Forms.Button();
            this.textBox_index = new System.Windows.Forms.TextBox();
            this.pictureBoxIpl = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.button_画像処理 = new System.Windows.Forms.Button();
            this.textBox_Points = new System.Windows.Forms.TextBox();
            this.button_csv = new System.Windows.Forms.Button();
            this.button_All = new System.Windows.Forms.Button();
            this.progressBar_全画像処理 = new System.Windows.Forms.ProgressBar();
            this.textBox_max = new System.Windows.Forms.TextBox();
            this.textBox_min = new System.Windows.Forms.TextBox();
            this.checkBox_th_enable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl)).BeginInit();
            this.SuspendLayout();
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(0, 0);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 23);
            this.button_open.TabIndex = 0;
            this.button_open.Text = "open";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.Click_open);
            // 
            // button_表示
            // 
            this.button_表示.Location = new System.Drawing.Point(34, 29);
            this.button_表示.Name = "button_表示";
            this.button_表示.Size = new System.Drawing.Size(41, 23);
            this.button_表示.TabIndex = 1;
            this.button_表示.Text = "表示";
            this.button_表示.UseVisualStyleBackColor = true;
            this.button_表示.Click += new System.EventHandler(this.Click_表示);
            // 
            // textBox_index
            // 
            this.textBox_index.Location = new System.Drawing.Point(0, 29);
            this.textBox_index.Name = "textBox_index";
            this.textBox_index.Size = new System.Drawing.Size(28, 19);
            this.textBox_index.TabIndex = 2;
            this.textBox_index.Text = "0";
            this.textBox_index.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pictureBoxIpl
            // 
            this.pictureBoxIpl.Location = new System.Drawing.Point(81, 168);
            this.pictureBoxIpl.Name = "pictureBoxIpl";
            this.pictureBoxIpl.Size = new System.Drawing.Size(574, 372);
            this.pictureBoxIpl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIpl.TabIndex = 3;
            this.pictureBoxIpl.TabStop = false;
            // 
            // button_画像処理
            // 
            this.button_画像処理.Location = new System.Drawing.Point(0, 155);
            this.button_画像処理.Name = "button_画像処理";
            this.button_画像処理.Size = new System.Drawing.Size(75, 23);
            this.button_画像処理.TabIndex = 4;
            this.button_画像処理.Text = "1画像処理";
            this.button_画像処理.UseVisualStyleBackColor = true;
            this.button_画像処理.Click += new System.EventHandler(this.Click_1画像処理);
            // 
            // textBox_Points
            // 
            this.textBox_Points.Location = new System.Drawing.Point(81, 2);
            this.textBox_Points.Multiline = true;
            this.textBox_Points.Name = "textBox_Points";
            this.textBox_Points.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Points.Size = new System.Drawing.Size(659, 160);
            this.textBox_Points.TabIndex = 5;
            // 
            // button_csv
            // 
            this.button_csv.Location = new System.Drawing.Point(0, 236);
            this.button_csv.Name = "button_csv";
            this.button_csv.Size = new System.Drawing.Size(75, 23);
            this.button_csv.TabIndex = 6;
            this.button_csv.Text = "csv出力";
            this.button_csv.UseVisualStyleBackColor = true;
            this.button_csv.Click += new System.EventHandler(this.Click_csv出力);
            // 
            // button_All
            // 
            this.button_All.Location = new System.Drawing.Point(0, 213);
            this.button_All.Name = "button_All";
            this.button_All.Size = new System.Drawing.Size(75, 23);
            this.button_All.TabIndex = 7;
            this.button_All.Text = "全画像処理";
            this.button_All.UseVisualStyleBackColor = true;
            this.button_All.Click += new System.EventHandler(this.Click_全画像処理);
            // 
            // progressBar_全画像処理
            // 
            this.progressBar_全画像処理.Location = new System.Drawing.Point(0, 184);
            this.progressBar_全画像処理.Name = "progressBar_全画像処理";
            this.progressBar_全画像処理.Size = new System.Drawing.Size(75, 23);
            this.progressBar_全画像処理.TabIndex = 8;
            // 
            // textBox_max
            // 
            this.textBox_max.Location = new System.Drawing.Point(0, 92);
            this.textBox_max.Name = "textBox_max";
            this.textBox_max.Size = new System.Drawing.Size(71, 19);
            this.textBox_max.TabIndex = 9;
            this.textBox_max.Text = "50,255,255";
            // 
            // textBox_min
            // 
            this.textBox_min.Location = new System.Drawing.Point(0, 129);
            this.textBox_min.Name = "textBox_min";
            this.textBox_min.Size = new System.Drawing.Size(71, 19);
            this.textBox_min.TabIndex = 10;
            this.textBox_min.Text = "20,100,100";
            // 
            // checkBox_th_enable
            // 
            this.checkBox_th_enable.AutoSize = true;
            this.checkBox_th_enable.Location = new System.Drawing.Point(0, 55);
            this.checkBox_th_enable.Name = "checkBox_th_enable";
            this.checkBox_th_enable.Size = new System.Drawing.Size(71, 16);
            this.checkBox_th_enable.TabIndex = 13;
            this.checkBox_th_enable.Text = "th_enable";
            this.checkBox_th_enable.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "max(H,SV)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "min(H,SV)";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(752, 596);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_th_enable);
            this.Controls.Add(this.textBox_min);
            this.Controls.Add(this.textBox_max);
            this.Controls.Add(this.progressBar_全画像処理);
            this.Controls.Add(this.button_All);
            this.Controls.Add(this.button_csv);
            this.Controls.Add(this.textBox_Points);
            this.Controls.Add(this.button_画像処理);
            this.Controls.Add(this.pictureBoxIpl);
            this.Controls.Add(this.textBox_index);
            this.Controls.Add(this.button_表示);
            this.Controls.Add(this.button_open);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_表示;
        private System.Windows.Forms.TextBox textBox_index;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl;
        private System.Windows.Forms.Button button_画像処理;
        private System.Windows.Forms.TextBox textBox_Points;
        private System.Windows.Forms.Button button_csv;
        private System.Windows.Forms.Button button_All;
        private System.Windows.Forms.ProgressBar progressBar_全画像処理;
        private System.Windows.Forms.TextBox textBox_max;
        private System.Windows.Forms.TextBox textBox_min;
        private System.Windows.Forms.CheckBox checkBox_th_enable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

