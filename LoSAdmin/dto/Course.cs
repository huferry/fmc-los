using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web;

namespace LoSAdmin.dto
{
    [DataContract]
	public class Course
	{		
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public Meeting[] Meetings { get; set; }

		[DataMember]
		public Student[] Students { get; set; }

		[DataMember]
		public string ReportDate { get; set; }

		public static string ExportToJson(Los.Core.Course[] courses)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer (typeof(Course[]));

			var stream = new MemoryStream ();

			var dtoCourses = courses.Select (c => Import (c)).ToArray ();

			serializer.WriteObject (stream, dtoCourses);
			stream.Seek (0, 0);
			var reader = new StreamReader (stream);

			return reader.ReadToEnd ();
		}

		public static Course Import(Los.Core.Course course)
		{
			var students = course
				.GetStudents ()
				.Select (s => 
					new Student {
						Id = s.GetHashCode(),
						Name = HttpUtility.HtmlEncode( string.Format("{0} {1}", s.Firstname, s.Surname) ),
						System = course.GetStudentStatus(s).System ?? 0
					})
				.OrderBy(s => s.Name)
				.ToArray();

			var meetings = Los.Core.DayAttendance
				.GetByCourse (course)
				.GroupBy (a => a.MeetingDate.Date)
				.Select(m => Meeting.Import(m.Key, students, m.ToArray()))
				.OrderBy(m => m.Date);

			return new Course {
				Name = course.Name,
				Students = students,
				Meetings = meetings.ToArray(),
				ReportDate = DateTime.Now.ToString("F")
			};
		}

	}

	[DataContract]
	public class Student
	{
		[DataMember]
		public int Id { get; set; }
		
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int System { get; set; }
	}

	[DataContract]
	public class Meeting
	{
		[DataMember]
		public string Date { get; set; }

		[DataMember]
		public IDictionary<int, string> Statuses { get; set; } 

		internal static Meeting Import(DateTime date, Student[] students, Los.Core.DayAttendance[] attends)
		{
			var statuses = new Dictionary<int, string> ();

			foreach (Student student in students) {
				var attd = attends.FirstOrDefault (a => a.Student.GetHashCode ().Equals (student.Id));

				var status = attd == null ? Los.Core.AttendanceStatus.Unknown : attd.AttendanceStatus;

				switch (status) {
				case Los.Core.AttendanceStatus.Present:
					statuses.Add(student.Id, "1_present");
						break;
				case Los.Core.AttendanceStatus.Ill:
					statuses.Add(student.Id, "0_ill");
					break;
				case Los.Core.AttendanceStatus.Leave:
					statuses.Add(student.Id, "0_leave");
					break;
				default:
					statuses.Add (student.Id, "0_unknown");
					break;
				}
			}

			return new Meeting {
				Date = date.ToString("yyyy-MM-dd"),
				Statuses = statuses
			};
		}
	}

	[DataContract]
	public enum Status { Present, Ill, Leave, Unknown }
}

