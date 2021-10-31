using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PruebaTrikiJuego.ModelosVista;
using PruebaTrikiJuego.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTrikiJuego.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnGetIniciarPartida(string nombre1, string nombre2)
        {
            var model = true;
            string json = JsonConvert.SerializeObject(model);
            return new JsonResult(json);
        }
        public IActionResult OnGetRegistrarBitacora(string numeroJugador,
            string casillaSeleccionada, string numeroPartida)
        {
            NegocioTriki _negocioTriki = new NegocioTriki();
            BitacoraVista bitacora = new BitacoraVista
            {
                NumeroPartida = numeroPartida,
                NumeroJugador = numeroJugador,
                CasillaSeleccionada = casillaSeleccionada

            };
            var model = _negocioTriki.RegistrarBitacora(bitacora);
            string json = JsonConvert.SerializeObject(model);
            return new JsonResult(json);
        }
        public IActionResult OnGetRegistrarGanador(string numeroJugadorGanador,
            string nombreJugadorUno, string nombreJugadorDos)
        {
            var resultado=false;
            NegocioTriki _negocioTriki = new NegocioTriki();
            if (numeroJugadorGanador=="jugador1")
            {
                resultado=_negocioTriki.RegistrarGanador(numeroJugadorGanador, nombreJugadorUno, nombreJugadorDos);
            }
            else{
                resultado= _negocioTriki.RegistrarGanador(numeroJugadorGanador, nombreJugadorDos, nombreJugadorUno);
            }

            var model = resultado;
            string json = JsonConvert.SerializeObject(model);
            return new JsonResult(json);
        }
        public IActionResult OnPostAsync()
        {

            return RedirectToPage("./Index");
        }
    }
}
