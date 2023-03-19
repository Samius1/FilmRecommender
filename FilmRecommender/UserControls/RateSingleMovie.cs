using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmRecommender.UserControls
{
    public partial class RateSingleMovie : Form
    {
        internal int Rating { get; set; } = 1;
        public RateSingleMovie()
        {
            InitializeComponent();
        }

        internal void SetTitle(string title)
        {
            FilmRatingControl.SetTitle(title);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Rating = FilmRatingControl.Rating;
            DialogResult = DialogResult.OK;
        }
    }
}
