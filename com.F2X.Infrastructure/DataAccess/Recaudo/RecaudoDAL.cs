
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.F2X.Infrastructure.DataAccess.Interfaces;
using com.F2X.Infrastructure.ModelDTO;
using com.F2X.Shared.LogEvent;
using com.F2X.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using com.F2X.Shared.SqlData;
using com.F2X.Shared.Utils;

namespace com.F2X.Infrastructure.DataAccess
{
    public class RecaudoDAL : IRecaudoDAL
    {
        public F2X_bdContext dbcontext;

        public RecaudoDAL()
        {
            dbcontext = new F2X_bdContext();
        }

        public DataSet getRecaudos()
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_Recaudos]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }

                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);

                    return null;
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        public DataSet getDataApi()
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[get_Recaudos]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }

                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);

                    return null;
                }

                finally
                {
                    connection.Close();
                }
            }
        }
        public DataSet GetInformacionRecaudo()
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection(dbcontext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                try
                {

                    using (var command = new SqlCommand("[dbo].[sp_GET_InformeRecaudos]", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandTimeout = 0;

                        var adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataSet);

                    }

                    return dataSet;
                }
                catch (System.Exception ex)
                {
                    LogEvent log = new LogEvent();
                    log.LogWrite(ex.Message);

                    return null;
                }

                finally
                {
                    connection.Close();
                }
            }
        }

        public void setIntegracionAPi(List<ConteoVehiculosDTO> conteoVehiculosDTO)
        {
            if (conteoVehiculosDTO == null) return;

            var dataSet = new DataSet();

            SqlObjectData SqlObjectData = new SqlObjectData();
            //onverterObject converterObject = new ConverterObject();

            DataTable recaudos = ConverterObject.CreateDataTable(conteoVehiculosDTO);
            object p = SqlObjectData.BulkInsertDataTable("recaudos", recaudos, dbcontext.Database.GetDbConnection().ConnectionString);

        }

    }
}
