using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class UserBin : IEnumerable
    {
        public List<Device> Bin { get; set; }
        public Device Offer { get; set; }

        public UserBin()
        {
            Bin ??= new List<Device>();
        }

        public UserBin(List<Device> bin, Device offer)
        {
            Bin = bin;
            Offer = offer;
        }
        public IEnumerator GetEnumerator()
        {
            return Bin.GetEnumerator();
        }
    }
}
