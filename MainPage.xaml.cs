namespace BMICalculator;

public partial class MainPage : ContentPage
{
    // You can use a string to store the selected gender, similar to your working project
    private string selectedGender = "Male"; // Initialize with Male as default selected
    private int height = 0; // Variable to store height input
    private int weight = 0; // Variable to store weight input

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
        DisplayAlert("Gender Selected", $"You have selected: {selectedGender}", "OK");
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
}
