using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace CMCS4
{
    public partial class HRWindow : Window
    {
        public ObservableCollection<Claim> ApprovedClaims { get; set; }

        public HRWindow()
        {
            InitializeComponent();

            // Load approved claims into DataGrid
            ApprovedClaims = new ObservableCollection<Claim>(ClaimData.Claims.Where(c => c.Status == "Approved"));
            ClaimsDataGrid.ItemsSource = ApprovedClaims;
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ApprovedClaims.Any())
                {
                    MessageBox.Show("No approved claims available for the report.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Define the path for the report file
                string filePath = "ApprovedClaimsReport.txt";

                // Build the report content
                StringBuilder reportContent = new StringBuilder();
                reportContent.AppendLine("Approved Claims Report");
                reportContent.AppendLine("Generated on: " + DateTime.Now);
                reportContent.AppendLine(new string('-', 50));
                foreach (var claim in ApprovedClaims)
                {
                    reportContent.AppendLine($"Lecturer: {claim.LecturerName}, Hours Worked: {claim.HoursWorked}, Hourly Rate: {claim.HourlyRate}, Total Payment: {claim.HoursWorked * claim.HourlyRate}");
                }

                // Write to the file
                File.WriteAllText(filePath, reportContent.ToString());

                // Notify the user
                MessageBox.Show($"Report successfully generated at: {filePath}\n\nPreview:\n{reportContent}", "Report Generated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating the report: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveLecturer_Click(object sender, RoutedEventArgs e)
        {
            string name = DescriptionTextBox.Text;
            string contact = LecturerContactTextBox.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show("Please fill in all lecturer details.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Add lecturer to the list (implement LecturerData for persistence)
            LecturerData.Lecturers.Add(new Lecturer { Name = name, Contact = contact });
            MessageBox.Show("Lecturer added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear text boxes
            DescriptionTextBox.Clear();
            LecturerContactTextBox.Clear();
        }

        private void DeleteLecturer_Click(object sender, RoutedEventArgs e)
        {
            string name = DescriptionTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please provide the lecturer's name to delete.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var lecturerToRemove = LecturerData.Lecturers.FirstOrDefault(l => l.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (lecturerToRemove != null)
            {
                LecturerData.Lecturers.Remove(lecturerToRemove);
                MessageBox.Show("Lecturer removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                DescriptionTextBox.Clear();
                LecturerContactTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Lecturer not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
