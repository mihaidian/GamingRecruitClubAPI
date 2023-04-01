﻿using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.Helpers;
using GamingRecruitClubAPI.Models;
using GamingRecruitClubAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GamingRecruitClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevInfosController : Controller
    {
        private readonly IDevInfosService _devsService;
        private readonly ILogger<DevInfosController> _logger;
        public DevInfosController(IDevInfosService devInfosService, ILogger<DevInfosController> logger)
        {
            _devsService = devInfosService;
            _logger = logger;
        }
        [HttpGet(Name="See all available Games")]
        public async Task<IActionResult> GetAllInfosAsync()
        {
            try
            {
                _logger.LogInformation("Getting all available Devs...");
                var devs = await _devsService.GetDevInfosAsync();
                if (devs == null || !devs.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(devs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Getting all devs occured an error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task <IActionResult> GetInfosById([FromRoute]Guid id)
        {
            try
            {
                _logger.LogInformation("Getting all available Devs by ID...");
                var devs = await _devsService.GetDevInfoByIdAsync(id);
                if (devs == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(devs);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Getting all devs by ID occured an error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UploadDevAsync([FromBody] DevInfoDTO newDev)
        {
            try
            {
                _logger.LogInformation(" Upload Developer started!");
                if (newDev == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _devsService.UploadDeveloperAsync(newDev);
                return Ok(SuccesMessagesEnum.ElementSuccesfullyCreated);
            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception error: {ex.Message}");
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Validation exception error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }
        }

    }
    }

