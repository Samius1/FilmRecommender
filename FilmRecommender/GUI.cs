using FilmRecommender.Entities;
using FilmRecommender.Services;
using FilmRecommender.UserControls;

namespace FilmRecommender
{
    public partial class GUI : Form
    {
        private Profile userProfile;

        public GUI()
        {
            InitializeComponent();

            userProfile = new Profile();
        }

        private void BtnLoadModel_Click(object sender, EventArgs e)
        {
            BackgroundWorkerProfile.RunWorkerAsync();
        }

        private void BtnSaveProfile_Click(object sender, EventArgs e)
        {
            TabPageRecommendations.Visible = true;
        }

        private void BackgroundWorkerProfile_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (BtnLoadModel.Text == "Load model")
            {
                MovieLensService.LoadModel(BackgroundWorkerProfile);
                userProfile.Scores = MovieLensService.GetFilmsToRate();
            }
            else
            {

            }
        }

        private void BackgroundWorkerProfile_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ProgressBarLoadingModel.Value = e.ProgressPercentage;
        }

        private void BackgroundWorkerProfile_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (BtnLoadModel.Text == "Load model")
            {
                foreach (var filmScore in userProfile.Scores)
                {
                    var filmRating = new FilmRating();
                    filmRating.SetTitle(filmScore.Key.Name);
                    filmRating.Dock = DockStyle.Top;

                    TabPageProfile.Controls.Add(filmRating);
                    TabPageProfile.Controls.SetChildIndex(filmRating, 0);
                }

                TabContent.Visible = true;
                TabPageRecommendations.Visible = false;
                BtnLoadModel.Text = "New model";
            }
            else
            {

            }
        }
    }
}