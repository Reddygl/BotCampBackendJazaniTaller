using AutoFixture;
using AutoMapper;
using Jazani.Application.Generales.Dtos.Holders;
using Jazani.Application.Generales.Dtos.Holders.Profiles;
using Jazani.Application.Generales.Services;
using Jazani.Application.Generales.Services.Implementations;
using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;
using Moq;

namespace Jazani.UnitTest.Application.Generals.Services
{
    public class HolderServiceTest
    {
        Mock<IHolderRepository> _mockHolderRepository;
        Mock<Microsoft.Extensions.Logging.ILogger<HolderService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public HolderServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<HolderProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mockHolderRepository = new Mock<IHolderRepository>();

            _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<HolderService>>();
        }

        [Fact]
        public async void returnHolderDtoWhenFindByIdAsync()
        {

            // Arrange
            Holder holder = _fixture.Create<Holder>();

            _mockHolderRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(holder);


            // Act
            IHolderService holderService = new HolderService(_mockILogger.Object,_mockHolderRepository.Object, _mapper);


            HolderDto holderDto = await holderService.FindByIdAsync(holder.Id);

            // Assert

            Assert.Equal(holder.Name, holderDto.Name);
        }

        [Fact]
        public async void returnHoldersDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<Holder> holders = _fixture.CreateMany<Holder>(5)
                .ToList();

            _mockHolderRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(holders);

            // Act
            IHolderService holderService = new HolderService(_mockILogger.Object, _mockHolderRepository.Object, _mapper);

            IReadOnlyList<HolderDto> holderDtos = await holderService.FindAllAsync();

            // Assert
            Assert.Equal(holders.Count, holderDtos.Count);
        }
         
    }
}
