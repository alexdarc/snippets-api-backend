namespace SnippetsApi.Features.Version1.Snippets.Actions.GetSingle
{
    using System.ComponentModel.DataAnnotations;
    using Common.Mongo;

    public class GetRequestModel
    {
        [Required]
        [ObjectId]
        public string Id { get; set; }
    }
}
