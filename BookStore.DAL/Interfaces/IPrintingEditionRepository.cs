using EntitiesLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IPrintingEditionRepository : IRepository<PrintingEdition>
    {
        Task<List<PrintingEdition>> Get(int index, int count);
        Task<int> GetTotalCount();
    }
}
