using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrototypePattern.Implementations;

namespace UnitTestProject
{
	[TestClass]
	public class MyUnitTest
	{
		[TestMethod]
		public void TestCloneSiberian�at()
		{
			//arrange
			string collor = "blue";
			int woolLength = 5;
			ColorPatternSiberian�at colorPatternSiberian�at = ColorPatternSiberian�at.Monochrome;

			//act
			Siberian�at TargetEntity = new Siberian�at(collor, woolLength, colorPatternSiberian�at);
			var ResultEntity = TargetEntity.MyClone();

			//asset
			Assert.AreEqual(TargetEntity.AnimalCollor, ResultEntity.AnimalCollor);
			Assert.AreEqual(TargetEntity.ColorPattern, ResultEntity.ColorPattern);
			Assert.AreEqual(TargetEntity.WoolLength, ResultEntity.WoolLength);
		}
		[TestMethod]
		public void TestClone�at()
		{
			//arrange
			string collor = "blue";
			int woolLength = 5;

			//act
			Cat TargetEntity = new Cat(collor, woolLength);
			var ResultEntity = TargetEntity.MyClone();

			//asset
			Assert.AreEqual(TargetEntity.AnimalCollor, ResultEntity.AnimalCollor);
			Assert.AreEqual(TargetEntity.WoolLength, ResultEntity.WoolLength);
		}
		[TestMethod]
		public void TestCloneAnimal()
		{
			//arrange
			string collor = "blue";

			//act
			Animal TargetEntity = new Animal(collor);
			var ResultEntity = TargetEntity.MyClone();

			//asset
			Assert.AreEqual(TargetEntity.AnimalCollor, ResultEntity.AnimalCollor);
		}
	}
}
 