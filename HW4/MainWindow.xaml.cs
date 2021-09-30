//******************************************************
// File: MainWindow.xaml.cs
//
// Purpose: Contains the class definition for MainWindow:Window.
//          Contains information for reading in course and professor
//          data, finding course and professor data,
//          and populating textboxes and listview
//
// Written By: Matthew Edwards
//
// Compiler: Visual Studio 2015
//
//******************************************************

using System;
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
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HW4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CourseCollection cc = new CourseCollection();
        ProfessorCollection pc = new ProfessorCollection();

        //****************************************************
        // Method: MainWindow
        //
        // Purpose: Constructor for initializing the main window
        //****************************************************
        public MainWindow()
        {
            InitializeComponent();
        }

        //****************************************************
        // Method: buttonOpenCourseCollection_Click
        //
        // Purpose: Opens an OpenFileDialog and receives course
        //          data from a JSON file
        //****************************************************
        private void buttonOpenCourseCollection_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openCourses = new OpenFileDialog();
            //Sets initial directory to current working directory
            openCourses.InitialDirectory = Directory.GetCurrentDirectory();
            //Filters for JSON files only
            openCourses.Filter = "JSON files (*.json)|*.json";
            openCourses.Title = "Open Course Collection from JSON";
      
            //Opens the dialog and runs if open is clicked
            if (openCourses.ShowDialog() != DialogResult.HasValue)
            {
                //Sets filename textbox to the chosen filename
                textBoxCourseFilename.Text = openCourses.FileName;

                //Clears all text boxes
                textBoxCourseDataId.Clear();
                textBoxCourseDataDesignator.Clear();
                textBoxCourseDataNumber.Clear();
                textBoxCourseDataTitle.Clear();
                textBoxCourseDataCredits.Clear();
                textBoxCourseDataDescription.Clear();
                textBoxFindCourseId.Clear();
                textBoxFindCourseDesignator.Clear();
                textBoxFindCourseNumber.Clear();

                FileStream reader;
                DataContractJsonSerializer inputJSON;
                //Initializes filestream for reading
                reader = new FileStream(openCourses.FileName, FileMode.Open, FileAccess.Read);
                //Initializes JsonSerializer
                inputJSON = new DataContractJsonSerializer(typeof(CourseCollection));
                //Initializes course collection object to read in file
                cc = (CourseCollection)inputJSON.ReadObject(reader);
                reader.Close();
            }
        }

        //****************************************************
        // Method: buttonFindCourseId_Click
        //
        // Purpose: Uses find method to find and display a course
        //          using course id
        //****************************************************
        private void buttonFindCourseId_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(textBoxFindCourseId.Text);
                //If find returns a course it will load the text boxes
                if (cc.Find(ID) != null)
                {
                    textBoxCourseDataId.Text = Convert.ToString(cc.Find(ID).ID);
                    textBoxCourseDataDesignator.Text = cc.Find(ID).Designator;
                    textBoxCourseDataNumber.Text = cc.Find(ID).Number;
                    textBoxCourseDataTitle.Text = cc.Find(ID).Title;
                    textBoxCourseDataCredits.Text = Convert.ToString(cc.Find(ID).Credits);
                    textBoxCourseDataDescription.Text = cc.Find(ID).Description;
                }
                else
                {
                    MessageBox.Show("Course not found.");
                }
            }
            catch
            {
                MessageBox.Show("Invalid entry.");
            }

        }

        //****************************************************
        // Method: buttonFindDesignatorNumber_Click
        //
        // Purpose: Uses find method to find a display a course
        //          using designator and number
        //****************************************************
        private void buttonFindDesignatorNumber_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string des = textBoxFindCourseDesignator.Text;
                string num = textBoxFindCourseNumber.Text;
                //If find returns a course it will load the text boxes
                if (cc.Find(des, num) != null)
                {
                    textBoxCourseDataId.Text = Convert.ToString(cc.Find(des, num).ID);
                    textBoxCourseDataDesignator.Text = cc.Find(des, num).Designator;
                    textBoxCourseDataNumber.Text = cc.Find(des, num).Number;
                    textBoxCourseDataTitle.Text = cc.Find(des, num).Title;
                    textBoxCourseDataCredits.Text = Convert.ToString(cc.Find(des, num).Credits);
                    textBoxCourseDataDescription.Text = cc.Find(des, num).Description;
                }
                else
                {
                    MessageBox.Show("Course not found.");
                }
            }
            catch
            {
                MessageBox.Show("Invalid entry.");
            }
        }

        //****************************************************
        // Method: buttonOpenProfessorCollection_Click
        //
        // Purpose: Opens an OpenFileDialog and receives professor
        //          data from a JSON file
        //****************************************************
        private void buttonOpenProfessorCollection_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openProfessors = new OpenFileDialog();
            //Sets initial directory to current working directory
            openProfessors.InitialDirectory = Directory.GetCurrentDirectory();
            //Filters for JSON files only
            openProfessors.Filter = "JSON files (*.json)|*.json";
            openProfessors.Title = "Open Professor Collection from JSON";

            //Opens the dialog and runs if open is clicked
            if (openProfessors.ShowDialog() != DialogResult.HasValue)
            {
                //Sets filename textbox to chosen filename
                textBoxProfessorFilename.Text = openProfessors.FileName;

                FileStream reader;
                DataContractJsonSerializer inputJSON;
                //Initializes filestream for reading
                reader = new FileStream(openProfessors.FileName, FileMode.Open, FileAccess.Read);
                //Initializes JsonSerializer
                inputJSON = new DataContractJsonSerializer(typeof(ProfessorCollection));
                //Initializes course collection object to read in file
                pc = (ProfessorCollection)inputJSON.ReadObject(reader);
                reader.Close();

                try
                {
                    //Loads listview with professor data
                    foreach (Professor p in pc.Professors)
                    {
                        listViewProfessors.Items.Add(p);
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid file.");
                }
            }
        }
    }
}
