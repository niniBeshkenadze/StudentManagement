using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    enum Grade
    {
        A = 90,
        B = 80,
        C = 70,
        D = 60,
        F= 0
    }
    internal class Student
    {
        private string _name;
        private string _email;
        private int _id;
        private int _age;
        private Grade _grade;
        public int Id
        {
            get => _id; set
            {
                if (value >= 0)
                {
                    _id = value;
                }
                else
                {
                    throw new ArgumentException("Id cannot be negative");
                }
              
            }
        }
        public string Name
        {
            get => _name; set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be empty");
                }
              
            }
        }
        public int Age
        {
            get => _age; set
            {
                if
                    (value >= 0) { _age = value; }
                else
                {
                    throw new ArgumentException("Age cannot be negative");
                }
              
            }
        }
        public Grade Grade
        {

            get => _grade;
            set => _grade = value;
        }
        public void SetGradeByScore(int score)
        {
               if (score >= 90) _grade = Grade.A;
               else if (score >= 80) _grade = Grade.B;
               else if (score >= 70) _grade = Grade.C;
               else if (score >= 60) _grade = Grade.D;
               else _grade = Grade.F;
        } 
             
        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Contains("@"))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Invalid email format");
                }
              
            }
        }

        public Student()
        {
            Id = 0;
            Name = string.Empty;
            Age = 0;
            Grade = Grade.F;
            Email = string.Empty;

        }
        public Student(int id, string name, int age, Grade grade, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            Grade = grade;
            this.Email= email;

        }
    }
}