using duonghongluyen.Exercise02.Context;
using duonghongluyen.Exercise02.Models;
using Microsoft.AspNetCore.Mvc;

namespace duonghongluyen.Exercise02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderStatusController : Controller
    {
        private Exercise02Context _db;
        public OrderStatusController(Exercise02Context db)
        {
            _db = db;
        }
        [HttpGet]
        public IEnumerable<OrderStatus> Get()
        {
            return _db.OrderStatuses.ToList();
        }
        [HttpGet("{id}", Name = "Get")]
        public OrderStatus Get(Guid id)
        {
            return _db.OrderStatuses.FirstOrDefault(e => e.Id == id);
        }
        [HttpPost]
        [Produces("application/json")]
        public void Post([FromBody] OrderStatus employee)
        {
            _db.OrderStatuses.Add(employee);
            _db.SaveChanges();
        }
        [HttpPut("id")]
        public void Put(Guid id, [FromBody] OrderStatus e)
        {
            var employee = _db.OrderStatuses.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _db.Entry<OrderStatus>(employee).CurrentValues.SetValues(e);
                _db.SaveChanges();
            }
        }
        [HttpDelete("id")]
        public void Delete(Guid id)
        {
            var employee = _db.OrderStatuses.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _db.OrderStatuses.Remove(employee);
                _db.SaveChanges();
            }
        }
    }
}