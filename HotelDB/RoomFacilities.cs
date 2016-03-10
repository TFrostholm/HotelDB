namespace HotelDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RoomFacilities
    {
        public int RoomFacilitiesID { get; set; }

        public int Facility_No { get; set; }

        public int Room_No { get; set; }

        public int Hotel_No { get; set; }

        public virtual Facilities Facilities { get; set; }

        public virtual Room Room { get; set; }
    }
}
