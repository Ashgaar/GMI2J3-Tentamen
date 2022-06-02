using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace IsbnLib.Tests
{
    public class UnitTestMock
    {
        private Mock<ILibraryDbService<string>> _libraryDbServiceMock;
        
        public UnitTestMock(/*ILibraryDbService<string> libraryDbService*/)
        {
            _libraryDbServiceMock = new Mock<ILibraryDbService<string>>();
        }
        
        [Fact]
        public void TestLibraryLendBook()
        {
            _libraryDbServiceMock.Setup(x => x.LendBook("123456789")).Returns(true);
            var result = _libraryDbServiceMock.Object.LendBook("123456789");
            Assert.True(result);
        }

        [Fact]
        public void TestLibraryReturnBook()
        {
            _libraryDbServiceMock.Setup(x => x.ReturnBook("123456789")).Returns(true);
            var result = _libraryDbServiceMock.Object.ReturnBook("123456789");
            Assert.True(result);
        }

        [Fact]
        public void TestLibrarySearchBooks()
        {
            _libraryDbServiceMock.Setup(x => x.Search("123456789")).Returns(new List<string> { "123456789" });
            var result = _libraryDbServiceMock.Object.Search("123456789");
            Assert.True(result.Count == 1);
        }        
    }
}
