using Newtonsoft.Json;
using TesteTecnicoJrMagalu.Interfaces;
using TesteTecnicoJrMagalu.Models;

namespace TesteTecnicoJrMagalu.Repositories
{
    public class MunicipioRepository : IMunicipioRepository
    {
        public async Task<MunicipioIBGE> FindById(string id)
        {
            MunicipioIBGE cidade = new MunicipioIBGE();

            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(requestUri: $"https://servicodados.ibge.gov.br/api/v1/localidades/municipios/{id}").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        try
                        {
                            cidade = JsonConvert.DeserializeObject<MunicipioIBGE>(jsonResponse);

                        } catch
                        {
                            cidade = null;
                        }
                    }
                }
            }


            return cidade;
        }

        public async Task<List<MunicipioIBGE>> Get()
        {
            List<MunicipioIBGE> cidades = new List<MunicipioIBGE>();

            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(requestUri: "https://servicodados.ibge.gov.br/api/v1/localidades/municipios?orderBy=nome").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        cidades = JsonConvert.DeserializeObject<List<MunicipioIBGE>>(jsonResponse);
                    }
                }
            }

            return cidades;
        }
    }
}
