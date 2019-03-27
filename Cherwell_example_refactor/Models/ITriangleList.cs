using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cherwell_example_refactor.Models
{
    public interface ITriangleList
    {
        // Simple interface to access the triangle List instance methods

        //Searches for a triangle based on the coordinates and returns the name of the triangle as a string if found. Returns string.empty if not found
        String Find(TriangleObject item);

        //Gets all the triangles in the grid
        IEnumerable<TriangleObject> GetAll();
    }
}