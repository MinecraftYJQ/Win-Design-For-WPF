﻿using iNKORE.UI.WPF.Modern;
using iNKORE.UI.WPF.Modern.Controls;
using iNKORE.UI.WPF.Modern.Media.Animation;
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
using Win_Design.Cs;
using Win_Design.Pages.Main_Page_SubProject;

namespace Win_Design.Pages
{
    /// <summary>
    /// Main_Page.xaml 的交互逻辑
    /// </summary>
    public partial class Main_Page : System.Windows.Controls.Page
    {
        public Main_Page()
        {
            InitializeComponent();
            Frame_Main.Navigate(Home);
            Nav.SelectedItem = NavigationViewItem_Home;
            Frames_Main = Frame_Main;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ThemeManager.Current.ApplicationTheme == ApplicationTheme.Dark)
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
                File.WriteAllText("Theme", "Light");
            }
            else
            {
                ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
                File.WriteAllText("Theme", "Dark");
            }
        }
        public static System.Windows.Controls.Frame Frames_Main;
        public Home Home = new Home();
        public static System.Windows.Controls.Page project = new Main_Page_SubProject.Project();
        public Plug plugs = new Main_Page_SubProject.Plug();
        public Setting setting = new Main_Page_SubProject.Setting();
        public About about = new Main_Page_SubProject.About();
        private void NavigationView_SelectionChanged(iNKORE.UI.WPF.Modern.Controls.NavigationView sender, iNKORE.UI.WPF.Modern.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            var item = sender.SelectedItem;
            System.Windows.Controls.Page? page = null;
             
            if (item == NavigationViewItem_Home)
            {
                page = Home;
            }
            else if (item == NavigationViewItem_Project)
            {
                page = project;
            }
            else if (item == NavigationViewItem_Plug)
            {
                page = plugs;
            }
            else if (item == NavigationViewItem_Setting)
            {
                page = setting;
            }
            else if (item == NavigationViewItem_About)
            {
                page = about;
            }

            if (page != null)
            {
                Frame_Main.Navigate(page, null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromBottom });
            }
        }
    }
}
