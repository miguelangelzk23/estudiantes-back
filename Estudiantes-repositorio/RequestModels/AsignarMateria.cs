using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudiantes_repositorio.RequestModels
{
    public  class AsignarMateria
    {

        public int EstudianteId { get; set; }

        public int MateriaId { get; set; }

        public int ProfesorId { get; set; }
    }
}
