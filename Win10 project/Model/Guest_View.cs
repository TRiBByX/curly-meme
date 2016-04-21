namespace Win10WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Guest_View
    {
        [Key]
        [StringLength(30)]
        public string Name { get; set; }

        public int? Bookings { get; set; }
    }
}
