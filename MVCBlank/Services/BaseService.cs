using DbConnector.Adapter;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCBlank.Services
{
    public abstract class BaseService
    {
        public DbAdapter Adapter
        {
            get
            {
                return new DbAdapter(new SqlCommand(), new SqlConnection("Server= 13.64.246.7; Database=C45_LeaseHold;User Id = C45_User; Password=Sabiopass1!"));
            }
            
        }
    }
}