using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudiantes_repositorio.RequestModels
{
    public class CreateEstudiante
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string EstudiantePassword { get; set; } = null!;
    }
}
