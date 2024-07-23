using NHibernate;
using ApiMyContabs.Repository;
using ApiMyContabs.Repository.Entity;
using System.Transactions;

namespace ApiMyContabs.Repository
{
    public class Persistence : IPersistence
    {
        private NHibernateHelper _nhibernateHelper = new NHibernateHelper();

        public void Delete(object obj)
        {
            try
            {
                using (NHibernate.ISession session = _nhibernateHelper.OpenSession())
                {
                    using (ITransaction Transaction = session.BeginTransaction())
                    {
                        Transaction.Begin();
                        session.Clear();
                        session.Delete(obj);
                        Transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: "+ ex.Message);
            }

        }

        public object Load(string Hql)
        {
            try
            {
                using (NHibernate.ISession session = _nhibernateHelper.OpenSession())
                {
                    session.Clear();
                    IQuery query = session.CreateQuery(Hql);
                    return query.List<object>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message);
            }
        }

        public object Load(string Hql, Dictionary<string, object> parameters)
        {
            try
            {
                using (NHibernate.ISession session = _nhibernateHelper.OpenSession())
                {
                    session.Clear();
                    IQuery query = session.CreateQuery(Hql);
                    query.SetParameterList(Hql,parameters);
                    return query.List<object>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message);
            }
        }

        public void Save(object obj)
        {
            try
            {
                using (NHibernate.ISession session = _nhibernateHelper.OpenSession())
                {
                    ITransaction Transaction = session.BeginTransaction();

                    Transaction.Begin();
                    session.Clear();
                    session.Save(obj);
                    Transaction.Commit();

                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Exception: " + ex.Message);
            }
        }

        public void Update(object obj)
        {
            try
            {
                using (NHibernate.ISession session = _nhibernateHelper.OpenSession())
                {
                    using (ITransaction Transaction = session.BeginTransaction())
                    {
                        Transaction.Begin();
                        session.Clear();
                        session.Update(obj);
                        Transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message);
            }
        }
    }

    public interface IPersistence
    {
        void Save(object obj);
        void Update(object obj);
        void Delete( object obj);
        object Load(string Hql);
        object Load(string Hql, Dictionary<string, object> parameters); 
    }
}
