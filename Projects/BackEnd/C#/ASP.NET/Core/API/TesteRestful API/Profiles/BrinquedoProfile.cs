using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteRestful_API.Data.DTO_S;
using TesteRestful_API.Models;

namespace TesteRestful_API.Profiles
{
    public class BrinquedoProfile : Profile
    {
        // ctor mais TAB 2x cria um construtor
        public BrinquedoProfile()
        {
            // "Convertendo" uma classe Model em outra
            CreateMap<CreateBrinquedoDTO,Brinquedo>();
            CreateMap<UpdateBrinquedoDTO, Brinquedo>();
            CreateMap<Brinquedo, ReadBrinquedoDTO>();
        }
    }
}
