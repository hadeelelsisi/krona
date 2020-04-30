using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
 using korona1.Models;



namespace korona1.Controllers
{ 
    public class KronaController : ApiController
    {
        KronaEntities db = new KronaEntities();
        DateTime end = DateTime.Now;
        DateTime start = DateTime.Now.AddDays(-14);


        [HttpPost]
        public List<int> places(int id)
        {
            List<int> placid = new List<int>();
            for (int i = 0; i < db.place_user.Count(); i++)
            {

                if ((id == db.place_user.ToList()[i].UuserID) && (end >= db.place_user.ToList()[i].Date && db.place_user.ToList()[i].Date >= start))
               
                {
                    placid.Add(db.place_user.ToList()[i].placeID);
                }
            }
            
         return placid.ToList();
    }
       
        [HttpGet]
          public List<int>users(int id)
        {
            List<int> placeid = places(id);
            List<int> Usersid = new List<int>();
            for (int i=0;i<db.place_user.Count();i++)
            {
                for(int j=0;j<placeid.Count();j++)
                {
                    if(db.place_user.ToList()[i].placeID==placeid[j]&& db.place_user.ToList()[i].UuserID!=id)
                    {
                        Usersid.Add(db.place_user.ToList()[i].UuserID);
                    }
                }
            }
            return Usersid.ToList();
        }
            
        
    }
   
}
