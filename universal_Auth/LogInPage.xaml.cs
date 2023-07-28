namespace universal_Auth;

public partial class LogInPage : ContentPage
{
    public LogInPage()
    {
        InitializeComponent();
        Title = "Log In Page";
    }

    void Login_Click(System.Object sender, System.EventArgs e)
    {
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
