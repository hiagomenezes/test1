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
        [HttpGet]
        public ActionResult IncluirTime()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirTime(Times TimeObj)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _repositorio = new TimeRepositorio();

                    if (_repositorio.AdicionarTime(TimeObj))
                    {
                        ViewBag.Mensagem = "Time cadastrado com sucesso";
                    }

                }

                return View();
            }
            catch (Exception)
            {
                return View("ObterTimes");
            }

        }

        public ActionResult EditarTime(int id)
        {
            _repositorio = new TimeRepositorio();
            return View(_repositorio.ObterTimes().Find(t => t.TimeId == id)); 
        }

        [HttpPost]
        public ActionResult EditarTime(int id, Times TimeObj)
        {
            try
            {

                _repositorio = new TimeRepositorio();
                _repositorio.AtualizarTime(TimeObj);

                return RedirectToAction("ObterTimes");
            }
            catch (Exception)
            {
                return View("ObterTime");
            }
        }

        public ActionResult Excluir(int id)
        {
            try
            {
                _repositorio = new TimeRepositorio();
                if (_repositorio.ExcluirTime(id)) 
                {
                    ViewBag.Mensagem = "Time excluido com sucesso";
                }

                return RedirectToAction("IncluirTime");
            }


            catch (Exception)
            {
                return RedirectToAction("IncluirTime");
            }




        }
    }
}     
    





                
            
