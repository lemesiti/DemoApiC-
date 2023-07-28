using DemoApiC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NLog;

namespace DemoApiC_
{
    public class DipendenteDelegateImpl :  DipendenteDelegate
    {   
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public DipendenteResponse Create([FromBody] Dipendente dipendente)
        {
            logger.Info("BEGIN - DipendenteDelegateImpl method: Create");
            logger.Debug("Test");
            BaseResponse response;
            using (var dbContext = new DbConfig())
            {
                try
                {
                    Dipendente dipendenteNew = dbContext.Dipendenti.Add(dipendente);
                    dbContext.SaveChanges();
                    response = new BaseResponse(Esito.Succes, EsitoHelper.GetMessage(Esito.Succes));

                    logger.Info("END - DipendenteDelegateImpl method: Create");
                    return new DipendenteResponse(response, dipendenteNew);
                }
                catch(Exception ex)
                {
                    logger.Info("Exc - DipendenteDelegateImpl - Create: " + ex.Message);

                    response = new BaseResponse(Esito.BadRequest, EsitoHelper.GetMessage(Esito.BadRequest));

                    logger.Info("END - DipendenteDelegateImpl method: Create");
                    return new DipendenteResponse(response, null);
                }
            }
            
        }

        public DipendenteResponse Delete(int id)
        {
            logger.Info("BEGIN - DipendenteDelegateImpl method: Delete");

            using (var dbContext = new DbConfig())
            {
                Dipendente dipendenteToDelete = dbContext.Dipendenti.FirstOrDefault(d => d.id == id);
                BaseResponse response;
                try
                {
                    dbContext.Dipendenti.Remove(dipendenteToDelete);
                    var temp = dbContext.SaveChanges();
                    response = new BaseResponse(Esito.Succes, EsitoHelper.GetMessage(Esito.Succes));

                    logger.Info("END - DipendenteDelegateImpl method: Delete");
                    return new DipendenteResponse(response, dipendenteToDelete);
                }
                catch(ArgumentNullException ex)
                {
                    logger.Info("Exc - DipendenteDelegateImpl - Delete: " + ex.Message);

                    response = new BaseResponse(Esito.NotFound, EsitoHelper.GetMessage(Esito.NotFound));

                    logger.Info("END - DipendenteDelegateImpl method: Delete");
                    return new DipendenteResponse(response, dipendenteToDelete);
                }
                catch(Exception ex)
                {
                    logger.Info("Exc - DipendenteDelegateImpl - Delete: " + ex.Message);

                    response = new BaseResponse(Esito.BadRequest, EsitoHelper.GetMessage(Esito.BadRequest));

                    logger.Info("END - DipendenteDelegateImpl method: Delete");
                    return new DipendenteResponse(response, null);
                }
            }
        }

        public DipendenteResponse geById(int id)
        {
            logger.Info("BEGIN - DipendenteDelegateImpl method: geById");

            using (var dbContext = new DbConfig())
            {
                Dipendente dipendente = dbContext.Dipendenti.FirstOrDefault(d => d.id == id);
                BaseResponse response;
                try
                { 
                    response = new BaseResponse(Esito.Succes, EsitoHelper.GetMessage(Esito.Succes));

                    logger.Info("END - DipendenteDelegateImpl method: geById");
                    return new DipendenteResponse(response, dipendente);
                }
                catch(ArgumentNullException ex)
                {
                    logger.Info("Exc - DipendenteDelegateImpl - geById: " + ex.Message);

                    response = new BaseResponse(Esito.NotFound, EsitoHelper.GetMessage(Esito.NotFound));

                    logger.Info("END - DipendenteDelegateImpl method: geById");
                    return new DipendenteResponse(response, dipendente);
                }
            }
        }

        public DipendentiResponse GetAll()
        {
            logger.Info("BEGIN - DipendenteDelegateImpl method: GetAll");

            using (var dbContext = new DbConfig())
            {
                List<Dipendente> allDipendenti = dbContext.Dipendenti.ToList();
                BaseResponse response = new BaseResponse(Esito.Succes, EsitoHelper.GetMessage(Esito.Succes));

                logger.Info("END - DipendenteDelegateImpl method: GetAll");
                return new DipendentiResponse(response, allDipendenti);
            }
        }

        public DipendenteResponse Update(int id, [FromBody] Dipendente dipendenteUp)
        {
            logger.Info("BEGIN - DipendenteDelegateImpl method: Update");

            BaseResponse response;
            using (var dbContext = new DbConfig())
            {
                Dipendente dipendente = dbContext.Dipendenti.FirstOrDefault(d => d.id == id);
                try
                {
                    dipendente.nome = dipendenteUp.nome;
                    dipendente.cognome = dipendenteUp.cognome;
                    dipendente.eta = dipendenteUp.eta;
                    dbContext.SaveChanges();
                    response = new BaseResponse(Esito.Succes, EsitoHelper.GetMessage(Esito.Succes));

                    logger.Info("END - DipendenteDelegateImpl method: Update");
                    return new DipendenteResponse(response, dipendente);
                }
                catch (ArgumentNullException ex)
                {
                    logger.Info("Exc - DipendenteDelegateImpl - Create: " + ex.Message);

                    response = new BaseResponse(Esito.NotFound, EsitoHelper.GetMessage(Esito.NotFound));

                    logger.Info("END - DipendenteDelegateImpl method: Update");
                    return new DipendenteResponse(response, dipendente);
                }
                catch (Exception ex)
                {
                    logger.Info("Exc - DipendenteDelegateImpl - Create: " + ex.Message);

                    response = new BaseResponse(Esito.BadRequest, EsitoHelper.GetMessage(Esito.BadRequest));

                    logger.Info("END - DipendenteDelegateImpl method: Update");
                    return new DipendenteResponse(response, null);
                }
            }
        }
    }
}