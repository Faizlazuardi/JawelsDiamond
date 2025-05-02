using JawelsDiamond.Models;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handler
{
    public class JewelHandler
    {
        public static List<MsJewel> GetAllJewels()
        {
            return JewelRepository.GetAllJewels();
        }

        public static MsJewel GetJewelById(int id)
        {
            return JewelRepository.GetJewelById(id);
        }
    }
}