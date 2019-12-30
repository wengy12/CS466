using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace part_3
{
    public partial class _Default : Page
    {
        public static int price;
        public static int[] pl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pl = new int[2];
                int[] n = { 1, 2 };
                pl = n;
            }
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            price = 0;
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    price += pl[i];
                }
            }
            Label1.Text = price.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            First.Visible = false;
        }
    }
}