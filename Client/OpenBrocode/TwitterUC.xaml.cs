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
using Tweetinvi.Core.Interfaces;
using OpenBrocode.User;

namespace OpenBrocode
{
    /// <summary>
    /// Interaction logic for TwitterUC.xaml
    /// </summary>
    public partial class TwitterUC : UserControl
    {


        public TwitterUC()
        {
            
                if (UserHandler.Twitter != null && !UserHandler.Twitter.userLoggedIn())
                {
                    WelcomeUC welUcObject = new WelcomeUC();
                    return;
                } else if (UserHandler.Twitter == null)
            {
                WelcomeUC welUcObject = new WelcomeUC();
                return;
            }
            

            InitializeComponent();
            getTweetsToList();

        }

        private void getTweetsToList()
        {

            List<ITweet> userTimeLine = UserHandler.Twitter.twitterUser.HomeTimeline.ToList();
            listbox1.ItemsSource = userTimeLine;
        }

        private void sendTweetClick(object sender, RoutedEventArgs e)
        {

            UserHandler.Twitter.User.PublishTweet(tweetTextBox.Text);
            tweetTextBox.Text = "Input tweet";
            getTweetsToList();

        }
    }
}
