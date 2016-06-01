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
using Twitter;
using Tweetinvi;




namespace OpenBrocode
{
    /// <summary>
    /// Interaction logic for TwitterUC.xaml
    /// </summary>
    public partial class TwitterUC : UserControl
    {

        
        public TwitterUC()
        {
            
            InitializeComponent();
            
            
        }

        private void sendTweetClick(object sender, RoutedEventArgs e)
        {

            SettingsUC.maintwitter.twitterUser.publishTweet(tweetTextBox.Text);
            tweetTextBox.Text = "twitter sendt";

        }
    }
}
