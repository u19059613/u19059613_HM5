using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u19059613_HW5.Models
{
    public class booksdetails
    {
        public int BorrowID { get; set; }
        public DateTime Take_Date { get; set; }
        public DateTime Brought_Date { get; set; }
        public Students Borrow_By { get; set; }

    }
}