using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rusada_Mvc_Demo
{
    public partial class date : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            DateTime thisDate1 = new DateTime(2011, 6, 10);
            Console.WriteLine("Today is " + thisDate1.ToString("MMMM dd, yyyy") + ".");

            DateTimeOffset thisDate2 = new DateTimeOffset(2011, 6, 10, 15, 24, 16,
                                                          TimeSpan.Zero);
            Console.WriteLine("The current date and time: {0:MM/dd/yy H:mm:ss zzz}",
                               thisDate2);
        }
    }
}