﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, ETRADE4Context>, IOrderDal
    {
    }
}
