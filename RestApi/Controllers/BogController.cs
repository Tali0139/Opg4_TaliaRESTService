using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Opg4_TaliaRESTService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/bog")]
    public class BogController : Controller
    {
        private static readonly List<Bog> bøger = new List<Bog>()
        {
            new Bog("REST in Peace", "Talia Damary",224,"1122334455667"),
            new Bog("NULL-værdier og hvorfor de er dybt frustrerende","Talia Damary",264,"1112333455567"),
            new Bog("C#, HTML & Typescript", "P. Eriksen",67,"1199887766551"),
            new Bog("System-DevOPS", "Hermann Petersen",924,"1122334455669"),
            new Bog("Agile For The Win", "Olivia Petersen",125,"0122334455667"),
        };

        // GET: api/bog
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return bøger;
        }

        // GET: api/bog/5
        [HttpGet]
        [Route("isbn/{substring}")]
        public Bog GetBog(string substring)
        {
            return bøger.Find(i => i.Isbn.Equals(substring));
        }

        [HttpGet]
        [Route("forfatter/{substring}")]
        public IEnumerable<Bog> GetForfatter(string substring)
        {
            return bøger.FindAll(i => i.Forfatter.Contains(substring));
        }

        [HttpGet]
        [Route("titel/{substring}")]
        public IEnumerable<Bog> GetTitel(string substring)
        {       
            return bøger.FindAll(i => i.Titel.Contains(substring));
        }


        // POST: api/bøger
        [HttpPost]
        public void Post([FromBody] Bog value)
        {
            bøger.Add(value);
        }

        // PUT: api/bøger/5
        [HttpPut]
        [Route("{isbn}")]
        public void Put(string isbn, [FromBody] Bog value)
        {
            Bog bog = GetBog(isbn);
            if (bog != null)
            {
                bog.Forfatter = value.Forfatter;
                bog.Titel = value.Titel;
                bog.Sidetal = value.Sidetal;
                bog.Isbn = value.Isbn;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{isbn}")]
        public void Delete(string isbn)
        {
            Bog bog = GetBog(isbn);
            bøger.Remove(bog);
        }
    }
}
