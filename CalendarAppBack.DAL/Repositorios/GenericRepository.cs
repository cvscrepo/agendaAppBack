using CalendarAppBack.DAL.Repositorios.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAppBack.DAL.Repositorios
{
    public class GenericRepository<TModelo> : IGenericRepository<TModelo> where TModelo : class
    {
        private readonly CalendarContext _calendarContext;

        public GenericRepository(CalendarContext calendarContext)
        {
            _calendarContext = calendarContext;
        }

        public async Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro)
        {
            try
            {
                TModelo modelo = await _calendarContext.Set<TModelo>().FirstOrDefaultAsync(filtro);
                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                //Base de datos.especificarElModeloATrabajar
                _calendarContext.Set<TModelo>().Add(modelo);
                await _calendarContext.SaveChangesAsync();

                return modelo;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _calendarContext.Set<TModelo>().Update(modelo);
                await _calendarContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {
            try
            {
                _calendarContext.Remove(modelo);
                await _calendarContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>> filtro = null)
        {
            try
            {
                IQueryable<TModelo> modelo = filtro == null ? _calendarContext.Set<TModelo>() : _calendarContext.Set<TModelo>().Where(filtro);
                return modelo;
            }
            catch
            {
                throw;
            }
        }
    }
}
