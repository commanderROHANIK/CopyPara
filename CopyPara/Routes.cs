using CopyPara.Application.Patient.Create;
using CopyPara.Endpoints;
using MediatR;

namespace CopyPara;

public static class Routes
{
    public static void MapRoutes(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("patient", Patient.Create);
    }
}
