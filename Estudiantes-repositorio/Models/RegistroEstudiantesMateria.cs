using System;
using System.Collections.Generic;

namespace Estudiantes_repositorio.Models;

public partial class RegistroEstudiantesMateria
{
    public int RegistroId { get; set; }

    public int EstudianteId { get; set; }

    public int MateriaId { get; set; }

    public int ProfesorId { get; set; }

    public virtual Estudiante Estudiante { get; set; } = null!;

    public virtual Materium Materia { get; set; } = null!;

    public virtual Profesor Profesor { get; set; } = null!;
}
