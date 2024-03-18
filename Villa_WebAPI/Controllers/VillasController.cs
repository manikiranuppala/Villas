using Microsoft.AspNetCore.Mvc;
using Villa_WebAPI.Data;
using Villa_WebAPI.Models;

namespace Villa_WebAPI.Controllers
{
    //[Route("api/[controller]")] //In future if we change the name of controller, then endpoint chnages and this will impact the existing users using it
    [Route("api/Villas")]
    [ApiController]
    public class VillasController : ControllerBase
    //need to inherit controller base if we inherit controller it will have MVC also because for both mvc and web api the controller is base class
    {
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas() // here the returntype can be IEnumerable<VillaDTO> or ActionResult<IEnumerable<VillaDTO>>
        {
            //return VillaStore.GetVillaList();
            return Ok(VillaStore.GetVillaList); // this will return statuscode as 200 OK
        }

        //[HttpGet]// if we don't define then by default GET is httpVerb
        //here we have two Get Methods and one accept ID, so we need to define the id in HTTP VERB as below 
        [HttpGet("Id",Name ="GetVilla")] // or we can give [HttpGet("{Id:int}",Name="GetVilla")] 
        //To document the API responses we use below Attributes
        [ProducesResponseType(200,Type=typeof(VillaDTO))] //here we need to declare Type if not decalred at ActionResult
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]// we can also use Statuscodes class and respective status instead of direct number 400
        public ActionResult<VillaDTO> GetVilla(int Id) // If we don't define the type of ActionResult and keep just ACtionResult and if we need sample response in document then need to declare the return type in above produceResponseType
        {
            //We can return multiple status codes with below conditions
            if(Id <=0)
            {
                return BadRequest(); // This will return 400 status
            }
            var VillaDetails= VillaStore.GetVillaList.FirstOrDefault(t => t.Id == Id);
            if(VillaDetails==null) 
            {
                return NotFound(); // This will return 404 status
            } 
            return Ok(VillaDetails); //this will return 200 OK staus
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> AddVilla([FromBody]VillaDTO villaDto) // we will use FromBody attribute to read it from Body
         // bydefault, ASP.NET Web API binds complex types from the request message body and simple types from URI, query string, etc
         //villa is complex type(class) and if i don't mention fromBody attribute it will bind automatically and work and if I pass in URI it will not work for complex datatype
         // for simple data type like string  we need to mention [FromBody] attribute and if we pass it in URI no need to mention [FromUri] attribute in WEB API, In MVC we need to mention both
        {
            if(villaDto == null) 
            { 
                return BadRequest();    
            }
            if(villaDto.Id > 0) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDto.Id = VillaStore.GetVillaList.OrderByDescending(t => t.Id).FirstOrDefault().Id + 1;
            VillaStore.GetVillaList.Add(villaDto);
            // return Ok(villaDto ); // We can return the created villa or we can route this to get villa by ID
            return CreatedAtRoute("GetVilla", new {id=villaDto.Id}, villaDto);

        }
    }
}
