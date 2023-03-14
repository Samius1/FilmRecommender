using FilmRecommender.UserControls;

namespace FilmRecommender
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        private void BtnLoadModel_Click(object sender, EventArgs e)
        {
            if (BtnLoadModel.Text == "Load model")
            {
                TabContent.Visible = true;
                TabPageRecommendations.Visible = false;
                BtnLoadModel.Text = "New model";

                var fakeFilmRating = new FilmRating();
                fakeFilmRating.SetTitle("Coco");
                fakeFilmRating.Dock = DockStyle.Top;

                TabPageProfile.Controls.Add(fakeFilmRating);
                TabPageProfile.Controls.SetChildIndex(fakeFilmRating, 0);
            }
            else
            {

            }
        }

        private void BtnSaveProfile_Click(object sender, EventArgs e)
        {
            TabPageRecommendations.Visible = true;
        }
    }
}