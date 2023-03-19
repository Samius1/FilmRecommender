using FilmRecommender.Entities;
using FilmRecommender.Services;
using FilmRecommender.UserControls;

namespace FilmRecommender
{
    public partial class GUI : Form
    {
        private Profile userProfile;
        private const string NewModelButtonText = "New model";
        private const string LoadModelButtonText = "Load model";

        public GUI()
        {
            InitializeComponent();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            userProfile = UserService.LoadUserProfile();
            if (userProfile.Scores.Count > 0)
            {
                PaintUserRatings();
                TabContent.Visible = true;
                BtnLoadModel.Text = NewModelButtonText;
            }
        }

        private void BtnLoadModel_Click(object sender, EventArgs e)
        {
            BackgroundWorkerProfile.RunWorkerAsync();
        }

        private void BtnSaveProfile_Click(object sender, EventArgs e)
        {
            UpdateProfileFromUI();
            UserService.SaveUserProfile(userProfile);
            TabPageRecommendations.Enabled = true;
        }

        private void BackgroundWorkerProfile_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (BtnLoadModel.Text == LoadModelButtonText)
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
            if (BtnLoadModel.Text == LoadModelButtonText)
            {
                PaintUserRatings();
                TabContent.Visible = true;
                TabPageRecommendations.Enabled = false;
                BtnLoadModel.Text = NewModelButtonText;
            }
            else
            {

            }
        }

        private void UpdateProfileFromUI()
        {
            var userRatings = new Dictionary<int, int>();
            foreach (var rating in TabPageProfile.Controls.OfType<FilmRating>())
            {
                userRatings.Add(rating.Id, rating.Rating);
            }
            userProfile.Scores = userRatings;
        }

        private void PaintUserRatings()
        {
            foreach (var filmScore in userProfile.Scores)
            {
                var filmRating = new FilmRating();
                filmRating.Id = filmScore.Key;
                filmRating.SetTitle(MovieLensService.GetFilmName(filmScore.Key));
                filmRating.SetRating(filmScore.Value);
                filmRating.Dock = DockStyle.Top;

                TabPageProfile.Controls.Add(filmRating);
                TabPageProfile.Controls.SetChildIndex(filmRating, 0);
            }
        }
    }
}