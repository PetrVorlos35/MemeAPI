using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemeAPI
{
    public partial class MemeBrowser : Form
    {
        public MemeBrowser()
        {
            InitializeComponent();
            LoadMemes();
        }

        private void LoadMemes()
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Url = new Uri("https://matav.cz/api");
            webBrowser.Height = 600;
            webBrowser.Width = 600;
            Controls.Add(webBrowser);
        }
    }
}
