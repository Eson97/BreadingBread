using BreadingBread.Common;
using System;

namespace BreadingBread.Infraestructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
