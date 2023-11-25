using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Treatment.Read;
public class ReadTreatmentRequest : IRequest<Domain.Treatments.Treatment[]>;