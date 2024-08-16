using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Win_Design.Cs.API
{
    class Add_Control
    {
        public static void Add_For_Grid(Grid FatControl,Control ChildControl,int x,int y)
        {
            int w = (int)FatControl.DesiredSize.Width;
            int h = (int)FatControl.DesiredSize.Height;

            ChildControl.Margin = new System.Windows.Thickness(x,y,w-x-ChildControl.DesiredSize.Width, h - y - ChildControl.DesiredSize.Height);
            FatControl.Children.Add(ChildControl);
        }
    }
}
