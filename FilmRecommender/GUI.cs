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
        private const string PromotionalFilmText = "Checkout this film!";

        public GUI()
        {
            InitializeComponent();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            Configuration.LoadConfiguration();
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
            Configuration.LoadConfiguration();
            if (!BackgroundWorkerProfile.IsBusy)
            {
                BackgroundWorkerProfile.RunWorkerAsync();
            }
        }

        private void BtnSaveProfile_Click(object sender, EventArgs e)
        {
            UpdateProfileFromUI();
            UserService.SaveUserProfile(userProfile);
        }

        private void BtnRecommendations_Click(object sender, EventArgs e)
        {
            Configuration.LoadConfiguration();
            MovieLensService.CreateNeighborhood(userProfile);
            var recommendations = MovieLensService.GetFilmsRated(userProfile);
            userProfile.Recommendations = recommendations.OrderByDescending(x => x.Rating).Take(Configuration.NumberOfFilmsToRecommend).ToList();
            AddRandomRecommendations(recommendations);
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
                PaintUserRatings();
                PaintUserRecommendations();
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
            PanelRatedFilms.Controls.Clear();
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
            PanelRecommendations.Controls.Clear();
            foreach (var filmRecommendation in userProfile.Recommendations.OrderBy(x => x.Rating))
            {
                var starsText = filmRecommendation.Rating == int.MinValue
                                        ? PromotionalFilmText
                                        : $"{filmRecommendation.Rating} stars";

                var lblInfo = new Label
                {
                    AutoSize = true,
                    Dock = DockStyle.Top,
                    Location = new Point(0, 0),
                    Name = $"LblInfo{filmRecommendation.Id}",
                    Size = new Size(493, 20),
                    Text = $"{filmRecommendation.Name} - {starsText}",
                    Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point)
                };

                if (starsText == PromotionalFilmText)
                {
                    lblInfo.BackColor = Color.Black;
                    lblInfo.ForeColor = Color.FromArgb(205, 164, 52);
                }

                lblInfo.Click += LblInfoRecommendations_Click;
                lblInfo.Cursor = Cursors.Hand;
                PanelRecommendations.Controls.Add(lblInfo);
            }
        }

        private void AddRandomRecommendations(IEnumerable<Recommendation> recommendations)
        {
            var anyMovieToCheck = recommendations.Any(x => userProfile.Recommendations.Contains(x));
            if (!anyMovieToCheck)
            {
                return;
            }

            var nonCommonRecommendations = recommendations.Where(x => x.Rating == int.MinValue);

            var counter = 0;
            var rand = new Random();
            while (counter < Configuration.NumberOfRandomFilms && anyMovieToCheck)
            {
                var newRecommendation = nonCommonRecommendations.ElementAt(rand.Next(0, nonCommonRecommendations.Count()));
                if (!userProfile.Recommendations.Contains(newRecommendation))
                {
                    userProfile.Recommendations.Add(newRecommendation);
                }

                counter++;
                anyMovieToCheck = recommendations.Any(x => userProfile.Recommendations.Contains(x));
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
            var rating = info.Text.Contains(PromotionalFilmText) 
                            ? int.MinValue 
                            : (int.Parse(info.Text.Split('-').Last().Split(' ', StringSplitOptions.RemoveEmptyEntries).First()));
            return new Recommendation()
            {
                Id = filmId,
                Name = filmTitle,
                Rating = rating
            };
        }
    }
}