using Estudiantes_repositorio;
using Estudiantes_repositorio.Models;
using Estudiantes_repositorio.RequestModels;
using Estudiantes_repositorio.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudiantes_negocio
{
    public class EstudianteNegocio
    {
        private readonly EstudianteRepositorio _repositorio;

        public EstudianteNegocio(EstudianteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<Estudiante>> ConsultarEstudiante()
        {

            return await _repositorio.ConsultarEstudiante();
        }

        public async Task<int> CrearEstudiante(CreateEstudiante dataInput)
        {

            return await _repositorio.CrearEstudiante(dataInput);
        }

        public async Task<bool> AsignarMateriaEstudiante(List<AsignarMateria> dataInput)
        {

            return await _repositorio.AsignarMateriaEstudiante(dataInput);
        }

        public async Task<List<ResultMaterias>> ConsultarMaterias()
        {
            return  await _repositorio.ConsultarMaterias();
        }
    }
}
