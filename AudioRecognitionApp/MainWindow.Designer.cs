namespace AudioRecognitionApp
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSongsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recognizeBtn = new System.Windows.Forms.Button();
            this.recordBtn = new System.Windows.Forms.Button();
            this.openSongBtn = new System.Windows.Forms.Button();
            this.songPathField = new System.Windows.Forms.TextBox();
            this.recordRadioBtn = new System.Windows.Forms.RadioButton();
            this.openRadioBtn = new System.Windows.Forms.RadioButton();
            this.matchesGridView = new System.Windows.Forms.DataGridView();
            this.songNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matchesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(436, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSongsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.programToolStripMenuItem.Text = "Songs";
            // 
            // addSongsToolStripMenuItem
            // 
            this.addSongsToolStripMenuItem.Name = "addSongsToolStripMenuItem";
            this.addSongsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addSongsToolStripMenuItem.Text = "Add Songs";
            this.addSongsToolStripMenuItem.Click += new System.EventHandler(this.addSongsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // recognizeBtn
            // 
            this.recognizeBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.recognizeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recognizeBtn.ForeColor = System.Drawing.Color.Transparent;
            this.recognizeBtn.Location = new System.Drawing.Point(166, 159);
            this.recognizeBtn.Margin = new System.Windows.Forms.Padding(2);
            this.recognizeBtn.Name = "recognizeBtn";
            this.recognizeBtn.Size = new System.Drawing.Size(91, 37);
            this.recognizeBtn.TabIndex = 1;
            this.recognizeBtn.Text = "Recognize";
            this.recognizeBtn.UseVisualStyleBackColor = false;
            this.recognizeBtn.Click += new System.EventHandler(this.recognizeBtn_Click);
            // 
            // recordBtn
            // 
            this.recordBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.recordBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordBtn.ForeColor = System.Drawing.Color.Transparent;
            this.recordBtn.Location = new System.Drawing.Point(166, 88);
            this.recordBtn.Margin = new System.Windows.Forms.Padding(2);
            this.recordBtn.Name = "recordBtn";
            this.recordBtn.Size = new System.Drawing.Size(91, 25);
            this.recordBtn.TabIndex = 2;
            this.recordBtn.Text = "Record";
            this.recordBtn.UseVisualStyleBackColor = false;
            this.recordBtn.Click += new System.EventHandler(this.recordBtn_Click);
            // 
            // openSongBtn
            // 
            this.openSongBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.openSongBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openSongBtn.ForeColor = System.Drawing.Color.Transparent;
            this.openSongBtn.Location = new System.Drawing.Point(71, 88);
            this.openSongBtn.Margin = new System.Windows.Forms.Padding(2);
            this.openSongBtn.Name = "openSongBtn";
            this.openSongBtn.Size = new System.Drawing.Size(91, 25);
            this.openSongBtn.TabIndex = 3;
            this.openSongBtn.Text = "Open Song";
            this.openSongBtn.UseVisualStyleBackColor = false;
            this.openSongBtn.Visible = false;
            this.openSongBtn.Click += new System.EventHandler(this.openSongBtn_Click);
            // 
            // songPathField
            // 
            this.songPathField.Location = new System.Drawing.Point(166, 92);
            this.songPathField.Margin = new System.Windows.Forms.Padding(2);
            this.songPathField.Name = "songPathField";
            this.songPathField.Size = new System.Drawing.Size(218, 20);
            this.songPathField.TabIndex = 4;
            this.songPathField.Visible = false;
            // 
            // recordRadioBtn
            // 
            this.recordRadioBtn.AutoSize = true;
            this.recordRadioBtn.Checked = true;
            this.recordRadioBtn.Location = new System.Drawing.Point(125, 42);
            this.recordRadioBtn.Name = "recordRadioBtn";
            this.recordRadioBtn.Size = new System.Drawing.Size(86, 17);
            this.recordRadioBtn.TabIndex = 6;
            this.recordRadioBtn.TabStop = true;
            this.recordRadioBtn.Text = "Record song";
            this.recordRadioBtn.UseVisualStyleBackColor = true;
            this.recordRadioBtn.CheckedChanged += new System.EventHandler(this.recordRadioBtn_CheckedChanged);
            // 
            // openRadioBtn
            // 
            this.openRadioBtn.AutoSize = true;
            this.openRadioBtn.Location = new System.Drawing.Point(226, 42);
            this.openRadioBtn.Name = "openRadioBtn";
            this.openRadioBtn.Size = new System.Drawing.Size(84, 17);
            this.openRadioBtn.TabIndex = 7;
            this.openRadioBtn.Text = "Open record";
            this.openRadioBtn.UseVisualStyleBackColor = true;
            this.openRadioBtn.CheckedChanged += new System.EventHandler(this.openRadioBtn_CheckedChanged);
            // 
            // matchesGridView
            // 
            this.matchesGridView.AllowUserToAddRows = false;
            this.matchesGridView.AllowUserToDeleteRows = false;
            this.matchesGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.matchesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matchesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.songNameColumn,
            this.matchesColumn});
            this.matchesGridView.Location = new System.Drawing.Point(11, 228);
            this.matchesGridView.Name = "matchesGridView";
            this.matchesGridView.ReadOnly = true;
            this.matchesGridView.RowHeadersVisible = false;
            this.matchesGridView.Size = new System.Drawing.Size(413, 168);
            this.matchesGridView.TabIndex = 8;
            // 
            // songNameColumn
            // 
            this.songNameColumn.HeaderText = "Song name";
            this.songNameColumn.Name = "songNameColumn";
            this.songNameColumn.ReadOnly = true;
            this.songNameColumn.Width = 250;
            // 
            // matchesColumn
            // 
            this.matchesColumn.HeaderText = "Matches";
            this.matchesColumn.Name = "matchesColumn";
            this.matchesColumn.ReadOnly = true;
            this.matchesColumn.Width = 160;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(436, 449);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.matchesGridView);
            this.Controls.Add(this.openRadioBtn);
            this.Controls.Add(this.recordRadioBtn);
            this.Controls.Add(this.songPathField);
            this.Controls.Add(this.openSongBtn);
            this.Controls.Add(this.recordBtn);
            this.Controls.Add(this.recognizeBtn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainWindow";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matchesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSongsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button recognizeBtn;
        private System.Windows.Forms.Button recordBtn;
        private System.Windows.Forms.Button openSongBtn;
        private System.Windows.Forms.TextBox songPathField;
        private System.Windows.Forms.RadioButton recordRadioBtn;
        private System.Windows.Forms.RadioButton openRadioBtn;
        private System.Windows.Forms.DataGridView matchesGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn songNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matchesColumn;
    }
}

