using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Shared.RequestModels
{
    public class RequestGetProductsModel
    {
        public int Index { get; set; }
        public int Count { get; set; }
    }
}
