using CarWebsite.Api.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWebsite.Api.Controller
{
     [Route("api/ad")]
     [ApiController]
     public class AdController : ControllerBase
     {
          private static List<Ad> _ads = new();
          private static int _nextId = 1;

          [HttpGet("all")]
          public IActionResult GetAllAds()
          {
               return Ok(_ads);
          }

          [HttpGet("{id}")]
          public IActionResult GetAdById(int id)
          {
               var ad = _ads.FirstOrDefault(a => a.Id == id);
               if (ad == null)
               {
                    return NotFound(new { Message = $"Ad with ID {id} not found" });
               }

               return Ok(ad);
          }

          [HttpPost]
          public IActionResult CreateAd([FromBody] Ad ad)
          {
               ad.Id = _nextId++;
               _ads.Add(ad);

               return Created($"/api/ads/{ad.Id}", ad);
          }

          [HttpPut("{id}")]
          public IActionResult UpdateAd(int id, [FromBody] Ad updatedAd)
          {
               var existingAd = _ads.FirstOrDefault(a =>a.Id == id);
               if (existingAd == null)
               {
                    return NotFound(new { Message = $"Ad with ID {id} not found" });
               }

               existingAd.Name = updatedAd.Name;
               existingAd.Description = updatedAd.Description;

               return Ok(existingAd);
          }

          [HttpDelete("{id}")]
          public IActionResult DeleteAd(int id)
          {
               var ad = _ads.FirstOrDefault(a =>a.Id == id);
               if (ad == null)
               {
                    return NotFound(new { Message = $"Ad with ID {id} not found" });
               }
               _ads.Remove(ad);

               return NoContent();
          }
     }
}
