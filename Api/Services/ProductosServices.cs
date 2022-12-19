using Data.Entities;
using Data.Manager;

namespace Api.Services
{
    public class ProductosServices
    {
		private readonly ProductosManager _manager;

		public ProductosServices()
		{
			_manager = new ProductosManager();
		}
        public async Task<List<Productos>> BuscarLista()
        {
			try
			{
				return await _manager.BuscarLista();
			}
			catch (Exception)
			{

				throw;
			}

        }
    }
}
