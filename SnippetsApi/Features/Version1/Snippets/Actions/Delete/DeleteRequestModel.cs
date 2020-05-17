namespace SnippetsApi.Features.Version1.Snippets.Actions.Delete
{
    using System.ComponentModel.DataAnnotations;
    using Common.Mongo;

    public class DeleteRequestModel
    {
        [Required]
        [ObjectId]
        public string Id { get; set; }
    }
}
