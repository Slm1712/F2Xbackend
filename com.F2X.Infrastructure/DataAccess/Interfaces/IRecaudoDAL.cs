using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using com.F2X.Infrastructure.ModelDTO;
using com.F2X.Infrastructure.Models;
using com.F2X.Shared.ModelDTO;

namespace com.F2X.Infrastructure.DataAccess.Interfaces
{
    public interface IRecaudoDAL
    {
        DataSet getRecaudos();
        DataSet getDataApi();
        void setIntegracionAPi(List<ConteoVehiculosDTO> conteoVehiculosDTO);
        DataSet GetInformacionRecaudo();

    }

}