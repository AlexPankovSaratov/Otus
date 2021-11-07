using PostgreSQLforOtus.Config;
using PostgreSQLforOtus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PostgreSQLforOtus
{
	class Program
	{
		static void Main(string[] args)
		{
			DbManager dbManager = new DbManager("Server=localhost;Port=5432;Database=Otus;User Id=postgres;Password=123;");
			var locations = new List<Location>
			{
				new Location
				{
					Id = 1,
					Name = "ONLINE",
					Address = ""
				}
				,
				new Location
				{
					Id = 2,
					Name = "Location 1",
					Address = "627330, г. Завьялово, ул. Мишина, дом 43, квартира 329"
				}
				,
				new Location
				{
					Id = 3,
					Name = "Location 2",
					Address = "672524, г. Камышин, ул. Бухвостова 2-я, дом 56, квартира 149"
				}
				,
				new Location
				{
					Id = 4,
					Name = "Location 3",
					Address = "672999, г. Ивня, ул. Заводской проезд, дом 67, квартира 482"
				}
				,
				new Location
				{
					Id = 5,
					Name = "Location 4",
					Address = "606521, г. Всеволожск, ул. Сердобольская (Приморский), дом 161, квартира 88"
				}
			};
			var teachers = new List<Teacher>
			{
				new Teacher
				{
					Id = 1,
					FirstName = "Иванов",
					LastName = "Александр"
				},
				new Teacher
				{
					Id = 2,
					FirstName = "Петров",
					LastName = "Иван"
				},
				new Teacher
				{
					Id = 3,
					FirstName = "Сидоров",
					LastName = "Арсений"
				},
				new Teacher
				{
					Id = 4,
					FirstName = "Хрусталёв",
					LastName = "Дмитрий"
				},
				new Teacher
				{
					Id = 5,
					FirstName = "Демидов",
					LastName = "Олег"
				},
			};
			var courses = new List<Сourse>
			{
				new Сourse
				{
					Id = 1,
					СourseName = "C#",
					Location = locations[0],
				},
				new Сourse
				{
					Id = 2,
					СourseName = "Java",
					Location = locations[1],
				},
				new Сourse
				{
					Id = 3,
					СourseName = "MS SQL",
					Location = locations[2],
				},
				new Сourse
				{
					Id = 4,
					СourseName = "Python",
					Location = locations[3],
				},
				new Сourse
				{
					Id = 5,
					СourseName = "Ruby",
					Location = locations[4],
				},
			};
			var teacherCourse = new List<TeacherCourse>
			{
				new TeacherCourse
				{
					Id = 1,
					Course = courses[0],
					Teacher = teachers[4]
				},
				new TeacherCourse
				{
					Id = 2,
					Course = courses[1],
					Teacher = teachers[3]
				},
				new TeacherCourse
				{
					Id = 3,
					Course = courses[2],
					Teacher = teachers[2]
				},
				new TeacherCourse
				{
					Id = 4,
					Course = courses[3],
					Teacher = teachers[1]
				},
				new TeacherCourse
				{
					Id = 5,
					Course = courses[4],
					Teacher = teachers[0]
				},
			};

			#region раскомментировать для создания
			foreach (var item in locations)
			{
				item.Id = 0;
			}
			foreach (var item in teachers)
			{
				item.Id = 0;
			}
			foreach (var item in courses)
			{
				item.Id = 0;
			}
			foreach (var item in teacherCourse)
			{
				item.Id = 0;
			}
			#endregion
			dbManager.InsertOrUpdateEntity(locations);
			dbManager.InsertOrUpdateEntity(teachers);
			dbManager.InsertOrUpdateEntity(courses);
			dbManager.InsertOrUpdateEntity(teacherCourse);

			Console.WriteLine($"\nLocations :\n { string.Join(',', dbManager.GetAllLocations().Select(it => "\n" + it.Id + " " + it.Name + " " + it.Address))}");
			Console.WriteLine($"\nTeachers :\n { string.Join(',', dbManager.GetAllTeachers().Select(it => "\n" + it.Id + " " + it.FirstName + " " + it.LastName))}");
			Console.WriteLine($"\nСourses :\n { string.Join(',', dbManager.GetAllСourses().Select(it => "\n" + it.Id + " " + it.СourseName))}");
			Console.WriteLine($"\nTeacherCourse :\n { string.Join(',', dbManager.GetAllTeacherCourse().Select(it => "\n" + it.Course.Id + " - " + it.Teacher.Id))}");
		}
	}
}
 