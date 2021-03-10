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

        private void CreateNote()
        {
            Note note = new Note();
            NoteForm noteForm = new NoteForm();
            noteForm.Note = note;
            if (noteForm.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void categoryLabel_Click(object sender, EventArgs e)
        {

        }

        private void removeNoteButton_Click(object sender, EventArgs e)
        {

        }

        private void editNoteButton_Click(object sender, EventArgs e)
        {

        }

        private void addNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote();
        }

        private void createdNoteLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
