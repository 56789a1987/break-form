namespace winform
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.board = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.ball = new System.Windows.Forms.RadioButton();
            this.scshow = new System.Windows.Forms.Label();
            this.defTimer = new System.Windows.Forms.Timer(this.components);
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.Location = new System.Drawing.Point(225, 424);
            this.board.Margin = new System.Windows.Forms.Padding(0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(100, 23);
            this.board.TabIndex = 0;
            this.board.Text = "\r\n";
            this.board.UseVisualStyleBackColor = true;
            this.board.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.ball);
            this.panel.Controls.Add(this.board);
            this.panel.Controls.Add(this.scshow);
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(545, 450);
            this.panel.TabIndex = 1;
            this.panel.Click += new System.EventHandler(this.panel_Click);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            // 
            // ball
            // 
            this.ball.AutoSize = true;
            this.ball.Checked = true;
            this.ball.Location = new System.Drawing.Point(268, 411);
            this.ball.Margin = new System.Windows.Forms.Padding(0);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(14, 13);
            this.ball.TabIndex = 1;
            this.ball.UseVisualStyleBackColor = true;
            this.ball.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            // 
            // scshow
            // 
            this.scshow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scshow.BackColor = System.Drawing.Color.Transparent;
            this.scshow.Font = new System.Drawing.Font("Consolas", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scshow.ForeColor = System.Drawing.SystemColors.GrayText;
            this.scshow.Location = new System.Drawing.Point(182, 250);
            this.scshow.Margin = new System.Windows.Forms.Padding(0);
            this.scshow.Name = "scshow";
            this.scshow.Size = new System.Drawing.Size(180, 75);
            this.scshow.TabIndex = 1;
            this.scshow.Text = "0";
            this.scshow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scshow.Click += new System.EventHandler(this.panel_Click);
            this.scshow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            // 
            // defTimer
            // 
            this.defTimer.Interval = 16;
            this.defTimer.Tick += new System.EventHandler(this.defTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 474);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BreakForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button board;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.RadioButton ball;
        private System.Windows.Forms.Timer defTimer;
        private System.Windows.Forms.Label scshow;
    }
}

