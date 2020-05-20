namespace SnippetsApi.Features.Version1.Snippets.Actions.List
{
    public class ListRequestModel
    {
        public int Limit { get; set; } = 50;

        public int Offset { get; set; } = 0;
    }
}
