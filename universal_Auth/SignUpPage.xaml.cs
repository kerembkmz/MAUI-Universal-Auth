namespace universal_Auth;

public partial class SignUpPage : ContentPage
{
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


    }
}
