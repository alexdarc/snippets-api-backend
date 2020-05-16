namespace SnippetsApi.Features.Version1.Snippets.Actions.Get
{
    public class GetManyRequestModel
    {
        public int Limit { get; set; } = 50;

        public int Offset { get; set; } = 0;
    }
}
