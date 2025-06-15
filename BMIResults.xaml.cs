namespace BMICalculator;

public partial class BMIResults : ContentPage
{
    private double currentBMI;
    private string currentSelectedGender;

    // Method that passes through variables brought over from previous pages.
    public BMIResults(double bmi, string selectedGender)
    {
        InitializeComponent();
        currentBMI = bmi; 
        currentSelectedGender = selectedGender;

        DisplayBMIResult(currentBMI);
        ShowBMICategory(currentBMI, currentSelectedGender); 
    }

    // Displays the numerical BMI result in an alert.
    public void DisplayBMIResult(double bmiValue)
    {
        string bmiResultText = $"Your BMI is: {bmiValue:F2}";
        // ResultLabel.Text = bmiResultText;
        BMILabel.Text = bmiResultText; // Update the BMI Label defined in BMIResults.xaml
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

