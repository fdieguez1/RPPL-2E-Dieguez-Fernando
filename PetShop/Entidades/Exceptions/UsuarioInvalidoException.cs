﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class UsuarioInvalidoException : Exception
    {
        public UsuarioInvalidoException(string message) : base(message)
        {

        }
    }
}
