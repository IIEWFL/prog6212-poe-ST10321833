using Microsoft.Win32;
using System.Windows;

namespace CMCS4
{
    public partial class UploadDocumentsWindow : Window
    {
        private string selectedFilePath;

        public UploadDocumentsWindow()
        {
            InitializeComponent();
        }

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|Word files (*.docx)|*.docx|Excel files (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName;
                FileNameTextBlock.Text = selectedFilePath;
            }
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Please select a file to upload.");
                return;
            }

         
            MessageBox.Show("File uploaded successfully!");
            this.Close();
        }
    }
}

