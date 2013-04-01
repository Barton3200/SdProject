using Logic;
using System.ComponentModel.DataAnnotations;

namespace SdProject.Models.MessageModels
{
    public class EditMessageModel
    {
        public EditMessageModel() {}
        public EditMessageModel(Message message) {
            MessageId = message.Id;
            Subject = message.Subject;
            MessageBody = message.MessageBody;
        }
        [Required]
        public int MessageId { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string MessageBody { get; set; }

        public string UpdateTargetId { get; set; }
    }

    public class EditMessageBodyModel {
        public EditMessageBodyModel() {}
        public EditMessageBodyModel(Message message) {
            MessageId = message.Id;
            MessageBody = message.MessageBody;
        }
        public EditMessageBodyModel(EditMessageModel message) {
            MessageId = message.MessageId;
            MessageBody = message.MessageBody;
        }

        [Required]
        public int MessageId { get; set; }
        [Required]
        public string MessageBody { get; set; }

        public string UpdateTargetId { get; set; }
    }

    public class EditMessageSubjectModel {
        public EditMessageSubjectModel() { }
        public EditMessageSubjectModel(Message message) {
            MessageId = message.Id;
            Subject = message.Subject;
        }
        public EditMessageSubjectModel(EditMessageModel message) {
            MessageId = message.MessageId;
            Subject = message.Subject;
        }

        [Required]
        public int MessageId { get; set; }
        [Required]
        public string Subject { get; set; }

        public string UpdateTargetId { get; set; }
    }
}