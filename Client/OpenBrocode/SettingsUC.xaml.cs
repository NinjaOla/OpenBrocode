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
using Newtonsoft.Json;

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



    }
}
