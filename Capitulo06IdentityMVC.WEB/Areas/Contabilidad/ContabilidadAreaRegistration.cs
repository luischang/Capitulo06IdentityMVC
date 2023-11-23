﻿using System.Web.Mvc;

namespace Capitulo06IdentityMVC.WEB.Areas.Contabilidad
{
    public class ContabilidadAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Contabilidad";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Contabilidad_default",
                "Contabilidad/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}