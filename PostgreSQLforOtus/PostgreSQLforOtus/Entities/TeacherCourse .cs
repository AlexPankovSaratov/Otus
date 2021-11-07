using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgreSQLforOtus.Entities
{
	[Class(Table = "TeacherCourse")]
	public class TeacherCourse : IDataBaseEntity
	{
		[Id(0, Name = "Id"), Generator(1, Class = "native")]
		public virtual long Id { get; set; }

		[ManyToOne(Name = "Course", Column = "Course_id", ClassType = typeof(Сourse), ForeignKey = "TeacherCourse_fk_courseId", Cascade = "all")]
		public virtual Сourse Course { get; set; }

		[ManyToOne(Name = "Teacher", Column = "Teacher_id", ClassType = typeof(Teacher), ForeignKey = "TeacherCourse_fk_teacher_id", Cascade = "all")]
		public virtual Teacher Teacher { get; set; }
	}
}
