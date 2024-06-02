using System;
using System.Threading;

namespace Client_Server
{
    public class Global : System.Web.HttpApplication
    {
        private Timer _timer;
        WebService webService;
        protected void Application_Start( object sender, EventArgs e )
        {
            webService = new WebService();
            _timer = new Timer(RunTask, null, TimeSpan.Zero, TimeSpan.FromHours(12));
        }
        private void RunTask( object state )
        {
            try
            {
                webService.ActualizareCursValutar();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        protected void Session_Start( object sender, EventArgs e )
        {

        }

        protected void Application_BeginRequest( object sender, EventArgs e )
        {

        }

        protected void Application_AuthenticateRequest( object sender, EventArgs e )
        {

        }

        protected void Application_Error( object sender, EventArgs e )
        {

        }

        protected void Session_End( object sender, EventArgs e )
        {

        }

        protected void Application_End( object sender, EventArgs e )
        {

        }

    }
}