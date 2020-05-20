namespace SnippetsApi.Features.Version1.Snippets.Actions.Create
{
    using System.ComponentModel.DataAnnotations;

    public class CreateRequestModel
    {
        [Required]
        [MaxLength(length: 1024)]
        public string Description { get; set; }

        [Required]
        [MaxLength(length: 255)]
        public string Content { get; set; }
    }
}
