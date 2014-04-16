using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using FizzWare.NBuilder;
using KendoGridWebApiOdata.Models;

namespace KendoGridWebApiOdata.Controllers
{
    public class CatsController : ODataController
    {
    static IReadOnlyList<Cat> Cats;
        
        public IQueryable<Cat> Get()
        {
            return BuildTestData();
        }

        private IQueryable<Cat> BuildTestData()
        {
            if (Cats == null)
            {
                
            var items=Builder<Cat>
               .CreateListOfSize(100)
              .All().With(c=>c.MateId=null)
              
               .Build();
            items.Add(Builder<Cat>.CreateNew().With(c=>c.Id=255).With(c=>c.MateId=items[0].Id).With(c=>c.Mate=items[0]).Build());
                Cats = items.ToArray();
            }
            return Cats.AsQueryable();

        }
    }
}