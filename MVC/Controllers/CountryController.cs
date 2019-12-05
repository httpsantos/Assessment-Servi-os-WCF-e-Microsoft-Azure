﻿using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CountryController : Controller
    {
        private readonly string base_url = "http://localhost:58373";

        // GET: Country
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var paises = new List<PaisViewModel>();
            var pais1 = new PaisViewModel();
            var pais2 = new PaisViewModel();
            pais1.PaisId = "1";
            pais1.Nome = "Brasil";
            pais1.FotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/05/Flag_of_Brazil.svg/2000px-Flag_of_Brazil.svg.png";

            pais2.PaisId = "2";
            pais2.Nome = "Uruguai";
            pais2.FotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Flag_of_Uruguay.svg/255px-Flag_of_Uruguay.svg.png";
            paises.Add(pais1);
            paises.Add(pais2);


            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(base_url);

            //    var response = await client.GetAsync("api/Country");

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var responseContent = await response.Content.ReadAsStringAsync();

            //        paises = JsonConvert.DeserializeObject<List<PaisViewModel>>(responseContent);

            //        return View(paises);
            //    }
            //}

            return View(paises);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            var novoPais = new PaisViewModel();

            var data = new Dictionary<string, string>
            {
                {"Nome", collection["Nome"]},
                {"FotoUrl", collection["FotoUrl"]}
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                using (var requestContent = new FormUrlEncodedContent(data))
                {
                    var response = await client.PostAsync("api/Country", requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(id);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(FormCollection collection, string id)
        {
            var data = new Dictionary<string, string>
            {
                {"Nome", collection["Nome"]},
                {"FotoUrl", collection["FotoUrl"]}
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                using (var requestContent = new FormUrlEncodedContent(data))
                {
                    var response = await client.PutAsync("api/Country", requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {
            return View(id);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id, FormCollection collection)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(base_url);

                var response = await client.GetAsync($"api/Country{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            return View(id);
        }

    }
}