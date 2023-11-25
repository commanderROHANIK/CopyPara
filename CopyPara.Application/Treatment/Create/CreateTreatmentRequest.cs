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
        public float Weight { get; init; }
        public DateTime StartDate { get; init; }
        public int Fraction { get; init; }
        public DateTime? UrgentTreatmentTime { get; init; }
        public bool CanHoldBreath { get; init; }


    }
}
