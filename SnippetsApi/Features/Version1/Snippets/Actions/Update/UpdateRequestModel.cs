namespace SnippetsApi.Features.Version1.Snippets.Actions.Update
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateRequestModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
