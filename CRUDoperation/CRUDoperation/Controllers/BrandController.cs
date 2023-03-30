using CRUDoperation.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDoperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandContext _dbContext;
        public BrandController(BrandContext dbContext)
        {
            _dbContext = dbContext;
        }
        //to get all brand Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            if(_dbContext.Brands == null)
            {
                return NotFound();
            }
           return await _dbContext.Brands.ToListAsync();
        }
        //To get Brand By id
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            if (_dbContext.Brands == null)
            {
                return NotFound();
            }
            var brand=await _dbContext.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return brand;
        }
        //http post method to add data to database
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBrand),new {id=brand.Id },brand);
        }
        //http put rthod used to add a prticular records from database by Id
        [HttpPut]
        public async Task<ActionResult> PutBrand(int Id,Brand brand)
        {
            if(Id!=brand.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(brand).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!BrandAvailable(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
            //declaring a prvivate bool to check brand availabe or not by id
             bool BrandAvailable(int id)
            {
                return (_dbContext.Brands?.Any(x => x.Id == id)).GetValueOrDefault();
            }
        }
        //For delete we have to create Http delete method
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            if(_dbContext==null)
            {
                return NotFound();
            }
            var brand =await _dbContext.Brands.FindAsync(id);
            if(brand==null)
            {
                return NotFound();
            }
            _dbContext.Brands.Remove(brand);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
