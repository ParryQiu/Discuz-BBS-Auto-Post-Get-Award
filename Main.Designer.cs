namespace DiscuzBBSAutoLogin
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonAddTopicID = new System.Windows.Forms.Button();
            this.ListBoxTopicIDs = new System.Windows.Forms.ListBox();
            this.TextBoxNewTopicNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButtonSetStatus = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.LabelCurrentFloor = new System.Windows.Forms.Label();
            this.ButtonShowNow = new System.Windows.Forms.Button();
            this.ButtonEnd = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxFitNumbers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TimerStartPost = new System.Windows.Forms.Timer(this.components);
            this.ListBoxInfo = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonViewInBrowse = new System.Windows.Forms.Button();
            this.TextBoxPrizeDetails = new System.Windows.Forms.TextBox();
            this.TimerStartCatch = new System.Windows.Forms.Timer(this.components);
            this.ButtonCatchNow = new System.Windows.Forms.Button();
            this.TimerOnlyCount = new System.Windows.Forms.Timer(this.components);
            this.ButtonAutoGetFloor = new System.Windows.Forms.Button();
            this.ButtonStopAutoGetFloor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TextBoxPrizeDetails);
            this.groupBox1.Controls.Add(this.ButtonViewInBrowse);
            this.groupBox1.Controls.Add(this.ButtonDelete);
            this.groupBox1.Controls.Add(this.ButtonAddTopicID);
            this.groupBox1.Controls.Add(this.ListBoxTopicIDs);
            this.groupBox1.Controls.Add(this.TextBoxNewTopicNo);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 191);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "帖子ID";
            // 
            // ButtonAddTopicID
            // 
            this.ButtonAddTopicID.Location = new System.Drawing.Point(152, 159);
            this.ButtonAddTopicID.Name = "ButtonAddTopicID";
            this.ButtonAddTopicID.Size = new System.Drawing.Size(56, 23);
            this.ButtonAddTopicID.TabIndex = 1;
            this.ButtonAddTopicID.Text = "添 加";
            this.ButtonAddTopicID.UseVisualStyleBackColor = true;
            this.ButtonAddTopicID.Click += new System.EventHandler(this.ButtonAddTopicID_Click);
            // 
            // ListBoxTopicIDs
            // 
            this.ListBoxTopicIDs.FormattingEnabled = true;
            this.ListBoxTopicIDs.ItemHeight = 12;
            this.ListBoxTopicIDs.Location = new System.Drawing.Point(3, 17);
            this.ListBoxTopicIDs.Name = "ListBoxTopicIDs";
            this.ListBoxTopicIDs.Size = new System.Drawing.Size(205, 136);
            this.ListBoxTopicIDs.TabIndex = 0;
            this.ListBoxTopicIDs.SelectedIndexChanged += new System.EventHandler(this.ListBoxTopicIDs_SelectedIndexChanged);
            // 
            // TextBoxNewTopicNo
            // 
            this.TextBoxNewTopicNo.Location = new System.Drawing.Point(6, 159);
            this.TextBoxNewTopicNo.Name = "TextBoxNewTopicNo";
            this.TextBoxNewTopicNo.Size = new System.Drawing.Size(140, 21);
            this.TextBoxNewTopicNo.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ButtonStopAutoGetFloor);
            this.groupBox2.Controls.Add(this.ButtonAutoGetFloor);
            this.groupBox2.Controls.Add(this.ButtonCatchNow);
            this.groupBox2.Controls.Add(this.ButtonSetStatus);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.LabelCurrentFloor);
            this.groupBox2.Controls.Add(this.ButtonShowNow);
            this.groupBox2.Controls.Add(this.ButtonEnd);
            this.groupBox2.Controls.Add(this.ButtonStart);
            this.groupBox2.Controls.Add(this.ButtonSave);
            this.groupBox2.Controls.Add(this.LabelStatus);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TextBoxFitNumbers);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 256);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "详细参数";
            // 
            // ButtonSetStatus
            // 
            this.ButtonSetStatus.Location = new System.Drawing.Point(285, 120);
            this.ButtonSetStatus.Name = "ButtonSetStatus";
            this.ButtonSetStatus.Size = new System.Drawing.Size(99, 24);
            this.ButtonSetStatus.TabIndex = 7;
            this.ButtonSetStatus.Text = "设置为已中奖";
            this.ButtonSetStatus.UseVisualStyleBackColor = true;
            this.ButtonSetStatus.Click += new System.EventHandler(this.ButtonSetStatus_Click);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(9, 81);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(59, 12);
            this.label44.TabIndex = 6;
            this.label44.Text = "当前楼层:";
            // 
            // LabelCurrentFloor
            // 
            this.LabelCurrentFloor.AutoSize = true;
            this.LabelCurrentFloor.Location = new System.Drawing.Point(77, 81);
            this.LabelCurrentFloor.Name = "LabelCurrentFloor";
            this.LabelCurrentFloor.Size = new System.Drawing.Size(41, 12);
            this.LabelCurrentFloor.TabIndex = 6;
            this.LabelCurrentFloor.Text = "label3";
            // 
            // ButtonShowNow
            // 
            this.ButtonShowNow.Location = new System.Drawing.Point(97, 216);
            this.ButtonShowNow.Name = "ButtonShowNow";
            this.ButtonShowNow.Size = new System.Drawing.Size(111, 23);
            this.ButtonShowNow.TabIndex = 5;
            this.ButtonShowNow.Text = "现在到哪了";
            this.ButtonShowNow.UseVisualStyleBackColor = true;
            this.ButtonShowNow.Click += new System.EventHandler(this.ButtonShowNow_Click);
            // 
            // ButtonEnd
            // 
            this.ButtonEnd.Location = new System.Drawing.Point(300, 216);
            this.ButtonEnd.Name = "ButtonEnd";
            this.ButtonEnd.Size = new System.Drawing.Size(80, 23);
            this.ButtonEnd.TabIndex = 4;
            this.ButtonEnd.Text = "停止";
            this.ButtonEnd.UseVisualStyleBackColor = true;
            this.ButtonEnd.Click += new System.EventHandler(this.ButtonEnd_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(214, 216);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(80, 23);
            this.ButtonStart.TabIndex = 4;
            this.ButtonStart.Text = "开始";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(11, 216);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(80, 23);
            this.ButtonSave.TabIndex = 4;
            this.ButtonSave.Text = "保  存";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(50, 49);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(41, 12);
            this.LabelStatus.TabIndex = 3;
            this.LabelStatus.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "状态:";
            // 
            // TextBoxFitNumbers
            // 
            this.TextBoxFitNumbers.Location = new System.Drawing.Point(127, 16);
            this.TextBoxFitNumbers.Name = "TextBoxFitNumbers";
            this.TextBoxFitNumbers.Size = new System.Drawing.Size(257, 21);
            this.TextBoxFitNumbers.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "中奖楼层(逗号分隔):";
            // 
            // TimerStartPost
            // 
            this.TimerStartPost.Interval = 5000;
            this.TimerStartPost.Tick += new System.EventHandler(this.TimerStartPost_Tick);
            // 
            // ListBoxInfo
            // 
            this.ListBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxInfo.FormattingEnabled = true;
            this.ListBoxInfo.ItemHeight = 12;
            this.ListBoxInfo.Location = new System.Drawing.Point(3, 17);
            this.ListBoxInfo.Name = "ListBoxInfo";
            this.ListBoxInfo.Size = new System.Drawing.Size(360, 232);
            this.ListBoxInfo.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ListBoxInfo);
            this.groupBox3.Location = new System.Drawing.Point(430, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 256);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志";
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(214, 159);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(56, 23);
            this.ButtonDelete.TabIndex = 1;
            this.ButtonDelete.Text = "删 除";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonViewInBrowse
            // 
            this.ButtonViewInBrowse.Location = new System.Drawing.Point(276, 159);
            this.ButtonViewInBrowse.Name = "ButtonViewInBrowse";
            this.ButtonViewInBrowse.Size = new System.Drawing.Size(56, 23);
            this.ButtonViewInBrowse.TabIndex = 1;
            this.ButtonViewInBrowse.Text = "查 看";
            this.ButtonViewInBrowse.UseVisualStyleBackColor = true;
            this.ButtonViewInBrowse.Click += new System.EventHandler(this.ButtonViewInBrowse_Click);
            // 
            // TextBoxPrizeDetails
            // 
            this.TextBoxPrizeDetails.Location = new System.Drawing.Point(214, 17);
            this.TextBoxPrizeDetails.Multiline = true;
            this.TextBoxPrizeDetails.Name = "TextBoxPrizeDetails";
            this.TextBoxPrizeDetails.Size = new System.Drawing.Size(563, 136);
            this.TextBoxPrizeDetails.TabIndex = 3;
            // 
            // TimerStartCatch
            // 
            this.TimerStartCatch.Interval = 5000;
            this.TimerStartCatch.Tick += new System.EventHandler(this.TimerStartCatch_Tick);
            // 
            // ButtonCatchNow
            // 
            this.ButtonCatchNow.Location = new System.Drawing.Point(128, 133);
            this.ButtonCatchNow.Name = "ButtonCatchNow";
            this.ButtonCatchNow.Size = new System.Drawing.Size(111, 46);
            this.ButtonCatchNow.TabIndex = 8;
            this.ButtonCatchNow.Text = "立即抢";
            this.ButtonCatchNow.UseVisualStyleBackColor = true;
            this.ButtonCatchNow.Click += new System.EventHandler(this.ButtonCatchNow_Click);
            // 
            // TimerOnlyCount
            // 
            this.TimerOnlyCount.Interval = 2000;
            this.TimerOnlyCount.Tick += new System.EventHandler(this.TimerOnlyCount_Tick);
            // 
            // ButtonAutoGetFloor
            // 
            this.ButtonAutoGetFloor.Location = new System.Drawing.Point(11, 133);
            this.ButtonAutoGetFloor.Name = "ButtonAutoGetFloor";
            this.ButtonAutoGetFloor.Size = new System.Drawing.Size(111, 46);
            this.ButtonAutoGetFloor.TabIndex = 8;
            this.ButtonAutoGetFloor.Text = "自动计数";
            this.ButtonAutoGetFloor.UseVisualStyleBackColor = true;
            this.ButtonAutoGetFloor.Click += new System.EventHandler(this.ButtonAutoGetFloor_Click);
            // 
            // ButtonStopAutoGetFloor
            // 
            this.ButtonStopAutoGetFloor.Location = new System.Drawing.Point(285, 155);
            this.ButtonStopAutoGetFloor.Name = "ButtonStopAutoGetFloor";
            this.ButtonStopAutoGetFloor.Size = new System.Drawing.Size(99, 23);
            this.ButtonStopAutoGetFloor.TabIndex = 9;
            this.ButtonStopAutoGetFloor.Text = "停止计数";
            this.ButtonStopAutoGetFloor.UseVisualStyleBackColor = true;
            this.ButtonStopAutoGetFloor.Click += new System.EventHandler(this.ButtonStopAutoGetFloor_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(808, 475);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrizeCatch V0.1 qiupengyuan@gmail.com";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox ListBoxTopicIDs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxFitNumbers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.Button ButtonAddTopicID;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.TextBox TextBoxNewTopicNo;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Timer TimerStartPost;
        private System.Windows.Forms.Button ButtonEnd;
        private System.Windows.Forms.ListBox ListBoxInfo;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label LabelCurrentFloor;
        private System.Windows.Forms.Button ButtonShowNow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ButtonSetStatus;
        private System.Windows.Forms.Button ButtonViewInBrowse;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.TextBox TextBoxPrizeDetails;
        private System.Windows.Forms.Timer TimerStartCatch;
        private System.Windows.Forms.Button ButtonCatchNow;
        private System.Windows.Forms.Timer TimerOnlyCount;
        private System.Windows.Forms.Button ButtonAutoGetFloor;
        private System.Windows.Forms.Button ButtonStopAutoGetFloor;


    }
}

