/*
 * Author: Mahmoud.borham.technology@gmail.com
 * Phone/whatsapp: +20 1000317287
 * Date: June 03, 2022
 * Version: 1.0
 */

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

        /// <summary>
        /// When pushing the button you should be asked to select a text file.
        /// Now you can select an existing file. 
        /// After selecting a file, the file path will be shown in the text field.
        /// After that the file should be read line by line. The file has this structure:
        ///1;10;15;11
        ///13;156;12;176
        ///41;16;321;41
        /// 51;67;34;1
        /// After reading the file it should be looped over all read rows automatically.
        /// A separate method should be called in the loop with one row as parameter.
        /// In this method the third number of the row should be taken and be returned.
        /// The returned values should be added to a list.
        /// After all rows are processed the values should be taken from the list and added up.
        /// The result should be shown in a message box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //Start the logic ( task description is in the summary section ) once the browse button is clicked.
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {

            // A dialogue box to browse and select a text file.
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.DefaultExt = ".txt";
            openFileDlg.Filter = "Text documents (.txt)|*.txt";
            /* Below has been the default directory in my device.
            However, it may be commented, created or modified if needed. */
            openFileDlg.InitialDirectory = @"E:\Best";
            Nullable<bool> result = openFileDlg.ShowDialog();
            //If the file could be opened, then print its path in the text box and do the required operations.
            if (result == true)
            {
                //Read the opened file and display the content in a text block.
                FilePath.Text = openFileDlg.FileName;
                FileContent.Text = File.ReadAllText(openFileDlg.FileName);

                //Count the number of file's line and store their count.
                int LinesCount;
                LinesCount = CountFileLines(FilePath.Text);

                //For each line in the file call a method that extract the third figure of the line.
                //Store the selected value in an array of integers.
                int LineNumber = 0;
                int[] LineThirdNumber = new int[LinesCount];
                foreach (string Line in File.ReadLines(FilePath.Text))
                {
                    LineThirdNumber[LineNumber] = GetLineThirdNumber(Line);
                    LineNumber++;
                };

                //create a loop to sum the third figure of each line of the file.
                int Sum = 0;
                for (int Index = 0; Index < LinesCount; Index++)
                {
                    Sum += LineThirdNumber[Index];
                };

                // Display the count of the third figure in a message box.
                MessageBox.Show("The Sum of Third Figures: " + Convert.ToString(Sum));
            };
        }

        // The method is used to count the lines of the selected file.
        int CountFileLines(string FilePath)
        {
            var lineCount = 0;
            using (var reader = File.OpenText(FilePath))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                };
            };
            return lineCount;
        }

        //The method is used to return the third figure of each line.
         int  GetLineThirdNumber( string Line)
        {
            string[] LineNumbers = Line.Split(';');
            return Convert.ToInt32(LineNumbers[2]);
        }
    };
}