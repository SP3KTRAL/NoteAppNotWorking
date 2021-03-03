using System;
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
            note.Title = "Test note";
            note.NoteCategory = NoteCategory.Other;
            note.NoteText = "13456789 qwer екуц !№;";
            note.Modified = DateTime.Now;

            Project project = new Project();
            project.Notes.Add(note);

            ProjectManager.Save(project);
        }
    }
}
