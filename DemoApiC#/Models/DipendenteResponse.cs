

namespace DemoApiC_.Models
{
    public class DipendenteResponse
    {
        public BaseResponse baseResponse { get; set; }
        public Dipendente dipendente { get; set; }

        public DipendenteResponse(BaseResponse baseResponse, Dipendente dipendente)
        {
            this.baseResponse = baseResponse;
            this.dipendente = dipendente;
        }
    }
}