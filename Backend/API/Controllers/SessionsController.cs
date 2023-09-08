﻿using API.Files;
using API.Utils;
using Core.IServices.Sessions;
using Core.IUtils;
using Infrastructure.DTOs;
using Infrastructure.Entities.DataTables;
using Microsoft.AspNetCore.Mvc;
using static API.Middlewares.Authorization;
using static Infrastructure.DTOs.Sessions.SessionsDTOs.Requests;
using static Infrastructure.DTOs.Sessions.SessionsDTOs.Responses;
using static Infrastructure.Enums.Enums;

namespace API.Controllers
{
    [ProducesResponseType(200, Type = typeof(MessageResponse))]
    [ProducesResponseType(404, Type = typeof(MessageResponse))]
    [ProducesResponseType(400, Type = typeof(MessageResponse))]
    [Route("/api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {

        private readonly ITranslationService _translationService;
        private readonly ISessionService _sessionService;

        public SessionsController(ITranslationService translationService, ISessionService sessionService)
        {
            _translationService = translationService;
            _sessionService = sessionService;
        }





        [AuthorizeUser(UserRole.Admin)]
        [ProducesResponseType(200, Type = typeof(MessageResponseWithDataTable<IEnumerable<GetAllDT>>))]
        [HttpPost, Route("GetAllDT")]
        public async Task<IActionResult> GetAllDT(DataTableDTOs.SessionDT dto)
        {
            string langKey = Headers.GetLanguage(Request.Headers);

            (int count, IEnumerable<GetAllDT> list) data = await _sessionService.GetAllDT(dto);
            string message = _translationService.GetByKey(TranslationKeys.SuccessFetch, langKey, nameof(Session));
            return Ok(MessageResponseFactory.Create(message, data, dto));
        }



        [AuthorizeUser(UserRole.Admin)]
        [ProducesResponseType(200, Type = typeof(MessageResponseWithObj<GetById>))]
        [HttpGet, Route("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            string langKey = Headers.GetLanguage(Request.Headers);

            GetById data = await _sessionService.GetById(id);
            string message = _translationService.GetByKey(TranslationKeys.SuccessFetch, langKey, nameof(Session));
            return Ok(MessageResponseFactory.Create(message, data));
        }


        [AuthorizeUser(UserRole.Admin)]
        [HttpPost, Route("Create")]
        public async Task<IActionResult> Create(IFormFile? imageFile, [FromForm] Create dto)
        {
            string langKey = Headers.GetLanguage(Request.Headers);

            IFileProxy? file = imageFile != null ? new AzureFormFileProxy(imageFile) : null;
            await _sessionService.Create(file, dto);

            string message = _translationService.GetByKey(TranslationKeys.Created, langKey, nameof(Session));
            return Ok(MessageResponseFactory.Create(message));
        }


        [AuthorizeUser(UserRole.Admin)]
        [HttpPost, Route("Edit")]
        public async Task<IActionResult> Edit(IFormFile? imageFile, [FromForm] Edit dto)
        {
            string langKey = Headers.GetLanguage(Request.Headers);

            IFileProxy? file = imageFile != null ? new AzureFormFileProxy(imageFile) : null;
            await _sessionService.Edit(file, dto);

            string message = _translationService.GetByKey(TranslationKeys.Edited, langKey, nameof(Session));
            return Ok(MessageResponseFactory.Create(message));
        }


        [AuthorizeUser(UserRole.Admin)]
        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            string langKey = Headers.GetLanguage(Request.Headers);

            await _sessionService.Delete(id);

            string message = _translationService.GetByKey(TranslationKeys.Deleted, langKey, nameof(Session));
            return Ok(MessageResponseFactory.Create(message));
        }



        [AuthorizeUser(allowAll = true)]
        [HttpPost, Route("AddParticipant")]
        public async Task<IActionResult> AddParticipant(AddParticipant dto)
        {
            string langKey = Headers.GetLanguage(Request.Headers);

            await _sessionService.AddParticipant(dto);

            string message = _translationService.GetByKey(TranslationKeys.Created, langKey, nameof(Participant));
            return Ok(MessageResponseFactory.Create(message));
        }



        [AuthorizeUser(allowAll = true)]
        [HttpDelete, Route("DeleteParticipant/{id}")]
        public async Task<IActionResult> DeleteParticipant(Guid id)
        {
            string langKey = Headers.GetLanguage(Request.Headers);

            await _sessionService.DeleteParticipant(id);

            string message = _translationService.GetByKey(TranslationKeys.Deleted, langKey, nameof(Participant));
            return Ok(MessageResponseFactory.Create(message));
        }




    }
}
