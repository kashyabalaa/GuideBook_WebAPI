using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGuideWebAPI.Controllers
{
       public class guidePostIDController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            using (SmartFaceEntities entities = new SmartFaceEntities())
            {
                var entity1 = entities.GuideBooks.Where(gb=>gb.GuidePostId==id).ToList();
                if (entity1 != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity1);
                }
                else { return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Guide Book not found for the selection"); }
            }
        }
    }
}
