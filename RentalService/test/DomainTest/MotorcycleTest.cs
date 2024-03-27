using Domain.Models;

namespace DomainTest
{
    //AAA (Arrange, Act, Assert)
    public class MotorcycleTest
    {
        private Motorcycle CreateMotorcycle(short? year = null, string? model = null, string? plate = null)
        {
            return new Motorcycle(
                 year : year ?? 2020,
                 model : model ?? "Twist",
                 plate : plate ?? "ABC1234"
                );
        }

        [Fact]
        public void Create_Motorcycle_Sucess()
        {
            //Arrange
            short year = 2020;
            var model = "Twist";
            var plate = "ABC1234";

            //Act
            var motorcycle = new Motorcycle(year, model, plate);

            //Assert
            Assert.True(motorcycle.Valid);
            Assert.NotEqual(Guid.Empty, motorcycle.Id);
            Assert.Equal(year, motorcycle.Year);
            Assert.Equal(model, motorcycle.Model);
            Assert.Equal(plate, motorcycle.Plate);
        }

        [Theory]
        [InlineData(1999)]
        [InlineData(2026)]
        
        public void Create_Motorcycle_Fail_When_Year_Invalid(short invalidYear)
        {
            //Act
            var motorcycle = CreateMotorcycle(year: invalidYear);  

            //Assert
            Assert.False(motorcycle.Valid);
            Assert.Single(motorcycle.ValidationResult.Errors);            
        }


        [Fact]
        public void Change_Motorcycle_Plate_Sucess()
        {
            //Arrange
            var plate = "ABC1234";
            var motorcycle = CreateMotorcycle(plate: plate);

            //Act
            motorcycle.ChangePlate(plate);

            //Assert
            Assert.True(motorcycle.Valid);
            Assert.Equal(plate, motorcycle.Plate);  
        }

        [Theory]
        [InlineData("121DWW2")]
        [InlineData("121WW2")]
        [InlineData("1111111")]
        public void Change_Motorcycle_Plate_Fail(string plate)
        {
            //Arrange           
            var motorcycle = CreateMotorcycle(plate: plate);

            //Act
            motorcycle.ChangePlate(plate);

            //Assert
            Assert.False(motorcycle.Valid);            
        }

    }
}