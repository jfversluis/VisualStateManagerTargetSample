using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace VSMTargetSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
		string _currentValidationState = "Normal";

		public MainPage()
        {
            InitializeComponent();

			CurrentState.Text = $"Current state: {_currentValidationState}";
		}

		void ToggleValid_OnClicked(object sender, EventArgs e)
		{
			if (_currentValidationState == "Normal")
			{
				_currentValidationState = "Invalid";
			}
			else
			{
				_currentValidationState = "Normal";
			}

			UpdateState();
		}

        void NeedsValidValueEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
			_currentValidationState = string.IsNullOrWhiteSpace(e.NewTextValue) || (int.TryParse(e.NewTextValue, out _) && !e.NewTextValue.StartsWith("1")) ? "Normal" : "Invalid";

			UpdateState();
        }

		void UpdateState()
        {
			CurrentState.Text = $"Current state: {_currentValidationState}";
			VisualStateManager.GoToState(MyLayout, _currentValidationState);

			// Not needed anymore with TargetName
			//VisualStateManager.GoToState(NeedsValidValueEntry, _currentValidationState);
			//VisualStateManager.GoToState(ToggleValidButton, _currentValidationState);
			//VisualStateManager.GoToState(SubmitButton, _currentValidationState);
		}

        void SubmitButton_Clicked(object sender, EventArgs e)
        {
			DisplayAlert("Submitted", "You've submitted a number, congratulations", "Thanks!");
        }
    }
}