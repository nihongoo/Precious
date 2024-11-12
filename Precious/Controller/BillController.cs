using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class BillController : ControllerBase
	{
		private readonly BillService _billService;
		private readonly AllService<Bill> _allService;
        public BillController(BillService billService, AllService<Bill> allService)
        {
			_allService = allService;
			_billService = billService;    
        }

		[HttpPost("Create-Bill")]
		public async Task<IActionResult> Create([FromBody] BillDTO bill)
		{
			var result = await _billService.CreateBillOffline(bill.Bill, bill.BillDetail);
			if(result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

		[HttpGet("Get-All")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _allService.GetAll());
		}
    }
}
