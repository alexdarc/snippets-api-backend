namespace SnippetsApi.Features.Version1.Snippets.Actions.Update
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateRequestModel
    {
        [Required]
        [MaxLength(length: 1024)]
        public string Description { get; set; }

        [Required]
        [MaxLength(length: 255)]
        public string Content { get; set; }
    }
}
