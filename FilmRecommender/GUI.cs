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

            if(userProfile.Recommendations.Count > 0)
            {
                PaintUserRecommendations();
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
        }

        private void BtnRecommendations_Click(object sender, EventArgs e)
        {
            PanelRecommendations.Controls.Clear();
            MovieLensService.CreateNeighborhood(userProfile);
            var recommendations = MovieLensService.GetFilmsRated(userProfile);
            userProfile.Recommendations = recommendations.Take(Configuration.NumberOfFilmsToRecommend).OrderByDescending(x => x.Rating).ToList();
            PaintUserRecommendations();
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
                if (MessageBox.Show("Do you really want to recreate the model?", "Delete actual model", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MovieLensService.LoadModel(BackgroundWorkerProfile);
                    userProfile.Scores = MovieLensService.GetFilmsToRate();
                    userProfile.Recommendations = new List<Recommendation>();
                    UserService.SaveUserProfile(userProfile);
                }
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
                BtnLoadModel.Text = NewModelButtonText;
            }
            else
            {

            }
        }

        private void LblInfoRecommendations_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var film = GetFilmFromLabel(label);
            var dialogRating = new RateSingleMovie();
            dialogRating.SetTitle(film.Name);
            if (dialogRating.ShowDialog() == DialogResult.OK)
            {
                userProfile.Scores.Add(film.Id, dialogRating.Rating);
                UserService.SaveUserProfile(userProfile);

                PanelRecommendations.Controls.Remove(label);

                var filmRating = new FilmRating();
                filmRating.Id = film.Id;
                filmRating.SetTitle(film.Name);
                filmRating.SetRating(dialogRating.Rating);
                filmRating.Dock = DockStyle.Top;

                PanelRatedFilms.Controls.Add(filmRating);
            }
        }

        private void UpdateProfileFromUI()
        {
            var userRatings = new Dictionary<int, int>();
            var userRecommendations = new List<Recommendation>();

            foreach (var rating in PanelRatedFilms.Controls.OfType<FilmRating>())
            {
                userRatings.Add(rating.Id, rating.Rating);
            }

            foreach (var recommendations in PanelRecommendations.Controls.OfType<Label>())
            {
                userRecommendations.Add(GetRecommendationFromLabel(recommendations));
            }

            userProfile.Scores = userRatings;
            userProfile.Recommendations = userRecommendations;
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

        private void PaintUserRecommendations()
        {
            foreach (var filmRecommendation in userProfile.Recommendations.OrderBy(x => x.Rating))
            {
                var lblInfo = new Label
                {
                    AutoSize = true,
                    Dock = DockStyle.Top,
                    Location = new Point(0, 0),
                    Name = $"LblInfo{filmRecommendation.Id}",
                    Size = new Size(493, 20),
                    Text = $"{filmRecommendation.Name} - {filmRecommendation.Rating} stars",
                    Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point)
                };
                lblInfo.Click += LblInfoRecommendations_Click;
                lblInfo.Cursor = Cursors.Hand;
                PanelRecommendations.Controls.Add(lblInfo);
            }
        }

        private static Film GetFilmFromLabel(Label info)
        {
            var filmId = int.Parse(info.Name.Remove(0, 7));
            var filmTitle = MovieLensService.GetFilmName(filmId);
            return new Film()
            {
                Id = filmId,
                Name = filmTitle
            };
        }

        private static Recommendation GetRecommendationFromLabel(Label info)
        {
            var filmId = int.Parse(info.Name.Remove(0, 7));
            var filmTitle = MovieLensService.GetFilmName(filmId);
            var rating = int.Parse(info.Text.Split('-').Last().Split(' ', StringSplitOptions.RemoveEmptyEntries).First());
            return new Recommendation()
            {
                Id = filmId,
                Name = filmTitle,
                Rating = rating
            };
        }
    }
}