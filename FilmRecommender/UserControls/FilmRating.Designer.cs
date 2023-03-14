namespace FilmRecommender.UserControls
{
    partial class FilmRating
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            BtnStarOne = new Button();
            BtnStarTwo = new Button();
            BtnStarThree = new Button();
            BtnStarFour = new Button();
            BtnStarFive = new Button();
            FlowLayoutStars = new FlowLayoutPanel();
            TxtTitle = new RichTextBox();
            FlowLayoutStars.SuspendLayout();
            SuspendLayout();
            // 
            // BtnStarOne
            // 
            BtnStarOne.BackColor = SystemColors.Window;
            BtnStarOne.BackgroundImage = Properties.Resources.yellowStar;
            BtnStarOne.BackgroundImageLayout = ImageLayout.Zoom;
            BtnStarOne.Cursor = Cursors.Hand;
            BtnStarOne.FlatAppearance.BorderSize = 0;
            BtnStarOne.FlatAppearance.MouseDownBackColor = SystemColors.Window;
            BtnStarOne.FlatAppearance.MouseOverBackColor = SystemColors.Window;
            BtnStarOne.FlatStyle = FlatStyle.Flat;
            BtnStarOne.Location = new Point(3, 3);
            BtnStarOne.Name = "BtnStarOne";
            BtnStarOne.Size = new Size(48, 41);
            BtnStarOne.TabIndex = 0;
            BtnStarOne.UseVisualStyleBackColor = false;
            BtnStarOne.MouseClick += BtnStarOne_MouseClick;
            BtnStarOne.MouseEnter += BtnStarOne_MouseEnter;
            BtnStarOne.MouseLeave += BtnStar_MouseLeave;
            // 
            // BtnStarTwo
            // 
            BtnStarTwo.BackColor = SystemColors.Window;
            BtnStarTwo.BackgroundImage = Properties.Resources.emptyStar;
            BtnStarTwo.BackgroundImageLayout = ImageLayout.Zoom;
            BtnStarTwo.Cursor = Cursors.Hand;
            BtnStarTwo.FlatAppearance.BorderSize = 0;
            BtnStarTwo.FlatAppearance.MouseDownBackColor = SystemColors.Window;
            BtnStarTwo.FlatAppearance.MouseOverBackColor = SystemColors.Window;
            BtnStarTwo.FlatStyle = FlatStyle.Flat;
            BtnStarTwo.Location = new Point(57, 3);
            BtnStarTwo.Name = "BtnStarTwo";
            BtnStarTwo.Size = new Size(48, 41);
            BtnStarTwo.TabIndex = 1;
            BtnStarTwo.UseVisualStyleBackColor = false;
            BtnStarTwo.MouseClick += BtnStarTwo_MouseClick;
            BtnStarTwo.MouseEnter += BtnStarTwo_MouseEnter;
            BtnStarTwo.MouseLeave += BtnStar_MouseLeave;
            // 
            // BtnStarThree
            // 
            BtnStarThree.BackColor = SystemColors.Window;
            BtnStarThree.BackgroundImage = Properties.Resources.emptyStar;
            BtnStarThree.BackgroundImageLayout = ImageLayout.Zoom;
            BtnStarThree.Cursor = Cursors.Hand;
            BtnStarThree.FlatAppearance.BorderSize = 0;
            BtnStarThree.FlatAppearance.MouseDownBackColor = SystemColors.Window;
            BtnStarThree.FlatAppearance.MouseOverBackColor = SystemColors.Window;
            BtnStarThree.FlatStyle = FlatStyle.Flat;
            BtnStarThree.Location = new Point(111, 3);
            BtnStarThree.Name = "BtnStarThree";
            BtnStarThree.Size = new Size(48, 41);
            BtnStarThree.TabIndex = 2;
            BtnStarThree.UseVisualStyleBackColor = false;
            BtnStarThree.MouseClick += BtnStarThree_MouseClick;
            BtnStarThree.MouseEnter += BtnStarThree_MouseEnter;
            BtnStarThree.MouseLeave += BtnStar_MouseLeave;
            // 
            // BtnStarFour
            // 
            BtnStarFour.BackColor = SystemColors.Window;
            BtnStarFour.BackgroundImage = Properties.Resources.emptyStar;
            BtnStarFour.BackgroundImageLayout = ImageLayout.Zoom;
            BtnStarFour.Cursor = Cursors.Hand;
            BtnStarFour.FlatAppearance.BorderSize = 0;
            BtnStarFour.FlatAppearance.MouseDownBackColor = SystemColors.Window;
            BtnStarFour.FlatAppearance.MouseOverBackColor = SystemColors.Window;
            BtnStarFour.FlatStyle = FlatStyle.Flat;
            BtnStarFour.Location = new Point(165, 3);
            BtnStarFour.Name = "BtnStarFour";
            BtnStarFour.Size = new Size(48, 41);
            BtnStarFour.TabIndex = 3;
            BtnStarFour.UseVisualStyleBackColor = false;
            BtnStarFour.MouseClick += BtnStarFour_MouseClick;
            BtnStarFour.MouseEnter += BtnStarFour_MouseEnter;
            BtnStarFour.MouseLeave += BtnStar_MouseLeave;
            // 
            // BtnStarFive
            // 
            BtnStarFive.BackColor = SystemColors.Window;
            BtnStarFive.BackgroundImage = Properties.Resources.emptyStar;
            BtnStarFive.BackgroundImageLayout = ImageLayout.Zoom;
            BtnStarFive.Cursor = Cursors.Hand;
            BtnStarFive.FlatAppearance.BorderSize = 0;
            BtnStarFive.FlatAppearance.MouseDownBackColor = SystemColors.Window;
            BtnStarFive.FlatAppearance.MouseOverBackColor = SystemColors.Window;
            BtnStarFive.FlatStyle = FlatStyle.Flat;
            BtnStarFive.Location = new Point(219, 3);
            BtnStarFive.Name = "BtnStarFive";
            BtnStarFive.Size = new Size(48, 41);
            BtnStarFive.TabIndex = 4;
            BtnStarFive.UseVisualStyleBackColor = false;
            BtnStarFive.MouseClick += BtnStarFive_MouseClick;
            BtnStarFive.MouseEnter += BtnStarFive_MouseEnter;
            BtnStarFive.MouseLeave += BtnStar_MouseLeave;
            // 
            // FlowLayoutStars
            // 
            FlowLayoutStars.BackColor = SystemColors.Window;
            FlowLayoutStars.Controls.Add(BtnStarOne);
            FlowLayoutStars.Controls.Add(BtnStarTwo);
            FlowLayoutStars.Controls.Add(BtnStarThree);
            FlowLayoutStars.Controls.Add(BtnStarFour);
            FlowLayoutStars.Controls.Add(BtnStarFive);
            FlowLayoutStars.Dock = DockStyle.Right;
            FlowLayoutStars.Location = new Point(644, 0);
            FlowLayoutStars.Name = "FlowLayoutStars";
            FlowLayoutStars.Size = new Size(282, 55);
            FlowLayoutStars.TabIndex = 5;
            // 
            // TxtTitle
            // 
            TxtTitle.BorderStyle = BorderStyle.None;
            TxtTitle.Dock = DockStyle.Fill;
            TxtTitle.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TxtTitle.Location = new Point(0, 0);
            TxtTitle.Name = "TxtTitle";
            TxtTitle.Size = new Size(644, 55);
            TxtTitle.TabIndex = 6;
            TxtTitle.Text = "Titanic";
            // 
            // FilmRating
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TxtTitle);
            Controls.Add(FlowLayoutStars);
            Name = "FilmRating";
            Size = new Size(926, 55);
            FlowLayoutStars.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button BtnStarOne;
        private Button BtnStarTwo;
        private Button BtnStarThree;
        private Button BtnStarFour;
        private Button BtnStarFive;
        private FlowLayoutPanel FlowLayoutStars;
        private RichTextBox TxtTitle;
    }
}
