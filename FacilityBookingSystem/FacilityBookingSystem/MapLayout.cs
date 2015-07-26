using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacilityBookingSystem
{
    public partial class MapLayout : Form
    {
        public MapLayout(string category)
        {
            InitializeComponent();
            switch (category)
            {
                case "BA": this.Layout_PictureBox1.Image = global::FacilityBookingSystem.Properties.Resources.BA_CAM;
                           this.Layout_PictureBox2.Image = global::FacilityBookingSystem.Properties.Resources.BA_UTW;
                           break;
                case "TE": this.Layout_PictureBox1.Image = global::FacilityBookingSystem.Properties.Resources.TC_CAM;
                           this.Layout_PictureBox2.Image = global::FacilityBookingSystem.Properties.Resources.TC_UTW;
                           break;
                case "TA": this.Layout_PictureBox1.Image = global::FacilityBookingSystem.Properties.Resources.TT_CAM;
                           this.Layout_PictureBox2.Image = global::FacilityBookingSystem.Properties.Resources.TT_UTW;
                           break;
                case "SQ": this.Layout_PictureBox1.Image = global::FacilityBookingSystem.Properties.Resources.SC_CAM;
                           this.Layout_PictureBox2.Image = global::FacilityBookingSystem.Properties.Resources.SC_UTW;
                           break;
            }
        }
    }
}
