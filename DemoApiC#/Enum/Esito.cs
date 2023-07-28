using System.Collections.Generic;

namespace DemoApiC_
{
    public enum Esito

    {
        Succes,

        BadRequest = -1,

        NotFound = -2
    }



    public static class EsitoHelper

    {

        private static readonly Dictionary<Esito, string> EnumMessages = new Dictionary<Esito, string>()

    {

        { Esito.Succes, "Ok" },

        { Esito.BadRequest, "Error" },

        { Esito.NotFound, "Not Found" }

    };



        public static string GetMessage(Esito key)
        {
            return EnumMessages[key];
        }

    }





}