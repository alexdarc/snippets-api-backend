namespace SnippetsApi.Features.Version1.Snippets.Actions.Create
{
    using System.ComponentModel.DataAnnotations;

    public class CreateRequestModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
