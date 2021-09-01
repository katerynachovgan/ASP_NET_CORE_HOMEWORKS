using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HW_11.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PharmacyController : ControllerBase
    {
        [HttpGet]
        public string GetRequest([FromQuery] Pharmacy prop)
        {
            return "Hello from GetRequest";
        }

        /*
         * curl --location --request GET 'https://localhost:5001/pharmacy?Name=Konex&Address=vinnitsa&EmployeeNumber=5' \
          --header 'TestHeared: TestHeared' \
          --header 'Content-Type: application/json' \
          --data-raw ''
        */

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Pharmacy> GetData([FromRoute] int id)
        {

            if (id > 5)
            {
                return NotFound();
            }

            return new Pharmacy
            {
                Id = 5,
                Name = "Podorognik",
                Address = "Kiyv",
                EmployeeNumber = 9
            };
        }

        /*
         * curl --location --request GET 'https://localhost:5001/pharmacy/4' \
            --header 'TestHeared: TestHeared' \
            --header 'Content-Type: application/json' \
            --data-raw '{
                "Name": "Konex",
                "Address": "Fastiv",
                "EmployeeNumber": 8
            }'
         */

        [HttpPost]
        public Pharmacy PostRequest([FromBody] Pharmacy pharmacy)
        {
            return pharmacy;
        }

        /*
         * curl --location --request POST 'https://localhost:5001/pharmacy' \
            --header 'TestHeared: TestHeared' \
            --header 'Content-Type: application/json' \
            --data-raw '{
                "Name": "Konex",
                "Address": "Fastiv",
                "EmployeeNumber": 8
            }'
         */


        [HttpDelete]
        public string DeleteRequest([FromHeader] int id)
        {
            return $"Pharmacy number {id} have been deleting";
        }

        /*
         * curl --location --request DELETE 'https://localhost:5001/pharmacy/' \
            --header 'TestHeared: TestHeared' \
            --header 'Content-Type: application/json' \
            --header 'id: 1' \
            --data-raw '{
                "Name": "Konex",
                "Address": "Fastiv",
                "EmployeeNumber": 8
            }'
         */

        [HttpPut]
        [Route("{id}")]
        public string PutRequest([FromRoute] int id)
        {
            return $"Pharmacy number {id} have been updating";
        }

        /*
         * 
         * curl --location --request PUT 'https://localhost:5001/pharmacy/0' \
            --header 'TestHeared: TestHeared' \
            --header 'Content-Type: application/json' \
            --data-raw '{
                "Name": "Konex",
                "Address": "Fastiv",
                "EmployeeNumber": 8
            }'
         */
    }
}
