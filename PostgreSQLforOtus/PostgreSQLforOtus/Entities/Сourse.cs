using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgreSQLforOtus.Entities
{
	[Class(Table = "Сourse")]
	public class Сourse : IDataBaseEntity
	{
		[Id(0, Name = "Id"), Generator(1, Class = "native")]
		public virtual long Id { get; set; }

		[Property(NotNull = true)]
		public virtual string СourseName { get; set; }

		[ManyToOne(Column = "Location_id", ForeignKey = "Сourses_fk_locationId", Cascade = "all")]
		public virtual Location Location { get; set; }

		//Реализовал так
		[ManyToOne(Column = "Teacher_id", ForeignKey = "Сourses_fk_teacherId", Cascade = "all")]
		public virtual Teacher Teacher { get; set; }

		// Почему то не работает =(

		//[Set(1, Table = "Сourse_Teacher", Cascade = "save-update")]
		//[Key(2, Column = "СourseId")]
		//[ManyToMany(3, ClassType = typeof(Teacher), Column = "TeacherId")]
		//private IList<Teacher> _teacher;

		//public virtual IList<Teacher> Teachers
		//{
		//	get
		//	{
		//		return _teacher ?? (_teacher = new List<Teacher>());
		//	}
		//	set { _teacher = value; }
		//}
	}
}
