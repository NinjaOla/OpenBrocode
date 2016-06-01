using System;
using System.Collections.Generic;
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
using System.IO;
using OpenBrocode.JSON;
using Twitter;




namespace OpenBrocode
{
    /// <summary>
    /// Interaction logic for SettingsUC.xaml
    /// </summary>
    public partial class SettingsUC : UserControl
    {

        public static MainTwitter maintwitter;

        public SettingsUC()
        {
            maintwitter = new MainTwitter();
            maintwitter.loginEventHandler += new EventHandler(loginEventHandler);
            InitializeComponent();
            loadToUI();

        }

        public void loginEventHandler(object sender, EventArgs e)
        {
            System.Console.WriteLine("Vi er framme");
        }


        private void btnTwitterClick(object sender, RoutedEventArgs e)
        {
            maintwitter.authenticateApp();
            InputBox.Visibility = Visibility.Visible;
           

            //OK popupboks knapp med pin - caller på eventhandler.(popup kjører authenticateUser)->


        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            maintwitter.authenticateUser(InputTextBox.Text);
            InputBox.Visibility = Visibility.Collapsed;
            chkBoxTwit.IsChecked = true;
            saveToFile();
            _btnTwitter.IsEnabled = false;

        }



        public void saveToFile()
        {
            JsonHandler handler = new JsonHandler();

            handler.objectToJson(txtBoxFace.Text, pwBoxFace.Password, (bool)chkBoxFace.IsChecked,
                 txtBoxMail.Text, pwBoxMail.Password, (bool)chkBoxMail.IsChecked, (bool)chkBoxTwit.IsChecked);
        }



        private void loadToUI()
        {

            JsonHandler handler = new JsonHandler();
            SettingsClass sc = handler.getSettings();

            //facebook
            txtBoxFace.Text = sc.FaceUN;
            pwBoxFace.Password = sc.FacePW;
            if (sc.FaceCHK == true) chkBoxFace.IsChecked=true;
            //mail
            txtBoxMail.Text = sc.MailUN;
            pwBoxMail.Password = sc.MailPW;
            if (sc.mailCHK == true) chkBoxMail.IsChecked = true;
            //twitter
            if (sc.TwitCHK == true) chkBoxTwit.IsChecked = true;

            if (chkBoxTwit.IsChecked == true)
            {
                _btnTwitter.IsEnabled = false;
            }
            else
            {
                _btnTwitter.IsEnabled = true;
            }            
        }

        private void faceUKEYUP(object sender, KeyEventArgs e)
        {
            saveToFile();
        }

        private void facePKEYUP(object sender, KeyEventArgs e)
        {
            saveToFile();
        }

        private void chkFCLICK(object sender, RoutedEventArgs e)
        {
            saveToFile();
        }

        private void mailUKEYUP(object sender, KeyEventArgs e)
        {
            saveToFile();
        }

        private void mailPKEYUP(object sender, KeyEventArgs e)
        {
            saveToFile();
        }


        private void chkMCLICK(object sender, RoutedEventArgs e)
        {
            saveToFile();
        }


        private void chkTwitCLICK(object sender, RoutedEventArgs e)
        {
            saveToFile();
            loadToUI();

        }


    }
}
