using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DAL.Services
{
    public class ApiKeyFakeService
    {
        private string[] _validApiKeys;
        public ApiKeyFakeService()
        {
            _validApiKeys = new string[] {
                "Toto", "Titi", "Tutu"
            };
        }

        public bool IsValid(string apiKey)
        {
            return _validApiKeys.Contains(apiKey);
        }
    }
}
