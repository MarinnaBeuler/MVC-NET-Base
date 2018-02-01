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
                return new DbAdapter(new SqlCommand(), new SqlConnection(@"Server=localhost\SQLEXPRESS;User Instance=true;Integrated Security=true;Database=PersonalProject;"));
            }
            
        }
    }
}