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
    public class ServicePlaneType : IService<PlaneTypeDTO>
    {
        IUnitOfWork UOW { get; set; }
        private IMapper mapper;

        public ServicePlaneType(IUnitOfWork uow, IMapper mapper)
        {
            UOW = uow;
            this.mapper = mapper;
        }

        public IEnumerable<PlaneTypeDTO> Get()
        {
            return mapper.Map<IEnumerable<PlaneTypeDTO>>(UOW.Set<PlaneType>().Get());
        }

        public PlaneTypeDTO Get(int id)
        {
            if (id == 0)
                throw new ValidationException("There is no plane type", "");

            var planeType = UOW.Set<PlaneType>().Get().FirstOrDefault(x => x.Id == id);

            if (planeType == null)
                throw new ValidationException("PlaneType not found", "");

            return mapper.Map<PlaneTypeDTO>(planeType);
        }

        public void Post(PlaneTypeDTO planeTypeDTO)
        {
            var planeType = mapper.Map<PlaneType>(planeTypeDTO);
            UOW.Set<PlaneType>().Create(planeType);
            UOW.SaveChages();
        }

        public void Put(PlaneTypeDTO planeTypeDTO)
        {
            var planeType = mapper.Map<PlaneType>(planeTypeDTO);
            UOW.Set<PlaneType>().Update(planeType);
            UOW.SaveChages();
        }

        public void Delete(int id)
        {
            UOW.Set<PlaneType>().Delete(id);
            UOW.SaveChages();
        }
    }
}
