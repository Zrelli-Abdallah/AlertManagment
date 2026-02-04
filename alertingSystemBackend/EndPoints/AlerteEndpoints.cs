public static class AlerteEndpoints
{
    public static void MapAlerteEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/alertes",() =>
        {
            return Results.Ok("Alertes End Point is working properly");
        });
    }
}