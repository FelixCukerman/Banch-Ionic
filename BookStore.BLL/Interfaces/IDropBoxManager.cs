using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Interfaces
{
    public interface IDropBoxManager
    {
        Task UploadFile(byte[] content, int bookid);
        Task<string> GetFileLink(int bookId);
    }
}
