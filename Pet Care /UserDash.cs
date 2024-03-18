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
         //User data load
        private void getUserData()
        {
            try
            {
                string querys = "select Full_Name,Profile_Img from UserTbl where Full_Email = '" + RegLog.accem + "'";
                Con.Open();
                SqlCommand cmds = new SqlCommand(querys, Con);
                SqlDataReader reader = cmds.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    FullN.Text = reader[0].ToString();
                    byte[] img = (byte[])(reader[1]);
                    if (img == null)
                    {
                        profilePic.Image = null;
                        Con.Close();
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(img);
                        profilePic.Image = Image.FromStream(ms);
                        Con.Close();
                    }
                }
            else
                {
                    Con.Close();
                }
            }
            catch
            {
                Con.Close();
            }

        }
         //Add profile picture button
        private void addProfilePicBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                imgLoc = opendlg.FileName.ToString();
                profilePic.ImageLocation = imgLoc;
                try
 {
                    byte[] images = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    images = br.ReadBytes((int)fs.Length);
                    Con.Open();
                    string query = "update UserTbl set Profile_Img = @images where Full_Email = '" + RegLog.accem + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.Add(new SqlParameter("@images", images));
                    int n = cmd.ExecuteNonQuery();
                    Con.Close();
                }
