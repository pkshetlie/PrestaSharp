using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class EmployeeFactory : RestSharpFactory
    {
		public EmployeeFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.employee Get(long id)
        {
            RestRequest request = this.RequestForGet("employees", id, "employee");
            return this.Execute<Entities.employee>(request);
        }

        public Entities.employee Add(Entities.employee employee)
        {
            long? idAux = employee.id;
            employee.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(employee);
            RestRequest request = this.RequestForAdd("employees", Entities);
            Entities.employee aux = this.Execute<Entities.employee>(request);
            employee.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.employee Employee)
        {
            RestRequest request = this.RequestForUpdate("employees", Employee.id, Employee);
            this.Execute<Entities.employee>(request);
        }

        public void Delete(long EmployeeId)
        {
            RestRequest request = this.RequestForDelete("employees", EmployeeId);
            this.Execute<Entities.employee>(request);
        }

        public void Delete(Entities.employee Employee)
        {
            this.Delete((long)Employee.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("employees", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "employee");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.employee> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("employees", "full", Filter, Sort, Limit, "employees");
            return this.ExecuteForFilter<List<Entities.employee>>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<long> GetIdsByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("employees", "[id]", Filter, Sort, Limit, "employees");
            List<PrestaSharp.Entities.FilterEntities.employee> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.employee>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all employees.
        /// </summary>
        /// <returns>A list of employees</returns>
        public List<Entities.employee> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of employees.
        /// </summary>
        /// <param name="Employees"></param>
        /// <returns></returns>
        public List<Entities.employee> AddList(List<Entities.employee> Employees)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.employee Employee in Employees)
            {
                Employee.id = null;
                Entities.Add(Employee);
            }
            RestRequest request = this.RequestForAdd("employees", Entities);
            return this.Execute<List<Entities.employee>>(request);
        }        
    }
}
