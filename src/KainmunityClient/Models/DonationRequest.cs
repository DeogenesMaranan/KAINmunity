using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KainmunityClient.Models
{
    internal class DonationRequest
    {
        public int RequestId { get; set; }
        public int RequesterId { get; set; }
        public int DonationId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
