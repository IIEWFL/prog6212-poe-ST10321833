using System.Linq;
using System.Windows;

namespace CMCS4
{
    public partial class TrackStatusWindow : Window
    {
        public TrackStatusWindow(ApproveClaimsWindow approveClaimsWindow)
        {
            InitializeComponent();

    
            approveClaimsWindow.ClaimsUpdated += OnClaimsUpdated;

            LoadClaims();
        }

     
        private void LoadClaims()
        {
            ClaimsStatusListBox.ItemsSource = ClaimData.Claims.Select(c => new ClaimViewModel
            {
                Id = c.Id,
                LecturerName = c.LecturerName,
                HoursWorked = c.HoursWorked,
                HourlyRate = c.HourlyRate,
                Status = c.Status
            }).ToList();
        }

       
        private void OnClaimsUpdated()
        {
            LoadClaims(); 
        }
    }

}