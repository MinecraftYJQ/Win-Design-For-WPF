using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Win_Design.Windows.Work;
using static Win_Design.Cs.API.Json.Json;

namespace Win_Design.Cs.Project.Save_Project
{
    class Save_Project
    {
        public static void Save_Design_File(List<Control> Items)
        {
            Export_Design export_Design = new Export_Design();
            export_Design.Set_JD_Value_Init(Items.Count);
            Task.Run(() =>
            {
                Thread.Sleep(300);
                List<WindowItem> windowItems = new List<WindowItem>();
                foreach (Control item in Items)
                {
                    if (item.GetType() == typeof(TextBox))
                    {
                        TextBox textBox = (TextBox)item;
                        textBox.Dispatcher.Invoke(new Action(() =>
                        {
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
                        }));
                    }
                    else
                    {
                        switch (item.GetType().ToString().Replace("System.Windows.Controls.", ""))
                        {
                            case "Button":
                                Button button = (Button)item;
                                button.Dispatcher.Invoke(new Action(() =>
                                {
                                    windowItems.Add(new WindowItem
                                    {
                                        Name = item.Name,
                                        Text = (string)button.Content,
                                        Type = "Button",
                                        X = (int)item.Margin.Left,
                                        Y = (int)item.Margin.Top,
                                        Wid = (int)item.Width,
                                        Hei = (int)item.Height
                                    });
                                }));
                                break;
                            case "Label":
                                Label Label = (Label)item;
                                Label.Dispatcher.Invoke(new Action(() =>
                                {
                                    windowItems.Add(new WindowItem
                                    {
                                        Name = item.Name,
                                        Text = (string)Label.Content,
                                        Type = "Label",
                                        X = (int)item.Margin.Left,
                                        Y = (int)item.Margin.Top,
                                        Wid = (int)item.Width,
                                        Hei = (int)item.Height
                                    });
                                }));
                                break;
                        }
                    }
                    export_Design.Set_JD_Value_Add();
                    Thread.Sleep(10);
                }
                

                GL.design_window.Dispatcher.Invoke(new Action(() =>
                {
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
                }));
                Thread.Sleep(800);
                export_Design.Dispatcher.Invoke(new Action(() =>
                {
                    export_Design.Close();
                }));
            });
            export_Design.ShowDialog();
        }
    }
}
