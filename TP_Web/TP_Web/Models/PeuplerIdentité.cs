using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP_Web.Models
{
    public class PeuplerIdentité
    {
        public static void CréerCompteAdminDéfault(IServiceProvider p_serviceProvider,
                                                   IConfiguration p_configuration)
        {
            //CréerCompteAdminDéfaultAsync(p_serviceProvider, p_configuration).Wait();
        }

        //public static async Task CréerCompteAdminDéfaultAsync(IServiceProvider p_serviceProvider, IConfiguration p_configuration)
        //{
        //    await new NotImplementedException();
        //}
    }
}
