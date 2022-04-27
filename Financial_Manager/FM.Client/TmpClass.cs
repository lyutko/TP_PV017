using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Financial_Manager
{
    public class TmpClass
    {
        static public MainWindow main { get; set; }

        static public Page Tmpmain { get; set; } 

        static public void tmpmethod(Page pa)
        {
            main.Content = pa;
        }

        
    }
}
