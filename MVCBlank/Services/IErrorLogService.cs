using System.Collections.Generic;
using MVCBlank.Models;
using MVCBlank.Models.Requests;

namespace MVCBlank.Services
{
    public interface IErrorLogService
    {
        int Delete(int id);
        int Insert(ErrorLogAddRequest model);
        IEnumerable<ErrorLog> SelectAll();
        ErrorLog SelectById(int id);
        IEnumerable<ErrorLog> SelectByPage(int page);
    }
}