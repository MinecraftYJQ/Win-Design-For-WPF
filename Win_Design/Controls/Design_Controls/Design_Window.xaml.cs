using iNKORE.UI.WPF.Helpers;
using iNKORE.UI.WPF.Modern.Controls;
using iNKORE.UI.WPF.Modern.Controls.Primitives;
using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Win_Design.Cs.API;
using Win_Design.Cs.API.Json;
using Win_Design.Windows.Work;
using static Win_Design.Cs.API.Json.Json;

namespace Win_Design.Controls.Design_Controls
{
    /// <summary>
    /// Design_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Design_Window : UserControl
    {
        public Design_Window()
        {
            InitializeComponent();
        }
        public void Init_Window(string path)
        {
            Design_Grid.Children.Clear();
            Title_Label.Content = "Main Window";

            string json = File.ReadAllText(path); // 将你的JSON字符串放在这里
            WindowConfig config = JsonConvert.DeserializeObject<Json.WindowConfig>(json);
            Title_Label.Content = config.Title;
            /*Design_Grid.Width = double.Parse(config.Size.Split('x')[0]);
            Design_Grid.Height = double.Parse(config.Size.Split('x')[1]);

            Title_Grid.Width= double.Parse(config.Size.Split('x')[0]);*/
            this.Width = double.Parse(config.Size.Split('x')[0]);
            this.Height = double.Parse(config.Size.Split('x')[1]);
            foreach (var item in config.Window)
            {
                switch (item.Type)
                {
                    case "Label":
                        Label label = new Label
                        {
                            Name = item.Name,
                            Content = item.Text,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top,
                            Margin =new Thickness(item.X,item.Y,0,0),
                            Width = item.Wid,
                            Height = item.Hei,
                            Foreground = Title_Label.Foreground
                        };
                        Design_Grid.Children.Add(label);
                        break;
                    case "Button":
                        Button button = new Button
                        {
                            Name = item.Name,
                            Content = item.Text,
                            Margin = new Thickness(item.X, item.Y, 0, 0),
                            Width = item.Wid,
                            Height = item.Hei,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top,
                        };
                        Design_Grid.Children.Add(button);
                        break;
                    case "TextBox":
                        TextBox TextBox = new TextBox
                        {
                            Name = item.Name,
                            Text = item.Text,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top,
                            //IsEnabled = false,
                            Width = item.Wid,
                            Height = item.Hei,
                            Margin = new Thickness(item.X, item.Y, 0, 0),
                            Foreground = Title_Label.Foreground
                        };
                        Design_Grid.Children.Add(TextBox);
                        break;
                    default:
                        iNKORE.UI.WPF.Modern.Controls.
                            MessageBox.Show($"未知控件 {item.Name}\n类型 {item.Type}\n\n遇到此类问题请检查设计文件\n如无法排查请联系开发者或将软件更新到最新版本", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
        }

        public string Get_Message()
        {
            return ((int)this.Width).ToString() + "x" + ((int)this.Height).ToString() + "|" + Title_Label.Content;
        }

        public void Set_Message(string message)
        {
            string size = message.Split('|')[0];
            string title = message.Split('|')[1];
            Title_Label.Content = title;
            this.Width = double.Parse(size.Split("x")[0]);
            this.Height = double.Parse(size.Split("x")[1]);
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Setting_Window setting = new Setting_Window();
            setting.ShowDialog();
        }
    }
}
