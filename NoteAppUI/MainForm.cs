using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApp;
using System.Windows.Forms;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Note note = new Note();
            note.Titles = "Test note";
            note.NoteCategory = NoteCategory.Sundry;
            note.NoteText = "13456789 qwer екуц !№;";
            note.Modified = DateTime.Now;

            Project project = new Project();
            project.Notes.Add(note);

            ProjectManager.Save(project);
        }
    }
}
