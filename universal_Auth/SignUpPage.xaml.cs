namespace universal_Auth;

using System.Xml;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using password_Manager;

public partial class SignUpPage : ContentPage
{
    DateTime selectedDate;


    public SignUpPage()
    {
        InitializeComponent();
        Title = "Sign Up Page";
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior()
        {
            TextOverride = "Back",
        });
    }

    private void SignUp_Click(object sender, EventArgs e)
    {

        
        string name = nameEntry.Text;
        string surname = surnameEntry.Text;
        string email = emailEntry.Text;
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;
        int age;

        
        if (int.TryParse(ageEntry.Text, out int enteredAge))
        {
            age = enteredAge;
        }
        else
        {
            DisplayAlert("Error", "Please enter a valid age.", "OK");
            return;
        }


        databaseService dbService = new databaseService();
        bool additionValid = dbService.RegisterUser(name, surname, email, username, password, age);

        if (additionValid)
        {
            DisplayAlert("Success", "User successfully added.", "OK");
        }
        else
        {
            DisplayAlert("Error", "Failed to add user. Please try again.", "OK");
        }
    }
    


}
