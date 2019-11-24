using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FFCryptGUI.Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }
        public bool ExitFlag = true;

        private void LoadingForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ExitFlag)
                e.Cancel = true;
        }
    }
}
