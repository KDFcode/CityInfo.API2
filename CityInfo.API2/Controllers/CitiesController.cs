using CityInfo.API2.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API2.Controllers
{
    [ApiController]
   [Route("api/cities")]
   // [Route("api/[controller]")] //posto nam je to za rutiranje istog imena kao kontroler onda mozemo ovako 
    public class CitiesController :ControllerBase
    {



        // [HttpGet("api/cities")] //ovaj deo nam ne treba za svaku metodu posebno kad imamo to podeseno gore preko  [Route("api/cities")] za celu klasu
//        [HttpGet]
//        public JsonResult GetCities()
//        {
//            //return  new JsonResult(
//            //      new List<object>
//            //      {
//            //      new {id=1, Name="New York City"},
//            //      new {id=2,Name="Antwerp"}
//            //      }); //ovo nam je trebalo ranije kad nismo imali klasu gradova i liste istih itd.,ali sad je nepotrebno

//            //var temp = new JsonResult(CitiesDataStore.Current.Cities);
//            //temp.StatusCode = 200;   
//////ovaj pristup je legit opcija ali je cimanje cim se nesto konkretnije radi,ControllerBase klasa korisne metode ima doduse


//            return new JsonResult(CitiesDataStore.Current.Cities); //ovo nam efektivno vraca sve trenutno postojece nazad
//        }


        [HttpGet]
        public ActionResult<IEnumerable<CityDto>>   GetCities()
        {
           
            return Ok(CitiesDataStore.Current.Cities); //Even an empty collection is a valid response so we dont need a second return option
        }




        //[HttpGet("{id}")] // api/cities vec imamo gore pokriveno,ali ovde treba da prosledimo direktno i id kao takav
        //public JsonResult GetCity(int id)
        //{ 
        //return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id)); //ovo radi u swagger-u,ali ne u postman-u,zasto?
        //} //hocemo da ne moramo da koristimo JSON pa radimo ovo dole


        [HttpGet("{id}")] // api/cities vec imamo gore pokriveno,ali ovde treba da prosledimo direktno i id kao takav
        public ActionResult<CityDto> GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            { 
            return NotFound(); //vratimo da nije nadjen ako ga nema da izbegnemo nejasni 404
            }

            return Ok(cityToReturn);
          }



    }
}
