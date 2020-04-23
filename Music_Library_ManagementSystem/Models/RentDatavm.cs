using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Library_ManagementSystem.Models
{
    public class RentDatavm
    {

        public int? CustomerId { get; set; }


        public string CustomerName { get; set; }

        public string MediaId { get; set; }


        public string TotalAmount { get; set; }

   
        public string Address { get; set; }

     
        public string Contact { get; set; }

        public DateTime? Startdate { get; set; }

        public DateTime? Enddate { get; set; }

        public int? Createdby_Id { get; set; }

        public DateTime? Createdby_Date { get; set; }

        public int? Modifiedby_Id { get; set; }

        public DateTime? Modifiedby_Date { get; set; }

        public int? Deleteby_Id { get; set; }

        public DateTime? Deleteby_Date { get; set; }

        public bool? Status { get; set; }



        public List<int> Id { get; set; }




    }
}