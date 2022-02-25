using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Implementations
{
	public class Cat : Animal
	{
		private int _woolLength;

		public int WoolLength 
		{
			get {return _woolLength;} 
			set { _woolLength = value < 0 ? 0 : value; } 
		}

		public Cat(string animalCollor, int woolLength) : base(animalCollor)
		{
			_woolLength = woolLength;
		}
		public override Cat MyClone()
		{
			return new Cat(AnimalCollor, _woolLength);
		}
	}
}
