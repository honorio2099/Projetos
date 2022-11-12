using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentResults;
using TesteRestful_API.Data;
using TesteRestful_API.Data.DTO_S;
using TesteRestful_API.Models;

namespace TesteRestful_API.Services
{
    public class BrinquedoService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public BrinquedoService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadBrinquedoDTO adicionar(CreateBrinquedoDTO brinqDTO)
        {
            Brinquedo brinq = _mapper.Map<Brinquedo>(brinqDTO);
            // passando toda a Model do Brinquedo original para a sua versão DTO

            _context.Brinquedos.Add(brinq);
            _context.SaveChanges();

            return _mapper.Map<ReadBrinquedoDTO>(brinq);
        }

        public List<ReadBrinquedoDTO> RecuperarBrinquedo()
        {
            List<ReadBrinquedoDTO> listabrinqDTO = _mapper.Map<List<ReadBrinquedoDTO>>(_context.Brinquedos);
            return listabrinqDTO;
        }

        public ReadBrinquedoDTO RecuperarBrinquedoPorID(int id)
        {
            Brinquedo brinquedo = _context.Brinquedos.FirstOrDefault(brinq => brinq.IDBrinquedo == id);

            if (brinquedo != null)
            {
                ReadBrinquedoDTO ReadbrinqDTO = _mapper.Map<ReadBrinquedoDTO>(brinquedo);

                return ReadbrinqDTO;
            }
            return null;
        }

        public Result DeletaBrinquedo(int id)
        {
            Brinquedo brinquedo = _context.Brinquedos.FirstOrDefault(brinq => brinq.IDBrinquedo == id);

            if (brinquedo != null)
            {
                _context.Remove(brinquedo);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Erro na Exclusão - Brinquedo não encontrado!!!");
        }

        public Result AtualizaBrinquedo(int id, UpdateBrinquedoDTO UpdatenovoBrinqDTO)
        {
            Brinquedo brinquedo = _context.Brinquedos.FirstOrDefault(brinq => brinq.IDBrinquedo == id);

            if (brinquedo != null)
            {
                _mapper.Map(UpdatenovoBrinqDTO, brinquedo);
                // basicamente realizando uma "troca", passando do Update para o original, sempre fazer desse jeito
                // para Updates

                _context.Update(brinquedo);
                // Redundante, o código já altera então não é nescessário o update (mas vou deixar aqui)
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Erro na Atualização - Brinquedo não encontrado!!!");
        }
    }
}

