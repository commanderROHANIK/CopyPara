using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Occasion.Create
{
    public sealed class CreateOccasionRequest : IRequest<string>
    {
        public ulong Id { get; set; }
        public DateTime Date { get; set; }
        public ulong MachineId { get; set; }
        public ulong TreatmentId { get; set; }
    }
}
