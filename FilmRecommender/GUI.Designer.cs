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
            PanelRatedFilms = new Panel();
            PanelLblInfo = new Panel();
            LblInfoProfile = new Label();
            TabPageRecommendations = new TabPage();
            PanelRecommendations = new Panel();
            PanelRecommendationsInfo = new Panel();
            LblRecommendations = new Label();
            BtnRecommendations = new Button();
            PanelSaveProfile = new Panel();
            BtnSaveProfile = new Button();
            BackgroundWorkerProfile = new System.ComponentModel.BackgroundWorker();
            PanelInitializeModel.SuspendLayout();
            PanelInitializeModelRight.SuspendLayout();
            TabContent.SuspendLayout();
            TabPageProfile.SuspendLayout();
            PanelLblInfo.SuspendLayout();
            TabPageRecommendations.SuspendLayout();
            PanelRecommendationsInfo.SuspendLayout();
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
            TabPageProfile.Controls.Add(PanelRatedFilms);
            TabPageProfile.Controls.Add(PanelLblInfo);
            TabPageProfile.Location = new Point(4, 29);
            TabPageProfile.Name = "TabPageProfile";
            TabPageProfile.Padding = new Padding(3);
            TabPageProfile.Size = new Size(992, 405);
            TabPageProfile.TabIndex = 0;
            TabPageProfile.Text = "Profile";
            TabPageProfile.UseVisualStyleBackColor = true;
            // 
            // PanelRatedFilms
            // 
            PanelRatedFilms.AutoScroll = true;
            PanelRatedFilms.Dock = DockStyle.Fill;
            PanelRatedFilms.Location = new Point(3, 28);
            PanelRatedFilms.Name = "PanelRatedFilms";
            PanelRatedFilms.Size = new Size(986, 374);
            PanelRatedFilms.TabIndex = 3;
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
            TabPageRecommendations.Controls.Add(PanelRecommendations);
            TabPageRecommendations.Controls.Add(PanelRecommendationsInfo);
            TabPageRecommendations.Location = new Point(4, 29);
            TabPageRecommendations.Name = "TabPageRecommendations";
            TabPageRecommendations.Padding = new Padding(3);
            TabPageRecommendations.Size = new Size(992, 405);
            TabPageRecommendations.TabIndex = 1;
            TabPageRecommendations.Text = "Recommendations";
            TabPageRecommendations.UseVisualStyleBackColor = true;
            // 
            // PanelRecommendations
            // 
            PanelRecommendations.AutoScroll = true;
            PanelRecommendations.Dock = DockStyle.Fill;
            PanelRecommendations.Location = new Point(3, 32);
            PanelRecommendations.Name = "PanelRecommendations";
            PanelRecommendations.Size = new Size(986, 370);
            PanelRecommendations.TabIndex = 1;
            // 
            // PanelRecommendationsInfo
            // 
            PanelRecommendationsInfo.Controls.Add(LblRecommendations);
            PanelRecommendationsInfo.Controls.Add(BtnRecommendations);
            PanelRecommendationsInfo.Dock = DockStyle.Top;
            PanelRecommendationsInfo.Location = new Point(3, 3);
            PanelRecommendationsInfo.Name = "PanelRecommendationsInfo";
            PanelRecommendationsInfo.Size = new Size(986, 29);
            PanelRecommendationsInfo.TabIndex = 0;
            // 
            // LblRecommendations
            // 
            LblRecommendations.AutoSize = true;
            LblRecommendations.Dock = DockStyle.Top;
            LblRecommendations.Location = new Point(0, 0);
            LblRecommendations.Name = "LblRecommendations";
            LblRecommendations.Size = new Size(493, 20);
            LblRecommendations.TabIndex = 0;
            LblRecommendations.Text = "Click on \"Find recommendations\" to find films similar to your preferences";
            // 
            // BtnRecommendations
            // 
            BtnRecommendations.Dock = DockStyle.Right;
            BtnRecommendations.Location = new Point(814, 0);
            BtnRecommendations.Name = "BtnRecommendations";
            BtnRecommendations.Size = new Size(172, 29);
            BtnRecommendations.TabIndex = 1;
            BtnRecommendations.Text = "Find recommendations";
            BtnRecommendations.UseVisualStyleBackColor = true;
            BtnRecommendations.Click += BtnRecommendations_Click;
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
            TabPageRecommendations.ResumeLayout(false);
            PanelRecommendationsInfo.ResumeLayout(false);
            PanelRecommendationsInfo.PerformLayout();
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
        private Panel PanelRecommendations;
        private Panel PanelRecommendationsInfo;
        private Button BtnRecommendations;
        private Label LblRecommendations;
        private Panel PanelRatedFilms;
    }
}