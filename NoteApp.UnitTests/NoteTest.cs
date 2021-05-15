using System;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class NoteTest
    {
        private Note _note;

        [SetUp]
        public void InitNote()
        {
            _note = new Note();
        }

        [Test(Description = "Позитивный тест геттера Title")]
        public void TestTitleGet_CorrectValue()
        {
            var expected = "Домашка";
            _note.Title = expected;
            var actual = _note.Title;

            Assert.AreEqual(expected, actual, "Геттер Title возвращает неправильную фамилию");
        }

        [Test(Description = "Присвоение пустой строки в качестве названия")]
        public void TestTitleSet_EmptyString()
        {
            var wrongTitle = string.Empty;
            _note.Title = wrongTitle;
            var actual = "Untitle";

            Assert.AreEqual(_note.Title, actual, "Cеттер Title неправильно заполняет название");
        }

        [Test(Description = "Присвоение неправильного названия больше 50 символов")]
        public void TestTitleSet_Longer50Symbols()
        {
            var wrongTitle = "Домашка-Домашка-Домашка-Домашка-Домашка-Домашка-Домашка";
            
            Assert.Throws<ArgumentException>(
                () => { _note.Title = wrongTitle;},
                "Должно возникать исключение, если название длиннее 50 символов");
        }

        [Test(Description = "Позитивный тест NoteCategory")]
        public void TestNoteCategoryGet_CorrectValue()
        {
            var expected = NoteCategory.Other;
            _note.NoteCategory = expected;
            var actual = _note.NoteCategory;

            Assert.AreEqual(expected, actual, "NoteCategory возвращает неправильную категорию");
        }

        [Test(Description = "Позитивный тест NoteText")]
        public void TestNoteTextGet_CorrectValue()
        {
            var expected = "Параграф №16, задачи №16.2, 16.3(а,б).";
            _note.NoteText = expected;
            var actual = _note.NoteText;

            Assert.AreEqual(expected, actual, "NoteText возвращает неправильный текст");
        }

        [Test(Description = "Позитивный тест геттера Created")]
        public void TestCreatedGet_CorrectValue()
        {
            var actualCreated = _note.Created;

            Assert.AreEqual(actualCreated, _note.Created, "Геттер Created возвращает неправильное время");
        }

        [Test(Description = "Позитивный тест геттера Modified")]
        public void TestModifiedGet_CorrectValue()
        {
            var expected = DateTime.Now;
            _note.Modified = expected;
            var actual = _note.Modified;

            Assert.AreEqual(expected, actual, "Геттер Modified возвращает неправильное время");
        }

        [Test(Description = "Присвоение категории Modified")]
        public void TestModifiedSet_CorrectValue()
        {
            var expected = DateTime.Now;
            _note.Modified = expected;
            var actual = _note.Modified;

            Assert.AreEqual(expected, actual, "Сеттер NoteCategory заполняет неправильное время");
        }
    }
}