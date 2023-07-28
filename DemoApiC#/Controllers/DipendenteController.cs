using DemoApiC_.Models;
using System.Web.Http;

namespace DemoApiC_.Controllers
{
    public class DipendenteController : ApiController
    {
        private DipendenteDelegate delegateImpl = new DipendenteDelegateImpl();

        [HttpPost]
        [Route("createDipendente")]
        public IHttpActionResult Create([FromBody] Dipendente dipendente)
        {
            return Ok(delegateImpl.Create(dipendente));
        
        }

        [HttpDelete]
        [Route("deleteDipendente")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(delegateImpl.Delete(id));
        }

        [HttpGet]
        [Route("getById")]
        public IHttpActionResult GeById(int id)
        {
            return Ok(delegateImpl.geById(id));
        }


        [HttpPut]
        [Route("updateDipendente")]
        public IHttpActionResult Update(int id,[FromBody] Dipendente dipendenteUp)
        {
            
            return Ok(delegateImpl.Update(id, dipendenteUp));
        }

        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            return Ok(delegateImpl.GetAll());
        }

       
    }
}
