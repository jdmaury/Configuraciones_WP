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
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
namespace Configuraciones
{
    public partial class paginaprincipal : PhoneApplicationPage
    {
        public IsolatedStorageSettings appSettings;

        public paginaprincipal()
        {
            InitializeComponent();
            appSettings = IsolatedStorageSettings.ApplicationSettings;
        }
    
                   protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
                   {
                       try
                            {
                                   textBox1.Text = appSettings["user"].ToString();
                                   textBox2.Text = appSettings["user1"].ToString();
                                   if(appSettings["user2"].ToString().Equals("True"))
                                   textBox3.Text = "Masculino";
                                    if(appSettings["user2"].ToString().Equals("False"))
                                   textBox3.Text = "Femenino";
                                
                            }
                       catch(Exception){
                                               textBox1.Text = "default_value";
                                               textBox2.Text = "default_value";
                                               textBox3.Text = "default_value";
                                               appSettings.Add("user", "Usuario");
                                               appSettings.Add("user2", false);
                                               appSettings.Add("user3", false);
                                               appSettings.Add("user1", "Edad");                
                                               appSettings.Save();
                
                       }
                   
        }
    
        private void navegar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

        }

        /*protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (PhoneApplicationService.Current.State.ContainsKey("Text"))
                textBox1.Text = (string)PhoneApplicationService.Current.State["Text"];
            if (PhoneApplicationService.Current.State.ContainsKey("Text1"))
                textBox2.Text = (string)PhoneApplicationService.Current.State["Text1"];
            if (PhoneApplicationService.Current.State.ContainsKey("Text2") )
                textBox3.Text = (string)PhoneApplicationService.Current.State["Text2"];
            
        }*/

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            appSettings["user"] = textBox1.Text;
            appSettings["user1"] = textBox2.Text;
            //appSettings["user2"] = user_test2.Text;
            
            appSettings.Save();
            PhoneApplicationService.Current.State["Text"] = textBox1.Text;
            PhoneApplicationService.Current.State["Text1"] =textBox2.Text;

            
            
            //PhoneApplicationService.Current.State["Text2"] = user_test2.Text;
        }
        
    }
}
