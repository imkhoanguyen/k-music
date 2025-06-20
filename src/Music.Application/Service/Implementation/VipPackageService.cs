﻿using System.Linq.Expressions;
using Music.Application.DTOs.VipPackages;
using Music.Application.Repositories;
using Music.Application.Service.Abstract;
using Music.Domain.Exceptions;
using Music.Domain.Entities;

namespace Music.Application.Service.Implementation
{
    public class VipPackageService : IVipPackageService
    {
        private readonly IUnitOfWork _unit;

        public VipPackageService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<Plan> CreateAsync(VipPackageCreateDto dto)
        {
            if (dto.PriceSell >= dto.Price)
            {
                throw new BadRequestException("Giá bán sau khi giảm phải nhỏ hơn giá bán ban đầu");
            }

            var entity = new Plan
            {
                Name = dto.Name,
                Price = dto.Price,
                PriceSell = dto.PriceSell,
                Description = dto.Description,
                DurationDay = dto.DurationDay,
            };

            await _unit.VipPackage.AddAsync(entity);

            if (await _unit.CompleteAsync())
            {
                return entity;
            }

            throw new BadRequestException("Có lỗi xảy ra khi thêm gói đăng ký");
        }

        public async Task DeleteAsync(Expression<Func<Plan, bool>> expression)
        {
            var entity = await _unit.VipPackage.GetAsync(expression, true);
            if (entity == null)
                throw new NotFoundException("Gói đăng ký không tồn tại");

            entity.IsDelete = true;
            
            if (!await _unit.CompleteAsync())
            {
                throw new Exception("Đã xảy ra lỗi khi xóa gói đăng ký");
            }
        }

        public async Task<IEnumerable<Plan>> GetAllAsync(Expression<Func<Plan, bool>>? expression = null)
        {
            return await _unit.VipPackage.GetAllAsync(expression);
        }

        public async Task<Plan> GetAsync(Expression<Func<Plan, bool>> expression)
        {
            return await _unit.VipPackage.GetAsync(expression) ?? throw new NotFoundException("Không tìm thấy gói đăng ký");
        }

        public async Task<Plan> UpdateAsync(int vipPackageId, Plan entity)
        {

            if (entity.Price < 10000)
            {
                throw new BadRequestException("Giá bán phải lớn hơn 10000 (10.000VND)");
            }

            if (entity.PriceSell < 10000)
            {
                throw new BadRequestException("Giá bán sau khi giảm phải lớn hơn 10000 (10.000VND)");
            }

            if (entity.PriceSell >= entity.Price)
            {
                throw new BadRequestException("Giá bán sau khi giảm phải nhỏ hơn giá bán ban đầu");
            }

            if (vipPackageId != entity.Id)
            {
                throw new BadRequestException("Id không khớp");
            }

            if (await _unit.VipPackage.ExistsAsync(vp => vp.Id == vipPackageId) == false)
            {
                throw new NotFoundException("Không tìm thấy gói đăng ký");
            }

            _unit.VipPackage.Update(entity);

            if (await _unit.CompleteAsync())
            {
                return entity;
            }

            throw new BadRequestException("Có lỗi xảy ra khi xóa gói đăng ký");
        }
    }
}
