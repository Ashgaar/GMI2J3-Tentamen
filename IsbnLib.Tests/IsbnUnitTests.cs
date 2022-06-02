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
        public void TestEmptyIsbnString()
        {
            Assert.False(_processor.TryValidate(""));
        }

        [Fact]
        public void TestMalformedIsbnString()
        {
            Assert.False(_processor.TryValidate("9781506711980A"));
        }
        
        [Fact]
        public void TestNullIsbnString()
        {
            Assert.False(_processor.TryValidate(null));
        }

        [Fact]
        public void TestStripIsbn()
        {
            var result = IsbnProcessorStud.TryStrip("978-1-50-671198-0");
            Assert.Equal("9781506711980", result);
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
        public void TestValidIsbn13Int(Int64 isbn)
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


        [Theory]
        [InlineData(1506727549)]
        public void TestConvertIsbn10ToIsbn13Int(int isbn)
        {
            var isbnString = isbn.ToString();
            var isbn13 = IsbnProcessorStud.ConvertTo13(isbnString);
            Assert.Equal("9781506727547", isbn13);
        }

        [Theory]
        [InlineData("1506727549")]
        public void TestConvertIsbn10ToIsbn13String(string isbn)
        {
            var isbn13 = IsbnProcessorStud.ConvertTo13(isbn);
            Assert.Equal("9781506727547", isbn13);
        }

        [Theory]
        [InlineData(9781506727547)]
        public void TestConvertIsbn13ToIsbn10Int(Int64 isbn)
        {
            var isbnString = isbn.ToString();
            var isbn13 = IsbnProcessorStud.ConvertTo10(isbnString);
            Assert.Equal("1506727549", isbn13);
        }

        [Theory]
        [InlineData("9781506727547")]
        public void TestConvertIsbn13ToIsbn10String(string isbn)
        {
            var isbn13 = IsbnProcessorStud.ConvertTo10(isbn);
            Assert.Equal("1506727549", isbn13);
        }
    }
}
