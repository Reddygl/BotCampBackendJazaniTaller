using AutoMapper;
using Jazani.Application.Generales.Dtos.MiningConcessions;
using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;

namespace Jazani.Application.Generales.Services.Implementations
{
    public class MiningConcessionService : IMiningConcessionService
    {
        private readonly IMiningConcessionRepository _miningConcessionRepository;
        private readonly IMapper _mapper;
        public MiningConcessionService(IMiningConcessionRepository miningConcessionRepository, IMapper mapper)
        {
            _miningConcessionRepository = miningConcessionRepository;
            _mapper = mapper;
        }
        public async Task<MiningConcessionDto> CreateAsync(MiningConcessionSaveDto miningConcessionSaveDto)
        {
            MiningConcession miningConcession = _mapper.Map<MiningConcession>(miningConcessionSaveDto);
            miningConcession.RegistrationDate = DateTime.Now;
            miningConcession.State = true;
            await _miningConcessionRepository.SaveAsync(miningConcession);
            return _mapper.Map<MiningConcessionDto>(miningConcession);
        }

        public async Task<MiningConcessionDto> DisabledAsync(int id)
        {
            MiningConcession miningConcession = await _miningConcessionRepository.FindByIdAsync(id);
            miningConcession.State = false;
            await _miningConcessionRepository.SaveAsync(miningConcession);
            return _mapper.Map<MiningConcessionDto>(miningConcession);
        }

        public async Task<MiningConcessionDto> EditAsync(int id, MiningConcessionSaveDto miningConcessionSaveDto)
        {
            MiningConcession miningConcession = await _miningConcessionRepository.FindByIdAsync(id);
            _mapper.Map<MiningConcessionSaveDto, MiningConcession>(miningConcessionSaveDto, miningConcession);
            MiningConcession miningConcessionSave = await _miningConcessionRepository.SaveAsync(miningConcession);
            return _mapper.Map<MiningConcessionDto>(miningConcessionSave);
        }

        public async Task<IReadOnlyList<MiningConcessionDto>> FindAllAsync()
        {
            IReadOnlyList<MiningConcession> miningConcessions = await _miningConcessionRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<MiningConcessionDto>>(miningConcessions);
        }

        public async Task<MiningConcessionDto> FindByIdAsync(int id)
        {
            MiningConcession? miningConcession = await _miningConcessionRepository.FindByIdAsync(id);
            return _mapper.Map<MiningConcessionDto>(miningConcession);
        }
    }
}
