using Microsoft.VisualBasic;

namespace MobilizSozlesmeAPI
{
    public class Firma
    {
        public Firma(string? firmaAdı, İlgiliKisi? ilgiliKisi, string? firmaEPosta, string? firmaAdres, string? vergiDairesi, int? vergiNumarası)
        {
            FirmaAdı = firmaAdı;
            İlgiliKisi = ilgiliKisi;
            FirmaEPosta = firmaEPosta;
            FirmaAdres = firmaAdres;
            VergiDairesi = vergiDairesi;
            VergiNumarası = vergiNumarası;
        }

        public string? FirmaAdı {  get; set; }
        public İlgiliKisi? İlgiliKisi {  get; set; }
        public string? FirmaEPosta {  get; set; }
        public string? FirmaAdres {  get; set; }
        public string? VergiDairesi { get; set; }
        public int? VergiNumarası { get; set; }

    }
}
