using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class AprioriStats
    {
        public double Support { get; set; } = default;
        public double Confidence { get; set; } = default;
        public double Lift { get; set; } = default;
        public Device Device { get; set; } = default;


    }
}
