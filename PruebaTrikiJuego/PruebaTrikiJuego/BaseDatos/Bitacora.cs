using System;
using System.Collections.Generic;

namespace PruebaTrikiJuego.BaseDatos
{
    public partial class Bitacora
    {
        public int IdBitacora { get; set; }
        public string NumeroJugador { get; set; }
        public string CasillaSeleccionada { get; set; }
        public string NumeroPartida { get; set; }
    }
}
