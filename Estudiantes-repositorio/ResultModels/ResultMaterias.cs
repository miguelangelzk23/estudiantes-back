using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudiantes_repositorio.ResultModels
{
    public class ResultMaterias
    {
        public int IdMateria { get; set; }
        public string MateriaNombre { get; set; } 
        public int IdProfesor { get; set; }
        public bool Seleccionada { get; set; }
    }
}
