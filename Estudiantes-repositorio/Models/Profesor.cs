using System;
using System.Collections.Generic;

namespace Estudiantes_repositorio.Models;

public partial class Profesor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<MateriasProfesor> MateriasProfesors { get; set; } = new List<MateriasProfesor>();

    public virtual ICollection<RegistroEstudiantesMateria> RegistroEstudiantesMateria { get; set; } = new List<RegistroEstudiantesMateria>();
}
