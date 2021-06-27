namespace CommandReplaceLinuxToWindows {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.passedCommandBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passedCommandBox
            // 
            this.passedCommandBox.Location = new System.Drawing.Point(24, 58);
            this.passedCommandBox.Margin = new System.Windows.Forms.Padding(6);
            this.passedCommandBox.Name = "passedCommandBox";
            this.passedCommandBox.Size = new System.Drawing.Size(800, 38);
            this.passedCommandBox.TabIndex = 0;
            this.passedCommandBox.TextChanged += new System.EventHandler(this.passedCommandBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "置換・実行したいコマンドを入力してください。";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(836, 58);
            this.runButton.Margin = new System.Windows.Forms.Padding(6);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(100, 38);
            this.runButton.TabIndex = 2;
            this.runButton.Text = "実  行";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.runButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 136);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passedCommandBox);
            this.Font = new System.Drawing.Font("游ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Bridge - Replace Commands for Linux to Windows";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passedCommandBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button runButton;
    }
}

