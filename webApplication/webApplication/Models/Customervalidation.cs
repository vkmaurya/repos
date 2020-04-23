using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webApplication.Models
{

    [MetadataType(typeof(CustomerMetadata))]
    public partial class customer
    {
        public class CustomerMetadata
        {


            [DisplayName("CusName")]
            public string custname { get; set; }

            [DisplayName("Address")]
            public string address { get; set; }

            [DisplayName("Mobile")]
            public string mobile { get; set; }
        }
    }
}