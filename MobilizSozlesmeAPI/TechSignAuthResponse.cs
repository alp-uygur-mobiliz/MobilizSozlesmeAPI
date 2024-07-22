
namespace MobilizSozlesmeAPI
{
    public class TechSignAuthResponse
    {
        public TechSignAuthResponse(string token_type, string access_token, int expires_in, string refresh_token)
        {
            this.token_type = token_type ?? throw new ArgumentNullException(nameof(token_type));
            this.access_token = access_token ?? throw new ArgumentNullException(nameof(access_token));
            this.expires_in = expires_in;
            this.refresh_token = refresh_token ?? throw new ArgumentNullException(nameof(refresh_token));
        }

        public string token_type {  get; set; }
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }

    }
}
