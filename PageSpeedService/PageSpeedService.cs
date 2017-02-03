using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PageSpeedService
{
    public partial class PageSpeedService : ServiceBase
    {
        public PageSpeedService()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            StartOwin();
        }

        protected override void OnStop()
        {

        }

        private void StartOwin()
        {
            string baseAddress = ConfigurationManager.AppSettings["BaseAddress"];

            IDisposable app = WebApp.Start<Startup>(baseAddress);
        }

    }
}
