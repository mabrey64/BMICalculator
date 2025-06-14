namespace BMICalculator;

public partial class RecommendationResults : ContentPage
{
    private double currentBMI;
    private string currentSelectedGender;

    public RecommendationResults(double bmi, string selectedGender)
    {
        InitializeComponent();
        currentBMI = bmi;
        currentSelectedGender = selectedGender;

        // Display the specific health recommendation when the page loads
        RecommendationLabel.Text = HealthRecommendation();
    }

    // Method that displays the health recommendation based on BMI and gender.
    private string HealthRecommendation()
    {
        string healthRecommended = "";
        if (currentSelectedGender == "Male")
        {
            if (currentBMI < 18.5)
            {
                healthRecommended = "You are underweight. Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed.";
            }
            else if (currentBMI >= 18.5 && currentBMI < 25)
            {
                healthRecommended = "You are at a normal weight. Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.";
            }
            else if (currentBMI >= 25 && currentBMI < 30)
            {
                healthRecommended = "You are overweight. Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progress.";
            }
            else // BMI >= 30
            {
                healthRecommended = "You are obese. Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.";
            }
        }
        else // Female
        {
            if (currentBMI < 18)
            {
                healthRecommended = "You are underweight. Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed.";
            }
            else if (currentBMI >= 18 && currentBMI < 24)
            {
                healthRecommended = "You are at a normal weight. Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.";
            }
            else if (currentBMI >= 24 && currentBMI < 29)
            {
                healthRecommended = "You are overweight. Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progress.";
            }
            else // BMI >= 29
            {
                healthRecommended = "You are obese. Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.";
            }
        }
        return healthRecommended;
    }
    // Event handler for "View Health Tips" button (Placeholder for future functionality)
    private async void OnViewHealthTipsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Health Tips", "This section can display more detailed health tips based on your BMI category.", "OK");
    }

    // Method used to go back to the BMI results page.
    private async void OnBackToBMIResultsClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); 
    }

    // Method used to go back to the main page of the app.
    private async void OnBackToMainPageClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}