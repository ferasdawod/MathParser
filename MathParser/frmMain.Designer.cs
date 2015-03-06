namespace MathParser
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.styleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.chkUseRadians = new MetroFramework.Controls.MetroCheckBox();
            this.lblEnterExpression = new MetroFramework.Controls.MetroLabel();
            this.txtInputExpression = new MetroFramework.Controls.MetroTextBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.pnlLoading = new MetroFramework.Controls.MetroPanel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.lblCurrentTask = new MetroFramework.Controls.MetroLabel();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.btnAbout = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.btnParse = new MetroFramework.Controls.MetroButton();
            this.txtAnswer = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtPostfix = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtExtractedTokens = new MetroFramework.Controls.MetroTextBox();
            this.txtOptimized = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.pnlImage = new MetroFramework.Controls.MetroPanel();
            this.pctrTree = new System.Windows.Forms.PictureBox();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.gridHelp = new MetroFramework.Controls.MetroGrid();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExample = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.pnlLoading.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrTree)).BeginInit();
            this.metroTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            // 
            // chkUseRadians
            // 
            this.chkUseRadians.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUseRadians.AutoSize = true;
            this.chkUseRadians.Location = new System.Drawing.Point(663, 35);
            this.chkUseRadians.Name = "chkUseRadians";
            this.chkUseRadians.Size = new System.Drawing.Size(86, 15);
            this.chkUseRadians.TabIndex = 0;
            this.chkUseRadians.Text = "Use Radians";
            this.chkUseRadians.UseSelectable = true;
            // 
            // lblEnterExpression
            // 
            this.lblEnterExpression.AutoSize = true;
            this.lblEnterExpression.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblEnterExpression.Location = new System.Drawing.Point(3, 31);
            this.lblEnterExpression.Name = "lblEnterExpression";
            this.lblEnterExpression.Size = new System.Drawing.Size(212, 19);
            this.lblEnterExpression.TabIndex = 1;
            this.lblEnterExpression.Text = "Enter The Math Expression Here :";
            // 
            // txtInputExpression
            // 
            this.txtInputExpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputExpression.Lines = new string[0];
            this.txtInputExpression.Location = new System.Drawing.Point(3, 53);
            this.txtInputExpression.MaxLength = 32767;
            this.txtInputExpression.Name = "txtInputExpression";
            this.txtInputExpression.PasswordChar = '\0';
            this.txtInputExpression.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtInputExpression.SelectedText = "";
            this.txtInputExpression.Size = new System.Drawing.Size(746, 23);
            this.txtInputExpression.TabIndex = 0;
            this.txtInputExpression.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInputExpression.UseSelectable = true;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.metroTabControl1.ItemSize = new System.Drawing.Size(130, 35);
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.ShowToolTips = true;
            this.metroTabControl1.Size = new System.Drawing.Size(760, 370);
            this.metroTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.metroTabControl1.TabIndex = 8;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.pnlLoading);
            this.metroTabPage1.Controls.Add(this.btnAbout);
            this.metroTabPage1.Controls.Add(this.metroLabel5);
            this.metroTabPage1.Controls.Add(this.btnParse);
            this.metroTabPage1.Controls.Add(this.txtAnswer);
            this.metroTabPage1.Controls.Add(this.metroLabel4);
            this.metroTabPage1.Controls.Add(this.txtPostfix);
            this.metroTabPage1.Controls.Add(this.metroLabel3);
            this.metroTabPage1.Controls.Add(this.txtExtractedTokens);
            this.metroTabPage1.Controls.Add(this.txtOptimized);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.txtInputExpression);
            this.metroTabPage1.Controls.Add(this.lblEnterExpression);
            this.metroTabPage1.Controls.Add(this.chkUseRadians);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(752, 327);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Expression Input";
            this.metroTabPage1.ToolTipText = "Here is where you input your math expression";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // pnlLoading
            // 
            this.pnlLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLoading.Controls.Add(this.metroLabel7);
            this.pnlLoading.Controls.Add(this.lblCurrentTask);
            this.pnlLoading.Controls.Add(this.metroProgressSpinner1);
            this.pnlLoading.HorizontalScrollbarBarColor = true;
            this.pnlLoading.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlLoading.HorizontalScrollbarSize = 10;
            this.pnlLoading.Location = new System.Drawing.Point(255, 266);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(209, 74);
            this.pnlLoading.TabIndex = 20;
            this.pnlLoading.VerticalScrollbarBarColor = true;
            this.pnlLoading.VerticalScrollbarHighlightOnWheel = false;
            this.pnlLoading.VerticalScrollbarSize = 10;
            this.pnlLoading.Visible = false;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(3, 20);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(88, 19);
            this.metroLabel7.TabIndex = 20;
            this.metroLabel7.Text = "Please Wait...";
            // 
            // lblCurrentTask
            // 
            this.lblCurrentTask.AutoSize = true;
            this.lblCurrentTask.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblCurrentTask.Location = new System.Drawing.Point(3, 39);
            this.lblCurrentTask.Name = "lblCurrentTask";
            this.lblCurrentTask.Size = new System.Drawing.Size(79, 19);
            this.lblCurrentTask.TabIndex = 19;
            this.lblCurrentTask.Text = "Initializing...";
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(156, 8);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(50, 50);
            this.metroProgressSpinner1.Speed = 2F;
            this.metroProgressSpinner1.TabIndex = 18;
            this.metroProgressSpinner1.TabStop = false;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.Value = 50;
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbout.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnAbout.Location = new System.Drawing.Point(3, 301);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(104, 23);
            this.btnAbout.TabIndex = 7;
            this.btnAbout.Text = "About";
            this.btnAbout.UseSelectable = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(3, 99);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(77, 25);
            this.metroLabel5.TabIndex = 15;
            this.metroLabel5.Text = "Results :";
            // 
            // btnParse
            // 
            this.btnParse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParse.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnParse.Highlight = true;
            this.btnParse.Location = new System.Drawing.Point(645, 301);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(104, 23);
            this.btnParse.TabIndex = 5;
            this.btnParse.Text = "Parse";
            this.btnParse.UseSelectable = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // txtAnswer
            // 
            this.txtAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnswer.Lines = new string[0];
            this.txtAnswer.Location = new System.Drawing.Point(156, 224);
            this.txtAnswer.MaxLength = 32767;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.PasswordChar = '\0';
            this.txtAnswer.PromptText = "Answer";
            this.txtAnswer.ReadOnly = true;
            this.txtAnswer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAnswer.SelectedText = "";
            this.txtAnswer.Size = new System.Drawing.Size(593, 23);
            this.txtAnswer.TabIndex = 4;
            this.txtAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAnswer.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(3, 228);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(61, 19);
            this.metroLabel4.TabIndex = 12;
            this.metroLabel4.Text = "Answer :";
            // 
            // txtPostfix
            // 
            this.txtPostfix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPostfix.Lines = new string[0];
            this.txtPostfix.Location = new System.Drawing.Point(156, 195);
            this.txtPostfix.MaxLength = 32767;
            this.txtPostfix.Name = "txtPostfix";
            this.txtPostfix.PasswordChar = '\0';
            this.txtPostfix.PromptText = "Postfix Expression";
            this.txtPostfix.ReadOnly = true;
            this.txtPostfix.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPostfix.SelectedText = "";
            this.txtPostfix.Size = new System.Drawing.Size(593, 23);
            this.txtPostfix.TabIndex = 3;
            this.txtPostfix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPostfix.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(3, 199);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(124, 19);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "Postfix Expression :";
            // 
            // txtExtractedTokens
            // 
            this.txtExtractedTokens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtractedTokens.Lines = new string[0];
            this.txtExtractedTokens.Location = new System.Drawing.Point(156, 166);
            this.txtExtractedTokens.MaxLength = 32767;
            this.txtExtractedTokens.Name = "txtExtractedTokens";
            this.txtExtractedTokens.PasswordChar = '\0';
            this.txtExtractedTokens.PromptText = "Extracted Math Tokens";
            this.txtExtractedTokens.ReadOnly = true;
            this.txtExtractedTokens.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtExtractedTokens.SelectedText = "";
            this.txtExtractedTokens.Size = new System.Drawing.Size(593, 23);
            this.txtExtractedTokens.TabIndex = 2;
            this.txtExtractedTokens.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtExtractedTokens.UseSelectable = true;
            // 
            // txtOptimized
            // 
            this.txtOptimized.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOptimized.Lines = new string[0];
            this.txtOptimized.Location = new System.Drawing.Point(156, 137);
            this.txtOptimized.MaxLength = 32767;
            this.txtOptimized.Name = "txtOptimized";
            this.txtOptimized.PasswordChar = '\0';
            this.txtOptimized.PromptText = "Optimized Expression";
            this.txtOptimized.ReadOnly = true;
            this.txtOptimized.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOptimized.SelectedText = "";
            this.txtOptimized.Size = new System.Drawing.Size(593, 23);
            this.txtOptimized.TabIndex = 1;
            this.txtOptimized.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOptimized.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(3, 170);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(119, 19);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "Extracted Tokens :";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(3, 141);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(147, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Optimized Expression :";
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.pnlImage);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(752, 327);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Tree Drawing";
            this.metroTabPage2.ToolTipText = "Here is where your math tree is rendered after parsing it from the expression tha" +
    "t you provide";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // pnlImage
            // 
            this.pnlImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImage.AutoScroll = true;
            this.pnlImage.Controls.Add(this.pctrTree);
            this.pnlImage.HorizontalScrollbar = true;
            this.pnlImage.HorizontalScrollbarBarColor = true;
            this.pnlImage.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlImage.HorizontalScrollbarSize = 10;
            this.pnlImage.Location = new System.Drawing.Point(3, 10);
            this.pnlImage.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(746, 314);
            this.pnlImage.TabIndex = 2;
            this.pnlImage.VerticalScrollbar = true;
            this.pnlImage.VerticalScrollbarBarColor = true;
            this.pnlImage.VerticalScrollbarHighlightOnWheel = false;
            this.pnlImage.VerticalScrollbarSize = 10;
            // 
            // pctrTree
            // 
            this.pctrTree.BackColor = System.Drawing.Color.Transparent;
            this.pctrTree.Location = new System.Drawing.Point(0, 0);
            this.pctrTree.Name = "pctrTree";
            this.pctrTree.Size = new System.Drawing.Size(553, 204);
            this.pctrTree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctrTree.TabIndex = 2;
            this.pctrTree.TabStop = false;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.gridHelp);
            this.metroTabPage3.Controls.Add(this.metroLabel6);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(752, 327);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Help";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(3, 22);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(185, 25);
            this.metroLabel6.TabIndex = 2;
            this.metroLabel6.Text = "Available Operations :";
            // 
            // gridHelp
            // 
            this.gridHelp.AllowUserToAddRows = false;
            this.gridHelp.AllowUserToDeleteRows = false;
            this.gridHelp.AllowUserToOrderColumns = true;
            this.gridHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridHelp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridHelp.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridHelp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridHelp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHelp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridHelp.ColumnHeadersHeight = 30;
            this.gridHelp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridHelp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnDescription,
            this.ColumnExample});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridHelp.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridHelp.EnableHeadersVisualStyles = false;
            this.gridHelp.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridHelp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridHelp.Location = new System.Drawing.Point(3, 57);
            this.gridHelp.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.gridHelp.Name = "gridHelp";
            this.gridHelp.ReadOnly = true;
            this.gridHelp.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHelp.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridHelp.RowHeadersVisible = false;
            this.gridHelp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.gridHelp.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.gridHelp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHelp.Size = new System.Drawing.Size(746, 267);
            this.gridHelp.TabIndex = 3;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnName.HeaderText = "Operation Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 161;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.HeaderText = "Description";
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.ReadOnly = true;
            // 
            // ColumnExample
            // 
            this.ColumnExample.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnExample.HeaderText = "Examples";
            this.ColumnExample.Name = "ColumnExample";
            this.ColumnExample.ReadOnly = true;
            this.ColumnExample.Width = 107;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnParse;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroTabControl1);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "frmMain";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Math Parser";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.pnlLoading.ResumeLayout(false);
            this.pnlLoading.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.pnlImage.ResumeLayout(false);
            this.pnlImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrTree)).EndInit();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager styleManager;
        private MetroFramework.Controls.MetroLabel lblEnterExpression;
        private MetroFramework.Controls.MetroCheckBox chkUseRadians;
        private MetroFramework.Controls.MetroTextBox txtInputExpression;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroPanel pnlImage;
        private MetroFramework.Controls.MetroTextBox txtOptimized;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtAnswer;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtPostfix;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtExtractedTokens;
        private MetroFramework.Controls.MetroButton btnParse;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.PictureBox pctrTree;
        private MetroFramework.Controls.MetroButton btnAbout;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroLabel lblCurrentTask;
        private MetroFramework.Controls.MetroPanel pnlLoading;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroGrid gridHelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExample;
    }
}