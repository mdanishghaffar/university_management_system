﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;

namespace uams.UI
{
    class StudentUI
    {
        public static void printStudents()
        {
            foreach (Student s in StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " got Admission in " + s.regDegree.getDegreeName());
                }
                else
                {
                    Console.WriteLine(s.name + " did not get Admission");

                }
            }
        }

        

        public static void viewStudentInDegree(string degName)
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    if (degName == s.regDegree.getDegreeName())
                    {
                        Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                    }
                }
            }
        }

        public static void viewRegisteredStudents()
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }

        public static Student takeInputForStudent()
        {
            string name;
            int age;
            double fscMarks;
            double ecatMarks;
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Console.Write("Enter Student Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Student Age: ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student FSc Marks: ");
            fscMarks = double.Parse(Console.ReadLine());
            Console.Write("Enter Student Ecat Marks: ");
            ecatMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs");
            DegreeProgramUI.viewDegreePrograms();

            Console.Write("Enter how many preferences to Enter: ");
            int Count = int.Parse(Console.ReadLine());
            for (int x = 0; x < Count; x++)
            {
                string degName = Console.ReadLine();
                bool flag = false;
                foreach (DegreeProgram dp in DegreeProgramDL.programList)
                {
                    if (degName == dp.getDegreeName() && !(preferences.Contains(dp)))
                    {
                        preferences.Add(dp);
                        flag = true;
                    }

                }
                if (flag == false)
                {
                    Console.WriteLine("Enter Valid Degree Program Name");
                    x--;
                }
            }
            Student s = new Student(name, age, fscMarks, ecatMarks, preferences);
            return s;

        }

        public static void calculateFeeForAll()
        {
            foreach (Student s in StudentDL.studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " has " + s.calculateFee() + " fees");
                }
            }
        }
    }
}
