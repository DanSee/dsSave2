namespace dsSave
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.lstBoxSavedGames = new System.Windows.Forms.ListBox();
            this.saveCustom = new System.Windows.Forms.Button();
            this.saveCustomTextBox = new System.Windows.Forms.TextBox();
            this.btnQuickSaves = new System.Windows.Forms.Button();
            this.btnCustomSaves = new System.Windows.Forms.Button();
            this.btnAutoSaves = new System.Windows.Forms.Button();
            this.btnLoadCustom = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnQuickSave = new System.Windows.Forms.Button();
            this.btnLoadQuickSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.enterSaveDIrectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblTimestamp = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrAutoSave = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBoxSavedGames
            // 
            this.lstBoxSavedGames.BackColor = System.Drawing.Color.Gray;
            this.lstBoxSavedGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoxSavedGames.ForeColor = System.Drawing.SystemColors.Window;
            this.lstBoxSavedGames.FormattingEnabled = true;
            this.lstBoxSavedGames.ItemHeight = 16;
            this.lstBoxSavedGames.Location = new System.Drawing.Point(8, 81);
            this.lstBoxSavedGames.Name = "lstBoxSavedGames";
            this.lstBoxSavedGames.Size = new System.Drawing.Size(342, 356);
            this.lstBoxSavedGames.TabIndex = 0;
            this.lstBoxSavedGames.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstBoxSavedGames_MouseDown);
            // 
            // saveCustom
            // 
            this.saveCustom.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.saveCustom.Location = new System.Drawing.Point(8, 455);
            this.saveCustom.Name = "saveCustom";
            this.saveCustom.Size = new System.Drawing.Size(75, 23);
            this.saveCustom.TabIndex = 1;
            this.saveCustom.Text = "Save custom";
            this.saveCustom.UseVisualStyleBackColor = false;
            this.saveCustom.Click += new System.EventHandler(this.saveCustom_Click);
            // 
            // saveCustomTextBox
            // 
            this.saveCustomTextBox.BackColor = System.Drawing.Color.Gray;
            this.saveCustomTextBox.Location = new System.Drawing.Point(88, 455);
            this.saveCustomTextBox.Name = "saveCustomTextBox";
            this.saveCustomTextBox.Size = new System.Drawing.Size(261, 20);
            this.saveCustomTextBox.TabIndex = 2;
            // 
            // btnQuickSaves
            // 
            this.btnQuickSaves.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnQuickSaves.Location = new System.Drawing.Point(8, 52);
            this.btnQuickSaves.Name = "btnQuickSaves";
            this.btnQuickSaves.Size = new System.Drawing.Size(109, 23);
            this.btnQuickSaves.TabIndex = 3;
            this.btnQuickSaves.Text = "Quick Saves";
            this.btnQuickSaves.UseVisualStyleBackColor = false;
            this.btnQuickSaves.Click += new System.EventHandler(this.btnQuickSaves_Click);
            // 
            // btnCustomSaves
            // 
            this.btnCustomSaves.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnCustomSaves.Location = new System.Drawing.Point(126, 52);
            this.btnCustomSaves.Name = "btnCustomSaves";
            this.btnCustomSaves.Size = new System.Drawing.Size(101, 23);
            this.btnCustomSaves.TabIndex = 4;
            this.btnCustomSaves.Text = "Custom Saves";
            this.btnCustomSaves.UseVisualStyleBackColor = false;
            this.btnCustomSaves.Click += new System.EventHandler(this.btnCustomSaves_Click);
            // 
            // btnAutoSaves
            // 
            this.btnAutoSaves.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAutoSaves.Location = new System.Drawing.Point(233, 52);
            this.btnAutoSaves.Name = "btnAutoSaves";
            this.btnAutoSaves.Size = new System.Drawing.Size(116, 23);
            this.btnAutoSaves.TabIndex = 5;
            this.btnAutoSaves.Text = "Auto Saves";
            this.btnAutoSaves.UseVisualStyleBackColor = false;
            this.btnAutoSaves.Click += new System.EventHandler(this.btnAutoSaves_Click);
            // 
            // btnLoadCustom
            // 
            this.btnLoadCustom.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLoadCustom.Location = new System.Drawing.Point(10, 19);
            this.btnLoadCustom.Name = "btnLoadCustom";
            this.btnLoadCustom.Size = new System.Drawing.Size(217, 23);
            this.btnLoadCustom.TabIndex = 6;
            this.btnLoadCustom.Text = "Load Save";
            this.btnLoadCustom.UseVisualStyleBackColor = false;
            this.btnLoadCustom.Click += new System.EventHandler(this.btnLoadCustom_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnRefresh.Location = new System.Drawing.Point(231, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnLoadCustom);
            this.groupBox1.Controls.Add(this.btnAutoSaves);
            this.groupBox1.Controls.Add(this.btnCustomSaves);
            this.groupBox1.Controls.Add(this.btnQuickSaves);
            this.groupBox1.Controls.Add(this.saveCustomTextBox);
            this.groupBox1.Controls.Add(this.saveCustom);
            this.groupBox1.Controls.Add(this.lstBoxSavedGames);
            this.groupBox1.Location = new System.Drawing.Point(12, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 484);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btnQuickSave
            // 
            this.btnQuickSave.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnQuickSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnQuickSave.Location = new System.Drawing.Point(6, 15);
            this.btnQuickSave.Name = "btnQuickSave";
            this.btnQuickSave.Size = new System.Drawing.Size(172, 39);
            this.btnQuickSave.TabIndex = 9;
            this.btnQuickSave.Text = "Quicksave";
            this.btnQuickSave.UseVisualStyleBackColor = false;
            this.btnQuickSave.Click += new System.EventHandler(this.btnQuickSave_Click);
            // 
            // btnLoadQuickSave
            // 
            this.btnLoadQuickSave.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLoadQuickSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLoadQuickSave.Location = new System.Drawing.Point(182, 15);
            this.btnLoadQuickSave.Name = "btnLoadQuickSave";
            this.btnLoadQuickSave.Size = new System.Drawing.Size(172, 39);
            this.btnLoadQuickSave.TabIndex = 10;
            this.btnLoadQuickSave.Text = "Load newest quicksave";
            this.btnLoadQuickSave.UseVisualStyleBackColor = false;
            this.btnLoadQuickSave.Click += new System.EventHandler(this.btnLoadQuickSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnQuickSave);
            this.groupBox2.Controls.Add(this.btnLoadQuickSave);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 60);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 26);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.setToolStripMenuItem.Text = "Enter game save Directory";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterSaveDIrectoryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // enterSaveDIrectoryToolStripMenuItem
            // 
            this.enterSaveDIrectoryToolStripMenuItem.Name = "enterSaveDIrectoryToolStripMenuItem";
            this.enterSaveDIrectoryToolStripMenuItem.Size = new System.Drawing.Size(124, 20);
            this.enterSaveDIrectoryToolStripMenuItem.Text = "Enter Save Directory";
            this.enterSaveDIrectoryToolStripMenuItem.Click += new System.EventHandler(this.enterSaveDIrectoryToolStripMenuItem_Click);
            // 
            // lblDisplay
            // 
            this.lblDisplay.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(15, 157);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(360, 20);
            this.lblDisplay.TabIndex = 15;
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimestamp
            // 
            this.lblTimestamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimestamp.ForeColor = System.Drawing.Color.Black;
            this.lblTimestamp.Location = new System.Drawing.Point(12, 90);
            this.lblTimestamp.Name = "lblTimestamp";
            this.lblTimestamp.Size = new System.Drawing.Size(178, 60);
            this.lblTimestamp.TabIndex = 17;
            this.lblTimestamp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClock
            // 
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblClock.Location = new System.Drawing.Point(197, 90);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(178, 60);
            this.lblClock.TabIndex = 18;
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clockTimer
            // 
            this.clockTimer.Enabled = true;
            this.clockTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmrAutoSave
            // 
            this.tmrAutoSave.Enabled = true;
            this.tmrAutoSave.Tick += new System.EventHandler(this.tmrAutoSave_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(384, 670);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.lblTimestamp);
            this.Controls.Add(this.lblDisplay);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dsSave   \\__  O.o  __/";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxSavedGames;
        private System.Windows.Forms.Button saveCustom;
        private System.Windows.Forms.TextBox saveCustomTextBox;
        private System.Windows.Forms.Button btnQuickSaves;
        private System.Windows.Forms.Button btnCustomSaves;
        private System.Windows.Forms.Button btnAutoSaves;
        private System.Windows.Forms.Button btnLoadCustom;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQuickSave;
        private System.Windows.Forms.Button btnLoadQuickSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enterSaveDIrectoryToolStripMenuItem;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblTimestamp;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer tmrAutoSave;


    }
}

