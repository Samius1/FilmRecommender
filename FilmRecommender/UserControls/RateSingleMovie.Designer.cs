namespace FilmRecommender.UserControls
{
    partial class RateSingleMovie
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
            FilmRatingControl = new FilmRating();
            PanelButtons = new Panel();
            BtnSave = new Button();
            PanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // FilmRatingControl
            // 
            FilmRatingControl.Dock = DockStyle.Top;
            FilmRatingControl.Location = new Point(0, 0);
            FilmRatingControl.Name = "FilmRatingControl";
            FilmRatingControl.Size = new Size(1152, 69);
            FilmRatingControl.TabIndex = 0;
            // 
            // PanelButtons
            // 
            PanelButtons.Controls.Add(BtnSave);
            PanelButtons.Dock = DockStyle.Fill;
            PanelButtons.Location = new Point(0, 69);
            PanelButtons.Name = "PanelButtons";
            PanelButtons.Size = new Size(1152, 43);
            PanelButtons.TabIndex = 1;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(1046, 6);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(94, 29);
            BtnSave.TabIndex = 0;
            BtnSave.Text = "Save";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // RateSingleMovil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 112);
            Controls.Add(PanelButtons);
            Controls.Add(FilmRatingControl);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RateSingleMovil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rate the movie";
            TopMost = true;
            PanelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FilmRating FilmRatingControl;
        private Panel PanelButtons;
        private Button BtnSave;
    }
}