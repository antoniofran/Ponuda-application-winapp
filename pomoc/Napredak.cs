using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PonudaApp
{
    class Napredak
    {
        public static Stack<string> openedButtonText = new Stack<string>();

        public static void pokreniAkciju(Button sender)
        {
            openedButtonText.Push(sender.Text);
            
            sender.Text = "Radim ...";
            
            sender.Enabled = false;
        }

        public static void zavrsiAkciju(Button sender)
        {
            sender.Text = openedButtonText.Pop();
            
            sender.Enabled = true;
        }
    }
}
