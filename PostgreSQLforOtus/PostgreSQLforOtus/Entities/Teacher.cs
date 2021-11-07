using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgreSQLforOtus.Entities
{
	[Class(Table = "Teacher")]
	public class Teacher : IDataBaseEntity
	{
		[Id(0, Name = "Id"), Generator(1, Class = "native")]		
		public virtual long Id { get; set; }

		[Property(NotNull = true)]
		public virtual string FirstName { get; set; }

		[Property(NotNull = true)]
		public virtual string LastName { get; set; }

		//Реализовал так
		[Bag(0, Name = "TeacherCourses", Inverse = true)]
		[Key(1, Column = "Teacher_id")]
		[OneToMany(2, ClassType = typeof(TeacherCourse))]
		private IList<TeacherCourse> _teacherCourses;
		public virtual IList<TeacherCourse> TeacherCourses
		{
			get
			{
				return _teacherCourses ?? (_teacherCourses = new List<TeacherCourse>());
			}
			set { _teacherCourses = value; }
		}

		// Почему то не работает =(

		//[Set(1, Table = "Сourse_Teacher", Inverse = true, Cascade = "save-update")]
		//[Key(2, Column = "TeacherId")]
		//[ManyToMany(3, ClassType = typeof(Сourse), Column = "СourseId")]
		//private IList<Сourse> _courses;

		//public virtual IList<Сourse> Сourses
		//{
		//	get
		//	{
		//		return _courses ?? (_courses = new List<Сourse>());
		//	}
		//	set { _courses = value; }
		//}
	}
}
