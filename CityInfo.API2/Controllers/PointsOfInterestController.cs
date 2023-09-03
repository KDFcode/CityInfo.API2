using CityInfo.API2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CityInfo.API2.Controllers
{
     [Route("api/[controller]")]
    //
    //[Route("api/pointsofinterest")] //to moze inace ali nama bi mozda odgovaralo vise 
    // [Route("api/cities/somecityid/pointsofinterest")]

   //[Route("api/cities/{cityId}/pointsofinterest")]

    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        // [HttpGet]
        //[HttpGet("{cityId:int}")]
        [HttpGet("{cityId}/pointsofinterest")]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        { 
                
                var city =CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null) 
            {
                return NotFound();
            }
            return Ok(city.PointsOfInterest);
        }

        //[HttpGet]
        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c=> c.Id == cityId);
            if (city == null) 
                {
                return NotFound();
                }
            //find point of interest 
            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(c => c.Id == pointOfInterestId);

            if (pointOfInterest == null)
                {
                return NotFound();
                }
            return Ok(pointOfInterest);
        }


        //od kad sam dodao ovo 
        //izlazi mi
        //Failed to load API definition.
       //Fetch errorresponse status is 500 https://localhost:7183/swagger/v1/swagger.json

    }
}
