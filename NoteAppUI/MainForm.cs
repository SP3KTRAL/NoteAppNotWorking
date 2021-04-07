using System;
using System.Linq;
using NoteApp;
using System.Windows.Forms;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список заметок
        /// </summary>
        Project _project = new Project();

        /// <summary>
        /// Список заметок выбранной категории
        /// </summary>
        Project _sortProject = new Project();

        public MainForm()
        {
            InitializeComponent();

            var catygories = Enum.GetValues(typeof(NoteCategory)).Cast<NoteCategory>().ToList();
            
            foreach (var catygory in catygories)
            {
                noteCategoryComboBox.Items.Add(catygory);
            }
            noteCategoryComboBox.Items.Insert(0, "All");

            noteCategoryComboBox.SelectedIndex = 0;

            string path = ProjectManager.DefaultPath + ProjectManager.FileName;

            _project = ProjectManager.Load(path);

            foreach (var note in _project.Notes)
            {
                titleNoteListBox.Items.Add(note.Title);
                _sortProject.Notes.Add(note);
            }

            SelectFirstItem();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Сохраняет заметки
        /// </summary>
        private void Save()
        {
            string path = ProjectManager.DefaultPath + ProjectManager.FileName;

            ProjectManager.Save(_project, path);
        }

        /// <summary>
        /// Создаёт заметку
        /// </summary>
        private void CreateNote()
        {
            Note note = new Note();
            NoteForm noteForm = new NoteForm
            {
                Note = note
            };
            if (noteForm.ShowDialog() == DialogResult.OK)
            {
                AddNote(noteForm.Note);
            }

            SelectFirstItem();

            Save();
        }


        /// <summary>
        /// Изменяет заметку
        /// </summary>
        /// <param name="note">Изменяемая заметка</param>
        private void EditNote(Note note)
        {
            NoteForm noteForm = new NoteForm();
            noteForm.Note = note;

            if (noteForm.ShowDialog() == DialogResult.OK)
            {
                Remove();

                AddNote(noteForm.Note);
            }

            SelectFirstItem();

            Save();
        }

        /// <summary>
        /// Выбирает первую заметку в списке
        /// </summary>
        private void SelectFirstItem()
        {
            if (_sortProject.Notes.Count != 0)
            {
                titleNoteListBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Удаляет заметку
        /// </summary>
        private void Remove()
        {
            Note selectNote = _sortProject.Notes[titleNoteListBox.SelectedIndex];
            int index = _project.Notes.IndexOf(selectNote);

            _project.Notes.RemoveAt(index);
            _sortProject.Notes.RemoveAt(titleNoteListBox.SelectedIndex);
            titleNoteListBox.Items.RemoveAt(titleNoteListBox.SelectedIndex);

            Save();
        }

        /// <summary>
        /// Добавляет заметку в список
        /// </summary>
        /// /// <param name="note">Добавляемая заметка</param>
        private void AddNote(Note note)
        {
            _project.Notes.Insert(0, note);

            if (noteCategoryComboBox.SelectedItem.ToString() == "All")
            {
                titleNoteListBox.Items.Insert(0, note.Title);
                _sortProject.Notes.Insert(0, note);
            }
            else if ((NoteCategory)noteCategoryComboBox.SelectedItem == note.NoteCategory)
            {
                titleNoteListBox.Items.Insert(0, note.Title);
                _sortProject.Notes.Insert(0, note);
            }
        }

        private void removeNoteButton_Click(object sender, EventArgs e)
        {
            Remove();

            SelectFirstItem();
        }

        private void editNoteButton_Click(object sender, EventArgs e)
        {
            if (titleNoteListBox.SelectedIndex != -1)
            {
                EditNote(_sortProject.Notes[titleNoteListBox.SelectedIndex]);
            }
            else
            {
                MessageBox.Show("Select a note to edit!");
            }
        }

        private void addNoteButton_Click(object sender, EventArgs e)
        {
            CreateNote();
        }

        private void noteCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            titleNoteListBox.Items.Clear();

            _sortProject.Notes.Clear();

            foreach (var note in _project.Notes)
            {
                if (noteCategoryComboBox.SelectedItem.ToString() == "All")
                {
                    titleNoteListBox.Items.Add(note.Title);
                    _sortProject.Notes.Add(note);
                }
                else if (note.NoteCategory == (NoteCategory) noteCategoryComboBox.SelectedItem)
                {
                    titleNoteListBox.Items.Add(note.Title);
                    _sortProject.Notes.Add(note);
                }
            }

            SelectFirstItem();
        }

        private void titleNoteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (titleNoteListBox.SelectedIndex == -1)
            {
                titleNoteLabel.Text = "";
                catrgoryNoteLabel.Text = "";
                createdNoteLabel.Text = "";
                modifiedNoteLabel.Text = "";
                textNoteRichTextBox.Text = "";
            }
            else
            {
                titleNoteLabel.Text = _sortProject.Notes[titleNoteListBox.SelectedIndex].Title;
                catrgoryNoteLabel.Text = _sortProject.Notes[titleNoteListBox.SelectedIndex].NoteCategory.ToString();
                createdNoteLabel.Text = _sortProject.Notes[titleNoteListBox.SelectedIndex].Created.ToLongDateString();
                modifiedNoteLabel.Text = _sortProject.Notes[titleNoteListBox.SelectedIndex].Modified.ToLongDateString();
                textNoteRichTextBox.Text = _sortProject.Notes[titleNoteListBox.SelectedIndex].NoteText;
            }
        }
    }
}
