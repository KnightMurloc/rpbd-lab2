using FluentNHibernate.Mapping;
using lab2.Models.NHibernate;
using NHibernate;

namespace lab2.Models
{
    public class Post
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Table("post");
            Id(x => x.Id);
            Map(x => x.Name).Column("name");
        }
    }

    // public class PostRepository : IRepositoryBase<Post>
    // {
    //     private ISession Session;
    //     private static PostRepository _instance = null; 
    //     
    //     private PostRepository()
    //     {
    //         Session = NHibernateHelper.OpenSession();
    //     }
    //
    //     public static PostRepository Instance
    //     {
    //         get
    //         {
    //             if (_instance == null)
    //             {
    //                 _instance = new PostRepository();
    //             }
    //
    //             return _instance;
    //         }
    //     }
    //     
    //     public IQuery FindByCondition(string expression, int count)
    //     {
    //         return Session.CreateQuery(expression).SetMaxResults(count);
    //     }
    //     
    //     public IQuery FindByCondition(string expression)
    //     {
    //         return Session.CreateQuery(expression);
    //     }
    //
    //     public void Create(Post entity)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public void Update(Post entity)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public void Delete(Post entity)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public Post Find(int id)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    // }
}