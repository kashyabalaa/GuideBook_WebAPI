using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGuideWebAPI.Controllers
{
   
    public class guideBookController : ApiController
    {
        public IEnumerable<GuideBook> Get()
        {
            using (SmartFaceEntities entities = new SmartFaceEntities())
            {
                return entities.GuideBooks.ToList();
            }
        }
        public HttpResponseMessage Get(string id)
        {
            using (SmartFaceEntities entities = new SmartFaceEntities())
            {
                var entity1 = entities.GuideBooks.Where(gb => gb.GuideBook1 == id).ToList();
                if (entity1 != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity1);
                }
                else { return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Guide Book not found for the selection"); }
            }
        }
        //public HttpResponseMessage Get(int id)
        //{
        //    using (SmartFaceEntities entities = new SmartFaceEntities())
        //    {
        //        var entity1 = entities.GuideBooks.FirstOrDefault(e => e.RSN == id);
        //        if (entity1 != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity1);
        //        }
        //        else { return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Guide Book not found for the selection"); }
        //    }
        //}
        public HttpResponseMessage Post([FromBody]GuideBook guideBook)
        {
            try
            {
                using (SmartFaceEntities entities = new SmartFaceEntities())
                {
                    entities.GuideBooks.Add(guideBook);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, guideBook);
                    message.Headers.Location = new Uri(Request.RequestUri + guideBook.RSN.ToString());
                    return message;
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (SmartFaceEntities entities = new SmartFaceEntities())
                {
                    var entity = entities.GuideBooks.FirstOrDefault(e => e.RSN == id);
                    if (entity == null)
                    { return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book Id = " + id.ToString() + " not found to delete"); }
                    else
                    {
                        entities.GuideBooks.Remove(entity);
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
