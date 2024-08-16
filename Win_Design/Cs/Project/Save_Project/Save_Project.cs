using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Win_Design.Cs.API.Json.Json;

namespace Win_Design.Cs.Project.Save_Project
{
    class Save_Project
    {
        public static void Save_Design_File(List<Control> Items)
        {
            List<WindowItem> windowItems = new List<WindowItem>();
            foreach (Control item in Items) {
                if (item.GetType() == typeof(TextBox)) {
                    TextBox textBox = (TextBox)item;
                    windowItems.Add(new WindowItem
                    {
                        Name = item.Name,
                        Text = (string)textBox.Text,
                        Type = "TextBox",
                        X = (int)item.Margin.Left,
                        Y = (int)item.Margin.Top,
                        Wid = (int)item.Width,
                        Hei = (int)item.Height
                    });
                }
                else
                {
                    Button button = (Button)item;
                    windowItems.Add(new WindowItem
                    {
                        Name = item.Name,
                        Text = (string)button.Content,
                        Type = item.GetType().ToString().Replace("System.Windows.Controls.",""),
                        X = (int)item.Margin.Left,
                        Y = (int)item.Margin.Top,
                        Wid = (int)item.Width,
                        Hei = (int)item.Height
                    });
                }
            }
            string temp = GL.design_window.Get_Message();
            WindowConfig config = new WindowConfig
            {
                Title = temp.Split('|')[1],
                Size = temp.Split('|')[0],
                Window = windowItems
            };

            // 将对象序列化为JSON字符串
            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText("Window.json", json); 
        }
    }
}
