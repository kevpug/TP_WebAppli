using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TP_Web.Models
{
    public class PeuplerBD
    {
        public static void Peupler(IApplicationBuilder app)
        {
            ContexteAutoLoco contexte = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ContexteAutoLoco>();

            if (contexte.Database.GetPendingMigrations().Any())
                contexte.Database.Migrate();

            if (!contexte.Succursales.Any())
            {
                contexte.Succursales.AddRange(
                        new Succursale
                        {
                            CodeSuccursale = 1,
                            NuméroCivique = 1,
                            CodePostal = "J3H3H3",
                            NomProvince = "Cfrac",
                            NomRue = "Bipbeep",
                            NomVille = "Robot",
                            NuméroTéléphone = "4504504501",
                        },
                        new Succursale
                        {
                            CodeSuccursale = 2,
                            NuméroCivique = 2,
                            CodePostal = "J3H3H4",
                            NomProvince = "Lapbie",
                            NomRue = "Jlzia",
                            NomVille = "Svaq",
                            NuméroTéléphone = "4504504551",
                        },
                        new Succursale
                        {
                            CodeSuccursale = 3,
                            NuméroCivique = 3,
                            CodePostal = "J3H3H5",
                            NomProvince = "KLAKP",
                            NomRue = "Squiartly",
                            NomVille = "BIItanboo",
                            NuméroTéléphone = "4504234501",
                        },
                        new Succursale
                        {
                            CodeSuccursale = 4,
                            NuméroCivique = 4,
                            CodePostal = "J2H3H2",
                            NomProvince = "HAHAHA",
                            NomRue = "OOOOOOSSAM",
                            NomVille = "VilleNomerea",
                            NuméroTéléphone = "1234504501",
                        });
            }
            if (!contexte.Voitures.Any())
            {
                contexte.Voitures.AddRange(
                        new Voiture
                        {
                            NuméroVoiture = 1,
                            EstDisponible = true,
                            Succursale = contexte.Succursales.First(),
                            Année = 2021,
                            Groupe = Voiture.GroupeVoiture.Luxe,
                            Millage = 10000,
                            Modèle = "Kitan X",
                        },
                        new Voiture
                        {
                            NuméroVoiture = 2,
                            EstDisponible = true,
                            Succursale = contexte.Succursales.First(),
                            Année = 2019,
                            Groupe = Voiture.GroupeVoiture.Compact,
                            Millage = 100020,
                            Modèle = "Kitane E",
                        },
                        new Voiture
                        {
                            NuméroVoiture = 3,
                            EstDisponible = true,
                            Succursale = contexte.Succursales.Last(),
                            Année = 2012,
                            Groupe = Voiture.GroupeVoiture.Sedan,
                            Millage = 112020,
                            Modèle = "K-Te",
                        }
                        );
            }
            if (!contexte.Clients.Any())
            {
                contexte.Clients.AddRange(
                            new Client
                            {
                                Prénom = "Régan",
                                Nom = "LeBicou",
                                NuméroPermisConduire = "2A4S2A5G3F1F",
                                NuméroTéléphone = "5146157829",
                            },
                            new Client
                            {
                                Prénom = "Bob",
                                Nom = "Carazan",
                                NuméroPermisConduire = "2K2S6fG3dS",
                                NuméroTéléphone = "5146927829",
                            },
                            new Client
                            {
                                Prénom = "Glitinne",
                                Nom = "Gnoujenta",
                                NuméroPermisConduire = "22A4S212s3F1F",
                                NuméroTéléphone = "5146157821",
                            });
            }

            if (!contexte.Locations.Any())
            {
                contexte.Locations.AddRange(
                    new Location
                    {
                        DateDeLocation = DateTime.Now,
                        SuccursaleDeRetour = contexte.Succursales.First(),
                        Client = contexte.Clients.First(),
                        NombreJoursLocation = 4,
                        Voiture = contexte.Voitures.First()
                    });
            }

            if (!contexte.DossierAccidents.Any())
            {
                contexte.DossierAccidents.AddRange(
                            new DossierAccident
                            {
                                Client = contexte.Clients.First(),
                                DossierFermé = false,
                                RapportAccident = "il allait vite",
                                Voiture = contexte.Voitures.Last()
                            });

            }


        }
    }
}
