﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tvita_Test.Controllers
{
    public class NewsController : TvitaController
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
    }
}