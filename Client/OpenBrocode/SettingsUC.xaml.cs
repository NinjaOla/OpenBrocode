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

namespace OpenBrocode
{
    /// <summary>
    /// Interaction logic for SettingsUC.xaml
    /// </summary>
    public partial class SettingsUC : UserControl
    {

        public SettingsUC()
        {
            InitializeComponent();
            loadToUI();



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
        }
    }
}
