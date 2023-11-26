using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyPara.Application.Utilization.Read;

    public record ReadUtiRequest(DateTime Start, DateTime End) : IRequest<List<int>>;

