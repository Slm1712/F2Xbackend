using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using com.F2X.ApplicationCore.BusinessLogic.Interfaces;
using com.F2X.Infrastructure.DataAccess.Interfaces;
using com.F2X.Infrastructure.ModelDTO;
using com.F2X.Infrastructure.Models;
using com.F2X.Shared.ModelDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.F2X.ApplicationCore.BusinessLogic
{
    public class RecaudoBL : IRecaudoBL
    {
        private readonly IRecaudoDAL _RecaudoDAL;
        private string baseUrl;

        public RecaudoBL(IRecaudoDAL RecaudoDAL)
        {
            this._RecaudoDAL = RecaudoDAL;
            this.baseUrl = "http://190.145.81.67:5200/";
        }

        public DataSet getRecaudos()
        {
            return this._RecaudoDAL.getRecaudos();
        }

        public DataSet getDataApi()
        {
            return this._RecaudoDAL.getDataApi();
        }
        public DataSet GetInformacionRecaudo()
        {
            return this._RecaudoDAL.GetInformacionRecaudo();
        }


        public async Task<List<ConteoVehiculosDTO>> setIntegracion(string paht,string date)
        {
            var data = await GetDataAsync(paht, date);

            var DataDTO = JsonConvert.DeserializeObject<List<ConteoVehiculosDTO>>(data.ToString());
            this._RecaudoDAL.setIntegracionAPi(DataDTO);
            return DataDTO;
        }


        private async Task<JArray> GetDataAsync(string path, string date)
        {
            try
            {
                var client = new HttpClient();
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}{path}{date}");
                req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken().ConfigureAwait(false));

                var response = await client.SendAsync(req);
                var json = await response.Content.ReadAsStringAsync();

                return JArray.Parse(json);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private async Task<string> GetToken()
        {
            try
            {
                string path = $"{baseUrl}api/Login";

                CredentialDTO credential = new CredentialDTO
                {
                    userName = "user",
                    password = "1234"
                };

                var content = new StringContent(JsonConvert.SerializeObject(credential), Encoding.UTF8, "application/json");

                var client = new HttpClient();
                var response = await client.PostAsync(path, content).ConfigureAwait(false);

                var json = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<TokenDTO>(json);
                return token.Token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
