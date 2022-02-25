using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrototypePattern.Implementations;

namespace UnitTestProject
{
	[TestClass]
	public class MyUnitTest
	{
		[TestMethod]
		public void TestCloneSiberianÑat()
		{
			//arrange
			string collor = "blue";
			int woolLength = 5;
			ColorPatternSiberianÑat colorPatternSiberianÑat = ColorPatternSiberianÑat.Monochrome;

			//act
			SiberianÑat TargetEntity = new SiberianÑat(collor, woolLength, colorPatternSiberianÑat);
			var ResultEntity = TargetEntity.MyClone();

			//asset
			Assert.AreEqual(TargetEntity.AnimalCollor, ResultEntity.AnimalCollor);
			Assert.AreEqual(TargetEntity.ColorPattern, ResultEntity.ColorPattern);
			Assert.AreEqual(TargetEntity.WoolLength, ResultEntity.WoolLength);
		}
		[TestMethod]
		public void TestCloneÑat()
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
 