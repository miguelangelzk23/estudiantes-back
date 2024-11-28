using Estudiantes_repositorio.Models;
using Estudiantes_repositorio.RequestModels;
using Estudiantes_repositorio.ResultModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudiantes_repositorio
{

    public class EstudianteRepositorio
    {

        private readonly RegistroEstudiantesContext _context;

        public EstudianteRepositorio(RegistroEstudiantesContext context)
        {
            _context = context;
        }
        public async Task<List<Estudiante>> ConsultarEstudiante() 
        {
            return await _context.Estudiantes.ToListAsync();
        }

        public  async Task<List<ResultMaterias>> ConsultarMaterias()
        {

            List<ResultMaterias> result = new List<ResultMaterias>();
            var consultaMaterias = await (from materia in _context.Materia
                                   join Mateprofesor in _context.MateriasProfesors
                                   on materia.Id equals Mateprofesor.MateriaId
                                   select new
                                   {
                                       IdMateria = materia.Id,
                                       MateriaNombre = materia.Nombre,
                                       IdProfesor = Mateprofesor.ProfesorId,
                                   }).ToListAsync();

            foreach (var item in consultaMaterias)
            {
                ResultMaterias NewMateria = new()
                {
                    IdMateria = item.IdMateria,
                    MateriaNombre = item.MateriaNombre,
                    IdProfesor = item.IdProfesor,
                    Seleccionada = false
                };
                result.Add(NewMateria);
            }
            return result;

        }

        public async Task<int> CrearEstudiante(CreateEstudiante input)
        {
            try
            {
                Estudiante dataInput = new()
                {
                    Nombre = input.Nombre,
                    Apellido = input.Apellido,
                    Documento = input.Documento,
                    Correo = input.Correo,
                    EstudiantePassword = input.EstudiantePassword
                };
                await _context.Estudiantes.AddAsync(dataInput);
                _context.SaveChanges();
                Estudiante? estudiante = await _context.Estudiantes.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                int result = estudiante!.Id;
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<bool> AsignarMateriaEstudiante(List<AsignarMateria> input)
        {
            try
            {
                List<RegistroEstudiantesMateria> registro = new List<RegistroEstudiantesMateria>();
                foreach (var materia in input)
                {
                    RegistroEstudiantesMateria dataInput = new()
                    {
                        EstudianteId = materia.EstudianteId,
                        MateriaId = materia.MateriaId,
                        ProfesorId = materia.ProfesorId,
                    };
                    registro.Add(dataInput);
                }
                await  _context.RegistroEstudiantesMaterias.AddRangeAsync(registro);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    
}
