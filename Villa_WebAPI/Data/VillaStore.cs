using System.Xml.Linq;
using Villa_WebAPI.Models;

namespace Villa_WebAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> GetVillaList = new List<VillaDTO>()
         { 
                new VillaDTO() { Id = 1, Name = "Pool View" },
                new VillaDTO { Id=2,Name="Beach View"  } //we can create and initialize with () brackets or withoutṣ
          };
    }
}
