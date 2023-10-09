﻿using Jazani.Application.Generales.Dtos.Investments;

namespace Jazani.Application.Generales.Services
{
    public interface IInvestmentService
    {
        Task<IReadOnlyList<InvestmentDto>> FindAllAsync();
        Task<InvestmentDto> FindByIdAsync(int id);
        Task<InvestmentDto> CreateAsync(InvestmentSaveDto investmentSaveDto);
        Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto investmentSaveDto);
        Task<InvestmentDto> DisabledAsync(int id);
    }
}
