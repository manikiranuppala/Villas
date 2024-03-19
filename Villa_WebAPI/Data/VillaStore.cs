using System.Xml.Linq;
using Villa_WebAPI.Models;

namespace Villa_WebAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> GetVillaList = new List<VillaDTO>()
         { 
                new VillaDTO() { Id = 1, Name = "Pool View",Occupency=5,Sqft=100 },
                new VillaDTO { Id=2,Name="Beach View",Occupency=6,Sqft=150  } //we can create and initialize with () brackets or withoutṣ

          };
    }
}
