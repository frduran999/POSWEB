﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PosWeb.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult SesionExpirada()
        {
            return View();
        }
    }
}
