namespace Matelso.ContactManager.Application.Responses
{
    public class BaseResponse
    {
        public Guid Id { get; set; }

        public List<String> Message { get; set; }

        public bool IsSuccess { get; set; } = true;
    }
}
