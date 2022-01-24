using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EventoController : ControllerBase
  {
    public IEnumerable<Evento> _evento = new Evento[]
    {
        new Evento(){
          EventoId = 1,
          Tema = "Angular 11 e .Net 5 - Desenvolvimento Web",
          Local = "São Paulo",
          Lote = "1° Lote",
          QtdPessoas = 200,
          DataEvento = DateTime.Now.ToString("dd/MM/yyyy"),
          ImagemURL = "http://www.google.com.br"
        },
        new Evento(){
            EventoId = 2,
            Tema = "Angular 11 e .Net 5 - Desenvolvimento Web",
            Local = "São Paulo",
            Lote = "1° Lote",
            QtdPessoas = 200,
            DataEvento = DateTime.Now.ToString("dd/MM/yyyy"),
            ImagemURL = "http://www.google.com.br"
        },
      };

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _evento;
    }
  }
}