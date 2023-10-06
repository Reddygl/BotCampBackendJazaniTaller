using AutoMapper;
using Jazani.Application.Generales.Dtos.MiningConcessionHolders;
using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;

namespace Jazani.Application.Generales.Services.Implementations
{
    public class MiningConcessionHolderService : IMiningConcessionHolderService
    {
        private readonly IMiningConcessionHolderRepository _miningConcessionHolderRepository;
        private readonly IMapper _mapper;
        public MiningConcessionHolderService(IMiningConcessionHolderRepository miningConcessionHolderRepository, IMapper mapper)
        {
            _miningConcessionHolderRepository = miningConcessionHolderRepository;
            _mapper = mapper;
        }
        public async Task<MiningConcessionHolderDto> CreateAsync(MiningConcessionHolderSaveDto miningConcessionSaveDto)
        {
            MiningConcessionHolder miningConcessionHolder = _mapper.Map<MiningConcessionHolder>(miningConcessionSaveDto);
            miningConcessionHolder.RegistrationDate = DateTime.Now;
            miningConcessionHolder.State = true;
            await _miningConcessionHolderRepository.SaveAsync(miningConcessionHolder);
            return _mapper.Map<MiningConcessionHolderDto>(miningConcessionHolder);
        }

        public async Task<MiningConcessionHolderDto> DisabledAsync(int id, int key)
        {
            MiningConcessionHolder miningConcessionHolder = await _miningConcessionHolderRepository.FindByIdAndKeyAsync(id,key);
            miningConcessionHolder.State = false;
            await _miningConcessionHolderRepository.SaveAsync(miningConcessionHolder);
            return _mapper.Map<MiningConcessionHolderDto>(miningConcessionHolder);
        }

        public async Task<MiningConcessionHolderDto> EditAsync(int id, int key, MiningConcessionHolderUpdateDto miningConcessionHolderUpdate)
        {
            MiningConcessionHolder miningConcessionHolder = await _miningConcessionHolderRepository.FindByIdAndKeyAsync(id,key);
            _mapper.Map<MiningConcessionHolderUpdateDto, MiningConcessionHolder>(miningConcessionHolderUpdate, miningConcessionHolder);
            MiningConcessionHolder miningConcessionHolderSave = await _miningConcessionHolderRepository.SaveAsync(miningConcessionHolder);
            return _mapper.Map<MiningConcessionHolderDto>(miningConcessionHolderSave);
        }  

        public async Task<IReadOnlyList<MiningConcessionHolderDto>> FindAllAsync()
        {
            IReadOnlyList<MiningConcessionHolder> miningConcessionHolders = await _miningConcessionHolderRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<MiningConcessionHolderDto>>(miningConcessionHolders);
        }

        public async Task<MiningConcessionHolderDto> FindByIdAndKeyAsync(int id, int key)
        {
            MiningConcessionHolder? miningConcessionHolder = await _miningConcessionHolderRepository.FindByIdAndKeyAsync(id,key);
            return _mapper.Map<MiningConcessionHolderDto>(miningConcessionHolder);
        }
    }
}
