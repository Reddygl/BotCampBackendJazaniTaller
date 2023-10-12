using AutoFixture;
using AutoMapper;
using Jazani.Application.Generales.Dtos.MeasureUnits;
using Jazani.Application.Generales.Dtos.MeasureUnits.Profiles;
using Jazani.Application.Generales.Services;
using Jazani.Application.Generales.Services.Implementations;
using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;
using Moq;

namespace Jazani.UnitTest.Application.Generals.Services
{
    public class MeasureUnitServiceTest
    {
        Mock<IMeasureUnitRepository> _mocMeasureUnitRepository;
        Mock<Microsoft.Extensions.Logging.ILogger<MeasureUnitService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public MeasureUnitServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MeasureUnitProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mocMeasureUnitRepository = new Mock<IMeasureUnitRepository>();

            _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<MeasureUnitService>>();
        }

        [Fact]
        public async void returnInvestmentDtoWhenFindByIdAsync()
        {

            // Arrange
            MeasureUnit measureUnit = _fixture.Create<MeasureUnit>();

            _mocMeasureUnitRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(measureUnit);


            // Act
            IMeasureUnitService measureUnitService = new MeasureUnitService(_mockILogger.Object, _mocMeasureUnitRepository.Object, _mapper);


            MeasureUnitDto measureUnitDto = await measureUnitService.FindByIdAsync(measureUnit.Id);

            // Assert

            Assert.Equal(measureUnit.Name, measureUnitDto.Name);
        }

        [Fact]
        public async void returnInvestmentsDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<MeasureUnit> investments = _fixture.CreateMany<MeasureUnit>(5)
                .ToList();

            _mocMeasureUnitRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(investments);

            // Act
            IMeasureUnitService investmentService = new MeasureUnitService(_mockILogger.Object, _mocMeasureUnitRepository.Object, _mapper);

            IReadOnlyList<MeasureUnitDto> investmentDtos = await investmentService.FindAllAsync();

            // Assert
            Assert.Equal(investments.Count, investmentDtos.Count);
        }
        [Fact]
        public async void returnMineralTypeDtoWhenCreateAsync()
        {

            // Arrage
            MeasureUnit measureUnit = new()
            {
                Id = 1,
                Name = "Ejemplo",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mocMeasureUnitRepository
                .Setup(r => r.SaveAsync(It.IsAny<MeasureUnit>()))
                .ReturnsAsync(measureUnit);


            // Act
            MeasureUnitSaveDto measureUnitSaveDto = new()
            {
                Name = measureUnit.Name
            };

            IMeasureUnitService measureUnitService = new MeasureUnitService(_mockILogger.Object, _mocMeasureUnitRepository.Object, _mapper);

            MeasureUnitDto measureUnitDto = await measureUnitService.CreateAsync(measureUnitSaveDto);


            // Assert
            Assert.Equal(measureUnit.Name, measureUnitDto.Name);
        }

        [Fact]
        public async void returnMineralTypeDtoWhenEditAsync()
        {

            // Arrage
            int id = 1;

            MeasureUnit measureUnit = new()
            {
                Id = id,
                Name = "Ejemplo",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mocMeasureUnitRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(measureUnit);

            _mocMeasureUnitRepository
                .Setup(r => r.SaveAsync(It.IsAny<MeasureUnit>()))
                .ReturnsAsync(measureUnit);

            // Act
            MeasureUnitSaveDto measureUnitSaveDto = new()
            {
                Name = measureUnit.Name,
            };

            IMeasureUnitService measureUnitService = new MeasureUnitService(_mockILogger.Object, _mocMeasureUnitRepository.Object, _mapper);

            MeasureUnitDto measureUnitDto = await measureUnitService.EditAsync(id, measureUnitSaveDto);


            // Assert
            Assert.Equal(measureUnit.Id, measureUnitDto.Id);
        }

        [Fact]
        public async void returnMineralTypeDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            MeasureUnit measureUnit = new()
            {
                Id = id,
                Name = "Ejemplo",
                State = false,
                RegistrationDate = DateTime.Now
            };


            _mocMeasureUnitRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(measureUnit);

            _mocMeasureUnitRepository
                .Setup(r => r.SaveAsync(It.IsAny<MeasureUnit>()))
                .ReturnsAsync(measureUnit);

            // Act

            IMeasureUnitService measureUnitService = new MeasureUnitService(_mockILogger.Object, _mocMeasureUnitRepository.Object, _mapper);

            MeasureUnitDto measureUnitDto = await measureUnitService.DisabledAsync(id);


            // Assert
            Assert.Equal(measureUnit.State, measureUnitDto.State);
        }
    }
}
