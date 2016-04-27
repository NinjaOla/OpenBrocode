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
        }


        public void loadedSettings()
        {

            //plan is to read from the json file what settings the user have and then apply them to the UI (if they use twitter module forexample)

            //read from file - set settings 

            //when close - read from settings - set file

        }

        public void createJSONfile()
        {
            JsonHandler handler = new JsonHandler();

            handler.objectToJson(txtBoxFace.Text, pwBoxFace.Password, (bool)chkBoxFace.IsChecked,
                 txtBoxMail.Text, pwBoxMail.Password, (bool)chkBoxMail.IsChecked,
                 txtBoxTwit.Text, pwBoxTwit.Password, (bool)chkBoxTwit.IsChecked);
        }

        private void buttonclick(object sender, RoutedEventArgs e)
        {
            createJSONfile();
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
            txtBoxTwit.Text = sc.TwitUN;
            pwBoxTwit.Password = sc.TwitPW;
            if (sc.TwitCHK == true) chkBoxTwit.IsChecked = true;
            
        }

        private void button2click(object sender, RoutedEventArgs e)
        {
            loadToUI();
        }
    }
}
