using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cherwell_example_refactor.Models
{
    public class TriangleList :  ITriangleList
    {
        // holds the list of triangles in the grid
        private List<TriangleObject> triangles;

        public TriangleList()
        {
            // instanciate the list, call the method the generate the list.
            triangles = new List<TriangleObject>();
            generateList();
        }



        private void generateList()
        {

            /* 
             temp values that clean up the assignment when adding coordinates
             x is the x1 coordinate, y is the y1. xeven, xodd, yodd are based on the x
             and y coordinates.
             */

            int x;
            int xe;
            int xo;
            int y;
            int yo;

            // number of rows and columns for the given problem
            int rows = 6;
            int cols = 12;

            for (int i = 1; i <= rows; ++i)
            {
                


                //inner (column) loop
                for (int j = 1; j <= cols; ++j)
                {

                    // calculating the coordinates of the triangle
                    x = 10 * (j / 2);
                    xe = x - 10;
                    xo = x + 10;

                    y = 10 * i;
                    yo = 10 * (i - 1);



                    //even triangles (mirrored from odd triangle)
                    if (j % 2 == 0)
                    {


                        triangles.Add(new TriangleObject
                        {
                            X1 = x,
                            X2 = xe,
                            X3 = x,
                            Y1 = yo,
                            Y2 = yo,
                            Y3 = y,
                            Row = i,
                            Col = j
                            
                        });
                    }
                    else
                    {
                        // odd triangles - A1, A3, B3, ect..
                        triangles.Add(new TriangleObject
                        {
                            X1 = x,
                            X2 = x,
                            X3 = xo,
                            Y1 = y,
                            Y2 = yo,
                            Y3 = y,
                            Row = i,
                            Col = j

                        });
                    }


                }
            }
        }

        public IEnumerable<TriangleObject> GetAll()
        {
            // returns the list of triangles
            return triangles;
        }

        public String Find(TriangleObject item)
        {
            try
            {
                // attempts to find a triangle with the given 
                return triangles.Where(x => x.X1 == item.X1 && x.X2 == item.X2 && x.X3 == item.X3 && x.Y1 == item.Y1 && x.Y2 == item.Y2 && x.Y3 == item.Y3).FirstOrDefault().Name;
            }
            catch (Exception)
            {

                return "";
            }
            
        }

    }
}