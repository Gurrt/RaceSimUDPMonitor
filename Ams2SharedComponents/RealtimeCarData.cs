using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams2SharedComponents
{
    [MessagePackObject]
    public class RealtimeCarData
    {
        [Key(0)]
        public float Speed;
        [SerializationConstructor]
        public RealtimeCarData()
        {

        }
    }
}
