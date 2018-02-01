using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DbConnector.Adapter;
using DbConnector.Tools;
using MVCBlank.Models;

namespace MVCBlank.Services
{
    public class StateProvinceService : BaseService
    {

        public IEnumerable<StateProvince> SelectAll()
        {
            return Adapter.LoadObject<StateProvince>("dbo.StateProvince_SelectAll");
        }
    }
}