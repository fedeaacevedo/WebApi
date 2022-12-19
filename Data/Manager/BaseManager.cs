using Microsoft.EntityFrameworkCore;

namespace Data.Manager
{
    
    public abstract class BaseManager<T> where T : class
    {
        #region Singleton Context
        protected static ApplicationDbContext _context;

        public static ApplicationDbContext contextoSingleton
        {
            get 
            {
                if(_context == null)
                {
                    _context = new ApplicationDbContext();
                }
                return _context;
            }
        }
        #endregion

        #region Metodos Abstractos
        public abstract Task<List<T>> BuscarLista();
        public abstract Task<T> Buscar();
        public abstract Task<bool> Eliminar(Task modelo);


        #endregion

        #region Metodos Publicos
        public async Task<bool> Guardar(T modelo, int id)
        {
            if(id == 0)
            {
                contextoSingleton.Entry<T>(modelo).State = EntityState.Added;
            }else
            {
                contextoSingleton.Entry<T>(modelo).State = EntityState.Modified;
            }

            var result = await contextoSingleton.SaveChangesAsync() > 0;
            contextoSingleton.Entry<T>(modelo).State = EntityState.Detached;

            return result;
        }
        #endregion
    }
}