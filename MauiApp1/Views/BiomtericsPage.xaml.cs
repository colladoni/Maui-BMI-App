namespace MauiApp1.Views;

public partial class BiometricsPage : ContentPage
{
	public BiometricsPage()
	{
		InitializeComponent();
	}

	private void OnCalculateBmiClicked(object sender, EventArgs e)
	{
		//Checks if the user actually typed a valid number
		if (double.TryParse(WeightEntry.Text, out double weight) &&
			double.TryParse(HeightEntry.Text, out double heightCm))
		{
			// BMI Formula: Weight (kg) / Height (m) squared
			double heightM = heightCm / 100; // Convert cm to meters
			double bmi = weight / (heightM * heightM);

			// Display the exact BMI number (rounded to 1 decimal)
			ResultLabel.Text = $"BMI: {Math.Round(bmi, 1)}";

			// Figure out the weight category
			if (bmi < 18.5)
			{
				CategoryLabel.Text = "Underweight";
				CategoryLabel.TextColor = Colors.Blue;
			}
			else if (bmi >= 18.5 && bmi <= 24.9)
			{
				CategoryLabel.Text = "Normal weight";
				CategoryLabel.TextColor = Colors.Green;
			}
			else if (bmi >= 25 && bmi <= 29.9)
			{
				CategoryLabel.Text = "Overweight";
				CategoryLabel.TextColor = Colors.Orange;
			}
			else
			{
				CategoryLabel.Text = "Obese";
				CategoryLabel.TextColor = Colors.Red;
			}
		}
		else
		{
			// If the user typed letters or left it blank
			ResultLabel.Text = "Invalid Input";
			CategoryLabel.Text = "Please enter valid numbers.";
			CategoryLabel.TextColor = Colors.Red;
		}
	}
}