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

        private void BtnRecommendations_Click(object sender, EventArgs e)
        {
            PanelRecommendations.Controls.Clear();
            MovieLensService.CreateNeighborhood(userProfile);
            var recommendations = MovieLensService.GetRecommendations(userProfile);
            foreach (var recommendation in recommendations.Take(Configuration.NumberOfFilmsToRecommend).OrderBy(x => x.Rating))
            {
                var lblInfo = new Label();
                lblInfo.AutoSize = true;
                lblInfo.Dock = DockStyle.Top;
                lblInfo.Location = new Point(0, 0);
                lblInfo.Name = $"LblInfo{recommendation.Id}";
                lblInfo.Size = new Size(493, 20);
                lblInfo.Text = $"{recommendation.Name} - {recommendation.Rating} stars";
                lblInfo.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
                lblInfo.Click += LblInfoRecommendations_Click;
                lblInfo.Cursor = Cursors.Hand;
                PanelRecommendations.Controls.Add(lblInfo);
            }
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

        private void LblInfoRecommendations_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var filmId = int.Parse(label.Name.Remove(0, 7));
            var filmTitle = MovieLensService.GetFilmName(filmId);
            var dialogRating = new RateSingleMovie();
            dialogRating.SetTitle(filmTitle);
            if (dialogRating.ShowDialog() == DialogResult.OK)
            {
                userProfile.Scores.Add(filmId, dialogRating.Rating);
                UserService.SaveUserProfile(userProfile);

                PanelRecommendations.Controls.Remove(label);

                var filmRating = new FilmRating();
                filmRating.Id = filmId;
                filmRating.SetTitle(filmTitle);
                filmRating.SetRating(dialogRating.Rating);
                filmRating.Dock = DockStyle.Top;

                PanelRatedFilms.Controls.Add(filmRating);
            }
        }

        private void UpdateProfileFromUI()
        {
            var userRatings = new Dictionary<int, int>();
            foreach (var rating in PanelRatedFilms.Controls.OfType<FilmRating>())
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

                PanelRatedFilms.Controls.Add(filmRating);
            }
        }
    }
}