﻿// Written by Kyle Pierson (u0632972) September 2014

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS
{
    /// <summary>
    /// Represents a Cell object, to be used by the Spreadsheet class
    /// </summary>
    public class Cell
    {
        // The contents of the cell and the value of the evaluated contents
        private String contents;
        private String value;

        public Cell()
        {
            contents = "";
            value = "";
        }

        /// <summary>
        /// Sets the contents of this cell
        /// </summary>
        /// <param name="newContents">The object to set as the contents of the cell</param>
        public void setContents(String newContents, String newValue)
        {
            contents = newContents;
            value = newValue;
        }

        /// <summary>
        /// Gets the contents of this cell
        /// </summary>
        /// <returns>The contents of the cell</returns>
        public String getContents()
        {
            return contents;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The value of the specified cell</returns>
        public String getValue()
        {
            return value;
        }
    }
}
