namespace FilmRecommender
{
    partial class GUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            PanelInitializeModel = new Panel();
            PanelInitializeModelRight = new Panel();
            BtnLoadModel = new Button();
            ProgressBarLoadingModel = new ProgressBar();
            TabContent = new TabControl();
            TabPageProfile = new TabPage();
            PanelLblInfo = new Panel();
            LblInfoProfile = new Label();
            TabPageRecommendations = new TabPage();
            PanelSaveProfile = new Panel();
            BtnSaveProfile = new Button();
            BackgroundWorkerProfile = new System.ComponentModel.BackgroundWorker();
            PanelInitializeModel.SuspendLayout();
            PanelInitializeModelRight.SuspendLayout();
            TabContent.SuspendLayout();
            TabPageProfile.SuspendLayout();
            PanelLblInfo.SuspendLayout();
            PanelSaveProfile.SuspendLayout();
            SuspendLayout();
            // 
            // PanelInitializeModel
            // 
            PanelInitializeModel.Controls.Add(PanelInitializeModelRight);
            PanelInitializeModel.Controls.Add(ProgressBarLoadingModel);
            PanelInitializeModel.Dock = DockStyle.Top;
            PanelInitializeModel.Location = new Point(0, 0);
            PanelInitializeModel.Name = "PanelInitializeModel";
            PanelInitializeModel.Size = new Size(1000, 37);
            PanelInitializeModel.TabIndex = 0;
            // 
            // PanelInitializeModelRight
            // 
            PanelInitializeModelRight.Controls.Add(BtnLoadModel);
            PanelInitializeModelRight.Dock = DockStyle.Right;
            PanelInitializeModelRight.Location = new Point(875, 0);
            PanelInitializeModelRight.Name = "PanelInitializeModelRight";
            PanelInitializeModelRight.Size = new Size(125, 37);
            PanelInitializeModelRight.TabIndex = 2;
            // 
            // BtnLoadModel
            // 
            BtnLoadModel.Location = new Point(3, 3);
            BtnLoadModel.Name = "BtnLoadModel";
            BtnLoadModel.Size = new Size(117, 29);
            BtnLoadModel.TabIndex = 1;
            BtnLoadModel.Text = "Load model";
            BtnLoadModel.UseVisualStyleBackColor = true;
            BtnLoadModel.Click += BtnLoadModel_Click;
            // 
            // ProgressBarLoadingModel
            // 
            ProgressBarLoadingModel.Dock = DockStyle.Fill;
            ProgressBarLoadingModel.Location = new Point(0, 0);
            ProgressBarLoadingModel.Name = "ProgressBarLoadingModel";
            ProgressBarLoadingModel.Size = new Size(1000, 37);
            ProgressBarLoadingModel.TabIndex = 0;
            // 
            // TabContent
            // 
            TabContent.Controls.Add(TabPageProfile);
            TabContent.Controls.Add(TabPageRecommendations);
            TabContent.Dock = DockStyle.Fill;
            TabContent.Location = new Point(0, 37);
            TabContent.Name = "TabContent";
            TabContent.SelectedIndex = 0;
            TabContent.Size = new Size(1000, 438);
            TabContent.TabIndex = 1;
            TabContent.Visible = false;
            // 
            // TabPageProfile
            // 
            TabPageProfile.AutoScroll = true;
            TabPageProfile.Controls.Add(PanelLblInfo);
            TabPageProfile.Location = new Point(4, 29);
            TabPageProfile.Name = "TabPageProfile";
            TabPageProfile.Padding = new Padding(3);
            TabPageProfile.Size = new Size(992, 405);
            TabPageProfile.TabIndex = 0;
            TabPageProfile.Text = "Profile";
            TabPageProfile.UseVisualStyleBackColor = true;
            // 
            // PanelLblInfo
            // 
            PanelLblInfo.Controls.Add(LblInfoProfile);
            PanelLblInfo.Dock = DockStyle.Top;
            PanelLblInfo.Location = new Point(3, 3);
            PanelLblInfo.Name = "PanelLblInfo";
            PanelLblInfo.Size = new Size(986, 25);
            PanelLblInfo.TabIndex = 2;
            // 
            // LblInfoProfile
            // 
            LblInfoProfile.AutoSize = true;
            LblInfoProfile.Dock = DockStyle.Fill;
            LblInfoProfile.Location = new Point(0, 0);
            LblInfoProfile.Name = "LblInfoProfile";
            LblInfoProfile.Size = new Size(864, 20);
            LblInfoProfile.TabIndex = 1;
            LblInfoProfile.Text = "Rate the films and click on \"Save\" to store your profile and generate recommendations. Click on \"New model\" to reset this screen.";
            // 
            // TabPageRecommendations
            // 
            TabPageRecommendations.Location = new Point(4, 29);
            TabPageRecommendations.Name = "TabPageRecommendations";
            TabPageRecommendations.Padding = new Padding(3);
            TabPageRecommendations.Size = new Size(992, 405);
            TabPageRecommendations.TabIndex = 1;
            TabPageRecommendations.Text = "Recommendations";
            TabPageRecommendations.UseVisualStyleBackColor = true;
            // 
            // PanelSaveProfile
            // 
            PanelSaveProfile.Controls.Add(BtnSaveProfile);
            PanelSaveProfile.Dock = DockStyle.Bottom;
            PanelSaveProfile.Location = new Point(0, 475);
            PanelSaveProfile.Name = "PanelSaveProfile";
            PanelSaveProfile.Size = new Size(1000, 34);
            PanelSaveProfile.TabIndex = 0;
            // 
            // BtnSaveProfile
            // 
            BtnSaveProfile.Dock = DockStyle.Right;
            BtnSaveProfile.Location = new Point(920, 0);
            BtnSaveProfile.Name = "BtnSaveProfile";
            BtnSaveProfile.Size = new Size(80, 34);
            BtnSaveProfile.TabIndex = 0;
            BtnSaveProfile.Text = "Save";
            BtnSaveProfile.UseVisualStyleBackColor = true;
            BtnSaveProfile.Click += BtnSaveProfile_Click;
            // 
            // BackgroundWorkerProfile
            // 
            BackgroundWorkerProfile.WorkerReportsProgress = true;
            BackgroundWorkerProfile.DoWork += BackgroundWorkerProfile_DoWork;
            BackgroundWorkerProfile.ProgressChanged += BackgroundWorkerProfile_ProgressChanged;
            BackgroundWorkerProfile.RunWorkerCompleted += BackgroundWorkerProfile_RunWorkerCompleted;
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 509);
            Controls.Add(TabContent);
            Controls.Add(PanelSaveProfile);
            Controls.Add(PanelInitializeModel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GUI";
            Text = "Film Recommender";
            Load += GUI_Load;
            PanelInitializeModel.ResumeLayout(false);
            PanelInitializeModelRight.ResumeLayout(false);
            TabContent.ResumeLayout(false);
            TabPageProfile.ResumeLayout(false);
            PanelLblInfo.ResumeLayout(false);
            PanelLblInfo.PerformLayout();
            PanelSaveProfile.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelInitializeModel;
        private Button BtnLoadModel;
        private ProgressBar ProgressBarLoadingModel;
        private Panel PanelInitializeModelRight;
        private TabControl TabContent;
        private TabPage TabPageProfile;
        private TabPage TabPageRecommendations;
        private Panel PanelSaveProfile;
        private Button BtnSaveProfile;
        private Label LblInfoProfile;
        private Panel PanelLblInfo;
        private System.ComponentModel.BackgroundWorker BackgroundWorkerProfile;
    }
}