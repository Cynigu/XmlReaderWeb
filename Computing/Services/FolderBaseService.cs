﻿using DBRepository.Factories;
using Models;
using XmlReader.BLL.DTO;
using XmlReader.BLL.Mapper.ToEntity;
using XmlReader.BLL.Services.FolderServices;
using XmlReader.Data.DBRepository.UOW;

namespace XmlReader.BLL.Service.Services
{
    public class FolderBaseService : IFolderBaseService
    {
        private readonly IRepositoryContextFactory _contextFactory;
        public FolderBaseService(IRepositoryContextFactory repositoryContextFactory)
        {
            _contextFactory = repositoryContextFactory;
        }

        public async Task Add(FolderDTO item)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.FolderRepository.Add(item.ToEntity());
            }
        }

        public async Task<FolderDTO> Delete(int id)
        {
            Folder emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = await uow.FolderRepository.Delete(id);
            }
            return emp.ToDTO();

        }

        public IEnumerable<FolderDTO> Get()
        {
            IEnumerable<Folder> emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = uow.FolderRepository.Get().ToList();
            }
            return emp.Select(x => x.ToDTO());
        }

        public async Task<FolderDTO> Get(int id)
        {
            Folder emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = await uow.FolderRepository.Get(id);
            }
            return emp.ToDTO();
        }

        public async Task<IEnumerable<FolderDTO>> Get(int[] ids)
        {
            IEnumerable<Folder> emp;
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                emp = await uow.FolderRepository.Get(ids);
            }
            return emp.Select(x => x.ToDTO());
        }

        public async Task SaveAsync()
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.SaveAsync();
            }
        }

        public async Task Update(FolderDTO item)
        {
            using (var uow = new UnitOfWork(_contextFactory.Create()))
            {
                await uow.FolderRepository.Update(item.ToEntity());
            }
        }
    }
}
