using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Management.Models
{
    public class RoomModel
    {
        public int room_id { get; set; }
        public DateTime check_in { get; set; }
        public DateTime check_out { get; set; }
        public int cust_id { get; set; }
        public int room_no { get; set; }
     }
}