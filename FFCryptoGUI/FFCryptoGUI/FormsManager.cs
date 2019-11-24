using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FFCryptGUI
{
    public class FormsManager
    {
        public Forms.ProjectForm pfObj { get; private set; } = null;
        public Forms.CryptoForm cfObj { get; private set; } = null;
        public Forms.LogForm lfObj { get; private set; } = null;
        public Forms.SettingsForm sfObj { get; private set; } = null;
        public Forms.InfoForm ifObj { get; private set; } = null;

        public List<Form> FormList = null;

        private Panel mainPanel = null;

        public FormsManager(Panel mainProjectPanel, int activeIndex = 0)
        {
            // Initialize Objects
            pfObj = new Forms.ProjectForm();
            cfObj = new Forms.CryptoForm();
            lfObj = new Forms.LogForm();
            sfObj = new Forms.SettingsForm();
            ifObj = new Forms.InfoForm();
            FormList = new List<Form>() { pfObj, cfObj, lfObj, sfObj, ifObj };
            mainPanel = mainProjectPanel;

            // Set Objects
            TopLevel(false);
            controlAddForms();
            if (activeIndex < 0 | FormList.Count - 1 < activeIndex)
                activeIndex = 0;

            ShowWindow(activeIndex);

        }

        private void controlAddForms()
        {
            foreach (Form f in FormList)
                mainPanel.Controls.Add(f);
        }

        public void ShowWindow(int index)
        {
            FormList[index].Visible = true;
            for (int i = 0; i < FormList.Count; i++)
                if (i != index)
                    FormList[i].Visible = false;
        }

        public void TopLevel(bool enable)
        {
            foreach(Form f in FormList)
                f.TopLevel = enable;
        }


    }
}
