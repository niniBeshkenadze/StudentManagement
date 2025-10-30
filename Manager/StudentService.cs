using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudentManagement.Manager
{
    internal class StudentService
    {
        private List<Student> students;
        private readonly string dataPath;
        private readonly XmlSerializer serializer;
        public StudentService()
        {
            students = new List<Student>();
            dataPath = "students.xml";
            serializer = new XmlSerializer(typeof(List<Student>));

        }
        public void AddStudent(Student student)
        {
            students.Add(student);

        }
        public static void IdGenerater(Student student, List<Student> students)
        {
            int maxId = students.Count > 0 ? students.Max(s => s.Id) : 0;
            student.Id = maxId + 1;
        }
        public List<Student> GetAllStudents()
        {
            return students;
        }
        public void SaveData()
        {
            using (var stream = new FileStream(dataPath, FileMode.Create))
            {
                serializer.Serialize(stream, students);
            }
        }
        public void LoadData()
        {
            if (File.Exists(dataPath))
            {
                using (var stream = new FileStream(dataPath, FileMode.Open))
                {
                    students = (List<Student>)serializer.Deserialize(stream);
                }
            }
        }
        public void ReadData()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
            }
        }

        public void DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        public void CreateStudent(string name, int age, Grade grade)
        {
            Student student = new Student();
            IdGenerater(student, students);
            student.Name = name;
            student.Age = age;
            student.Grade = grade;
            AddStudent(student);
        }
        public void UpdateStudent(int id, string name, int age, Grade grade)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.Name = name;
                student.Age = age;
                student.Grade = grade;
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}

