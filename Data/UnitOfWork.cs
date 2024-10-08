﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Core;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Data
{
    public class UnitOfWork : IDisposable
    {
        public Context dbcontext;
        private IDbContextTransaction? _currentTransaction;

        private GenericRepository<Client>? clientRepository;
        private GenericRepository<Store>? storeRepository;
        private GenericRepository<Items>? itemsRepository;
        private GenericRepository<ItemStoreRelation>? itemStoreRelationRepository;
        private GenericRepository<ClientItemRelation>? clientItemRelationRepository;

        public UnitOfWork(Context context)
        {
            dbcontext = context;
        }

        public void Save()
        {
            dbcontext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await dbcontext.SaveChangesAsync();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbcontext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction()
        {
            if (_currentTransaction == null)
            {
                _currentTransaction = dbcontext.Database.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {
            try
            {
                _currentTransaction?.Commit();
            }
            catch
            {
                // Manejar cualquier excepción aquí
                RollbackTransaction();
                throw;
            }
            finally
            {
                _currentTransaction?.Dispose();
                _currentTransaction = null;
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                _currentTransaction?.Dispose();
                _currentTransaction = null;
            }
        }

        public GenericRepository<Client> ClientRepository
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new GenericRepository<Client>(dbcontext);
                }
                return clientRepository;
            }
        }
        public GenericRepository<Store> StoreRepository
        {
            get
            {
                if (storeRepository == null)
                {
                    storeRepository = new GenericRepository<Store>(dbcontext);
                }
                return storeRepository;
            }
        }

        public GenericRepository<Items> ItemsRepository
        {
            get
            {
                if (itemsRepository == null)
                {
                    itemsRepository = new GenericRepository<Items>(dbcontext);
                }
                return itemsRepository;
            }
        }

        public GenericRepository<ItemStoreRelation> ItemStoreRelationRepository
        {
            get
            {
                if (itemStoreRelationRepository == null)
                {
                    itemStoreRelationRepository = new GenericRepository<ItemStoreRelation>(dbcontext);
                }
                return itemStoreRelationRepository;
            }
        }

        public GenericRepository<ClientItemRelation> ClientItemRelationRepository
        {
            get
            {
                if (clientItemRelationRepository == null)
                {
                    clientItemRelationRepository = new GenericRepository<ClientItemRelation>(dbcontext);
                }
                return clientItemRelationRepository;
            }
        }

    }
}
