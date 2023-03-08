using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using serviceTestTassk.Data;
using serviceTestTassk.Models;
using serviceTestTassk.Models.ViewModels;
using System.Data;

namespace serviceTestTassk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationContext _applicationContext;

        public ContractController(ILogger<WeatherForecastController> logger, ApplicationContext applicationContext)
        {
            _logger = logger;
            _applicationContext = applicationContext;
        }

        [Route("addcontract")]
        [HttpPost]
        public async Task<ActionResult> AddContractAsync([FromBody] AddContractViewModel contractViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Building? building = await _applicationContext.Buildings.FirstOrDefaultAsync(u => u.Code == contractViewModel.CodeBuilding);
            if (building == null) return NotFound(new { message = "Building Code NotFound" });

            Equipment? equipment = await _applicationContext.Equipments.FirstOrDefaultAsync(u => u.Code == contractViewModel.CodeEquipment);
            if (equipment == null) return NotFound(new { message = "Equipment Code NotFound" });

            var occupiedArea = await _applicationContext.Contracts.Include(el => el.Equipment).Where(el => el.BuildingId == building.Id).SumAsync(el => el.Equipment.Area * el.CountEquipment);
            if(building.MaxArea<= occupiedArea + equipment.Area * contractViewModel.CountEquipment) { return BadRequest( new { message = "Not enough free area" }); }

            var contract = new Contract { BuildingId = building.Id, EquipmentId = equipment.Id, CountEquipment = contractViewModel.CountEquipment }; 
            await _applicationContext.Contracts.AddAsync(contract);
            await _applicationContext.SaveChangesAsync();
            return Ok();
        }

        [Route("contracts")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetContractsViewModel>>> GetContractsAsync()
        {

            var res = await _applicationContext.Contracts.Include(p => p.Building ).Include(p => p.Equipment).ToListAsync();
            if(res == null) { return BadRequest("No data"); }

            var contracts = new List<GetContractsViewModel>();
            foreach (Contract c in res)
            {
                contracts.Add(new GetContractsViewModel
                {
                    Id = c.Id,
                    BuildingName = c.Building.Name,
                    EquipmentName = c.Equipment.Name,
                    CountEquipment = c.CountEquipment   
                });
            }
            return Ok(contracts);
        }
    }
}
