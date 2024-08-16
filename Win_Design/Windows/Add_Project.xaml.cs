using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Win_Design.Windows
{
    /// <summary>
    /// Add_Project.xaml 的交互逻辑
    /// </summary>
    public partial class Add_Project : Window
    {
        public Add_Project()
        {
            InitializeComponent();
            List<string> strings = new List<string>();
            strings.Add("C++");
            foreach(string s in strings)
            {
                Project_Type.Items.Add(s);
            }
            Project_Type.SelectedIndex = 0;

            Project_Path.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
    }
}
