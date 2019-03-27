using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cherwell_example_refactor.Models
{
    public class TriangleObject
    {

        // object representation of the triangles in the grid

        //row and column numeric values
        // row and column are used to produce name
        public int Row { get; set; }
        public int Col { get; set; }
        
        public string Name
        {
            /*
             Converts row number to alpabetic row name like excel columns A, B, AA,  AB ect..
             Appends column number to alphabetic row name to create a triangle name 
             */
            get {

                int dividend = Row;
                string rowName = String.Empty;
                int mod;

                while (dividend > 0)
                {
                    mod = (dividend - 1) % 26;
                    rowName = Convert.ToChar(65 + mod).ToString() + rowName;
                    dividend = (int)((dividend - mod) / 26);
                }

                // appends the column name to the row letter(s) to give the name of the triangle "A1, B2, AA1, ect"
                rowName = rowName + Col.ToString();

                return rowName;
            }
        }

        // Coordinate values of Triangle
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int X3 { get; set; }

        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int Y3 { get; set; }

    }
}