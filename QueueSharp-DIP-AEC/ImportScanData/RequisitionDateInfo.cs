using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImportScanData
{
    public class RequisitionDateInfo
    {
        DateTime _FILING_DATE = new DateTime(1,1,1);
        DateTime _RECEIVE_DATE = new DateTime(1, 1, 1);

        public DateTime FILING_DATE {
           get { return _FILING_DATE; }
           set { _FILING_DATE = value; }
        }
        public DateTime RECEIVE_DATE {
            get { return _RECEIVE_DATE; }
            set { _RECEIVE_DATE = value; }
        }

    }
}
