using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FFCryptGUI
{
    public class MenuManager
    {
        private List<Button> buttonList = null;
        public MenuManager(List<Button> buttons, int activeIndex)
        {
            buttonList = buttons;

            if (activeIndex < 0 | buttonList.Count - 1 < activeIndex)
                activeIndex = 0;
            ActiveButton(activeIndex);
        }

        public void ActiveButton(int index)
        {
            buttonList[index].BackColor = SystemColors.WindowFrame;
            buttonList[index].Enabled = false;
            for (int i = 0; i < buttonList.Count; i++)
            {
                if (index != i)
                {
                    buttonList[i].Enabled = true;
                    buttonList[i].BackColor = Color.FromArgb(64, 64, 64);
                }
            }
        }

        public void DisableButton()
        {
            foreach (Button b in buttonList)
            {
                b.Enabled = false;
            }
        }
    }
}
