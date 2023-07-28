using System.Collections.Generic;

namespace DemoApiC_.Models
{
    public class DipendentiResponse
    {
        public BaseResponse baseResponse { get; set; }
        public List<Dipendente> dipendenteList { get; set; }


        public DipendentiResponse(BaseResponse baseResponse, List<Dipendente> dipendenteList)
        {
            this.baseResponse = baseResponse;
            this.dipendenteList = dipendenteList;
        }
    }
}