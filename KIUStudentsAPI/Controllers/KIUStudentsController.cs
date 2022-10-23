using KIUStudentsAPI.Data;
using KIUStudentsAPI.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KIUStudentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KIUStudentsController : ControllerBase
    {
        private readonly DataContext dataContext;
        

        public KIUStudentsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<KIUStudent>>> Get()
        {
            return  Ok(await dataContext.KiuStudents.ToListAsync());
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<KIUStudent>>> Get(int id)
        {
            var hero = await dataContext.KiuStudents.FindAsync(id);
            if (hero == null)
                return BadRequest("NO such hero");
            return  Ok(hero);
        }
        
        [HttpPost]
        public async Task<ActionResult<List<KIUStudent>>> AddHero(KIUStudent hero)
        {
            dataContext.KiuStudents.Add(hero);
            await dataContext.SaveChangesAsync();
            
            return  Ok(await dataContext.KiuStudents.ToListAsync());
        }
        
        [HttpPut]
        public async Task<ActionResult<List<KIUStudent>>> Update(KIUStudent request)
        {
            var dbHero = await dataContext.KiuStudents.FindAsync(request.Id);
            if (dbHero == null)
                return BadRequest("NO such hero");
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.GPA = request.GPA;
            
            await dataContext.SaveChangesAsync();

            
            return  Ok(await dataContext.KiuStudents.ToListAsync());
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<KIUStudent>>> Delete(int id)
        {
            var dbHero = await dataContext.KiuStudents.FindAsync(id);
            if (dbHero == null)
                return BadRequest("NO such hero");

            dataContext.KiuStudents.Remove(dbHero);
            await dataContext.SaveChangesAsync();
            return  Ok(dbHero);
        }
        
    }
}
