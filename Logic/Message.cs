﻿using System;


namespace Logic {
    public class Message {
        public int Id { get; set; }
        public string MessageBody { get; set; }       
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; } 
        public string LastModifiedBy { get; set; }     
    }
}
