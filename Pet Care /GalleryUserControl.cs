namespace PetCare
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Represents a user control for displaying a gallery in a PetCare application.
    /// </summary>
    public partial class GalleryUserControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GalleryUserControl"/> class.
        /// </summary>
        public GalleryUserControl()
        {
            InitializeComponent();
        }

        private Image _icons1, _icons2, _icons3, _icons4;

        /// <summary>
        /// Gets or sets the first image in the gallery.
        /// </summary>
        public Image Icons1
        {
            get { return _icons1; }
            set { _icons1 = value; GallPic1.Image = value; }
        }

        /// <summary>
        /// Gets or sets the second image in the gallery.
        /// </summary>
        public Image Icons2
        {
            get { return _icons2; }
            set { _icons2 = value; GallPic2.Image = value; }
        }

        /// <summary>
        /// Gets or sets the third image in the gallery.
        /// </summary>
        public Image Icons3
        {
            get { return _icons3; }
            set { _icons3 = value; GallPic3.Image = value; }
        }

        /// <summary>
        /// Gets or sets the fourth image in the gallery.
        /// </summary>
        public Image Icons4
        {
            get { return _icons4; }
            set { _icons4 = value; GallPic4.Image = value; }
        }

        /// <summary>
        /// Event handler for the load event of the GalleryUserControl.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GalleryUserControl_Load(object sender, EventArgs e)
        {
            // Add any specific load logic here if needed.
        }
    }
}

