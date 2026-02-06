using alertingSystemBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;

public static class AlerteEndpoints
{
    public static void MapAlerteEndpoints(this IEndpointRouteBuilder app)
    {
        // GET /alertes
        app.MapGet("/alertes", async (IAlerteServicePostgres service) =>
        {
            var alertes = await service.getAllAlertesAsync();
            return Results.Ok(alertes);
        });

        // GET /alertes/{id}
        app.MapGet("/alertes/{id:long}", async (long id, IAlerteServicePostgres service) =>
        {
            var alerte = await service.getAlerteByIdAsync(id);
            return alerte is null ? Results.NotFound() : Results.Ok(alerte);
        });

        // POST /alertes
        app.MapPost("/alertes", async (
            Alert alerte,
            IAlerteServicePostgres service,
            ApplicationDBContext db) =>
        {
            alerte.DateCreation = DateTime.UtcNow;

            // 🔴 CAS IMPORTANT : responsable déjà existant
            if (alerte.ResponsableActuel != null)
            {
                var user = await db.Users
                    .FirstOrDefaultAsync(u => u.Id == alerte.ResponsableActuel.Id);

                if (user == null)
                    return Results.BadRequest("ResponsableActuel inexistant");

                // 🔑 on rattache l’utilisateur existant
                alerte.ResponsableActuel = user;
            }

            await service.addAlerteAsync(alerte);
            return Results.Created($"/alertes/{alerte.Id}", alerte);
        });

        // PUT /alertes/{id}
        app.MapPut("/alertes/{id:long}", async (
            long id,
            Alert input,
            IAlerteServicePostgres service,
            ApplicationDBContext db) =>
        {
            var existing = await service.getAlerteByIdAsync(id);
            if (existing is null)
                return Results.NotFound();

            existing.Titre = input.Titre;
            existing.Description = input.Description;
            existing.TypeAlerte = input.TypeAlerte;
            existing.Criticite = input.Criticite;
            existing.StatutAlert = input.StatutAlert;
            existing.NiveauEscaladeActuel = input.NiveauEscaladeActuel;
            existing.DateNotification = input.DateNotification;
            existing.DateEscaladeN1 = input.DateEscaladeN1;
            existing.DateEscaladeN2 = input.DateEscaladeN2;
            existing.DatePriseEnCharge = input.DatePriseEnCharge;
            existing.DateResolution = input.DateResolution;
            existing.Metadata = input.Metadata;
            existing.SourceId = input.SourceId;

            if (input.ResponsableActuel != null)
            {
                var user = await db.Users
                    .FirstOrDefaultAsync(u => u.Id == input.ResponsableActuel.Id);

                if (user == null)
                    return Results.BadRequest("ResponsableActuel inexistant");

                existing.ResponsableActuel = user;
            }

            await service.updateAlerteAsync(existing);
            return Results.Ok(existing);
        });

        // DELETE /alertes/{id}
        app.MapDelete("/alertes/{id:long}", async (long id, IAlerteServicePostgres service) =>
        {
            var existing = await service.getAlerteByIdAsync(id);
            if (existing is null)
                return Results.NotFound();

            await service.deleteAlerteAsync(id);
            return Results.NoContent();
        });
    }
}
