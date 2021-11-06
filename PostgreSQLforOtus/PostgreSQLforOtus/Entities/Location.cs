using NHibernate.Mapping.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgreSQLforOtus.Entities
{
	[Class(Table = "Location")]
	public class Location : IDataBaseEntity
	{
		[Id(0, Name = "Id"), Generator(1, Class = "native")]
		public virtual long Id { get; set; }

		[Property(NotNull = true)]
		public virtual string Name { get; set; }

		[Property(NotNull = false)]
		public virtual string Address { get; set; }

		[Bag(0, Name = "Сourses", Inverse = true)]
		[Key(1, Column = "Location_id")]
		[OneToMany(2, ClassType = typeof(Сourse))]
		public virtual IList<Сourse> Сourses { get; set; }
	}
}
