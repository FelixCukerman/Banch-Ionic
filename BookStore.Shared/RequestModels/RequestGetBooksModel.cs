using BookStore.Shared.RequestModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Shared.RequestModels
{
    public class RequestGetBooksModel : BaseRequestGetBooksModel
    {
        public int Index { get; set; }
        public int Count { get; set; }
    }
}
