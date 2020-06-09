using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VKHospital.VwModel
{
    public partial class VwMoceldata
    {
        public int PatientSelectSickID { get; set; }

        public int? PatientID { get; set; }

        public int? DoctorID { get; set; }

        public int? SickID { get; set; }

        public bool? IsValid { get; set; }

        public int? CreatedByID { get; set; }

        public DateTime? CreateByDate { get; set; }

        public int? ModifyByID { get; set; }

        public DateTime? ModifyBYDate { get; set; }

        public int? DeletedByID { get; set; }

        public DateTime? DeleteByDate { get; set; }

        public int SickTypeID { get; set; }

     
        public string SickTypeName { get; set; }

        public int? DoctorTypeID { get; set; }

        public string PatientName { get; set; }

        public string SSNumber { get; set; }

        public DateTime? DOB { get; set; }

        public string Gander { get; set; }

    
        public string PhoneNumber { get; set; }

      
        public string Email { get; set; }

    
        public string Address { get; set; }

        public string Password { get; set; }

        public string DoctorTypeName { get; set; }

    
        public int DoctorId { get; set; }

        public string DoctorName { get; set; }

        public int AppointmentId { get; set; }

        public DateTime? AppointmentDateStart { get; set; }

 
        public DateTime? AppointmentDateEnd { get; set; }

        public bool? AppointmentStatus { get; set; }


        public string AppointmentPatientSession { get; set; }

        public DateTime? AppointmentBookingDate { get; set; }

     


    }
}