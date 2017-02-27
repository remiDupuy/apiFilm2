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

    }
}
}
