using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using JurneyTag.Core;
using JurneyTag.Core.Models;
using JurneyTag.Resources;
using JurneyTag.Utilities.Mappers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JurneyTag.Controllers
{
    [Route("api/offert")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class OffertController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOffertRespository _offertRespository;

        public OffertController(IUnitOfWork unitOfWork, IOffertRespository offertRespository)
        {
            _unitOfWork = unitOfWork;
            _offertRespository = offertRespository;
        }

        [HttpPost("addOffert")]
        public async Task<IActionResult> AddOffert(OffertResource offertResource)
        {
            var offert = OffertMapper.MapOffertResourceToOffert(offertResource);

            _offertRespository.AddOffert(offert);
            await _unitOfWork.UpdateDatabase();
            return Ok();
        }

        [HttpGet("getOffert/{id}")]
        public async Task<IActionResult> GetOffert(int id)
        {
            var offert = await _offertRespository.GetOffert(id);
            var offertResource = OffertMapper.MapOffertToOffertResource(offert);

            return Ok(offertResource);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetOfferts()
        {
            var offerts = await _offertRespository.GetOfferts();
            var offertResources = OffertMapper.MapOffertsToOffertsResources(offerts);

            return Ok(offertResources);
        }

        [HttpPost("addClient")]
        public async Task<IActionResult> AddClient(ClientInfoResource clientInfoResource)
        {
            var clientInfo = OffertMapper.MapClientInfoResourceToClientInfo(clientInfoResource);

            _offertRespository.AddClient(clientInfo);
            await _unitOfWork.UpdateDatabase();

            return Ok();
        }

        [HttpGet("getClients/{offertId}")]
        public async Task<IActionResult> GetClients(int offertId)
        {
            var clients = await _offertRespository.GetClientsInfo(offertId);
            var clientsResources = OffertMapper.MapClientsInfoToClientInfoResources(clients);

            return Ok(clientsResources);
        }

        [HttpPost("publishOffert")]
        public async Task<IActionResult> PublishOffert([FromBody] int id)
        {
            var offert = await _offertRespository.GetOffert(id);
            offert.IsPublished = true;
            await _unitOfWork.UpdateDatabase();

            return Ok();
        }

        [HttpPost("checkClient")]
        public async Task<IActionResult> CheckClient(ClientInfoResource clientInfoResource)
        {
            var clients = await _offertRespository.GetClientsInfo(clientInfoResource.OffertId);
            var client = clients.SingleOrDefault(c => c.Id == clientInfoResource.Id);

            var offert = await _offertRespository.GetOffert(clientInfoResource.OffertId);
            client.Offert = offert;

            if (clientInfoResource.IsAccepted)
            {
                client.IsAccepted = true;
                SendAcceptedEmail(client);     
            }
            if (clientInfoResource.IsRejected)
            {
                client.IsRejected = true;
                SendRejectedEmail(client);
            }
            await _unitOfWork.UpdateDatabase();
            return Ok();
        }

        private void SendAcceptedEmail(ClientInfo clientInfo)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("piechurnotificationsystem@gmail.com");
                mail.To.Add(clientInfo.Email);
                mail.Subject = "Piechur.pl Akceptacja" + "-" + clientInfo.Offert.Name;
                mail.Body = "<h2>Zostałeś pomyślnie dodany do listy klientów</h2>" +
                            "<p> Organizator Dawid Zoń zaakceptował Ciebie jako nowego klienta. </p>" +
                            "<p> Oto krótki opis oferty: </p>" +
                            clientInfo.Offert.Description;

                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("piechurnotificationsystem@gmail.com", "Piechur123");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

        }

        private void SendRejectedEmail(ClientInfo clientInfo)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("piechurnotificationsystem@gmail.com");
                mail.To.Add(clientInfo.Email);
                mail.Subject = "Piechur.pl Odmowa" + "-" +  clientInfo.Offert.Name;
                mail.Body = "<h2>Niestety Twoje zgłoszenie zostało odrzucone przez organizatora</h2>" +
                            "<p>Organizator Dawid Zoń odrzucił Twoje zgłoszenie. </p>";

                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("piechurnotificationsystem@gmail.com", "Piechur123");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

        }


    }
}