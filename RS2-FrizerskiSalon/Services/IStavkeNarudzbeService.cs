﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrizerskiSalon.Modal.Requests;
using FrizerskiSalon.Modal.SearchObjects;

namespace RS2_FrizerskiSalon.Services
{
    public interface IStavkeNarudzbeService : ICRUDService<FrizerskiSalon.Modal.StavkeNarudzbe, StavkeNarudzbeSearchObject, StavkeNarudzbeInsertRequest, StavkeNarudzbeUpdateRequest>
    {
    }
}
