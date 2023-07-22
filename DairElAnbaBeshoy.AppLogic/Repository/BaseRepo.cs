using DairElAnbaBeshoy.Core.Interfaces;
using DairElAnbaBeshoy.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DairElAnbaBeshoy.AppLogic.Repository
{
    public class BaseRepo<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext DbContext;
        protected DbSet<TEntity> DbSet;
        public BaseRepo( ApplicationDbContext context )
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>( );
        }

        public IQueryable<TEntity> GetAll( )
        {
            IQueryable<TEntity> entities = DbSet;
            return entities;
        }
        public TEntity GetOne( Expression<Func<TEntity , bool>> where , params Expression<Func<TEntity , object>>[ ] includeProperties )
        {
            return GetMany( where , includeProperties ).FirstOrDefault( );
        }
        public virtual IQueryable<TEntity> GetMany( Expression<Func<TEntity , bool>> where = null ,
            params Expression<Func<TEntity , object>>[ ] includeProperties )
        {
            var query = where == null
                ? DbSet
                : DbSet.Where( where );
            var entities = includeProperties.Aggregate( query , ( current , includeProperty ) =>
                current.Include( includeProperty ) );


            return entities;
        }
        public TEntity Get<TKey>( TKey id )
        {
            return DbSet.Find( id );
        }
        public void Add( TEntity entity )
        {
            try
            {
                DbContext.Set<TEntity>( ).Add( entity );

                Save( );
            }
            catch ( Exception e )
            {
                var s = e.Message;
                throw;
            }

        }
        public void Delete( int Id )
        {

            DbContext.Remove( DbSet.Find( Id ) );

            Save( );
        }

        private void Save( )
        {
            DbContext.SaveChanges( );
        }

        public void Edit( TEntity entity )
        {
            DbContext.Entry( entity ).State = EntityState.Modified;
            DbContext.SaveChanges( );
        }
        public decimal SumWhere( Expression<Func<TEntity , bool>> where , Expression<Func<TEntity , decimal>> selector ) => DbSet.Where( where ).Sum( selector );


    }
}
