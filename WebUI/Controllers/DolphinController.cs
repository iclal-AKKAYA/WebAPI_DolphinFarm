using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DolphinController : ControllerBase
    {
        [HttpPost("post-dolphin-data")]

        public IActionResult AddDolphin([FromBody] DolphinData dolphinData)
        {
            if (dolphinData == null) return BadRequest("Uncorrect Data");

            DolphinBusiness dolphinBusiness = new DolphinBusiness();
            dolphinBusiness.AddDolphin(dolphinData);
            return Ok("Dolphin added is succesful");

        }

        [HttpGet("get-dolphin-data")]

        public DolphinData GetWhaleData()
        {
            List<DolphinData> dolphinData = new List<DolphinData>();
            DolphinBusiness dolphinBusiness = new DolphinBusiness();
            dolphinData = dolphinBusiness.GetData();
            int dolphinId = 0;
            string name = "";
            int age = 0;
            DateTime bornDate = DateTime.Now;
            bool ısItForRent = false;
            int rentalPrice = 0;
            foreach (DolphinData item in dolphinData)
            {
                dolphinId = item.DolphinId;
                name = item.Name;
                age = item.Age;
                bornDate = item.BornDate;
                ısItForRent = item.IsItForRent;
                rentalPrice = item.RentalPrice;

            }
            return new DolphinData(dolphinId, name, age, bornDate, ısItForRent, rentalPrice);

        }

        [HttpDelete("delete-dolphin-data")]

        public IActionResult DeleteDolphin(int dolphinId)
        {
            if (dolphinId == 0) return BadRequest("Uncorrect Data OR your ıd input is wrong");

            DolphinBusiness dolphinBusiness = new DolphinBusiness();
            bool isDeleted = dolphinBusiness.DeleteDolphin(dolphinId);

            if (!isDeleted) return NotFound();

            else return Ok("Dolphin delete is succesful");
           

        }

        [HttpPut("put-dolphin-data")]

        public IActionResult UpdateDolphin([FromBody] DolphinData dolphinData, int dolphinId)
        {
            if (dolphinId == 0) return BadRequest("Uncorrect Data OR your ıd input is wrong");

            DolphinBusiness dolphinBusiness = new DolphinBusiness();
            dolphinBusiness.UpdateDolphin(dolphinData, dolphinId);
            return Ok("UPDATE is successful");

        }
    }
}
