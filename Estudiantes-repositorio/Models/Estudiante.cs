using System;
using System.Collections.Generic;

namespace Estudiantes_repositorio.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Documento { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string EstudiantePassword { get; set; } = null!;

    public virtual ICollection<RegistroEstudiantesMateria> RegistroEstudiantesMateria { get; set; } = new List<RegistroEstudiantesMateria>();
}
