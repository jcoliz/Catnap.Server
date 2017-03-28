using Catnap.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Catnap.Sample.Controllers
{
    [RoutePrefix("status")]
    class StatusController : Controller
    {
        private SynchronizationContext Context = SynchronizationContext.Current;

        [HttpGet]
        [Route]
        public HttpResponse Get()
        {
            Context.Post(_ => App.Log.Add("status"), null);            
            return new HttpResponse(HttpStatusCode.Ok, "Test#1");
        }

        [HttpPost]
        [Route("start")]
        public HttpResponse Start([Body] string postContent)
        {
            Context.Post(_ => App.Log.Add("status/start"), null);
            return new HttpResponse(HttpStatusCode.Ok, $"Test#4:{postContent}");
        }

        [HttpPost]
        [Route("stop")]
        public HttpResponse Stop([Body] string postContent)
        {
            Context.Post(_ => App.Log.Add("status/stop"), null);
            return new HttpResponse(HttpStatusCode.Ok, $"Test#4:{postContent}");
        }
    }

}
