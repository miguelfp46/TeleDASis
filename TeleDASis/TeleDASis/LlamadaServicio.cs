﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleDASis
{
    class LlamadaServicio
    {
        public int idLlamada;
        public int idServicios;

        public LlamadaServicio(int idLlamada, int idServicios)
        {
            this.idLlamada = idLlamada;
            this.idServicios = idServicios;
        }
    }
}
