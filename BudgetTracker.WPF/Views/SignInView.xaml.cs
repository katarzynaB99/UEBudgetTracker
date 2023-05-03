using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetTracker.WPF.Views
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    public partial class SignInView : UserControl
    {
        public static readonly DependencyProperty SignInCommandProperty =
            DependencyProperty.Register("SignInCommand", typeof(ICommand), typeof(SignInView),
                new PropertyMetadata(null));

        public ICommand SignInCommand
        {
            get => (ICommand)GetValue(SignInCommandProperty);
            set => SetValue(SignInCommandProperty, value);
        }

        public SignInView()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (SignInCommand != null)
            {
                var password = pbPassword.Password;
                SignInCommand.Execute(password);
            }
        }
    }
}
