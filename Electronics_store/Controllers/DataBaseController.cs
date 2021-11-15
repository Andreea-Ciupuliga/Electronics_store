using System.Threading.Tasks;
using Electronics_store.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Electronics_store.Controllers
{
    public class DataBaseController : ControllerBase
    {
        private readonly ElectronicsStoreContext _context;

        public DataBaseController(ElectronicsStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_context.DataBaseModels.ToListAsync());
        }
    }
}