namespace MobilizSozlesmeAPI
{
    public class SozlesmeTextFields
    {
        public SozlesmeTextFields(string? adSoyadUnvan, string? vergiDairesi, string? vergiNumarası, string? adres, string? telefon, string? ePosta, string? cihazSeriNumarası)
        {
            AdSoyadUnvan = adSoyadUnvan;
            VergiDairesi = vergiDairesi;
            VergiNumarası = vergiNumarası;
            Adres = adres;
            Telefon = telefon;
            EPosta = ePosta;
            CihazSeriNumarası = cihazSeriNumarası;
        }

        public string? AdSoyadUnvan {  get; set; }
        public string? VergiDairesi { get; set; }
        public string? VergiNumarası { get; set; }
        public string? Adres { get; set; }
        public string? Telefon { get; set; }
        public string? EPosta { get; set; }
        public string? CihazSeriNumarası { get; set; }

    }
}
