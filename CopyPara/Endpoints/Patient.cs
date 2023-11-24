using CopyPara.Application.Patient.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CopyPara.Endpoints;

public static class Patient
{
    public static async Task<Results<Ok<string>, BadRequest>> Create(ISender sender, CancellationToken cancellationToken)
    {
        string message = await sender.Send(new CreatePatientRequest(), cancellationToken);

        return TypedResults.Ok(message);
    }
}
