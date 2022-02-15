using System.Threading.Tasks;
using ProEventos.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ProEventos.Persistence.Contratos;
using ProEventos.Persistence.Contextos;

namespace ProEventos.Persistence
{
    public class EventosPersist: IEventoPersist
    {
        private readonly ProEventosContext _context;
        public EventosPersist(ProEventosContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
   
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.AsNoTracking()
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrantes){
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Eventos.AsNoTracking()
            .Include(et => et.Lotes)
            .Include(et => et.RedesSociais);

            if (includePalestrantes){
                query = query
                .Include(et => et.PalestrantesEventos)
                .ThenInclude(pet => pet.Palestrante);
            }

            query = query.OrderBy(et => et.Id).Where(et => et.Tema.ToLower().Contains(tema.ToLower()));
            
            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
             IQueryable<Evento> query = _context.Eventos.AsNoTracking()
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrantes){
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderBy(e => e.Id).Where(e  => e.Id == eventoId);
            
            return await query.FirstOrDefaultAsync();
        }
      
    }
}