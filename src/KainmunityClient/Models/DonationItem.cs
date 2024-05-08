using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KainmunityClient.Models
{
    internal class DonationItem
    {
        public int DonationId { get; set; }
        public int DonorId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string ExpiryDate { get; set; }
    }
}
