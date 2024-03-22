using Xunit;
using MyLibrary;

namespace MyLibrary;

public class UnitTest1{
    [Fact]
	public void TestProduct1() {
	
		double a = 4; // arrange
        double b = 5;
		double expected = 20;
	
		double actual = Class1.Multiply(a,b); // act
 
		Assert.Equal(expected, actual); // assert
	}	
	[Fact]
    public void TestProduct2() {
    
		double a = 2; // arrange
        double b = 6;
		double expected = 12;
	
		double actual = Class1.Multiply(a,b); // act
 
		Assert.Equal(expected, actual); // assert
	} 
}