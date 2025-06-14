namespace BMICalculator;

public partial class BMIResults : ContentPage
{
    private double currentBMI; // Renamed to avoid confusion with parameter name
    private string currentSelectedGender; // Renamed to avoid confusion with parameter name

    public BMIResults(double bmi, string selectedGender)
    {
        InitializeComponent();
        currentBMI = bmi; // Assign passed BMI to the page's field
        currentSelectedGender = selectedGender; // Assign passed gender to the page's field

        DisplayBMIResult(currentBMI);
        ShowBMICategory(currentBMI, currentSelectedGender); // Pass BMI to the category method
    }

    // Displays the numerical BMI result in an alert.
    // Consider setting a Label's text directly instead of an alert for better UX.
    public void DisplayBMIResult(double bmiValue)
    {
        string bmiResultText = $"Your BMI is: {bmiValue:F2}";
        // You can update a Label on the page directly like this instead of an alert:
        // ResultLabel.Text = bmiResultText;
        DisplayAlert("BMI Calculation Result", bmiResultText, "OK");
    }

    // Shows the BMI category text based on BMI and gender.
    public void ShowBMICategory(double bmiValue, string selectedGender)
    {
        string categoryText = "";
        if (selectedGender == "Male")
        {
            categoryText = "For Males:\n" +
                           "• BMI < 18.5: Underweight\n" +
                           "• BMI 18.5 - 24.9: Normal Weight\n" +
                           "• BMI 25 - 29.9: Overweight\n" +
                           "• BMI >= 30: Obese";
        }
        else // Female
        {
            categoryText = "For Females:\n" +
                           "• BMI < 18.0: Underweight\n" +
                           "• BMI 18.0 - 23.9: Normal Weight\n" +
                           "• BMI 24 - 28.9: Overweight\n" +
                           "• BMI >= 29: Obese";
        }
        ResultLabel.Text = categoryText; // Update the ResultLabel defined in BMIResults.xaml
    }

    // Event handler for the "View Health Recommendations" button.
    private async void OnRecommendedClicked(object sender, EventArgs e)
    {
        // Navigate to the RecommendationResults page, passing BMI and selectedGender
        await Navigation.PushAsync(new RecommendationResults(currentBMI, currentSelectedGender));
    }

    // Event handler for the "Back to Main Page" button.
    private async void OnBackToMainPageClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync(); // Goes back to the very first page in the navigation stack
    }
}

