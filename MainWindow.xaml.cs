using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft;
using Microsoft.Win32;

namespace Best_Task
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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.DefaultExt = ".txt";
            openFileDlg.Filter = "Text documents (.txt)|*.txt";
            openFileDlg.InitialDirectory = @"E:\Best";
            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                FilePath.Text = openFileDlg.FileName;
                FileContent.Text = File.ReadAllText(openFileDlg.FileName);
            }

            int LinesCount;

            LinesCount = CountFileLines(FilePath.Text);
  
            int LineNumber = 0;
            int[] LineThirdNumber = new int[LinesCount];

            foreach (string Line in File.ReadLines(FilePath.Text))
            {
                LineThirdNumber[LineNumber] = GetLineThirdNumber(Line); 
                LineNumber++;   
            }

            int Sum = 0;
            for (  int Index = 0; Index < LinesCount; Index++)
            {
                Sum += LineThirdNumber[Index];
            }
            MessageBox.Show("The Sum of Third Figures: " + Convert.ToString(Sum));


        }


        int CountFileLines ( string FilePath)
        {

            var lineCount = 0;
            using (var reader = File.OpenText(FilePath))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }

            return lineCount; 
        }


         int  GetLineThirdNumber( string Line)
        {
            string[] LineNumbers = Line.Split(';');
         //  MessageBox.Show(LineNumbers[2]);
            return Convert.ToInt32(LineNumbers[2]);

        }
    }
}
