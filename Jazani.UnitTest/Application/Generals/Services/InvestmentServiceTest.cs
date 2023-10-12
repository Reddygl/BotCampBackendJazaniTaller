using AutoFixture;
using AutoMapper;
using Jazani.Application.Generales.Dtos.Investments;
using Jazani.Application.Generales.Dtos.Investments.Profiles;
using Jazani.Application.Generales.Services;
using Jazani.Application.Generales.Services.Implementations;
using Jazani.Domain.Generales.Moldels;
using Jazani.Domain.Generales.Repositories;
using Moq;

namespace Jazani.UnitTest.Application.Generals.Services
{
    public class InvestmentServiceTest
    {
        Mock<IInvestmentRepository> _mocInvestmentRepository;
        Mock<Microsoft.Extensions.Logging.ILogger<InvestmentService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public InvestmentServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<InvestmentProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mocInvestmentRepository = new Mock<IInvestmentRepository>();

            _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<InvestmentService>>();
        }

        //[Fact]
        //public async void returnInvestmentDtoWhenFindByIdAsync()
        //{

        //    // Arrange
        //    Investment investment = _fixture.Create<Investment>();

        //    _mocInvestmentRepository
        //        .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
        //        .ReturnsAsync(investment);


        //    // Act
        //    IInvestmentService investmentService = new InvestmentService(_mockILogger.Object, _mocInvestmentRepository.Object, _mapper);


        //    InvestmentDto investmentDto = await investmentService.FindByIdAsync(investment.Id);

        //    // Assert

        //    Assert.Equal(investment.Description, investmentDto.Description);
        //}

        //[Fact]
        //public async void returnInvestmentsDtoWhenFindAllAsync()
        //{
        //    // Arrage
        //    IReadOnlyList<Investment> investments = _fixture.CreateMany<Investment>(5)
        //        .ToList();

        //    _mocInvestmentRepository
        //        .Setup(r => r.FindAllAsync())
        //        .ReturnsAsync(investments);

        //    // Act
        //    IInvestmentService investmentService = new InvestmentService(_mockILogger.Object, _mocInvestmentRepository.Object, _mapper);

        //    IReadOnlyList<InvestmentDto> investmentDtos = await investmentService.FindAllAsync();

        //    // Assert
        //    Assert.Equal(investments.Count, investmentDtos.Count);
        //}

        [Fact]
        public async void returnMineralTypeDtoWhenCreateAsync()
        {

            // Arrage
            Investment investment = new()
            {
                Id = 1,
                Description = "Ejemplo",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mocInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);


            // Act
            InvestmentSaveDto investmentSaveDto = new()
            {
                Description = investment.Description
            };

            IInvestmentService mineralTypeService = new InvestmentService(_mockILogger.Object, _mocInvestmentRepository.Object, _mapper);

            InvestmentDto investmentDto = await mineralTypeService.CreateAsync(investmentSaveDto);


            // Assert
            Assert.Equal(investment.Description, investmentDto.Description);
        }

        [Fact]
        public async void returnMineralTypeDtoWhenEditAsync()
        {

            // Arrage
            int id = 1;

            Investment investment = new()
            {
                Id = id,
                Description = "Ejemplo",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mocInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mocInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);

            // Act
            InvestmentSaveDto investmentSaveDto = new()
            {
                Description = investment.Description,
            };

            IInvestmentService investmentService = new InvestmentService(_mockILogger.Object, _mocInvestmentRepository.Object, _mapper);

            InvestmentDto investmentDto = await investmentService.EditAsync(id, investmentSaveDto);


            // Assert
            Assert.Equal(investment.Id, investmentDto.Id);
        }

        [Fact]
        public async void returnMineralTypeDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            Investment investment = new()
            {
                Id = id,
                Description = "Ejemplo",
                State = false,
                RegistrationDate = DateTime.Now
            };


            _mocInvestmentRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(investment);

            _mocInvestmentRepository
                .Setup(r => r.SaveAsync(It.IsAny<Investment>()))
                .ReturnsAsync(investment);

            // Act

            IInvestmentService investmentService = new InvestmentService(_mockILogger.Object, _mocInvestmentRepository.Object, _mapper);

            InvestmentDto investmentDto = await investmentService.DisabledAsync(id);


            // Assert
            Assert.Equal(investment.State, investmentDto.State);
        }
    }
}
