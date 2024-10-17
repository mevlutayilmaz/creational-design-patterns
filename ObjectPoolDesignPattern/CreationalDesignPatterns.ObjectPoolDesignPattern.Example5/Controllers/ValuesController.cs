using CreationalDesignPatterns.ObjectPoolDesignPattern.Example5.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;

//Asp.NET Core mimarisinde Object Pool Design Pattern 
namespace CreationalDesignPatterns.ObjectPoolDesignPattern.Example5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly ObjectPool<X> _pool;

        public ValuesController(ObjectPool<X> pool)
        {
            _pool = pool;
        }

        [HttpGet("[action]")]
        public IActionResult Get1()
        {
            X x = _pool.Get();
            x.Count++;
            _pool.Return(x);
            return Ok(x.Count);
        }

        [HttpGet("[action]")]
        public IActionResult Get2()
        {
            X x = _pool.Get();
            x.Count++;
            _pool.Return(x);
            return Ok(x.Count);
        }
    }
}
