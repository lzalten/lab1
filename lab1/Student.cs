using System;
using System.IO;
class Student
{
    private string name;
    private string secName;
    private int course;
    private int group;
    private int[] results;

    public Student(string name, string secName, int course, int group, int[] results)
    {
        this.name = name;
        this.secName = secName;
        this.course = course;
        this.group = group;
        this.results = results;
    }

    public string GetName()
    {
        return this.name;
    }
    public string GetSecName()
    {
        return this.secName;
    }
    public int GetCourse()
    {
        return this.course;
    }
    public int GetGroup()
    {
        return this.group;
    }
    public int[] GetResults()
    {
        return this.results;
    }
    public String ShowInfo()
    {
        return $"name : {name}\r\nsecName : {secName}\r\ncourse : {course}\r\ngroup : {group}\r\nresults : {results[0]} {results[1]} {results[2]} {results[3]}\r\n";
    }
    static public Student RandomStudent()
    {
        Random rand = new Random();
        string[] names = { "Bob", "John", "Carl", "Sam", "Ben" };
        string[] secNames = { "Marley", "Weak", "Shelby", "Addam", "Bradley", "Collin" };
        string tname = names[rand.Next(5)];
        string tsname = secNames[rand.Next(6)];
        int tcourse = rand.Next(4) + 1;
        int tgroup = rand.Next(4) + 1;
        int[] tres = { rand.Next(5) + 1, rand.Next(5) + 1, rand.Next(5) + 1, rand.Next(5) + 1 };
        return new Student(tname, tsname, tcourse, tgroup, tres);
    }
    static public void SortList(List<Student> students)
    {
        students.Sort((x, y) =>
        {
            if (x.course != y.course)
            {
                return x.course.CompareTo(y.course); // сначала сортируем по полю course
            }
            else
            {
                int xCount = x.results.Count(r => r == 5); // считаем количество элементов в массиве results равных 5
                int yCount = y.results.Count(r => r == 5);
                return yCount.CompareTo(xCount); // затем сортируем по количеству элементов равных 5 (в обратном порядке)
            }
        });
    }
    static public void WriteStudentsToFIle(string path, List<Student> students)
    {
        StreamWriter writer = new StreamWriter(path, false);
        int[] reses;
        foreach (Student i in students)
        {
            reses = i.GetResults();
            writer.WriteLine($"{i.GetName()},{i.GetSecName()},{i.GetCourse()},{i.GetGroup()},{reses[0]};{reses[1]};{reses[2]};{reses[3]}");
        }
        writer.Close();
    }
    static public List<Student> ReadStudentsFromFile(string path)
    {

        List<Student> students = new List<Student>();
        StreamReader reader = new StreamReader(path);
        while (reader.Peek() >= 0)
        {
            string line = reader.ReadLine();
            string[] parts = line.Split(',');
            string[] tresults = parts[4].Split(';');
            int[] results = { 0, 0, 0, 0 };

            for (int i = 0; i < 4; i++)
            {
                results[i] = Convert.ToInt32(tresults[i]);
            }
            Student student = new Student(parts[0], parts[1], Convert.ToInt32(parts[2]), Convert.ToInt32(parts[3]), results);
            students.Add(student);
        }
        reader.Close();
        return students;
        //return students;
    }
}