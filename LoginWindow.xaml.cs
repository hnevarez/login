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
using System.Windows.Shapes;
using database.DataSet1TableAdapters;

namespace database
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private UsersTableAdapter user = new UsersTableAdapter();
        private DataSet1 dataSet = new DataSet1();
        public string name;
        public string password;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            user.Fill(dataSet.Users);
            DataContext = dataSet.Users.DefaultView;

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var query = from user in dataSet.Users
                        where (user.Name == txtName.Text)
                        where (user.Password == txtPassword.Text)
                        select user;
            // check if there is a match, query will have entry
            if (query.Count() > 0)
            {
                // create instance of the MainWindow (new)
                MainWindow main = new MainWindow();
                // show window
                main.Show();
                // Close() this window
            
            }
            else
            {
                // show message box that states the user does not exist
                MessageBox.Show("The user does not exist", "Submit", MessageBoxButton.OK, MessageBoxImage.Error);

                // clear text boxes
                txtName.Clear();
                txtPassword.Clear();
            }
        }



        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            DataSet1.UsersRow row = (DataSet1.UsersRow)dataSet.Users.NewRow();
            // set row Name to name textbox Text
            row.Name = txtName.Text;
            row.Password = txtPassword.Text;
            // set row Password to password textbox TextdataSet.Users.AddUsersRow(row);
            dataSet.Users.AddUsersRow(row);
            user.Update(dataSet);

            // show message box that states the user was registered
            // on the message box show an information icon and “Register” caption


            // show message box that states the user does not exist
            MessageBox.Show("The user was registered", "Register", MessageBoxButton.OK, MessageBoxImage.Information);
             
            // clear text boxes
            txtName.Clear();
            txtPassword.Clear();
          

        }
    }
}
