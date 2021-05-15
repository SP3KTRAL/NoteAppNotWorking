using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class ProjectTest
    {
        [Test(Description = "Позитивный тест Project")]
        public void TestProject_CorrectValue()
        {
            var expected = new Note();
            expected.Title = "Домашка";
            expected.NoteCategory = NoteCategory.Documents;
            expected.NoteText = "Параграф №16, задачи №16.2, 16.3(а,б).";
            var note = expected;
            var actual = note;

            Assert.AreEqual(expected, actual, "Project возвращает или заполняет неправильный проект");
        }
    }
}
