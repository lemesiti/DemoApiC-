using DemoApiC_.Models;
using System.Web.Http;


namespace DemoApiC_
{
    public interface DipendenteDelegate 
    {
        DipendenteResponse Create([FromBody] Dipendente dipendente);

        DipendenteResponse Delete(int id);

        DipendenteResponse geById(int id);

        DipendenteResponse Update(int id, [FromBody] Dipendente dipendenteUp);

        DipendentiResponse GetAll();
        
    }
}