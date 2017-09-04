﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    class PopulateRowsException : Exception
    {        
        public PopulateRowsException(FacebookDataTable i_Sender, Exception i_InnerException)
            : base(string.Format("Exception while populating {0} data table: {1}", i_Sender.TableName, i_InnerException.Message))
        {
        }
    }
}