﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Lab9
{
    public class Department
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id,2}), {Name,11}";
        }

    }
    
    public class Topic
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Topic(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => $"{Id,2}), {Name,11}";
    }

    public enum Gender
    {
        Female,
        Male
    }

    public class Student
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public int DepartmentId { get; set; }

        public List<string> Topics { get; set; }
        public Student(int id, int index, string name, Gender gender, bool active,
            int departmentId, List<string> topics)
        {
            Id = id;
            Index = index;
            Name = name;
            Gender = gender;
            Active = active;
            DepartmentId = departmentId;
            Topics = topics;
        }

        public override string ToString()
        {
            var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}, topics: ";
            foreach (var str in Topics)
                result += str + ", ";
            return result;
        }
    }
    
    public class StudentWithTopics
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public int DepartmentId { get; set; }

        public List<Topic> Topics { get; set; }
        public StudentWithTopics(int id, int index, string name, Gender gender, bool active,
            int departmentId, List<Topic> topics)
        {
            Id = id;
            Index = index;
            Name = name;
            Gender = gender;
            Active = active;
            DepartmentId = departmentId;
            Topics = topics;
        }

        public override string ToString()
        {
            var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2},\n --- topics: ";
            return Topics.Aggregate(result, (current, str) => $"{current}\n --- {str}, ");
        }
    }
    public static class Generator
    {
        public static int[] GenerateIntsEasy()
        {
            return new[] { 5, 3, 9, 7, 1, 2, 6, 7, 8 };
        }

        public static int[] GenerateIntsMany()
        {
            var result = new int[10000];
            Random random = new Random();
            for (int i = 0; i < result.Length; i++)
                result[i] = random.Next(1000);
            return result;
        }

        public static List<string> GenerateStringsEasy()
        {
            return new List<string>
            {
                "Nowak",
                "Kowalski",
                "Schmidt",
                "Newman",
                "Bandingo",
                "Miniwiliger"
            };
        }
        public static List<Student> GenerateStudentsEasy()
        {
            return new List<Student>
            {
            new Student(1,12345,"Nowak", Gender.Female,true,1,
                    new List<string>{"C#","PHP","algorithms"}),
            new Student(2, 13235, "Kowalski", Gender.Male, true,1,
                    new List<string>{"C#","C++","fuzzy logic"}),
            new Student(3, 13444, "Schmidt", Gender.Male, false,2,
                    new List<string>{"Basic","Java"}),
            new Student(4, 14000, "Newman", Gender.Female, false,3,
                    new List<string>{"JavaScript","neural networks"}),
            new Student(5, 14001, "Bandingo", Gender.Male, true,3,
                    new List<string>{"Java","C#"}),
            new Student(6, 14100, "Miniwiliger", Gender.Male, true,2,
                    new List<string>{"algorithms","web programming"}),
            new Student(11,22345,"Nowak", Gender.Female,true,2,
                    new List<string>{"C#","PHP","algorithms"}),
            new Student(12, 23235, "Nowak", Gender.Male, true,1,
                    new List<string>{"C#","C++","fuzzy logic"}),
            new Student(13, 23444, "Schmidt", Gender.Male, false,1,
                    new List<string>{"Basic","Java"}),
            new Student(14, 24000, "Newman", Gender.Female, false,1,
                    new List<string>{"JavaScript","neural networks"}),
            new Student(15, 24001, "Bandingo", Gender.Male, true,3,
                    new List<string>{"Java","C#"}),
            new Student(16, 24100, "Bandingo", Gender.Male, true,2,
                    new List<string>{"algorithms","web programming"}),
            };
        }

        public static List<Department> GenerateDepartmentsEasy()
        {
            return new List<Department>
            {
            new Department(1,"Computer Science"),
            new Department(2,"Electronics"),
            new Department(3,"Mathematics"),
            new Department(4,"Mechanics")
            };
        }

    }

    static class Program
    {
        static void zad1()
        {
            // var path = Console.ReadLine();
            var path = "D:/Scripts/dotnet-pwr/Lab9/big.txt";
            var words = File.ReadAllText(path).Split();

            var selection =
                from word in words
                let matches = new Regex("^[a-zA-Z]+$").Matches(word)
                where matches.Count > 0
                let w = word.ToLower()
                group w by w into g
                orderby g.Count() descending
                select new
                {
                    Text = g.Key,
                    Count = g.Count(),
                };

            selection.Take(10).ToList().ForEach(Console.WriteLine);
        }
        static void zad2(int n)
        {
            var students = Generator.GenerateStudentsEasy();
            var studentsGrouped =
                from pair in (
                    from student in students
                    orderby student.Name, student.Index
                    select student
                ).Select((s, index) => (s, index))
                group pair by pair.index / n
                into g
                select (g.Key, Students: g.Select(pair => pair.s));
            foreach ((int key, var enumerable) in studentsGrouped)
            {
                Console.WriteLine(key);
                enumerable.ToList().ForEach(Console.WriteLine);
            }
        }

        static void zad3()
        {
            var students = Generator.GenerateStudentsEasy();
            var selection =
                from student in students
                from topic in student.Topics
                group topic by topic into g
                orderby g.Count() descending 
                select new
                {
                    g.Key,
                    Count = g.Count()
                };
            var genderedSelection =
                from student in students
                group student by student.Gender
                into genderGrouping
                select new
                {
                    genderGrouping.Key,
                    TopicGroup = from student in genderGrouping
                        from topic in student.Topics
                        group topic by topic
                        into g
                        orderby g.Count() descending
                        select new
                        {
                            g.Key,
                            Count = g.Count()
                        }
                };
                
            selection.ToList().ForEach(Console.WriteLine);
            foreach (var group in genderedSelection)
            {
                Console.WriteLine(group.Key);
                group.TopicGroup.ToList().ForEach(Console.WriteLine);
            }
        }

        static void zad4()
        {
            var students = Generator.GenerateStudentsEasy();
            var topicsStrings =
                from student in students
                from topic in student.Topics
                select topic;
            var topicStringsDistinct = topicsStrings.Distinct().ToList();
            var studentsWithTopics =
                from student in students
                select new StudentWithTopics(student.Id, student.Index, student.Name, student.Gender, student.Active,
                    student.DepartmentId,
                    (from topic in student.Topics
                    select new Topic(topicStringsDistinct.FindIndex(s => s == topic), topic)).ToList()
                );
            studentsWithTopics.ToList().ForEach(Console.WriteLine);
        }

        static void zad5()
        {
            typeof(Program).GetMethod("zad2", BindingFlags.NonPublic | BindingFlags.Static)?.Invoke(null, new object[]{ 3 });
        }

        static void Main(string[] args)
        {
            // zad1();
            // zad2(5);
            // zad3();
            // zad4();
            zad5();
        }
    }
}
