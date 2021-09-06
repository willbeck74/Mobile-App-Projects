using System;

using Xamarin.Forms;

namespace ControlsAndEvents
{
    public class MainPage : ContentPage
    {
        Entry TextChanged;
        Label LabelTextChanged;

        Button Counter;
        Label LabelCounter;
        int num = 0;

        CheckBox box;
        Label LabelCheckBox;

        Switch toggle;
        Label LabelToggle;

        Stepper step;
        Label LabelStepper;
        double val = 0.5;

        Slider slide;
        Label LabelSlider;
        double sval = 0.5;

        public MainPage()
        {
            StackLayout topLevel = new StackLayout();
            StackLayout entry = new StackLayout { Orientation = StackOrientation.Horizontal };

            TextChanged = new Entry { Text = "Enter Word" };
            LabelTextChanged = new Label() { Text = " a" };
            entry.Children.Add(TextChanged);
            entry.Children.Add(LabelTextChanged);

            StackLayout button = new StackLayout { Orientation = StackOrientation.Horizontal };
            Counter = new Button();
            Counter.Text = "Click Me";
            LabelCounter = new Label();
            button.Children.Add(Counter);
            button.Children.Add(LabelCounter);

            StackLayout CheckBox = new StackLayout { Orientation = StackOrientation.Horizontal };
            box = new CheckBox { IsChecked = true };
            LabelCheckBox = new Label() { Text = "Checked" };
            CheckBox.Children.Add(box);
            CheckBox.Children.Add(LabelCheckBox);

            StackLayout SwitchFormat = new StackLayout { Orientation = StackOrientation.Horizontal };
            toggle = new Switch { IsToggled = true };
            LabelToggle = new Label() { Text = "on" };
            SwitchFormat.Children.Add(toggle);
            SwitchFormat.Children.Add(LabelToggle);

            StackLayout StepperLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
            step = new Stepper
            {
                Maximum = 1,
                Minimum = 0,
                Increment = 0.1,
                HorizontalOptions = LayoutOptions.Center
            };
            step.Value = 0.5;
            LabelStepper = new Label() { Text = "0.5" };
            StepperLayout.Children.Add(step);
            StepperLayout.Children.Add(LabelStepper);

            StackLayout SliderLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
            slide = new Slider
            {
                Maximum = 1,
                Minimum = 0,
                HorizontalOptions = LayoutOptions.Center
            };
            LabelSlider = new Label() { Text = "0.5" };
            slide.Value = 0.5;
            SliderLayout.Children.Add(slide);
            SliderLayout.Children.Add(LabelSlider);

            topLevel.Children.Add(entry);
            topLevel.Children.Add(button);
            topLevel.Children.Add(CheckBox);
            topLevel.Children.Add(SwitchFormat);
            topLevel.Children.Add(StepperLayout);
            topLevel.Children.Add(SliderLayout);
            topLevel.Padding = new Thickness(0, 50, 0, 0);

            this.Content = topLevel;

            TextChanged.TextChanged += entryChanged;
            Counter.Clicked += OnClicked;
            box.CheckedChanged += OnChecked;
            toggle.Toggled += OnToggled;
            step.ValueChanged += OnValueChanged;
            slide.ValueChanged += OnValueChangedSlider;

        }

        private void entryChanged(object sender, TextChangedEventArgs e)
        {
            string ret = TextChanged.Text;
            LabelTextChanged.Text = Convert.ToString(ret.Length);
        }

        private void OnClicked(object sender, EventArgs e)
        {
            num++;
            LabelCounter.Text = Convert.ToString(num);
        }
        private void OnChecked(object sender, CheckedChangedEventArgs e)
        {
            bool check = box.IsChecked;
            if (check == true)
                LabelCheckBox.Text = "checked";
            else LabelCheckBox.Text = "unchecked";
        }

        private void OnToggled(object sender, ToggledEventArgs e)
        {
            bool tog = toggle.IsToggled;
            if (tog == true)
                LabelToggle.Text = "on";
            else LabelToggle.Text = "off";
        }

        private void OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            val = ((Stepper)sender).Value;
            LabelStepper.Text = Convert.ToString(val);
        }

        private void OnValueChangedSlider(object sender, ValueChangedEventArgs e)
        {
            sval = ((Slider)sender).Value;
            LabelSlider.Text = Convert.ToString(sval);
        }
    }
}