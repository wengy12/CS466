using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace part_2
{
    public partial class _default : System.Web.UI.Page
    {
        public static int cnt; //current image counter
        public static bool toggle; //toggle for random/sequentual
        public static bool toggle2; //toggle for start/stop
        public static bool toggle3;  //toggle for backward/forward
        public static string[] urls;
        public static string[] description;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                urls = System.IO.File.ReadAllLines(Server.MapPath("urls.txt"));
                description = System.IO.File.ReadAllLines(Server.MapPath("description.txt"));
                cnt = 1;
                toggle = true;
                toggle2 = false;
                toggle3 = true;
                Button3.Visible = false;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (toggle2)
            {
                proceed();
            }
        }

        protected void proceed()
        {
            if (toggle)
            {
                Random_Tick();
            }
            else
            {
                if (toggle3)
                {
                    Sequence_Tick();
                }
                else
                {
                    BSequence_Tick();
                }
            }
        }

        protected void BSequence_Tick()
        {
            if (cnt > 1)
            {
                cnt = cnt - 1;
            }
            else
            {
                cnt = 23;
            }
            Image1.ImageUrl = urls[cnt-1];
            TextBox1.Text = description[cnt-1];
        }

        protected void Sequence_Tick()
        {
            if (cnt < 23)
            {
                cnt = cnt + 1;
            }
            else
            {
                cnt = 1;
            }
            Image1.ImageUrl = urls[cnt-1];
            TextBox1.Text = description[cnt-1];
        }

        protected void Random_Tick()
        {
            Random _rand = new Random();
            cnt = _rand.Next(1, 23);
            Image1.ImageUrl = urls[cnt - 1];
            TextBox1.Text = description[cnt - 1];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (toggle)
            {
                Button3.Visible = true;
                Button1.Text = "random";
                toggle = false;
            }
            else
            {
                Button3.Visible = false;
                Button1.Text = "sequence";
                toggle = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (toggle2)
            {
                Button2.Text = "stop";
                toggle2 = false;
            }
            else
            {
                Button2.Text = "start";
                toggle2 = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (toggle3)
            {
                Button3.Text = "forward";
                toggle3 = false;
            }
            else
            {
                Button3.Text = "backward";
                toggle3 = true;
            }
        }
    }
}