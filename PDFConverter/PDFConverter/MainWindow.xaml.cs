using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// work with windows system
using Microsoft.Win32;

// work with word documents
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;

// to read convert and work with pdf files
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;

// for theme
using Syncfusion.SfSkinManager;
using Syncfusion.Themes.FluentLight.WPF;

// to start a process we need the diagnostics namespace
using System.Diagnostics;

// to work with images
using System.Drawing;

// to save and read files
using System.IO;
using System.Windows;

namespace PDFConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? result = openFileDialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                // pathTextBox is the variable name from xaml textbox
                pathTextBox.Text = openFileDialog.FileName;
            }
        }


        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if(pathTextBox.Text == String.Empty)
            {
                MessageBox.Show("Please select a file");
                return;
            }

            switch (conversionDropDown.SelectedIndex)
            {
                case 0: // Convert DOC to PDF
                    ConvertDocToPDF(pathTextBox.Text);
                    break;
                default:
                    MessageBox.Show("Please select an option");
                    return;
            }
        }

        private void ConvertDocToPDF(string docPath)
        {
            WordDocument wordDocument = new WordDocument(docPath, FormatType.Automatic);
            DocToPDFConverter converter = new DocToPDFConverter();
            PdfDocument pdfDocument = converter.ConvertToPDF(wordDocument);

            // generate new file pdf name with previous filename and adding .pdf at the end
            string newPDFPath = docPath.Split('.')[0] + ".pdf";
            pdfDocument.Save(newPDFPath);
            pdfDocument.Close(true);
            wordDocument.Close();
            
        }

        private void OpenFolder(string folderPath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                Arguments = folderPath.Substring(0, folderPath.LastIndexOf('\\')),
                FileName = "explorer.exe"
            };
            Process.Start(startInfo);
        }
    }
}