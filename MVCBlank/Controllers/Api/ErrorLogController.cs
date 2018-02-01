using MVCBlank.Filters;
using MVCBlank.Models;
using MVCBlank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCBlank.Controllers.Api
{
    [AuthorizationRequired]
    [RoutePrefix("api/ErrorLogs")]
    public class ErrorLogController : ApiController
    {
        IErrorLogService _errorLogService;
        public ErrorLogController(IErrorLogService errorLogService) {
            _errorLogService = errorLogService;
        }
        [Route(), HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                IEnumerable<ErrorLog> errorLogs = _errorLogService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, errorLogs);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("page/{pageId:int}"), HttpGet]
        public HttpResponseMessage GetByPage(int pageId)
        {
            try
            {
                IEnumerable<ErrorLog> errorLogs = _errorLogService.SelectByPage(pageId);
                return Request.CreateResponse(HttpStatusCode.OK, errorLogs);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
