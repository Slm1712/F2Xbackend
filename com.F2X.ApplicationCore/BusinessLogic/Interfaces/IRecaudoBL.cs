using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.F2X.Infrastructure.ModelDTO;
using com.F2X.Infrastructure.Models;
using Newtonsoft.Json.Linq;

namespace com.F2X.ApplicationCore.BusinessLogic.Interfaces
{
    public interface IRecaudoBL
    {
        DataSet getRecaudos();

        DataSet getDataApi();

        Task<List<ConteoVehiculosDTO>> setIntegracion(string path, string date);
        DataSet GetInformacionRecaudo();
    }
}