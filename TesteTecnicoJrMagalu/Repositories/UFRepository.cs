using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TesteTecnicoJrMagalu.Interfaces;
using TesteTecnicoJrMagalu.Models;

namespace TesteTecnicoJrMagalu.Repositories
{
    public class UFRepository : IUFRepository
    {
        public async Task<List<UFIBGE?>> Get()
        {
            List<UFIBGE> estados = new List<UFIBGE>();

            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(requestUri: "https://servicodados.ibge.gov.br/api/v1/localidades/estados/").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        estados = JsonConvert.DeserializeObject<List<UFIBGE>>(jsonResponse);
                    }
                }
            }


            return estados;
        }
    }
}
