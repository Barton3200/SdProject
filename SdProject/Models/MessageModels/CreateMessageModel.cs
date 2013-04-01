using System.ComponentModel.DataAnnotations;

namespace SdProject.Models.MessageModels {
    public class CreateMessageModel {
        [Required(ErrorMessage = "Every message needs a subject")] 
        public string Subject { get; set; }

        [Required(ErrorMessage = "A message cannot be empty")]
        [DataType(DataType.MultilineText)]
        public string MessageBody { get; set; }

        public string UpdateTargetId { get; set; }
    }
}