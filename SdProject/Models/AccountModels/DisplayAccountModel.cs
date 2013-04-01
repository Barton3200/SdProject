using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SdProject.Models.HouseModels;

namespace SdProject.Models.AccountModels 
{
    public class DisplayAccountModel 
    {
        public User User { get; set; }
        public List<HouseDisplayModel> Houses { get; set; }
    }
}