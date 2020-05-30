using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGuideWebAPI.Controllers
{
    public class enabledController : ApiController
    {
        public HttpResponseMessage Get(bool id)
        {
            using (SmartFaceEntities entities = new SmartFaceEntities())
            {
                var entity1 = entities.GuideBooks.Where(gb => gb.Enabled == id).ToList();
                if (entity1 != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity1);
                }
                else { return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Guide Book not found for the selection"); }
            }
        }
        public HttpResponseMessage Delete(bool id)
        {
            try
            {
                using (SmartFaceEntities entities = new SmartFaceEntities())
                {
                    var entity = entities.GuideBooks.Where(e => e.Enabled == id).ToList();
                    if (entity == null)
                    { return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record(s) not found to delete"); }
                    else
                    {
                        foreach (var gb in entities.GuideBooks)
                        { entities.GuideBooks.Remove(gb); }
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
