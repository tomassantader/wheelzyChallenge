using System;
using System.Collections.Generic;

namespace TestFiles
{
    // Clases
    public class UserVm
    {
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }

    public class AddressDto
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class UsersVms
    {
        public List<UserVm> List { get; set; }
    }

    public class CarDto
    {
        public string Brand { get; set; }
    }

    public class CarsDtos
    {
        public CarDto[] CarArray { get; set; }
        public List<CarDto> CarList { get; set; }
    }

    // Método con parámetros y variables locales
    public class Mapper
    {
        public UserVm MapToUserVm(AddressDto addressDto)
        {
            var userVm = new UserVm
            {
                Address = addressDto,
                Name = "John"
            };

            return userVm;
        }

        public List<CarDto> GetCarDtos(List<CarsDtos> carsDtos)
        {
            var carDtos = new List<CarDto>();
            foreach (var carsDto in carsDtos)
            {
                carDtos.AddRange(carsDto.CarList);
            }
            return carDtos;
        }
    }

    // Propiedades en otras clases
    public class Garage
    {
        public List<CarDto> Cars { get; set; }
        public UsersVms Users { get; set; }
    }
}
