using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music_Library_ManagementSystem.Models
{
    public class MediaRecordsVm
    {
        //costomer Id
        public int Id { get; set; }

        //------------------------------
        public int? MediaId { get; set; }

        public int? CustomerId { get; set; }

        //----------------------------

        public string AuthorName { get; set; }

     
        public string CategoryName { get; set; }

        public string CategoryNumber { get; set; }

  
        public string Title { get; set; }


        public string Description { get; set; }


        public string Price { get; set; }


        //--------------------------------------------------------------


        public string MediaIdm { get; set; }

    
        public string TotalAmount { get; set; }

        public string Address { get; set; }

  
        public string Contact { get; set; }


        //-----------------------------------------------------------------------------------


    }
}