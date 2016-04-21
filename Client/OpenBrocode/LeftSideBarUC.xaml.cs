﻿using System;
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

namespace OpenBrocode
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class LeftSideBarUC : UserControl
    {
        public LeftSideBarUC()
        {
            InitializeComponent();
        }

        private void _btnHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _btnFacebook_Click(object sender, RoutedEventArgs e)
        {

            //Creates a reference to the mainwindow instead of a new instance, then uses the public method loadFacePanel in MainWindow

            MainWindow mwObj = (MainWindow)Application.Current.MainWindow;
            mwObj.loadFacePanel();
            
        }
    }
}
