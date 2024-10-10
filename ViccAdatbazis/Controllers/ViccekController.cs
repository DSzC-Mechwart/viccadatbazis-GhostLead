using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ViccAdatbazis.Data;
using ViccAdatbazis.Models;

namespace ViccAdatbazis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViccController : ControllerBase
    {
        //Adatbázis kapcsolat
        private readonly ViccDbContext _context;
        public ViccController(ViccDbContext context)
        {
            _context = context;
        }


        //Összes Vicc
        [HttpGet]
        //public ActionResult<List<Vicc>> GetViccek()
        //{
        //    return _context.Viccek.Where(x => x.Aktiv == true).ToList();
        //}

        public async Task<ActionResult<List<Vicc>>> GetViccek()
        {
            return await _context.Viccek.Where(x => x.Aktiv == true).ToListAsync();
        }

        //Egy vicc 
        [HttpGet("{id}")]
        public async Task<ActionResult<Vicc>> GetVicc(int id)
        {
            var vicc = await _context.Viccek.FindAsync(id);
            //if (vicc == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return vicc;
            //}
            return vicc == null ? NotFound() : vicc;
        }

        //Vicc feltöltése
        [HttpPost]
        public async Task<ActionResult<Vicc>> PostVicc(Vicc vicc)
        {
            _context.Viccek.Add(vicc);
            await _context.SaveChangesAsync();

            //return Ok(vicc); Válasz: 200as kód

            //Válasz: vicc
            return CreatedAtAction("GetVicc", new { id = vicc.Id }, vicc);
        }

        //Vicc módosítása
        [HttpPut("{id}")]
        public async Task<ActionResult> PutVicc(int id, Vicc vicc)
        {
            if (id != vicc.Id)
            {
                return BadRequest();
            }
            _context.Entry(vicc).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Vicc törlése
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVicc(int id)
        {
            var vicc = await _context.Viccek.FindAsync(id);
            if (vicc == null)
            {
                return NotFound();
            }
            if (vicc.Aktiv == true)
            {
                vicc.Aktiv = false;
            }
            else
            {
                _context.Viccek.Remove(vicc);
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }





    }
    //public class ViccekController : Controller
    //{




    //    //List<Vicc> viccList = new List<Vicc>();

    //    //[HttpGet]
    //    //[Route("[controller]")]

    //    //public string Get()
    //    //{
    //    //    createviccek();
    //    //    string finalszoveg = "";
    //    //    foreach (var item in viccList)
    //    //    {
    //    //        finalszoveg += $"\n\n{item.Id}\n{item.Tartalom}\n{item.Tetszik}\n{item.NemTetszik}\n{item.Aktiv}";
    //    //    }
    //    //    return finalszoveg;
    //    //}

    //    //public void createviccek()
    //    //{
    //    //    Vicc vici = new Vicc(1,
    //    //        " A kalória az, ami éjszaka beköltözik a szekrényedbe, és kicseréli az összes ruhádat kisebbre. ",
    //    //        "Janivagyok",
    //    //        1,
    //    //        0);
    //    //    viccList.Add(vici);

    //    //    vici = new Vicc(2,
    //    //        " Ha csinálod, és nem élvezed, az már munka. ",
    //    //        "Pistivagyok",
    //    //        10,
    //    //        500);
    //    //    viccList.Add(vici);

    //    //    vici = new Vicc(3,
    //    //        " Ezt most nem értem, ha jobbra kanyarodok, miért indul be az ablaktörlő? Valamivel össze van kötve? ",
    //    //        "Emberiség",
    //    //        20,
    //    //        11);
    //    //    viccList.Add(vici);

    //    //    vici = new Vicc(4,
    //    //        "  Akkora paraszt vagy, hogy kocsonyával zselézed a hajad.  ",
    //    //        "Jólvagyokkössz",
    //    //        3,
    //    //        5);
    //    //    viccList.Add(vici);

    //    //    vici = new Vicc(5,
    //    //        "  A Facebook olyan, mint a hűtőszekrény. 15 percenként kinyitogatod, és mindig ugyanaz van benne.  ",
    //    //        "Mindenkisenki",
    //    //        0,
    //    //        7);
    //    //    viccList.Add(vici);
    //    //}
    //}
}
