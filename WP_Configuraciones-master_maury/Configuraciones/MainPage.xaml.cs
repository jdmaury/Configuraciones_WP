using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Shell;

namespace Configuraciones
{
    public partial class MainPage : PhoneApplicationPage
    {
        public IsolatedStorageSettings appSettings;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
            appSettings = IsolatedStorageSettings.ApplicationSettings;

        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            try
            {
                user_test.Text = appSettings["user"].ToString();
                user_test1.Text = appSettings["user1"].ToString();
                
                radioButton1.IsChecked = (bool)appSettings["user2"];
                radioButton2.IsChecked = (bool)appSettings["user3"];
                //user_test2.Text = appSettings["user2"].ToString();
                
            }
            catch (Exception)
            {
                appSettings.Add("user", "User");
                appSettings.Add("user2", false);
                appSettings.Add("user3", false);
                appSettings.Add("user1", "Edad");                
                
                radioButton1.IsChecked = false;
                radioButton2.IsChecked = false;
                //user_test2.Text = "Masculino";
                
                appSettings.Save();
            }
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            appSettings["user"] = user_test.Text;
            appSettings["user1"] = user_test1.Text;
            //appSettings["user2"] = user_test2.Text;
            appSettings["user2"] = radioButton1.IsChecked;
            appSettings["user3"] = radioButton2.IsChecked;
            appSettings.Save();
            PhoneApplicationService.Current.State["Text"] = user_test.Text;
            PhoneApplicationService.Current.State["Text1"] = user_test1.Text;

            if (radioButton1.IsChecked == true)
            {
                PhoneApplicationService.Current.State["Text2"] = radioButton1.Content;
            }
            else
            {
                if (radioButton2.IsChecked == true)
                {
                    PhoneApplicationService.Current.State["Text2"] = radioButton2.Content;
                }
            }
            
            
            //PhoneApplicationService.Current.State["Text2"] = user_test2.Text;
        }

    }
}