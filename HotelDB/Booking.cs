namespace HotelDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int Booking_id { get; set; }

        public int Hotel_No { get; set; }

        public int Guest_No { get; set; }

        [Required]
        [StringLength(50)]
        public string Date_From { get; set; }

        [Required]
        [StringLength(50)]
        public string Date_To { get; set; }

        public int Room_No { get; set; }

        public virtual Room Room { get; set; }

        public virtual Guest Guest { get; set; }
    }
}
