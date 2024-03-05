using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace PetFriends
{
    public partial class RegLog : Form
    {
        public RegLog()
        {
            InitializeComponent();
        }
 //Database connection
        static string cone = ConfigurationManager.ConnectionStrings["PFC"].ConnectionString;
        SqlConnection Con = new SqlConnection(cone);
        //RegLog close button
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
