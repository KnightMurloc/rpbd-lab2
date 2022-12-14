using System;
using System.Collections;
using System.Collections.Generic;
using FluentNHibernate.Conventions;
using lab2.Models;

namespace lab2
{
    public class EntityIterator<T> where T : IEntity
    {
        private int FirtsId = 0;
        private int LasdId;
        private int PackageSize;
        // private const string HqlTemplateNext = "from {0} where ({1}) and Id > {2} order by Id limit {3}";
        private const string HqlTemplateNext = "from {0} e where {1} e.Id > {2} order by e.Id";
        private const string HqlTemplatePerv = "from {0} e where {1} e.Id < {2} order by e.Id DESC";
        public string Condition { get; set; }

        public EntityIterator(int packageSize)
        {
            PackageSize = packageSize;
            LasdId = PackageSize;
            Condition = "";
        }

        public System.Collections.IList NextPackage()
        {
            
            string hql = String.Format(
                HqlTemplateNext,
                typeof(T).Name,
                Condition.IsEmpty() ? "" : "(" + Condition + ") and ",
                FirtsId
            );
            
            Console.WriteLine(hql);
            var query = Repository.Instance.FindByCondition<T>(hql,PackageSize);
            List<T> list = (List<T>) query.List<T>();
            if (list.Count != 0)
            {
                FirtsId = list[^1].Id;
                LasdId = list[0].Id;
            }
            return list;
        }
        
        public System.Collections.IList PrevPackage()
        {
            string hql = String.Format(
                HqlTemplatePerv,
                typeof(T).Name,
                Condition.IsEmpty() ? "" : "(" + Condition + ") and ",
                LasdId
            );
            
            Console.WriteLine(hql);
            var query = Repository.Instance.FindByCondition<T>(hql,PackageSize);
            List<T> list = (List<T>) query.List<T>();
            if (list.Count != 0)
            {
                LasdId = list[^1].Id;
                FirtsId = list[0].Id;
            }
            return list;
        }

        public void Reset()
        {
            FirtsId = 0;
            LasdId = 0;
        }
    }
}