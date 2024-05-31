using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Microsoft.AspNetCore.Mvc;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;
using MyCompanyName.AbpZeroTemplate.MedicalUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.IMedicalUnit
{
    public class MedicalUnitAppService: AbpZeroTemplateAppServiceBase, IMedicalUnitAppService
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly UserRepository _userRepository;


        public MedicalUnitAppService(IUnitOfWorkManager unitOfWorkManager,UserRepository userRepository)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _userRepository = userRepository;
        }

        [HttpDelete]
        public async Task DeleteTemporaryMedicalUnitById(EntityDto<long> input)
        {
            var dvkcb = await _userRepository.GetAsync(input.Id);
            await _userRepository.DeleteAsync(dvkcb);
        }

        [HttpPost]
        public async Task RestoreDeletedMedicalUnitById(EntityDto<long> input)
        {
            using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var dvkcb = await _userRepository.GetAsync(input.Id);
                dvkcb.IsDeleted = false;
                await _userRepository.UpdateAsync(dvkcb);
            }
        }

        [HttpDelete]
        public async Task DeletePermanentMedicalUnitById(EntityDto<long> input)
        {
            using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                var dvkcb = await _userRepository.GetAsync(input.Id);
                await _userRepository.HardDeleteAsync(dvkcb);
            }
        }

    }
}
