using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NoteApp;
using ArgumentException = System.ArgumentException;


namespace NoteAppUI
{
    /// <summary>
    /// форма для создания и изменения заметок
    /// </summary>
    public partial class NoteForm : Form
    {
        /// <summary>
        /// перекрашивает название в зависимости от наличия ошибки
        /// </summary>
        private string _errorText = string.Empty;

        public NoteForm()
        {
            InitializeComponent();

            var catygories = Enum.GetValues(typeof(NoteCategory)).Cast<NoteCategory>().ToList();

            foreach (var catygory in catygories)
            {
                categoryComboBox.Items.Add(catygory);
            }
        }

        /// <summary>
        /// хранит информацию о добавленной/изменённой заметки
        /// </summary>
        private Note _note;

        public Note Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = (Note) value.Clone();
                if (_note.Title == null)
                {
                    _note.Title = titleTextBox.Text;
                }
                titleTextBox.Text = _note.Title; 
                categoryComboBox.SelectedItem = _note.NoteCategory;
                createdNoteLabel.Text = _note.Created.ToLongDateString();
                modifiedNoteLabel.Text = _note.Modified.ToLongDateString();
                noteTextBox.Text = _note.NoteText;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            
            if (_errorText != string.Empty)
            {
                MessageBox.Show(_errorText);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// перекрашивает название в зависимости от наличия ошибки
        /// </summary>
        private void SearchError()
        {
            if (_errorText == string.Empty)
            {
                titleTextBox.BackColor = Color.White;
            }
            else
            {
                titleTextBox.BackColor = Color.Red;
            }
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _note.Title = titleTextBox.Text;
                _errorText = string.Empty;
            }
            catch (ArgumentException exception)
            {
                _errorText = exception.Message;
            }
            SearchError();
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _note.NoteCategory = (NoteCategory)categoryComboBox.SelectedItem;
        }

        private void noteTextBox_TextChanged(object sender, EventArgs e)
        {
            _note.NoteText = noteTextBox.Text;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
