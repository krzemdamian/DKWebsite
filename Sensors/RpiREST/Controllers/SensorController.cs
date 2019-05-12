using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;
using Iot.Device.DHTxx;
using Iot.Units;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DKWeb.Sensors.RpiREST.Controllers
{
    [Route("api/[controller]")]
    public class SensorController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            // GPIO Pin, DHT Type
            try
            {
                using (DHTSensor dht = new DHTSensor(17, DhtType.Dht11))
                {
                    Temperature temperature = dht.Temperature;
                    double humidity = dht.Humidity;
                    return humidity.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
