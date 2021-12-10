using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTest.Login_and_Job_Info
{
    class JobInfo
    {
         public string title = "Python developer";
         public string description = "Coding, designing, deploying, and debugging development projects.";
         public string note = "A Python Developer is responsible for coding, designing, deploying, and " +
                             "debugging development projects, typically on the server-side (or back-end). " +
                             "They may, however, also help organizations with their technological framework. " +
                             "A Python Developer's role can span a wide variety of duties.";

         public string newdescryption = "A Python Web Developer is responsible for writing server-side web application logic. ";
         public string pathtotitle = "//a[contains(text(),'" + "Python developer" + "')]";
    }
}
