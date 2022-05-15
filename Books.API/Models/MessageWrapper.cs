namespace Books.API.Models
{
    public class MessageWrapper
    {
        public MessageWrapper(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
