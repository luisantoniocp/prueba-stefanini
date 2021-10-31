using PruebaTrikiJuego.BaseDatos;
using PruebaTrikiJuego.ModelosVista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTrikiJuego.AccesoDatos
{
    public class AccesoDatosTriki
    {
        public int RegistrarJugador(Jugador jugador)
        {
            try
            {
                BaseDatosTrikiContext baseDatosTrikiContext = new BaseDatosTrikiContext();
                Jugadores jugadorBaseDatos = new Jugadores
                {
                    Nombres = jugador.Nombres,
                };
                baseDatosTrikiContext.Jugadores.Add(jugadorBaseDatos);
                baseDatosTrikiContext.SaveChanges();
                return baseDatosTrikiContext.Jugadores.Local.FirstOrDefault().IdJugador;
            }
            catch (Exception)
            {
                return 0;
            }            
        }

        public bool RegistrarGanador(Ganador ganador)
        {
            try
            {
                BaseDatosTrikiContext baseDatosTrikiContext = new BaseDatosTrikiContext();
                Ganadores ganadore = new Ganadores
                {
                    JugadorId = ganador.JugadorId,
                    NumeroJugador = ganador.NumeroJugador
                };
                baseDatosTrikiContext.Ganadores.Add(ganadore);
                baseDatosTrikiContext.SaveChanges();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool RegistrarBitacora(BitacoraVista bitacora)
        {
            try
            {
                BaseDatosTrikiContext baseDatosTrikiContext = new BaseDatosTrikiContext();
                Bitacora bitacoraDatos = new Bitacora
                {
                    CasillaSeleccionada = bitacora.CasillaSeleccionada,
                    NumeroJugador = bitacora.NumeroJugador,
                    NumeroPartida = bitacora.NumeroPartida
                };
                baseDatosTrikiContext.Bitacora.Add(bitacoraDatos);
                baseDatosTrikiContext.SaveChanges();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}

