namespace universal_Auth;
using password_Manager;

public partial class LogInPage : ContentPage
{
    public LogInPage()
    {
        InitializeComponent();
        Title = "Log In Page";
    }

    void Login_Click(System.Object sender, System.EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        databaseService dbService = new databaseService();
        bool validation = dbService.CheckValidationUser(username, password);

        if (validation)
        {
            DisplayAlert("Success", "Logging in.", "OK");
        }
        else
        {
            DisplayAlert("Error", "Failed to log in. Please try again.", "OK");
        }
    }

    void Register_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            // Navigate to SignUpPage when the "Register" button is clicked
            Navigation.PushAsync(new SignUpPage());

        }
        catch (Exception ex)
        {

            // Handle or log any exceptions that occur during navigation
        }
    }
}
