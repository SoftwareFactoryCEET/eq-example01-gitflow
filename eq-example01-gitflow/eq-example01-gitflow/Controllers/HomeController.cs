using eq_example01_gitflow.Interfaces;
using eq_example01_gitflow.Models;
using eq_example01_gitflow.Models.ViewModels;
using eq_example01_gitflow.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace eq_example01_gitflow.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalculable calculable;

        public HomeController(ILogger<HomeController> logger, ICalculable calculable)
        {
            this._logger = logger;
            this.calculable = calculable;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult CalculartorAjax([FromBody] CalculatorViewModel data)
        {
            if (!ModelState.IsValid || data is null)
            {
                return Json(data);
            }
            var operacion = data.Operation;
            decimal result = 0;
            try
            {
                switch (operacion)
                {
                    case "Add":
                        _logger.LogInformation("Performing addition operation...");
                        result = calculable.Add(data.Number1, data.Number2);
                        break;
                    case "Subtract":
                        _logger.LogInformation("Performing subtraction operation...");
                        result = calculable.Subtract(data.Number1, data.Number2);
                        break;
                    case "Multiply":
                        _logger.LogInformation("Performing multiplication operation...");
                        result = calculable.Multiply(data.Number1, data.Number2);
                        break;
                    case "Dividir":
                        _logger.LogInformation("Performing division operation...");
                        result = calculable.Divide(data.Number1, data.Number2);
                        break;
                }
            }
            catch (Exception exception)
            {

                _logger.LogError(exception, "Failed to perform the operation.");
                // Here you can perform some action in case of division by zero, such as display an error message to the user
                ModelState.AddModelError(string.Empty, exception.Message);

                var errorMessages = ModelState.Values
                    .SelectMany(state => state.Errors)
                    .Select(error => error.ErrorMessage);
                // You can use the error messages however you want, for example pass it to the model or display it in the view


                return Json(errorMessages.FirstOrDefault());
            }
            return Json(result);
        }
    }
}