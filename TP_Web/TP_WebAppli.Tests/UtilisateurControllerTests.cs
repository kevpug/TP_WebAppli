using TP_Web.Controllers;
using TP_Web;
using Xunit;
using TP_Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace TP_WebAppli.Tests
{
    public sealed class UtilisateurControllerTests : ReadMe
    {


        //DbContextOptions<ContexteAutoLoco> p_optionsAutoLoco = new DbContextOptionsBuilder<ContexteAutoLoco>()
        //    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AutoLoco;MultipleActiveResultSets=True")
        //    .Options;
        //DbContextOptions<ContexteIdentité> p_optionsIdentité = new DbContextOptionsBuilder<ContexteIdentité>()
        //    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=IdentityUtilisateur;Trusted_Connection=True; MultipleActiveResultSets=True")
        //    .Options;

        //var contextAutoLoco = new ContexteAutoLoco(p_optionsAutoLoco);
        //var contexteIdentité = new ContexteIdentité(p_optionsIdentité);
        //IDépôt dépôt = new DépôtEF(contextAutoLoco, contexteIdentité);


        



    }
}
