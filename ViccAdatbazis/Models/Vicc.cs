namespace ViccAdatbazis.Models
{
    public class Vicc
    {
        public Vicc(int id, string tartalom, string feltolto, int tetszik, int nemTetszik)
        {
            Id = id;
            Tartalom = tartalom;
            Feltolto = feltolto;
            Tetszik = tetszik;
            NemTetszik = nemTetszik;
            Aktiv = tetszik > nemTetszik ? true : false;
        }

        public int Id { get; set; }
        public string Tartalom { get; set; }
        public string Feltolto { get; set; }
        public int Tetszik { get; set; }
        public int NemTetszik { get; set; }
        public bool Aktiv { get; set; }
    }
}
