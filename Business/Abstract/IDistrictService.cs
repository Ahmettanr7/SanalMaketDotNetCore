﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDistrictService
    {
        IDataResult<List<District>> GetByTownId(int townId);
    }
}
