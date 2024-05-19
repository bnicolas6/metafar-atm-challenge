using Metafar.ATM.Challenge.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Metafar.ATM.Challenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMemoryCacheRepository _memoryCacheRepository;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IConfiguration _configuration;

        private string KEY = "A";
        private int LIMITE = 3;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger, 
            IMemoryCacheRepository memoryCacheRepository, 
            ITokenGenerator tokenGenerator,
            IConfiguration configuration)
        {
            _logger = logger;
            _memoryCacheRepository = memoryCacheRepository;
            _tokenGenerator = tokenGenerator;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            if(_memoryCacheRepository.TryGetItem(KEY, out Contador contador))
            {
                if(contador.Conteo + 1 == LIMITE)
                {
                    _memoryCacheRepository.Delete(KEY);
                }
                else
                {
                    contador.Conteo++;
                    _memoryCacheRepository.Update(KEY, contador);
                }
            }
            else
            {
                _memoryCacheRepository.Insert(KEY, new Contador());
            }    

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name = "GetWeatherForecast2")]
        public string GetJwt()
        {
            var response = _tokenGenerator.GenerateToken(new Dictionary<string, string>
            {
                { "NumeroDeTarjeta", "1234567890X" }
            });

            return response;
        }

        [HttpPatch(Name = "GetWeatherForecast3")]
        [Authorize]
        public IActionResult OtroGet()
        {
            var numeroDeTarjeta = User.GetNumeroDeTarjetaClaim();

            return Ok($"Token JWT válido, numeroDeTarjeta: ${numeroDeTarjeta}");
        }
    }



    public class Contador
    {
        public int Conteo { get; set; } = 1;
    }
}
