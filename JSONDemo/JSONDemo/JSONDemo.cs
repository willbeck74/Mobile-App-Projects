using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSONDemo {
	public class Physicist {
		public string fullname;
		public string dateOfBirth;
		public School[] education;
		public int numChildren;
		public override string ToString() {
			string physicist = String.Format("Physicist: {0} ({1})", fullname, dateOfBirth.ToString());
			foreach (School s in education) {
				physicist += s.ToString() + " ";
			}
			return physicist;
		}
	}
	public class School {
		public string school;
		public string degree;
		public override string ToString() {
			return String.Format("({0} {1})", school, degree);
		}
	}

	public class Student {
		public string Name { get; set; }
		public int Age { get; set; }
		public override string ToString() {
			return string.Format("{0} ({1})", Name, Age);
		}
	}
	public class Course {
		public Student [] students;
		public Course() {
		}
		public Course(params Student [] S) {
			students = new Student[S.Length];
			int i = 0;
			foreach (Student s in S) {
				students[i++] = s;
			}
		}
		public override string ToString() {
			string result = "[";
			foreach (Student s in students) {
				result += "<" + s.ToString() + ">";
			}
			return result + "]";
		}
	}
	class JSONDemo {
		public static void Main(string[] args) {
			Console.WriteLine("========= PHYSICISTS ========");
			StreamReader input = new StreamReader("sample.txt");
			string response = input.ReadToEnd();

			JObject d = JObject.Parse(response);
			Console.WriteLine("Fullname: " + d.Property("fullname").Value);
			Console.WriteLine("Date of birth: " + (DateTime)d.Property("dateofbirth").Value);
			Console.WriteLine("education: " + d.Property("education").Value);

			Physicist p = JsonConvert.DeserializeObject<Physicist>(response);
			Console.WriteLine(p);
			/* OUTPUT
			 ========= PHYSICISTS ========
			Fullname: Albert Einstein
			Date of birth: 3/14/1879 12:00:00 AM
			education: [
			  {
				"school": "Federal polytechnic school",
				"degree": "BA"
			  },
			  {
				"school": " University of Zurich",
				"degree": "PhD"
			  }
			]
			Physicist: Albert Einstein (March 14, 1879)(Federal polytechnic school BA) (University of Zurich PhD)
 			*/
			Console.WriteLine("========= STUDENTS ========");

			Student student1 = new Student { Name = "Willie", Age = 18 };
			Student student2 = new Student { Name = "Fred", Age = 19 };
			Student student3 = new Student { Name = "Jenni", Age = 19 };

			Course course1 = new Course(student1, student2, student3);

			string student1Str = JsonConvert.SerializeObject(student1);
			Student student1Deserialized = JsonConvert.DeserializeObject<Student>(student1Str);

			string course1Str = JsonConvert.SerializeObject(course1);
			var definition = new { Name = "" };
			var obj = JsonConvert.DeserializeAnonymousType(student1Str, definition);

			Course course1Deserialized = JsonConvert.DeserializeObject<Course>(course1Str);

			String str = "ABC" + (char)5 + "DEF";
			var strSerialize = JsonConvert.SerializeObject(str);
			Console.WriteLine(strSerialize);

			Console.WriteLine("Student 1:");
			Console.WriteLine(student1);
			Console.WriteLine(student1Str);
			Console.WriteLine(student1Deserialized);
			Console.WriteLine("Course 1:");
			Console.WriteLine(course1);
			Console.WriteLine(course1Str);
			Console.WriteLine(course1Deserialized);
			/* OUTPUT
			========= STUDENTS ========
			Student 1:
			Willie (18)
			{"Name":"Willie","Age":18}
			Willie (18)

			Course 1:
			[<Willie (18)><Fred (19)><Jenni (19)>]
			{"students":[{"Name":"Willie","Age":18},{"Name":"Fred","Age":19},{"Name":"Jenni","Age":19}]}
			[<Willie (18)><Fred (19)><Jenni (19)>]
			*/
		}
	}
}
