using FilmRecommender.Entities;

namespace FilmRecommender.UserControls
{
    public partial class FilmRating : UserControl
    {
        internal int Rating { get; private set; } = 1;
        internal int Id { get; set; }

        public FilmRating()
        {
            InitializeComponent();
        }

        internal void SetTitle(string title)
        {
            TxtTitle.Text = title;
        }

        internal void SetRating(int rating)
        {
            Rating = rating;
            BtnStar_MouseLeave(null, null);
        }

        private void BtnStarOne_MouseClick(object sender, MouseEventArgs e)
        {
            Rating = 1;
            PaintOneStarRating();
        }

        private void BtnStarOne_MouseEnter(object sender, EventArgs e)
        {
            PaintOneStarRating();
        }

        private void BtnStarTwo_MouseClick(object sender, EventArgs e)
        {
            Rating = 2;
            PaintTwoStarRating();
        }

        private void BtnStarTwo_MouseEnter(object sender, EventArgs e)
        {
            PaintTwoStarRating();
        }

        private void BtnStarThree_MouseClick(object sender, EventArgs e)
        {
            Rating = 3;
            PaintThreeStarRating();
        }

        private void BtnStarThree_MouseEnter(object sender, EventArgs e)
        {
            PaintThreeStarRating();
        }

        private void BtnStarFour_MouseClick(object sender, EventArgs e)
        {
            Rating = 4;
            PaintFourStarRating();
        }

        private void BtnStarFour_MouseEnter(object sender, EventArgs e)
        {
            PaintFourStarRating();
        }

        private void BtnStarFive_MouseClick(object sender, EventArgs e)
        {
            Rating = 5;
            PaintFiveStarRating();
        }

        private void BtnStarFive_MouseEnter(object sender, EventArgs e)
        {
            PaintFiveStarRating();
        }

        private void BtnStar_MouseLeave(object? sender, EventArgs? e)
        {
            switch (Rating)
            {
                case 1: PaintOneStarRating(); break;
                case 2: PaintTwoStarRating(); break;
                case 3: PaintThreeStarRating(); break;
                case 4: PaintFourStarRating(); break;
                case 5: PaintFiveStarRating(); break;
            }
        }

        private void PaintOneStarRating()
        {
            BtnStarTwo.BackgroundImage = Properties.Resources.emptyStar;
            BtnStarThree.BackgroundImage = Properties.Resources.emptyStar;
            BtnStarFour.BackgroundImage = Properties.Resources.emptyStar;
            BtnStarFive.BackgroundImage = Properties.Resources.emptyStar;
        }

        private void PaintTwoStarRating()
        {
            BtnStarTwo.BackgroundImage = Properties.Resources.yellowStar;
            BtnStarThree.BackgroundImage = Properties.Resources.emptyStar;
            BtnStarFour.BackgroundImage = Properties.Resources.emptyStar;
            BtnStarFive.BackgroundImage = Properties.Resources.emptyStar;
        }

        private void PaintThreeStarRating()
        {
            BtnStarTwo.BackgroundImage = Properties.Resources.yellowStar;
            BtnStarThree.BackgroundImage = Properties.Resources.yellowStar;
            BtnStarFour.BackgroundImage = Properties.Resources.emptyStar;
            BtnStarFive.BackgroundImage = Properties.Resources.emptyStar;
        }

        private void PaintFourStarRating()
        {
            BtnStarTwo.BackgroundImage = Properties.Resources.yellowStar;
            BtnStarThree.BackgroundImage = Properties.Resources.yellowStar;
            BtnStarFour.BackgroundImage = Properties.Resources.yellowStar;
            BtnStarFive.BackgroundImage = Properties.Resources.emptyStar;
        }

        private void PaintFiveStarRating()
        {
            BtnStarTwo.BackgroundImage = Properties.Resources.yellowStar;
            BtnStarThree.BackgroundImage = Properties.Resources.yellowStar;
            BtnStarFour.BackgroundImage = Properties.Resources.yellowStar;
            BtnStarFive.BackgroundImage = Properties.Resources.yellowStar;
        }
    }
}
