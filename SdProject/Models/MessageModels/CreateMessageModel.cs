using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SdProject.Models.MessageModels {
    public class CreateMessageModel {
        public string Subject { get; set; }
        public string MessageBody { get; set; }
    }
}