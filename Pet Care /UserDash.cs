using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Reflection;
namespace PetCare
{
    public partial class UserDash : Form
    {
        public UserDash()
        {
            InitializeComponent();
        }
 //Database connection
        static string conse = ConfigurationManager.ConnectionStrings["PFC"].ConnectionString;
        SqlConnection Con = new SqlConnection(conse);
        //String image location
        string imgLoc = "";
        //Load user info
        public static string emailacc;
        private void UserDash_Load(object sender, EventArgs e)
        {
VisibleComponents();
            getUserData();
            emailacc = RegLog.accem;
        }
        //Visible components
        private void VisibleComponents()
        {
 closImg1.Visible = false;
            closImg2.Visible = false;
            closImg3.Visible = false;
            closImg4.Visible = false;
            webBrowser1.Visible = false;
            searchLoc.Visible = false;
            searchLocBtn.Visible = false;
            mapType.Visible = false;
            searchLoc.Location = new Point(519, 17);
            searchLocBtn.Location = new Point(863, 17);
            webBrowser1.Location = new Point(263, 99);
            mapType.Location = new Point(519, 58);
            GenerateDynamicPostControl();
            flowLayoutPanel1.Location = new Point(264, 174);
            flowLayoutPanel2.Location = new Point(307, 66);
            flowLayoutPanel2.Visible = false;
            panel2.Location = new Point(542, 19);
            panel3.Location = new Point(398, 6);
            panel4.Location = new Point(357, 33);
            panel4.Visible = false;
            panel3.Visible = false;
        }
