using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Services
{
    public interface IStavkePortfoliumService : ICRUDService<FrizerskiSalon.Modal.StavkePortfolium, StavkePortfoliumSearchObject, StavkePortfoliumInsertRequest, StavkePortfoliumInsertRequest>
    {
    }
}
