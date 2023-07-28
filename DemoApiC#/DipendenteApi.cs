using DemoApiC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Http;

namespace DemoApiC_
{
    internal interface DipendenteApi
    {
        IHttpActionResult Create([FromBody] Dipendente dipendente);

        IHttpActionResult Delete(int id);

        IHttpActionResult GeById(int id);

        IHttpActionResult Update(int id, [FromBody] Dipendente dipendenteUp);

        IEnumerable<Dipendente> GetAll();
    }
}
