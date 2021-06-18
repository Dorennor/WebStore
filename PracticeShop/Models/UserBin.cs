using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class UserBin
    {
        public List<Device> Bin { get; set; }
        public Device Offer { get; set; }

        public UserBin(List<Device> bin, Device offer)
        {
            Bin = bin;
            Offer = offer;
        }
    }
}
