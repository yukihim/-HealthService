using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.MedicalUnit
{

    public interface IMedicalUnitAppService : IApplicationService
    {
        Task DeleteTemporaryMedicalUnitById(EntityDto<long> input);
        Task RestoreDeletedMedicalUnitById(EntityDto<long> input);
        Task DeletePermanentMedicalUnitById(EntityDto<long> input);

    }
}
