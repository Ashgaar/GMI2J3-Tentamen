using System.Collections.Generic;

namespace IsbnLib.Interfaces
{
    public interface ILibraryDbService<T>
    {
        bool LendBook(T isbn);
        bool ReturnBook(T isbn);

        List<T> Search(T searchFilter);
    }
}   
