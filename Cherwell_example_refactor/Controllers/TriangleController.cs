using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cherwell_example_refactor.Models;


namespace Cherwell_example_refactor.Controllers
{
    [Route("api/[controller]")]
    public class TriangleController : Controller
    {
        // instance of triangle list interface
        private readonly ITriangleList triangles;


        // the constructor sets the interface instance to the existing list 
        public TriangleController(ITriangleList triangles)
        {
            this.triangles = triangles;
        }

        // Get all triangles (to draw the grid)
        [HttpGet]
        public IEnumerable<TriangleObject> Get()
        {
            return triangles.GetAll();
        }

        // Search for a Particular triangle based on input coordinates
        // the input url begins with api/Search?
        [HttpGet("Search")]
        public ActionResult Search(string X1, string X2, string X3, string Y1, string Y2, string Y3)
        {
            string triName;
            TriangleObject item = new TriangleObject
            {
                X1 = Convert.ToInt32(X1),
                X2 = Convert.ToInt32(X2),
                X3 = Convert.ToInt32(X3),
                Y1 = Convert.ToInt32(Y1),
                Y2 = Convert.ToInt32(Y2),
                Y3 = Convert.ToInt32(Y3),
            };
            try
            {
                //searches linq list for a triangle with matching coordinates
                //and returns the name if found
                triName = triangles.GetAll().Where(x => x.X1 == item.X1 && x.X2 == item.X2 && x.X3 == item.X3 && x.Y1 == item.Y1 && x.Y2 == item.Y2 && x.Y3 == item.Y3).FirstOrDefault().Name;
                return Content(triName);
            }
            catch (Exception)
            {
                // returns empty string if no match
                return Content("");

            }


        }
    }
    
}