﻿using iNKORE.UI.WPF.Modern;
using iNKORE.UI.WPF.Modern.Media.Animation;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Win_Design.Cs;
using Win_Design.Pages;

namespace Win_Design
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GL.Frame = Main_Frame;
            GL.Frame.Navigate(new Main_Page(), null, new DrillInNavigationTransitionInfo());
            Task.Run(() =>
            {
                while (true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        Title = "Win-Design By:Minecraft一角钱";
                    }));
                    Thread.Sleep(2000);
                }
            });
            try
            {
                if (File.ReadAllText("Theme") == "Light")
                {
                    ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
                }
                else
                {
                    ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
                }
            }
            catch
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ThemeManager.Current.ApplicationTheme == ApplicationTheme.Dark)
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
            }
            else
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
            }
            File.WriteAllText("Theme", ThemeManager.Current.ApplicationTheme.ToString());
        }
    }
}