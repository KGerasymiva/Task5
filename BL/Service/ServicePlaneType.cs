using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BL.Infrastructure;
using DAL.Models;
using DAL.UnitOfWork;
using DTO;

namespace BL.Service
{
    public class ServicePlaneType : IServicePlaneType
    {
        IUnitOfWork Database { get; set; }

        public ServicePlaneType(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<PlaneTypeDTO> GetPlaneTypes()
        {
            // автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaneType, PlaneTypeDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<PlaneType>, IEnumerable<PlaneTypeDTO>>(Database.Set<PlaneType>().Get());
        }

        public PlaneTypeDTO GetPlaneType(int? id)
        {
            if (id == null)
                throw new ValidationException("There is no plane type", "");

            var planeType = Database.Set<PlaneType>().Get().FirstOrDefault(x => x.Id == id.Value);

            if (planeType == null)
                throw new ValidationException("PlaneType not found", "");

            return new PlaneTypeDTO() { Id = planeType.Id, Model = planeType.Model, Seats = planeType.Seats };
        }
    }
}
