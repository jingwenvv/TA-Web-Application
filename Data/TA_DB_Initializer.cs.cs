/*
Author: Jingwen Zhang
Partner: -Na-
Date: 2021/9/28
Course: CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Jingwen Zhang - This work may not be copied for use in Academic Coursework.

I, Jingwen Zhang, certify that I wrote this code from scratch and did not copy it in part or whole from
another source. Any references used in the completion of the assignment are cited in my README file.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA__Application.Models;

namespace TA__Application.Data
{

    public class TA_DB_Initializer
    {
        public Application[] applications;

        public Course[] courses;

        public Enrollment[] enrollments;

        public TA_DB_Initializer()
        {
            //ApplicationIntia();
            CourseIntia();
            EnrollmentInitiaAsync();
        }
      
        private void CourseIntia()
        {
            courses = new Course[]
            {
                new Course
                {
                    Title = "Intro Comp Programming",
                    Department = Department.CS,
                    CourseNumber = "1400",
                    ClassNumber = "17432",
                    Section="001",
                    Description = "This course is an introduction to the engineering and mathematical skills " +
                        "required to effectively program computers and is designed for students with no prior " +
                        "programming experience.",
                    ProfessorUNID = "dkopta",
                    ProfessorName = "KOPTA DANIEL",
                    DayOffered = DayOffered.M_W,
                    TimeStart = "01:25PM",
                    TimeEnd = "02:45PM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "ASB 220",
                    CreditHour = 4,
                    EnrollmentCap = 240,
                    Enrolled = 0,
                    Note = "This course needs 4 TAs."
                },
                new Course
                {
                    Title = "Object-Oriented Prog",
                    Department = Department.CS,
                    CourseNumber = "1410",
                    ClassNumber = "17442",
                    Section="001",
                    Description = "The second course required for students intending to major in computer science " +
                        "and computer engineering. Introduction to the engineering and mathematical skills required " +
                        "to effectively program computers, and to the range of issues confronted by computer scientists. " +
                        "Roles of procedural and data abstraction in decomposing programs into manageable pieces. " +
                        "Introduction to object-oriented programming. Extensive programming exercises " +
                        "that involve the application of elementary software engineering techniques.",
                    ProfessorUNID = "dejohnso",
                    ProfessorName = "DAVID E JOHNSON",
                    DayOffered = DayOffered.M_W_Fr,
                    TimeStart = "10:45AM",
                    TimeEnd = "11:35AM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "MEB 3225",
                    CreditHour = 4,
                    EnrollmentCap = 300,
                    Enrolled = 0,
                    Note = "This course needs 3 TAs."
                },
                new Course
                {
                    Title = "Object-Oriented Prog",
                    Department = Department.CS,
                    CourseNumber = "1420",
                    ClassNumber = "17442",
                    Section="001",
                    Description = "The second course required for students intending to major in computer science " +
                        "and computer engineering. Introduction to the engineering and mathematical skills required " +
                        "to effectively program computers, and to the range of issues confronted by computer scientists. " +
                        "Roles of procedural and data abstraction in decomposing programs into manageable pieces. " +
                        "Introduction to object-oriented programming. Extensive programming exercises " +
                        "that involve the application of elementary software engineering techniques.",
                    ProfessorUNID = "dejohnso",
                    ProfessorName = "DAVID E JOHNSON",
                    DayOffered = DayOffered.M_W_Fr,
                    TimeStart = "10:45AM",
                    TimeEnd = "11:35AM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "MEB 3225",
                    CreditHour = 4,
                    EnrollmentCap = 300,
                    Enrolled = 0,
                    Note = "This course needs 3 TAs."
                },
                new Course
                {
                    Title = "Discrete Structures",
                    Department = Department.CS,
                    CourseNumber = "2100",
                    ClassNumber = "8613",
                    Section="001",
                    Description = "Introduction to propositional logic, predicate logic, formal logical arguments, " +
                        "finite sets, functions, relations, inductive proofs, recurrence relations, graphs, probability, " +
                        "and their applications to Computer Science.",
                    ProfessorUNID = "pavpanchekha",
                    ProfessorName = "PAVEL PANCHEKHA",
                    DayOffered = DayOffered.Tu_Th,
                    TimeStart = "10:45AM",
                    TimeEnd = "12:05PM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "WEB L104",
                    CreditHour = 3,
                    EnrollmentCap = 210,
                    Enrolled = 0,
                    Note = "This course needs 1 TAs."
                },
                new Course
                {
                    Title = "Intro Alg & Data Struct",
                    Department = Department.CS,
                    CourseNumber = "2420",
                    ClassNumber = "5829",
                    Section="001",
                    Description = "This course provides an introduction to the problem of engineering computational efficiency into programs. " +
                        "Students will learn about classical algorithms (including sorting, searching, and graph traversal), " +
                        "data structures (including stacks, queues, linked lists, trees, hash tables, and graphs), " +
                        "and analysis of program space and time requirements. Students will complete extensive programming exercises " +
                        "that require the application of elementary techniques from software engineering.",
                    ProfessorUNID = "parker",
                    ProfessorName = "ERIN PARKER",
                    DayOffered = DayOffered.Tu_Th,
                    TimeStart = "12:25PM",
                    TimeEnd = "01:45PM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "GC 1900",
                    CreditHour = 4,
                    EnrollmentCap = 254,
                    Enrolled = 0,
                    Note = "This course needs 1 TAs."
                },
                new Course
                {
                    Title = "Software Practice",
                    Department = Department.CS,
                    CourseNumber = "3100",
                    ClassNumber = "9306",
                    Section="001",
                    Description = "Practical exposure to the process of creating large software systems, " +
                        "including requirements specifications, design, implementation, testing, and maintenance. " +
                        "Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), " +
                        "software engineering techniques (time management, code, and documentation standards, " +
                        "source code management, object-oriented analysis and design), and team development practice. " +
                        "Much of the work will be in groups and will involve modifying preexisting software systems.",
                    ProfessorUNID = "GERMAIN",
                    ProfessorName = "H JAMES DE ST GERMAIN",
                    DayOffered = DayOffered.Tu_Th,
                    TimeStart = "02:00PM",
                    TimeEnd = "03:20PM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "WEB L104",
                    CreditHour = 4,
                    EnrollmentCap = 225,
                    Enrolled = 0,
                    Note = "This course needs 5 TAs."
                },
                new Course
                {
                    Title = "Software Practice",
                    Department = Department.CS,
                    CourseNumber = "3200",
                    ClassNumber = "9306",
                    Section="001",
                    Description = "Practical exposure to the process of creating large software systems, " +
                        "including requirements specifications, design, implementation, testing, and maintenance. " +
                        "Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), " +
                        "software engineering techniques (time management, code, and documentation standards, " +
                        "source code management, object-oriented analysis and design), and team development practice. " +
                        "Much of the work will be in groups and will involve modifying preexisting software systems.",
                    ProfessorUNID = "GERMAIN",
                    ProfessorName = "H JAMES DE ST GERMAIN",
                    DayOffered = DayOffered.Tu_Th,
                    TimeStart = "02:00PM",
                    TimeEnd = "03:20PM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "WEB L104",
                    CreditHour = 4,
                    EnrollmentCap = 225,
                    Enrolled = 0,
                    Note = "This course needs 5 TAs."
                },
                new Course
                {
                    Title = "Software Practice",
                    Department = Department.CS,
                    CourseNumber = "3500",
                    ClassNumber = "9306",
                    Section="001",
                    Description = "Practical exposure to the process of creating large software systems, " +
                        "including requirements specifications, design, implementation, testing, and maintenance. " +
                        "Emphasis on software process, software tools (debuggers, profilers, source code repositories, test harnesses), " +
                        "software engineering techniques (time management, code, and documentation standards, " +
                        "source code management, object-oriented analysis and design), and team development practice. " +
                        "Much of the work will be in groups and will involve modifying preexisting software systems.",
                    ProfessorUNID = "GERMAIN",
                    ProfessorName = "H JAMES DE ST GERMAIN",
                    DayOffered = DayOffered.Tu_Th,
                    TimeStart = "02:00PM",
                    TimeEnd = "03:20PM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "WEB L104",
                    CreditHour = 4,
                    EnrollmentCap = 225,
                    Enrolled = 0,
                    Note = "This course needs 5 TAs."
                },
                new Course
                {
                    Title = "Software Practice II",
                    Department = Department.CS,
                    CourseNumber = "3505",
                    ClassNumber = "5835",
                    Section="001",
                    Description = "An in-depth study of traditional software development (using UML) from inception through implementation. " +
                        "The entire class is team-based, and will include a project that uses an agile process.",
                    ProfessorUNID = "dejohnso",
                    ProfessorName = "DAVID E JOHNSON",
                    DayOffered = DayOffered.Tu_Th,
                    TimeStart = "12:25PM",
                    TimeEnd = "01:45PM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "WEB L104",
                    CreditHour = 4,
                    EnrollmentCap = 170,
                    Enrolled = 0,
                    Note = "This course needs 4 TAs."
                },

                new Course
                {
                    Title = "Algorithms",
                    Department = Department.CS,
                    CourseNumber = "4150",
                    ClassNumber = "5868",
                    Section="001",
                    Description = "Study of algorithms, data structures, and complexity analysis beyond the introductory treatment from CS 2420. " +
                        "Balanced trees, heaps, hash tables, string matching, graph algorithms, external sorting and searching. " +
                        "Dynamic programming, exhaustive search. Space and time complexity, derivation and solution of recurrence relations, complexity hierarchies, " +
                        "reducibility, NP completeness. Laboratory practice.",
                    ProfessorUNID = "pajensen",
                    ProfessorName = "PETER A JENSEN",
                    DayOffered = DayOffered.Tu_Th,
                    TimeStart = "10:45AM",
                    TimeEnd = "12:05PM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "WEB L101",
                    CreditHour = 3,
                    EnrollmentCap = 280,
                    Enrolled = 0,
                    Note = "This course needs 2 TAs."
                },
                new Course
                {
                    Title = "Computer Systems",
                    Department = Department.CS,
                    CourseNumber = "4400",
                    ClassNumber = "10829",
                    Section="001",
                    Description = "Introduction to computer systems from a programmer's point of view. " +
                        "Machine level representations of programs, optimizing program performance, memory hierarchy, " +
                        "linking, exceptional control flow, measuring program performance, virtual memory, concurrent programming " +
                        "with threads, network programming.",
                    ProfessorUNID = "benjones",
                    ProfessorName = "BENJAMIN JAMES JONES",
                    DayOffered = DayOffered.M_W,
                    TimeStart = "11:50AM",
                    TimeEnd = "01:10PM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "HPR E 206",
                    CreditHour = 3,
                    EnrollmentCap = 180,
                    Enrolled = 0,
                    Note = "This course needs 4 TAs."
                },
                new Course
                {
                    Title = "Computer Organization",
                    Department = Department.CS,
                    CourseNumber = "4480",
                    ClassNumber = "9310",
                    Section="001",
                    Description = "An in-depth study of traditional software development (using UML) from inception through implementation. " +
                        "The entire class is team-based, and will include a project that uses an agile process.",
                    ProfessorUNID = "RAJEEV",
                    ProfessorName = "RAJEEV BALASUBRAMONIAN",
                    DayOffered = DayOffered.Tu_Th,
                    TimeStart = "09:10AM",
                    TimeEnd = "10:30AM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "WEB L104",
                    CreditHour = 4,
                    EnrollmentCap = 170,
                    Enrolled = 0,
                    Note = "This course needs 4 TAs."
                },
                new Course
                {
                    Title = "Senior Capstone Design",
                    Department = Department.CS,
                    CourseNumber = "4500",
                    ClassNumber = "10076",
                    Section="001",
                    Description = "During their last two semesters, senior Computer Science students form teams to develop significant software projects. " +
                        "This class is the first semester in the sequence. Seniors will work on team formation, project identification, project planning " +
                        "(including UI design, software architecture, testing methods, scheduling, etc.), and completion of a system prototype. " +
                        "This course will provide teams with time and guidance to effectively plan their projects, " +
                        "as well as emphasizing the written and oral communications necessary to succeed in industry. " +
                        "Projects formed in this course must be completed during the following semester in CS 4500. " +
                        "Students should have four or less CS electives/required courses left when signing up for this course and should be graduating during the following semester.",
                    ProfessorUNID = "gitpushoriginmaster",
                    ProfessorName = "CHRISTOPHER SCOTT BROWN",
                    DayOffered = DayOffered.M_W_Fr,
                    TimeStart = "10:45AM",
                    TimeEnd = "11:35AM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "WEB 1230",
                    CreditHour = 3,
                    EnrollmentCap = 80,
                    Enrolled = 0,
                    Note = "This course needs 5 TAs."
                },
                new Course
                {
                    Title = "Computer Systems",
                    Department = Department.CS,
                    CourseNumber = "4530",
                    ClassNumber = "10829",
                    Section="001",
                    Description = "Introduction to computer systems from a programmer's point of view. " +
                        "Machine level representations of programs, optimizing program performance, memory hierarchy, " +
                        "linking, exceptional control flow, measuring program performance, virtual memory, concurrent programming " +
                        "with threads, network programming.",
                    ProfessorUNID = "benjones",
                    ProfessorName = "BENJAMIN JAMES JONES",
                    DayOffered = DayOffered.M_W,
                    TimeStart = "11:50AM",
                    TimeEnd = "01:10PM",
                    SemesterOffered = SemesterOffered.Fall_Spring,
                    YearOffered = "2022",
                    Location = "HPR E 206",
                    CreditHour = 3,
                    EnrollmentCap = 180,
                    Enrolled = 0,
                    Note = "This course needs 4 TAs."
                }
            };
        }

        private void ApplicationIntia()
        {
            applications = new Application[]
            {

            new Application{FirstMidName="Arturo",LastName="Anand",UID="U0123456", PhoneNumber="801-123-4567",
                Address="201 Presidents' Cir, Salt Lake City, UT 84112", Degree=Degree.BS, Program=Models.Program.CE,
                GPA=3.5, PersonalStatement="-Na-", EnglishFluency=EnglishFluency.Native, Semesters=3,
                LinkedInURL="https://www.linkedin.com", Resume="-Na-", CreationDate=DateTime.Parse("2021-09-03"),
                ModificationDate=DateTime.Parse("2021-09-21")},
            new Application{FirstMidName="Yan",LastName="Li",UID="U0123456", PhoneNumber="801-123-4567",
                Address="201 Presidents' Cir, Salt Lake City, UT 84112", Degree=Degree.PHD, Program=Models.Program.CS,
                GPA=3.6, PersonalStatement="-Na-", EnglishFluency=EnglishFluency.Fluent, Semesters=5,
                LinkedInURL="https://www.linkedin.com", Resume="-Na-", CreationDate=DateTime.Parse("2021-09-04"),
                ModificationDate=DateTime.Parse("2021-09-21")},
            new Application{FirstMidName="Peggy",LastName="Justice",UID="U0123456", PhoneNumber="801-123-4567",
                Address="201 Presidents' Cir, Salt Lake City, UT 84112", Degree=Degree.MS, Program=Models.Program.ME,
                GPA=3.5, PersonalStatement="-Na-", EnglishFluency=EnglishFluency.Fluent, Semesters=2,
                LinkedInURL="https://www.linkedin.com", Resume="-Na-", CreationDate=DateTime.Parse("2021-09-05"),
                ModificationDate=DateTime.Parse("2021-09-21")},
            new Application{FirstMidName="Laura",LastName="Norman",UID="U0123456", PhoneNumber="801-123-4567",
                Address="201 Presidents' Cir, Salt Lake City, UT 84112", Degree=Degree.PHD, Program=Models.Program.CS,
                GPA=4.0, PersonalStatement="-Na-", EnglishFluency=EnglishFluency.Native, Semesters=6,
                LinkedInURL="https://www.linkedin.com", Resume="-Na-", CreationDate=DateTime.Parse("2021-09-06"),
                ModificationDate=DateTime.Parse("2021-09-21")}
                            };
        }

        private void EnrollmentInitiaAsync()
        {
            enrollments = new Enrollment[]
            {
                new Enrollment
                {
                    course = "CS 1400",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,0,1,1,1,43,44,57,65,84,85,90,91,94,96,98,99,99,101,102,105,109,110,110,110,113")
                },
                new Enrollment
                {
                    course = "CS 1410",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,3,3,3,3,127,141,167,173,189,193,195,201,207,213,217,223,223,222,224,229,231,233,235,235,235")
                },
                new Enrollment
                {
                    course = "CS 1420",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,0,0,0,1,44,52,61,66,72,75,76,76,81,80,80,85,85,88,89,91,94,94,94,95,95")
                },
                new Enrollment
                {
                    course = "CS 2100",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,4,5,5,5,45,51,83,91,108,110,114,118,125,128,129,130,131,132,134,138,143,143,144,146,147")
                },
                new Enrollment
                {
                    course = "CS 2420",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,6,7,7,7,156,166,201,210,233,237,243,249,254,258,261,265,266,268,269,270,276,277,278,281,284")
                },new Enrollment
                {
                    course = "CS 3100",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,1,1,1,1,42,47,60,63,65,65,65,68,70,70,70,71,73,74,75,76,76,76,76,76,78")
                },
                new Enrollment
                {
                    course = "CS 3200",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,0,0,0,0,30,40,50,55,57,58,59,61,64,66,68,68,68,68,69,70,71,71,71,71,71")
                },
                new Enrollment
                {
                    course = "CS 3500",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,0,0,0,0,10,13,25,31,36,37,38,38,39,40,41,41,41,41,42,44,45,45,45,45,46")
                },
                new Enrollment
                {
                    course = "CS 4150",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,0,0,0,0,77,83,111,119,122,125,127,131,135,140,141,141,142,142,142,143,144,144,143,143,146")
                },
                new Enrollment
                {
                    course = "CS 4400",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,3,3,3,3,78,95,113,117,121,121,122,126,130,131,133,134,133,132,133,136,136,137,137,136,140")
                },new Enrollment
                {
                    course = "CS 4480",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,0,0,0,0,52,66,81,87,91,90,92,99,99,103,106,106,106,106,110,111,112,112,112,112,113")
                },
                new Enrollment
                {
                    course = "CS 4500",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,0,0,0,0,43,52,58,60,63,64,65,66,68,71,71,71,71,71,72,72,75,75,76,77,78")
                },
                new Enrollment
                {
                    course = "CS 4530",
                    dateEnrollString = GenerateDateEnrollString("0,0,0,0,0,0,0,0,77,86,100,107,108,112,113,117,122,124,125,125,125,125,125,125,125,125,125,125,125")
                }
            };
        }

        private static string GenerateDateEnrollString(string v)
        {
            string[] tabs = v.Split(",");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= tabs.Length - 1; i++)
            {
                if (i == tabs.Length - 1)
                {
                    sb.Append("11/" + (i + 1) + "." + tabs[i]);
                }
                else if (i < 10)
                {
                    sb.Append("11/0" + (i + 1) + "." + tabs[i] + ",");
                }
                else
                {
                    sb.Append("11/" + (i + 1) + "." + tabs[i] + ",");
                }
            }
            return sb.ToString();
        }

    }
}
