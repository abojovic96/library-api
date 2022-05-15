using System;

namespace Books.API.Models.Responses
{
    public class TokenDto
    {
        public string Username { get; set; }

        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
