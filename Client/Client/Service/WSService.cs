using Client.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Service
{
    class WSService
    {
        private static WSService instance;
        private WSService() { }

        public static WSService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WSService();
                }
                return instance;
            }
        }


        static HttpClient client = new HttpClient();


        public async Task<T_E_COMPTE_CPT> getCompteByEmail(string email)
        {
            T_E_COMPTE_CPT model = null;

            var task = await client.GetAsync("http://localhost:3124/api/compte?email="+email);
            var jsonString = await task.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<T_E_COMPTE_CPT>(jsonString);
            return model;
        }

        public async Task<Boolean> putCompte(T_E_COMPTE_CPT updateCompte)
        {

            var stringContent = new StringContent(JsonConvert.SerializeObject(updateCompte), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("http://localhost:3124/api/compte/" + updateCompte.CPT_ID, stringContent);
            return response.IsSuccessStatusCode;
            
        }

        public async Task<Boolean> createCompte(T_E_COMPTE_CPT createdComtpe)
        {

            var stringContent = new StringContent(JsonConvert.SerializeObject(createdComtpe), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:3124/api/compte", stringContent);
            return response.IsSuccessStatusCode;

        }

        public async Task<Rootobject> getCoordonnees(String rue, String cp, String ville)
        {
            Rootobject model = null;
            var task = await client.GetAsync("http://dev.virtualearth.net/REST/v1/Locations/FR/" + cp + "/" + ville + "/" + rue + "?key=AvwYogeHamJ_OUE_uJTXJHmBcDkmNcs2mryb2mpdOKGCCLU8sb_0Bf3BorGBVk LN");
            var jsonString = await task.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<Rootobject>(jsonString);
            return model;
        }

    }
}

