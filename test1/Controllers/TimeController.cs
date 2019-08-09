using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test1.fonts.Repositorio;
using test1.Models;

namespace test1.Controllers
{
    public class TimeController : Controller
    {
        private TimeRepositorio _repositorio;

        [HttpGet]
        public ActionResult ObterTimes()
        {

            _repositorio = new TimeRepositorio();

            ModelState.Clear();
            return View(_repositorio.ObterTimes());
        }

        public ActionResult IncluirTime()
        {

        }

        [HttpPost]
        public ActionResult IncluirTime(Times TimeObj)
        {

        }
    }
}