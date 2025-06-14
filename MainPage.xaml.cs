namespace BMICalculator;

public partial class MainPage : ContentPage
{
    private string selectedGender = "Male"; // Initialize with Male as default selected
    private int height = 0; // Variable to store height input
    private int weight = 0; // Variable to store weight input
    private double BMI = 0; // Variable to store calculated BMI

    public MainPage()
    {
        InitializeComponent();
    }

    // Handles the Gender selection
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
    }

    // Event handler for the Calculate button click but commented out as it is used in the Next page button click instead.
    private void OnCalculateClick(object sender, EventArgs e)
    {
        //height = (int)HeightSlider.Value; // Get height from the input
        //weight = (int)WeightSlider.Value; // Get weight from the input
        //if (height > 0 && weight > 0)
        //{
        //    // Calculate BMI
        //    BMI = ((double)weight / (height * height)) * 703;
        //    string BMIResult = $"Your BMI is: {BMI:F2} \n";
        //    DisplayAlert("BMI Result & Health Recommendation",  BMIResult + "\n" + HealthRecommendation(), "OK");
        //}
        //else
        //{
        //    DisplayAlert("Input Error", "Please enter valid height and weight.", "OK");
        //}
    }

    private void OnHeightChanged(object sender, ValueChangedEventArgs e)
    {
        // Handle height input changes if needed. But it is handled in the OnCalculateClick method.
    }

    private void OnWeightChanged(object sender, ValueChangedEventArgs e)
    {
        // Handle weight input changes if needed. But it is handled in the OnCalculateClick method.
    }

    // Method that displays the health recommendation based on BMI and gender. Commented out as it's not currently used in the UI and used in the BMIResults page instead.
    //private string HealthRecommendation()
    //{
    //    string HealthRecommended = "";
    //    if (selectedGender == "Male")
    //    {
    //        if (BMI < 18.5)
    //        {
    //            return HealthRecommended = "You are underweight. Increase calorie intake with nutrient-rich foods (e.g., buts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutrionist if needed.";
    //        }
    //        else if (BMI >= 18.5 && BMI < 25)
    //        {
    //            return HealthRecommended = "You are at a normal weight. Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.";
    //        }
    //        else if (BMI >= 25 && BMI < 30)
    //        {
    //            return HealthRecommended = "You are overweight. Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progress.";
    //        }
    //        else
    //        {
    //            return HealthRecommended = "You are obese. Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.";
    //        }
    //    }
    //    else
    //    {
    //        if (BMI < 18)
    //        {
    //            return HealthRecommended = "You are underweight. Increase calorie intake with nutrient-rich foods (e.g., nuts, lean protein, whole grains). Incorporate strength training to build muscle mass. Consult a nutritionist if needed.";
    //        }
    //        else if (BMI >= 18 && BMI < 24)
    //        {
    //            return HealthRecommended = "You are at a normal weight. Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.";
    //        }
    //        else if (BMI >= 24 && BMI < 29)
    //        {
    //            return HealthRecommended = "You are overweight. Reduce processed foods and focus on portion control. Engage in regular aerobic exercises (e.g., jogging, swimming) and strength training. Drink plenty of water and track your progress.";
    //        }
    //        else
    //        {
    //            return HealthRecommended = "You are obese. Consult a doctor for personalized guidance. Start with low-impact exercises (e.g., walking, cycling). Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.";
    //        }
    //    }
    //}

    // Event handler for the Next page button click
    private async void OnNextPageClick(object sender, EventArgs e)
    {
        height = (int)HeightSlider.Value; // Get height from the input
        weight = (int)WeightSlider.Value; // Get weight from the input
        if (height <= 0 || weight <= 0)
        {
            await DisplayAlert("Input Error", "Please enter valid height and weight.", "OK");
            return;
        }
        else
        {
            // Calculate BMI
            BMI = ((double)weight / (height * height)) * 703;
        }
        await Navigation.PushAsync(new BMIResults(BMI, selectedGender));
    }
}
