using System;
using System.Windows;

namespace CMCS4
{
    public partial class SubmitClaimWindow : Window
    {
        public SubmitClaimWindow()
        {
            InitializeComponent();

            // Attach auto-calculation for total payment
            HoursWorkedTextBox.TextChanged += UpdateTotalPayment;
            HourlyRateTextBox.TextChanged += UpdateTotalPayment;
        }

        private void UpdateTotalPayment(object sender, EventArgs e)
        {
            if (double.TryParse(HoursWorkedTextBox.Text, out double hours) &&
                double.TryParse(HourlyRateTextBox.Text, out double rate))
            {
                TotalPaymentTextBlock.Text = (hours * rate).ToString("C2");
            }
            else
            {
                TotalPaymentTextBlock.Text = "Invalid input";
            }
        }

        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LecturerNameTextBox.Text) ||
                !double.TryParse(HoursWorkedTextBox.Text, out double hours) ||
                !double.TryParse(HourlyRateTextBox.Text, out double rate))
            {
                MessageBox.Show("Please fill out all fields with valid data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Save the claim
            var claim = new Claim
            {
                LecturerName = LecturerNameTextBox.Text,
                HoursWorked = hours,
                HourlyRate = rate,
                Status = "Pending"
            };

            ClaimData.Claims.Add(claim);
            MessageBox.Show("Claim submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
