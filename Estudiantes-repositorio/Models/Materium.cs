using System;
using System.Collections.Generic;

namespace Estudiantes_repositorio.Models;

public partial class Materium
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Creditos { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<MateriasProfesor> MateriasProfesors { get; set; } = new List<MateriasProfesor>();

    public virtual ICollection<RegistroEstudiantesMateria> RegistroEstudiantesMateria { get; set; } = new List<RegistroEstudiantesMateria>();
}
