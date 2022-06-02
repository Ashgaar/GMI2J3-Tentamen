using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbnLib.Tests
{
    public class UnitTestMock
    {
        private ILibraryDbService<string> _libraryDbService;
        public UnitTestMock()
        {
            //_libraryDbService = new LibraryDbServiceMock();
        }
        
        [Fact]
        public void Test()
        {

        }


    }
}
