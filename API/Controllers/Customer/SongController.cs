﻿using API.Controllers.Base;
using KM.Application.DTOs.Songs;
using KM.Application.Service.Abstract;
using KM.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Customer
{
    public class SongController : BaseApiController
    {
        private readonly ISongService _songService;
        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet("random-list")]
        public async Task<IEnumerable<SongDto>> GetRamdomSong([FromQuery] RandomSongRequest request)
        {
            return await _songService.GetRandomSongAsync(20, request);
        }

    }
}