using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitThis.Classes
{
    /// <summary>
    /// Abstract/Interface class common to all data mappers
    /// </summary>
    /// <typeparam name="T">The type of object the mapper is for</typeparam>
    public abstract class IDataMapper<T>
    {
        /// <summary>
        /// A .Net database connection (SQL Server, MySql, Oracle, etc.... )
        /// </summary>
        public IDbConnection Connection { get; private set; }

        /// <summary>
        /// Reads configuration from the app.config and initializes the data mapper
        /// </summary>
        /// <param name="connection">A .net connection that implements IDbConnection</param>
        public IDataMapper(IDbConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("A valid database connection is required");

            this.Connection = connection;
        }

        /// <summary>
        /// Default select method for type T
        /// </summary>
        /// <param name="exError">Out exception object</param>
        /// <returns>List of type T</returns>
        public abstract List<T> Select(out Exception exError);

        /// <summary>
        /// Default create method for type T
        /// </summary>
        /// <param name="instance">The instance to create</param>
        /// <param name="exError">Out exception object</param>
        /// <returns>Boolean success/failure</returns>
        public abstract bool Create(T instance, out Exception exError);

        /// <summary>
        /// Default read method for type T 
        /// </summary>
        /// <param name="ID">ID of instance to read</param>
        /// <param name="exError">Out exception object</param>
        /// <returns>Instance of type T</returns>
        public abstract T Read(int ID, out Exception exError);

        /// <summary>
        /// Default read method for type T 
        /// </summary>
        /// <param name="instance">Object of instance to read</param>
        /// <param name="exError">Out exception object</param>
        /// <returns>Instance of type T</returns>
        public abstract T Read(T instance, out Exception exError);

        /// <summary>
        /// Default update method for type T
        /// </summary>
        /// <param name="instance">Object of instance to update</param>
        /// <param name="exError">Out exception object</param>
        /// <returns>Instance of type T</returns>
        public abstract bool Update(T instance, out Exception exError);

        /// <summary>
        /// Default delete method for type T 
        /// </summary>
        /// <param name="ID">ID of instance to delete</param>
        /// <param name="exError">Out exception object</param>
        /// <returns>Boolean success/failure</returns>
        public abstract bool Delete(int ID, out Exception exError);

        /// <summary>
        /// Default delete method for type T 
        /// </summary>
        /// <param name="instance">Object of instance to delete</param>
        /// <param name="exError">Out exception object</param>
        /// <returns>Boolean success/failure</returns>
        public abstract bool Delete(T instance, out Exception exError);
    }
}
