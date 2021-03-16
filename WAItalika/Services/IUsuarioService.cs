using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAItalika.Models.Services
{
    interface IUsuarioService
    {
        UsuarioResponse Response(AuthRequest auth);
    }
}
