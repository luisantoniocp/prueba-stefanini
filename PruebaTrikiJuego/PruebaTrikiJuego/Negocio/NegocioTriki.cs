using PruebaTrikiJuego.AccesoDatos;
using PruebaTrikiJuego.ModelosVista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTrikiJuego.Negocio
{
    public class NegocioTriki
    {
        public bool RegistrarGanador(string numeroJugadorGanador, string nombreGanador, string nombrePerdedor)
        {

            try
            {
                Jugador jugadorGanador = new Jugador
                {
                    Nombres = nombreGanador
                };
                Jugador jugadorPerdedor = new Jugador
                {
                    Nombres = nombrePerdedor
                };
                AccesoDatosTriki accesoDatos = new AccesoDatosTriki();
                accesoDatos.RegistrarJugador(jugadorPerdedor);
                var idJugador = accesoDatos.RegistrarJugador(jugadorGanador);
                Ganador ganador = new Ganador
                {
                    JugadorId = idJugador,
                    NumeroJugador = numeroJugadorGanador
                };

                return accesoDatos.RegistrarGanador(ganador);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RegistrarBitacora(BitacoraVista bitacora)
        {
            try
            {
                AccesoDatosTriki accesoDatos = new AccesoDatosTriki();
                return accesoDatos.RegistrarBitacora(bitacora);

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

