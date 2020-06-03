using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoMongoDBNetCore.Core.Entities;
using TutoMongoDBNetCore.Core.Models;

namespace TutoMongoDBNetCore.Core.Services
{
    public class EmployeeService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IMongoCollection<Employee> _employees;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public EmployeeService(IEmployeeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _employees = database.GetCollection<Employee>(settings.EmployeesCollectionName);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Employee> Get()
        {
            List<Employee> employees;
            employees = _employees.Find(emp => true).ToList();
            return employees;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee Get(string id) =>
            _employees.Find<Employee>(emp => emp.Id == id).FirstOrDefault();
    }
}
