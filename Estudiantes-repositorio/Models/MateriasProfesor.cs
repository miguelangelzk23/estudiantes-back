using System;
using System.Collections.Generic;

namespace Estudiantes_repositorio.Models;

public partial class MateriasProfesor
{
    public int MateriaProfesorId { get; set; }

    public int ProfesorId { get; set; }

    public int MateriaId { get; set; }

    public virtual Materium Materia { get; set; } = null!;

    public virtual Profesor Profesor { get; set; } = null!;
}
