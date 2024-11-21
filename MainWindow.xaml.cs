using CMCS4;
using System.Windows;

//Tutus Funny [@TutusFunny]. (n.d.). Create the WPF application desktop app in visual studio 2022. Youtube. Retrieved October 17, 2024, from https://www.youtube.com/watch?v=H1m4n70rdPs 
//XAML styles. (n.d.). Microsoft.com. Retrieved October 17, 2024, from https://learn.microsoft.com/en-us/windows/apps/design/style/xaml-styles 
//Plays, K. [@KampaPlays]. (n.d.). C# WPF tutorial #3 - getting started with WPF. Youtube. Retrieved October 17, 2024, from https://www.youtube.com/watch?v=4DZZadT2RPs 
//Color Codes. (n.d.). HTML & CSS Wiki; Fandom, Inc. Retrieved October 17, 2024, from https://htmlcss.fandom.com/wiki/Color_Codes 
//CSS Color Codes. (n.d.). Quackit.com. Retrieved October 17, 2024, from https://www.quackit.com/css/css_color_codes.cfm 
//Coding Under Pressure [@codingunderpressure7818]. (n.d.). Buttons and click events in WPF C# - WPF C# tutorial part 2. Youtube. Retrieved October 17, 2024, from https://www.youtube.com/watch?v=70-x_Zkf2gE 
//Coding Under Pressure [@codingunderpressure7818]. (n.d.-b). How to let user browse and upload files in WPF C# - prompt for a file in C# part 1. Youtube. Retrieved October 17, 2024, from https://www.youtube.com/watch?v=DKYssZ8JUx0 
//Kettlesimulator [@kettlesimulator]. (n.d.). C# WPF: Making a File Explorer! (#1 setting up the navigation and controls). Youtube. Retrieved October 17, 2024, from https://www.youtube.com/watch?v=uRhXrxvnTus 
//Coding Under Pressure [@codingunderpressure7818]. (n.d.-c). The scrollviewer in WPF - how to scroll content in WPF part 7. Youtube. Retrieved October 17, 2024, from https://www.youtube.com/watch?v=dCKhDAOhuyw 


namespace CMCS4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitClaims_Click(object sender, RoutedEventArgs e)
        {
            SubmitClaimWindow submitClaimWindow = new SubmitClaimWindow();
            submitClaimWindow.Show();
        }

        private void TrackStatus_Click(object sender, RoutedEventArgs e)
        {
            ApproveClaimsWindow approveClaimsWindow = new ApproveClaimsWindow();
            TrackStatusWindow trackStatusWindow = new TrackStatusWindow(approveClaimsWindow);
            trackStatusWindow.Show();
        }

        private void ApproveClaims_Click(object sender, RoutedEventArgs e)
        {
            ApproveClaimsWindow approveClaimsWindow = new ApproveClaimsWindow();
            approveClaimsWindow.Show();
        }

        private void UploadDocuments_Click(object sender, RoutedEventArgs e)
        {
            UploadDocumentsWindow uploadDocumentsWindow = new UploadDocumentsWindow();
            uploadDocumentsWindow.Show();
        }

        private void HRPanel_Click(object sender, RoutedEventArgs e)
        {
            HRWindow hrWindow = new HRWindow();
            hrWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
