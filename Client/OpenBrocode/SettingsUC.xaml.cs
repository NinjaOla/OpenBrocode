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
using OpenBrocode.User;




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
            InitializeComponent();

            if (UserHandler.Twitter != null && UserHandler.Twitter.userLoggedIn())
            {
                chkBoxTwit.IsChecked = true;
                _btnTwitter.IsEnabled = false;
            }
            else
            {
                UserHandler.Twitter = new MainTwitter();
                UserHandler.Twitter.loginEventHandler += new EventHandler(loginEventHandler);

            }

            setCHKMail();

            loadToUI();

        }

        public void loginEventHandler(object sender, EventArgs e)
        {
            MainTwitter twitter = (MainTwitter)sender;

            UserHandler.getUser().settings.settings.TwitterUserToken = twitter.getUserAccessToken();

            UserHandler.getUser().settings.settings.TwitterUserSecretToken = twitter.getUserAccessTokenSecret();

            UserHandler.getUser().settings.writeFile(); 
        }


        private void btnTwitterClick(object sender, RoutedEventArgs e)
        {
            UserHandler.Twitter.authenticateApp(); 
            //maintwitter.authenticateApp();
            InputBox.Visibility = Visibility.Visible;
           

            //OK popupboks knapp med pin - caller på eventhandler.(popup kjører authenticateUser)->


        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            //maintwitter.authenticateUser(InputTextBox.Text);
            UserHandler.Twitter.authenticateUser(InputTextBox.Text);
            InputBox.Visibility = Visibility.Collapsed;
            chkBoxTwit.IsChecked = true;
            saveToFile();
            _btnTwitter.IsEnabled = false;

        }

        

        public void saveToFile()
        {
            UserHandler.getUser().settings.writeFile();

            //JsonHandler handler = new JsonHandler();

            //handler.objectToJson(txtBoxFace.Text, pwBoxFace.Password, (bool)chkBoxFace.IsChecked,
            //     txtBoxMail.Text, pwBoxMail.Password, (bool)chkBoxMail.IsChecked, (bool)chkBoxTwit.IsChecked);
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
            UserHandler.getUser().settings.settings.FaceUN = txtBoxFace.Text;
            
        }

        private void facePKEYUP(object sender, KeyEventArgs e)
        {
            UserHandler.getUser().settings.settings.FacePW = pwBoxFace.Password;
            
        }

        private void chkFCLICK(object sender, RoutedEventArgs e)
        {
            saveToFile();
        }

        private void mailUKEYUP(object sender, KeyEventArgs e)
        {
            UserHandler.getUser().settings.settings.MailUN = txtBoxMail.Text;
            
        }

        private void mailPKEYUP(object sender, KeyEventArgs e)
        {
            UserHandler.getUser().settings.settings.MailPW = pwBoxMail.Password;
            
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

        private void _btnSave_Click(object sender, RoutedEventArgs e)
        {
            saveToFile();
            setCHKMail();
        }


        private void setCHKMail()
        {
            if(txtBoxMail.Text != null && pwBoxMail.Password != null)
            {
                chkBoxMail.IsChecked = true;
            }
        }
    }
}
