using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.IO;
using PDC03_MODULE08.Model;
using System.Threading.Tasks;

namespace PDC03_MODULE08.ViewModel
{
    public class EmployeeViewModel
    {
        //call database

        private Services.DatabaseContext getContext()
        {
            return new Services.DatabaseContext();
        }
        //Insert Records

        public int InsertEmployee(EmployeeModel obj) 
        {
            var _dbcontext = getContext();
            _dbcontext.Employee.Add(obj);
            int c = _dbcontext.SaveChanges();
            return c;
         }

        //Retrieve Records
        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var _dbcontext = getContext();
            var res = await _dbcontext.Employee.ToListAsync();
            return res;
        }
        //Delete Records
        public int DeleteEmployee(EmployeeModel obj)
        {
            var _dbcontext = getContext();
            _dbcontext.Employee.Remove(obj);
            int c = _dbcontext.SaveChanges();
            return c;
        }

        //Update Records
        public async Task<int> UpdateEmployee(EmployeeModel obj)
        {
            var _dbcontext = getContext();
            _dbcontext.Employee.Update(obj);
            int c =await _dbcontext.SaveChangesAsync();
            return c;
        }
    }
}
