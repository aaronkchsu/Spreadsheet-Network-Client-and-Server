using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadsheetGUI
{
    /// <summary>
    /// Keeps track of how many top-level forms are running
    /// </summary>
    class DemoApplicationContext : ApplicationContext
    {

        Action<String, String> connect;

        // Number of open forms
        private int formCount = 0;

        // Singleton ApplicationContext
        private static DemoApplicationContext appContext;

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private DemoApplicationContext()
        {


        }

        /// <summary>
        /// Returns the one DemoApplicationContext.
        /// </summary>
        public static DemoApplicationContext getAppContext()
        {
            if (appContext == null)
            {
                appContext = new DemoApplicationContext();
            }
            return appContext;
        }

        /// <summary>
        /// Runs the form
        /// </summary>
        public void RunForm(Form form)
        {
            // One more form is running
            formCount++;

            // When this form closes, we want to find out
            form.FormClosed += (o, e) => { if (--formCount <= 0) ExitThread(); };

            // Run the form
            form.Show();
        }
    }


    static class Program
    {

        static DemoApplicationContext appContext;
        static ConnectScreen cs;
        static LoginForm lf;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start an application context and run one form inside it
            appContext = DemoApplicationContext.getAppContext();
            cs = new ConnectScreen();

            appContext.RunForm(cs);
            cs.connect += attemptConnection;
            
            Application.Run(appContext);
        }

        private static void attemptConnection(string ip, string port)
        {

            cs.Hide();
            lf = new LoginForm();
            appContext.RunForm(lf);

            lf.loginAttempt += attemptLogin;
        }


        private void callback()
        {


        }

        private static void attemptLogin(string user, string password)
        {
            appContext.RunForm(new Form1());
        }


    }
}
