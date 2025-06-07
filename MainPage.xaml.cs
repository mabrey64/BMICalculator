namespace BMICalculator;

public partial class MainPage : ContentPage
{
    // You can use a string to store the selected gender, similar to your working project
    private string selectedGender = "Male"; // Initialize with Male as default selected
    private int height = 0; // Variable to store height input
    private int weight = 0; // Variable to store weight input
    private double BMI = 0; // Variable to store calculated BMI

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnGenderTap(object sender, TappedEventArgs e)
    {
        // Cast the sender back to a Frame
        Frame tappedFrame = sender as Frame;

        if (tappedFrame == null) return; // Safety check

        // Reset borders for both frames
        FrameMale.BorderColor = Colors.Transparent;
        FrameFemale.BorderColor = Colors.Transparent;

        // Set the border for the tapped frame
        tappedFrame.BorderColor = Colors.Green;

        // Update the selected gender based on which frame was tapped
        if (tappedFrame == FrameMale)
        {
            selectedGender = "Male";
        }
        else if (tappedFrame == FrameFemale)
        {
            selectedGender = "Female";
        }

        // Optional: You can add a Debug.WriteLine to see the choice
        // System.Diagnostics.Debug.WriteLine($"Selected Gender: {selectedGender}");
    }

    private void OnCalculateClick(object sender, EventArgs e)
    {
        // For demonstration, display the selected gender.
        // You'll integrate this with your BMI calculation logic later.
        height = (int)HeightSlider.Value; // Get height from the input
        weight = (int)WeightSlider.Value; // Get weight from the input
        if (height > 0 && weight > 0)
        {
            // Calculate BMI
            BMI = ((double)weight / (height * height)) * 703;
            DisplayAlert("BMI Result", $"Your BMI is: {BMI:F2}", "OK");
            HealthRecommendation(sender, e); // Call the health recommendation method
        }
        else
        {
            DisplayAlert("Input Error", "Please enter valid height and weight.", "OK");
        }
    }

    private void OnHeightChanged(object sender, ValueChangedEventArgs e)
    {
        // Handle height input changes if needed
        // For example, you can validate the input or update UI elements
    }

    private void OnWeightChanged(object sender, ValueChangedEventArgs e)
    {
        // Handle weight input changes if needed
        // For example, you can validate the input or update UI elements
    }

    private void HealthRecommendation(object sender, EventArgs e)
    {
        // This method can be used to provide health recommendations based on the BMI
        // For now, it will just display a message
        if (selectedGender == "Male")
        {
            if (BMI < 18.5)
            {
                DisplayAlert("Health Recommendation", "You are underweight. Increase calorie intake with nutrient-rich foods (e.g., buts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutrionist if needed.", "OK");
            }
            else if (BMI >= 18.5 && BMI < 25)
            {
                DisplayAlert("Health Recommendation", "You are at a normal weight. Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.", "OK");
            }
            else if (BMI >= 25 && BMI < 30)
            {
                DisplayAlert("Health Recommendation", "You are overweight. Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progress.", "OK");
            }
            else
            {
                DisplayAlert("Health Recommendation", "You are obese. Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.", "OK");
            }
        }
        else
        {
            if (BMI < 18)
            {
                DisplayAlert("Health Recommendation", "You are underweight. Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed.", "OK");
            }
            else if (BMI >= 18 && BMI < 24)
            {
                DisplayAlert("Health Recommendation", "You are at a normal weight. Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.", "OK");
            }
            else if (BMI >= 24 && BMI < 29)
            {
                DisplayAlert("Health Recommendation", "You are overweight. Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progress.", "OK");
            }
            else
            {
                DisplayAlert("Health Recommendation", "You are obese. Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.", "OK");
            }
        }
    }
}
