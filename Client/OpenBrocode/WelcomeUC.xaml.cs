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
using Microsoft.VisualBasic;
using OpenBrocode.User; 

namespace OpenBrocode
{
    /// <summary>
    /// Interaction logic for WelcomeUC.xaml
    /// </summary>
    public partial class WelcomeUC : UserControl
    {
        private string usrNameText;

        private UserHandler handler; 

        public WelcomeUC()
        {
            handler = new UserHandler(); 
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(this.handler.login(usrNameText.ToString(), pwBoxMain.Password.ToString()))
            {
                MainWindow mwObj = (MainWindow)Application.Current.MainWindow;
                mwObj.initialLoadPanel();
            }
            else {
                    MessageBox.Show("Invalid username or password.");                
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            MainWindow mwObj = (MainWindow)Application.Current.MainWindow;
            mwObj.loadPanel(new ForgotPasswordUC());
        }

        private void textBoxMain_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            this.usrNameText = textBox.Text;
        }
    }
}
