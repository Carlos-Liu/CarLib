namespace CarLib.Common
{
    partial class MessageBoxEx
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
            this.layoutPanelRoot = new System.Windows.Forms.TableLayoutPanel();
            this.layoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnIgnoreAll = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.layoutPanelRoot.SuspendLayout();
            this.layoutPanelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutPanelRoot
            // 
            this.layoutPanelRoot.AutoSize = true;
            this.layoutPanelRoot.ColumnCount = 4;
            this.layoutPanelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutPanelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanelRoot.Controls.Add(this.layoutPanelButtons, 1, 2);
            this.layoutPanelRoot.Controls.Add(this.pictureBox, 1, 1);
            this.layoutPanelRoot.Controls.Add(this.labelMessage, 2, 1);
            this.layoutPanelRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanelRoot.Location = new System.Drawing.Point(0, 0);
            this.layoutPanelRoot.Name = "layoutPanelRoot";
            this.layoutPanelRoot.RowCount = 4;
            this.layoutPanelRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanelRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanelRoot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanelRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanelRoot.Size = new System.Drawing.Size(423, 172);
            this.layoutPanelRoot.TabIndex = 1;
            // 
            // layoutPanelButtons
            // 
            this.layoutPanelButtons.AutoSize = true;
            this.layoutPanelButtons.ColumnCount = 4;
            this.layoutPanelRoot.SetColumnSpan(this.layoutPanelButtons, 2);
            this.layoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutPanelButtons.Controls.Add(this.btnIgnore, 0, 0);
            this.layoutPanelButtons.Controls.Add(this.btnIgnoreAll, 1, 0);
            this.layoutPanelButtons.Controls.Add(this.btnRetry, 2, 0);
            this.layoutPanelButtons.Controls.Add(this.btnAbort, 3, 0);
            this.layoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanelButtons.Location = new System.Drawing.Point(20, 121);
            this.layoutPanelButtons.Margin = new System.Windows.Forms.Padding(0);
            this.layoutPanelButtons.Name = "layoutPanelButtons";
            this.layoutPanelButtons.RowCount = 1;
            this.layoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanelButtons.Size = new System.Drawing.Size(383, 31);
            this.layoutPanelButtons.TabIndex = 3;
            // 
            // btnIgnore
            // 
            this.btnIgnore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnIgnore.Location = new System.Drawing.Point(10, 4);
            this.btnIgnore.Margin = new System.Windows.Forms.Padding(4);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(75, 23);
            this.btnIgnore.TabIndex = 0;
            this.btnIgnore.Text = "&Ignore";
            this.btnIgnore.UseVisualStyleBackColor = true;
            // 
            // btnIgnoreAll
            // 
            this.btnIgnoreAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnIgnoreAll.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnIgnoreAll.Location = new System.Drawing.Point(105, 4);
            this.btnIgnoreAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnIgnoreAll.Name = "btnIgnoreAll";
            this.btnIgnoreAll.Size = new System.Drawing.Size(75, 23);
            this.btnIgnoreAll.TabIndex = 1;
            this.btnIgnoreAll.Text = "Ingore &All";
            this.btnIgnoreAll.UseVisualStyleBackColor = true;
            this.btnIgnoreAll.Click += new System.EventHandler(this.btnIgnoreAll_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnRetry.Location = new System.Drawing.Point(200, 4);
            this.btnRetry.Margin = new System.Windows.Forms.Padding(4);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(75, 23);
            this.btnRetry.TabIndex = 2;
            this.btnRetry.Text = "&Retry";
            this.btnRetry.UseVisualStyleBackColor = true;
            // 
            // btnAbort
            // 
            this.btnAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnAbort.Location = new System.Drawing.Point(296, 4);
            this.btnAbort.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbort.TabIndex = 3;
            this.btnAbort.Text = "Abot";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(24, 24);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(32, 32);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 6;
            this.pictureBox.TabStop = false;
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(64, 24);
            this.labelMessage.Margin = new System.Windows.Forms.Padding(4);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Padding = new System.Windows.Forms.Padding(2);
            this.labelMessage.Size = new System.Drawing.Size(335, 17);
            this.labelMessage.TabIndex = 7;
            // 
            // MessageBoxEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(423, 172);
            this.Controls.Add(this.layoutPanelRoot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBoxEx";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBoxEx";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageBoxEx_FormClosing);
            this.layoutPanelRoot.ResumeLayout(false);
            this.layoutPanelRoot.PerformLayout();
            this.layoutPanelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutPanelRoot;
        private System.Windows.Forms.TableLayoutPanel layoutPanelButtons;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Button btnIgnoreAll;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Button btnAbort;
    }
}