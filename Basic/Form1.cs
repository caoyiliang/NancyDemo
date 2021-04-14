using Nancy;
using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var url = new Url("http://localhost:9995");
            var hostConfig = new HostConfiguration();
            hostConfig.UrlReservations = new UrlReservations { CreateAutomatically = true };
            var host = new NancyHost(hostConfig, url);

            host.Start();
        }

    }
}
