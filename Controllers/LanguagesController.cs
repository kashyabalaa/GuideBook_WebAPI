using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGuideWebAPI.Controllers
{
    [RoutePrefix("api/Language")]
    public class languagesController : ApiController
    {
        public IEnumerable<Language> Get()
        {
            using (SmartFaceEntities entities = new SmartFaceEntities())
            {
                return entities.Languages.ToList();
            }
        }

        public HttpResponseMessage Get(string id)
        {
            using (SmartFaceEntities entities = new SmartFaceEntities())
            {
                var entity1 = entities.Languages.FirstOrDefault(e => e.Language_Code == id);
                if (entity1 != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity1);
                }
                else { return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Language not found for the selection"); }
            }
        }
    }
}
