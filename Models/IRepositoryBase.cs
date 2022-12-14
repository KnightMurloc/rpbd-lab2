using NHibernate;

namespace lab2.Models
{
    public interface IRepositoryBase
    {
        IQuery FindByCondition<T>(string expression);
        IQuery FindByCondition<T>(string expression, int count);
        void Create<T>(T entity);
        void Update<T>(T entity);
        void Delete<T>(T entity);
        public T Find<T>(int id);

        public void Refresh<T>(T entity);
    }
}