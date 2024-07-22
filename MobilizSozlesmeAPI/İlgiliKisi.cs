namespace MobilizSozlesmeAPI
{
    public class İlgiliKisi
    {
        public İlgiliKisi(string? ad, string? soyadı, string? ePosta, string? cepTelefonu)
        {
            Ad = ad;
            Soyadı = soyadı;
            EPosta = ePosta;
            CepTelefonu = cepTelefonu;
        }

        public string? Ad {  get; set; }
        public string? Soyadı { get; set; }
        public string? EPosta { get; set; }
        public string? CepTelefonu { get; set; }

    }
}
