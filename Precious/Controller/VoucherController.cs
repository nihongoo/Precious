using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class VoucherController : ControllerBase
	{
		private readonly AllService<Voucher> _allService;

		/// <summary>
		/// contructor
		/// </summary>
		/// <param name="service"></param>
		public VoucherController(AllService<Voucher> service)
		{
			_allService = service;
		}

		/// <summary>
		/// Get all
		/// </summary>
		/// <returns></returns>
		[HttpGet("Get-All-Voucher")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _allService.GetAll());
		}

		/// <summary>
		/// Get a record by id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpGet("Get-By-ID-Voucher")]
		public async Task<IActionResult> GetByID(Guid Id)
		{
			return Ok(await _allService.GetAsync(Id));
		}

		/// <summary>
		/// create new record
		/// </summary>
		/// <param name="Voucher"></param>
		/// <returns></returns>
		[HttpPost("Create-Voucher")]
		public async Task<IActionResult> Create(VoucherViewModel Voucher)
		{
			var checkUnique = await _allService.CheckUnique("VoucherCode", Voucher.VoucherCode);
			if (checkUnique.k == false) return BadRequest(checkUnique.msg);
			var data = new Voucher()
			{
				IDVoucher = Guid.NewGuid(),
				VoucherCode = Voucher.VoucherCode,
				Value = Voucher.Value,
				Quantity = Voucher.Quantity,
				StartDay = Voucher.StartDay,
				EndDay = Voucher.EndDay,
				Status = 1
			};
			var result = await _allService.Add(data);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

		/// <summary>
		/// update a record
		/// </summary>
		/// <param name="Voucher"></param>
		/// <returns></returns>
		[HttpPut("Edit-Voucher")]
		public async Task<IActionResult> Update(VoucherViewModel Voucher)
		{
			var checkUnique = await _allService.CheckUnique("VoucherCode", Voucher.VoucherCode);
			if (checkUnique.k == false) return BadRequest(checkUnique.msg);
			var data = new Voucher()
			{
				IDVoucher = Voucher.IDVoucher,
				VoucherCode = Voucher.VoucherCode,
				Value = Voucher.Value,
				Quantity = Voucher.Quantity,
				StartDay = Voucher.StartDay,
				EndDay = Voucher.EndDay,
				Status = Voucher.Status
			};
			var result = await _allService.Update(data);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

		/// <summary>
		/// delete a record
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpDelete("Delete-Voucher")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var result = await _allService.Delete(Id);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}
	}
}
