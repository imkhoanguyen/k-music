using API.Controllers.Base;
using KM.Application.Authorization;
using KM.Application.DTOs.VipPackages;
using KM.Application.Service.Abstract;
using KM.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin
{
    [Authorize]
    public class VipPackageController : BaseAdminApiController
    {
        private readonly IVipPackageService _vipPackageService;

        public VipPackageController(IVipPackageService vipPackageService)
        {
            _vipPackageService = vipPackageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<VipPackage>>> GetAll()
        {
            var list = await _vipPackageService.GetAllAsync(vp => vp.IsDelete == false);
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<VipPackage>> GetVipPackage(int id)
        {
            return await _vipPackageService.GetAsync(vp => vp.Id == id);
        }

        [HttpPost]
        [Authorize(Policy = AppPermission.VipPackage_Create)]
        public async Task<ActionResult<VipPackage>> Create(VipPackageCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vipPackage = await _vipPackageService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetVipPackage), new { id = vipPackage.Id }, vipPackage);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = AppPermission.VipPackage_Edit)]
        public async Task<ActionResult<VipPackage>> Update(int id, VipPackage entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vipPackage = await _vipPackageService.UpdateAsync(id, entity);
            return Ok(vipPackage);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Policy = AppPermission.VipPackage_Delete)]
        public async Task<ActionResult> Delete(int id)
        {
            await _vipPackageService.DeleteAsync(vp => vp.Id == id);
            return NoContent();
        }

    }
}
