using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ViccAdatbazis.Models;

namespace ViccAdatbazis.Controllers
{
    public class ViccekController : Controller
    {
        List<Vicc> viccList = new List<Vicc>();

        [HttpGet]
        [Route("[controller]")]

        public string Get()
        {
            createviccek();
            string finalszoveg = "";
            foreach (var item in viccList)
            {
                finalszoveg += $"\n\n{item.Id}\n{item.Tartalom}\n{item.Tetszik}\n{item.NemTetszik}\n{item.Aktiv}";
            }
            return finalszoveg;
        }

        public void createviccek()
        {
            Vicc vici = new Vicc(1,
                " A kalória az, ami éjszaka beköltözik a szekrényedbe, és kicseréli az összes ruhádat kisebbre. ",
                "Janivagyok",
                1,
                0);
            viccList.Add(vici);

            vici = new Vicc(2,
                " Ha csinálod, és nem élvezed, az már munka. ",
                "Pistivagyok",
                10,
                500);
            viccList.Add(vici);

            vici = new Vicc(3,
                " Ezt most nem értem, ha jobbra kanyarodok, miért indul be az ablaktörlő? Valamivel össze van kötve? ",
                "Emberiség",
                20,
                11);
            viccList.Add(vici);

            vici = new Vicc(4,
                "  Akkora paraszt vagy, hogy kocsonyával zselézed a hajad.  ",
                "Jólvagyokkössz",
                3,
                5);
            viccList.Add(vici);

            vici = new Vicc(5,
                "  A Facebook olyan, mint a hűtőszekrény. 15 percenként kinyitogatod, és mindig ugyanaz van benne.  ",
                "Mindenkisenki",
                0,
                7);
            viccList.Add(vici);
        }
    }
}
