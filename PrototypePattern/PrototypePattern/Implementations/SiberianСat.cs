using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern.Implementations
{
	public enum ColorPatternSiberianСat
	{
		NevaMasquerade,
		Monochrome,
		Tabby
	}
	public class SiberianСat : Cat
	{
		public ColorPatternSiberianСat ColorPattern;

		public SiberianСat(string animalCollor, int woolLength, ColorPatternSiberianСat colorPattern) : base(animalCollor, woolLength)
		{
			ColorPattern = colorPattern;
		}

		public override Cat MyClone()
		{
			return new SiberianСat(AnimalCollor, WoolLength, ColorPattern);
		}
	}
}
