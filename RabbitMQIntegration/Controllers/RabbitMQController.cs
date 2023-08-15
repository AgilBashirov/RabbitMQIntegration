using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQIntegration.RabbitMQ;

namespace RabbitMQIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
        private readonly IRabbitMQProducer _rabbitMqProducer;

        public RabbitMQController(IRabbitMQProducer rabbitMqProducer)
        {
            _rabbitMqProducer = rabbitMqProducer;
        }

        [HttpGet("sendRabbit")]
        public OkResult SendRabbitMq(string message)
        {
            _rabbitMqProducer.SendMessage(message);
            return Ok();
        }
        [HttpGet("receiveRabbit")]
        public async Task<IActionResult> ReceiveRabbitMq()
        {
            var message = _rabbitMqProducer.ReceiveMessage();
            return Ok(message);
        }
    }
}
