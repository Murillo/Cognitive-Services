﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComputerVision.Models;
using ComputerVision.ViewModel;
using ComputerVision.Api;
using Newtonsoft.Json;

namespace ComputerVision.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View(new AnalysisViewModel());

        [HttpPost]
        public async Task<IActionResult> Index(string image)
        {
            var key = "<KEY>";
            var uriBase = "https://brazilsouth.api.cognitive.microsoft.com/vision/v1.0/analyze";

            var customVision = new ComputerVisionAnalysis(uriBase, key);
            var result = JsonConvert.DeserializeObject<AnalysisViewModel>(
                await customVision.MakeAnalysis(image));
            return View("Index", result);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
