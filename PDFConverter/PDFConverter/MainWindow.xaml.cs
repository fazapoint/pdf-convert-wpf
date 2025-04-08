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
    }
}