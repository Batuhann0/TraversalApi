using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalApi.DAL.Context;
using TraversalApi.DAL.Entities;

namespace TraversalApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var c = new VisitorContext())
            {
                var values = c.Visitors.ToList();
                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var c = new VisitorContext())
            {
                c.Visitors.Add(visitor);
                c.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using (var c = new VisitorContext())
            {
                var values = c.Visitors.Find(id);

                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);

                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            using (var c = new VisitorContext())
            {
                var values = c.Visitors.Find(id);

                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    c.Remove(values);
                    c.SaveChanges();
                    return Ok();
                }
            }
        }

        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            using (var c = new VisitorContext())
            {
                var values = c.Find<Visitor>(visitor.VisitorID);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    values.Name = visitor.Name;
                    values.Surname = visitor.Surname;
                    values.City = visitor.City;
                    values.Country = visitor.Country;
                    values.Mail = visitor.Mail;

                    c.Update(values);
                    c.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
