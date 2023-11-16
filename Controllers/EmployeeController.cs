using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using EmpDemoApp.Repository;

namespace EmpDemoApp.Controllers
{
    public class EmployeeController : ApiController
    {


        // GET 
        public IHttpActionResult GetEmployees()
        {
            try
            {
                return Ok(EmployeeRepository.GetAllEmployees());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // GET 
        public IHttpActionResult GetEmployee(int id)
        {
            try
            {
                var employee = EmployeeRepository.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // POST
        public IHttpActionResult PostEmployee(EmployeeClass employee)
        {
            try
            {
                string msg = EmployeeRepository.AddEmployee(employee);
                if (msg.Contains("success"))
                {
                    return Ok(employee);
                }
                else
                {
                    return BadRequest(msg);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // PUT 
        public IHttpActionResult PutEmployee(int id, EmployeeClass employee)
        {
            try
            {
                string msg = EmployeeRepository.UpdateEmployee(employee);
                if (msg.Contains("success"))
                {
                    return Ok(employee);
                }
                else if (msg.Contains("0"))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(msg);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // DELETE 
        public IHttpActionResult DeleteEmployee(int id)
        {
            try
            {
                string msg = EmployeeRepository.DeleteEmployee(id);
                if (msg.Contains("success"))
                {
                    return Ok(msg);
                }
                else if (msg.Contains("0"))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(msg);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}