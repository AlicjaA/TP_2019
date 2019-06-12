
using System.Windows;


namespace GUI.View
{
    /// <summary>
    /// Logika interakcji dla klasy UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetails : Window
    {
        public UserDetails()
        {
            InitializeComponent();
        }

        public void OnCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
