using System.Data;
using System.Threading.Tasks;
using com.F2X.ApplicationCore.BusinessLogic.Interfaces;
using com.F2X.ApplicationCore.BusinessLogic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com.F2X.WebAPI.Controllers.Recaudos
{   
    [ApiController]
    public class RecaudoController : ControllerBase
    {
        private readonly IRecaudoBL _RecaudoBL;

        public RecaudoController(IRecaudoBL RecaudoBL)
        {
            this._RecaudoBL = RecaudoBL;
        }

        // GET: api/GetRecaudos
        [Route("api/GetRecaudos")]
        [HttpGet]
        public JsonResult getRecaudos()
        {
            var result = this._RecaudoBL.getRecaudos();
            if (result == null)
            {
                result = new DataSet();
                DataTable dt = new DataTable("table");
                dt.Columns.Add(new DataColumn("resultado", typeof(string)));
                DataRow dr = dt.NewRow();
                dr["resultado"] = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
                dt.Rows.Add(dr);
                result.Tables.Add(dt);
            }
            JsonResult json = new JsonResult(result);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;
        }

        // GET: api/GetDataApiConteo
        [Route("api/GetDataApiConteo/{date}")]
        [HttpGet]
        public async Task<JsonResult> getDataApiConteoAsync(string date)
        {
            var result = await this._RecaudoBL.setIntegracion("api/ConteoVehiculos/",date);

            JsonResult json = new JsonResult(result);
            return json;
        }

        // GET: api/GetDataApiCategoria
        [Route("api/GetDataApiCategoria/{date}")]
        [HttpGet]
        public async Task<JsonResult> getDataApiVehiculoAsync(string date)
        {
            var result = await this._RecaudoBL.setIntegracion("api/RecaudoVehiculos/",date);

            JsonResult json = new JsonResult(result);
            return json;
        }

        // GET: api/GetDataApiConteo
        [Route("api/GetInformeRecaudo")]
        [HttpGet]
        public JsonResult GetInformeRecaudo()
        {
            DataSet result = new DataSet();
            result = this._RecaudoBL.GetInformacionRecaudo();
            JsonResult json = new JsonResult(result);
            if (json.Value == null)
            {
                json.StatusCode = 500;
                json.Value = "Error al consumir el servicio, revise el log de eventos en la carpeta (C:\\EventLogTecnoCEDI\\Utils\\)";
            }
            else
                json.StatusCode = 200;

            return json;

        }

    }
}
