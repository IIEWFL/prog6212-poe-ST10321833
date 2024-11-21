using System;
using System.Linq;
using System.Windows;

namespace CMCS4
{
    public partial class ApproveClaimsWindow : Window
    {
        public event Action ClaimsUpdated;

        public ApproveClaimsWindow()
        {
            InitializeComponent();

            // Bind claims to the ListBox
            UpdateObservableCollection();
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsListBox.SelectedItem is ClaimViewModel selectedClaim)
            {
                Claim originalClaim = ClaimData.Claims.First(c => c.Id == selectedClaim.Id);

                // Automated verification: Ensure hours worked are within limits
                if (selectedClaim.HoursWorked > 100 || selectedClaim.HourlyRate > 1000)
                {
                    MessageBox.Show("Claim does not meet verification criteria.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                originalClaim.Status = "Approved";
                UpdateObservableCollection();
                ClaimsUpdated?.Invoke();
            }
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsListBox.SelectedItem is ClaimViewModel selectedClaim)
            {
                Claim originalClaim = ClaimData.Claims.First(c => c.Id == selectedClaim.Id);
                originalClaim.Status = "Rejected";

                UpdateObservableCollection();
                ClaimsUpdated?.Invoke();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Updates the claims in the ListBox to reflect the latest state.
        /// </summary>
        private void UpdateObservableCollection()
        {
            ClaimsListBox.ItemsSource = ClaimData.Claims.Select(c => new ClaimViewModel
            {
                Id = c.Id,
                LecturerName = c.LecturerName,
                HoursWorked = c.HoursWorked,
                HourlyRate = c.HourlyRate,
                Status = c.Status
            }).ToList();

            ClaimsListBox.Items.Refresh(); // Ensures the UI reflects the latest data.
        }
    }
}
