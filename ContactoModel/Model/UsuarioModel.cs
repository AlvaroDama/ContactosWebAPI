﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactoModel.Model
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Foto { get; set; }
    }
}
