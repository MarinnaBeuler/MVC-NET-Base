using DbConnector.Tools;
using MVCBlank.Models;
using MVCBlank.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCBlank.Services
{
    public class ErrorLogService : BaseService, IErrorLogService
    {
        public IEnumerable<ErrorLog> SelectAll()
        {
            return Adapter.LoadObject<ErrorLog>("dbo.ErrorLog_SelectAll");
        }

        public ErrorLog SelectById(int id)
        {
            return Adapter.LoadObject<ErrorLog>("dbo.ErrorLog_SelectById", new[] 
            {
                new SqlParameter("@Id", id)
            }).FirstOrDefault();//function always returns a collection so .FirstOrDefault returns the first object
        }
        public int Insert(ErrorLogAddRequest model)
        {
            int id = 0;
            Adapter.ExecuteQuery("dbo.ErrorLog_Insert", new[]
            {
                SqlDbParameter.Instance.BuildParameter("@Title", model.Title, System.Data.SqlDbType.NVarChar, 150),
                SqlDbParameter.Instance.BuildParameter("@Message", model.Message, System.Data.SqlDbType.NVarChar, 4000),
                SqlDbParameter.Instance.BuildParameter("@StackTrace", model.StackTrace, System.Data.SqlDbType.VarChar, -1),
                SqlDbParameter.Instance.BuildParameter("@ErrorSourceTypeId", model.ErrorSourceTypeId, System.Data.SqlDbType.Int),
                SqlDbParameter.Instance.BuildParameter("@Id", 0, System.Data.SqlDbType.Int,paramDirection: System.Data.ParameterDirection.Output)
            },
            (parameters => {
                id = parameters.GetParamValue<int>("@Id");
                //int.TryParse(parameters[4].Value.ToString(), out id);
            }));
            return id;
        }
        public int Delete(int id)
        {
            return Adapter.ExecuteQuery("dbo.ErrorLog_Delete", new[]
            {
                SqlDbParameter.Instance.BuildParameter("@Id", id, System.Data.SqlDbType.Int)
            });
        }
        public IEnumerable<ErrorLog> SelectByPage(int page)
        {
            return Adapter.LoadObject<ErrorLog>("dbo.ErrorLog_PaginatedSearch", new[]{
                SqlDbParameter.Instance.BuildParameter("@PageNumber", page, System.Data.SqlDbType.Int)
                });
        }
    }
}