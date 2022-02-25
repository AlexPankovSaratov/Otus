using PrototypePattern.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Implementations
{
	public class Animal : IMyCloneable<Animal>, ICloneable
	{
		public string AnimalCollor;

		public Animal(string animalCollor)
		{
			AnimalCollor = animalCollor;
		}

		public virtual object Clone()
		{
			return MyClone();
		}

		public virtual Animal MyClone()
		{
			return new Animal(AnimalCollor);
		}
	}
}
