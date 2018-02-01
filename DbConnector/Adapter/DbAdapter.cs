using DbConnector.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnector.Adapter
{
    public class DbAdapter : IDbAdapter
    {
        public IDbCommand DbCommand { get; private set; }
        public IDbConnection DbConnection { get; private set; }
        private const int _timeout = 5000;

        public DbAdapter(IDbCommand dbCommand, IDbConnection dbConnection)
        {
            DbCommand = dbCommand;
            DbConnection = dbConnection;
        }

        public IEnumerable<T> LoadObject<T>(string storedProcedure, IDbDataParameter[] parameters = null) where T:class
        {
            List<T> items = new List<T>();

            using (IDbConnection conn = DbConnection)
                using(IDbCommand cmd = DbCommand)
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); }
                cmd.CommandTimeout = _timeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedure;
                cmd.Connection = conn;

                if (parameters != null)
                {
                    foreach (IDbDataParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(DataMapper<T>.Instance.MapToObject(reader));
                }
            }

                return items;
        }

        public IEnumerable<T> LoadObject<T>(string storedProcedure, Func<IDataReader, T> mapper, IDbDataParameter[] parameters = null)
        {
            List<T> items = new List<T>();

            using (IDbConnection conn = DbConnection)
                using(IDbCommand cmd = DbCommand)
            {
                if (conn.State != ConnectionState.Open) { conn.Open(); }
                cmd.CommandTimeout = _timeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedure;
                cmd.Connection = conn;

                if(parameters != null)
                {
                    foreach (IDbDataParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(mapper(reader));
                }
                return items;

            }
        }

        public int ExecuteQuery(string storedProcedure, IDbDataParameter[] parameters, Action<IDbDataParameter[]> returnParameters = null)
        {
            using (IDbConnection conn = DbConnection)
            using(IDbCommand cmd = DbCommand)
            {
                if(conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.CommandTimeout = _timeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedure;
                cmd.Connection = conn;
                if(parameters != null)
                {
                    foreach(IDbDataParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                int returnVal = cmd.ExecuteNonQuery();
                if (returnParameters != null)
                {
                    returnParameters(parameters);
                }
                return returnVal;
            }
        }

        public object ExecuteScalar(string storedProcedure, IDbDataParameter[] parameters = null)
        {
            using (IDbConnection conn = DbConnection)
            using (IDbCommand cmd = DbCommand)
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                cmd.CommandTimeout = _timeout;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedure;
                cmd.Connection = conn;
                if (parameters != null)
                {
                    foreach (IDbDataParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                return cmd.ExecuteScalar();
            }
        }
    }
}
