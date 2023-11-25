using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Treatment.Create
{
    public sealed class CreateTreatmentRequest : IRequest<string>
    {
        public int AvgTimeMins { get; init; }
        public ulong PatientId { get; init; }
        public ulong CancerId {  get; init; }
    }
}
