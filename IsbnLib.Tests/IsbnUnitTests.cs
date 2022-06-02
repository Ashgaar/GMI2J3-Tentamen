using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IsbnLib.Tests
{
    public class IsbnUnitTests
    {
        private IsbnProcessorStud _processor;
        public IsbnUnitTests()
        {
            _processor = new IsbnProcessorStud();
        }

        [Fact]
        public void TestCreateBookUrl()
        {
            
            Assert.Equal("https://amzn.com/9781506711980", _processor.CreateBookUrl("", "9781506711980"));
        }

        [Theory]
        [InlineData(1506727549)]
        [InlineData(1506711987)]
        [InlineData(1506711995)]
        [InlineData(1506712002)]
        public void TestValidIsbn10Int(int isbn)
        {
            var isbnString = isbn.ToString();
            Assert.True(IsbnProcessorStud.IsValidIsbn10(isbnString));
        }

        [Theory]
        [InlineData("1506727549")]
        [InlineData("1506711987")]
        [InlineData("1506711995")]
        [InlineData("1506712002")]
        public void TestValidIsbn10String(string isbn)
        {
            Assert.True(IsbnProcessorStud.IsValidIsbn10(isbn));
        }
        
        [Theory]
        [InlineData(9781506711980)]
        [InlineData(9781506711997)]
        [InlineData(9781506712000)]
        [InlineData(9781506717920)]
        public void TestValidIsbn13Int(double isbn)
        {
            var isbnString = isbn.ToString();
            Assert.True(IsbnProcessorStud.IsValidIsbn13(isbnString));
        }

        [Theory]
        [InlineData("9781506711980")]
        [InlineData("9781506711997")]
        [InlineData("9781506712000")]
        [InlineData("9781506717920")]
        public void TestValidIsbn13String(string isbn)
        {   
            Assert.True(IsbnProcessorStud.IsValidIsbn13(isbn));
        }
    }
}
