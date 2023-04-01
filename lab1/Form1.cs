using lab1.Models;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Student> students = new List<Student>();
        string filePath = "INFO.txt";
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            textBox1.Text="";
            students = Student.ReadStudentsFromFile(filePath);
            if (students.Count == 0)
            {
                textBox1.Text = "000";
            }
            while (i < students.Count)
            {
                textBox1.Text += students[i].ShowInfo();
                i++;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var stud = Student.RandomStudent();
            students.Add(stud);
            Student.SortList(students);
            Student.WriteStudentsToFIle(filePath, students);
            textBox10.Text=stud.ShowInfo();
        }
    }
}