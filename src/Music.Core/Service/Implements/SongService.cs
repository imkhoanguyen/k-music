﻿using Music.Core.Entities;
using Music.Core.Exceptions;
using System.Linq.Expressions;
using Music.Core.DTOs.Songs;
using Music.Core.Utilities;
using Music.Core.Parameters;
using Music.Core.Repositories;
using Music.Core.Mappers;
using Music.Core.Interfaces;
using Music.Core.Service.Interfaces;

namespace Music.Application.Service.Implementation
{
    public class SongService : ISongService
    {
        private readonly IUnitOfWork _unit;
        private readonly ICloudinaryService _cloudinaryService;

        public SongService(IUnitOfWork unit, ICloudinaryService cloudinaryService)
        {
            _unit = unit;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<SongDto> CreateAsync(SongCreateDto songCreateDto)
        {
            // up ảnh lên cloudinary
            var resultUpImg = await _cloudinaryService.AddImageAsync(songCreateDto.ImgFile);
            if (resultUpImg.Error != null)
                throw new BadRequestException(resultUpImg.Error);

            // up audio lên cloudinary
            var resultUpAu = await _cloudinaryService.AddFileAsync(songCreateDto.SongFile);
            if (resultUpAu.Error != null)
                throw new BadRequestException(resultUpAu.Error);

            var song = SongMapper.SongCreateDtoToEntity(songCreateDto); // map songCreateDto to Song
            song.ImgUrl = resultUpImg.Url;
            song.PublicImgId = resultUpImg.PublicId;
            song.SongUrl = resultUpAu.Url;
            song.PublicSongId = resultUpAu.PublicId;

            // add song_genre
            foreach (int genreId in songCreateDto.GenreList)
            {
                var songGenre = new SongGenre(song.Id, genreId);
                song.SongGenres.Add(songGenre);
            }

            // add song_singer
            foreach (int singerId in songCreateDto.SingerList)
            {
                var songSinger = new SongSinger(song.Id, singerId);
                song.SongSingers.Add(songSinger);
            }

            // add song to db
            await _unit.Song.AddAsync(song);

            if (await _unit.CompleteAsync())
            {
              
               var songToReturn = await _unit.Song.GetAsync(s => s.Id == song.Id);
               return SongMapper.EntityToSongDto(songToReturn); 
            }

            throw new BadRequestException("Xảy ra lỗi khi thêm bài hát");
        }

        public async Task DeleteAsync(Expression<Func<Song, bool>> expression)
        {
            var song = await _unit.Song.GetAsync(expression);
            if (song == null)
               throw new NotFoundException("Không tìm thấy bài hát");

            // delete img on cloudinary
            if (song.PublicImgId != null)
            {
                var resultDeteleImg = await _cloudinaryService.DeleteFileAsync(song.PublicImgId);
                if (resultDeteleImg.Error != null)
                    throw new BadRequestException(resultDeteleImg.Error);
            }


            // delete song on cloudinary
            if (song.PublicSongId != null)
            {
                var resultDeleteSong = await _cloudinaryService.DeleteFileAsync(song.PublicSongId);
                if (resultDeleteSong.Error != null)
                    throw new BadRequestException(resultDeleteSong.Error);
            }

            _unit.Song.Remove(song);

            if (!await _unit.CompleteAsync())
                throw new BadRequestException("Xảy ra lỗi khi xóa bài hát");
        }

        public async Task<PagedList<SongDto>> GetAllAsync(SongParams prm, Expression<Func<Song, bool>>? expression = null)
        {
            var songs = await _unit.Song.GetAllAsync(prm, expression);

            var songDtos = songs.Select(SongMapper.EntityToSongDto); // map

            return new PagedList<SongDto>(songDtos, songs.TotalCount, songs.CurrentPage, songs.PageSize);
        }

        public async Task<IEnumerable<SongDto>> GetRandomSongAsync(int size, RandomSongRequest requset)
        {
            var songs = await _unit.Song.GetRandomAsync(size, requset);
            return songs.Select(SongMapper.EntityToSongDto).ToList();
        }

        public async Task<IEnumerable<SongDto>> GetAllAsync(Expression<Func<Song, bool>>? expression = null)
        {
            var songs = await _unit.Song.GetAllAsync(expression);
            return songs.Select(SongMapper.EntityToSongDto);
        }

        public async Task<SongDto> GetAsync(Expression<Func<Song, bool>> expression)
        {
            var song = await _unit.Song.GetAsync(expression, false);
            if (song == null)
            {
                throw new NotFoundException("Không tìm thấy bài hát");
            }

            return SongMapper.EntityToSongDto(song);
        }

        public async Task<SongDto> UpdateAsync(int songId, SongUpdateDto songUpdateDto)
        {
            if (songUpdateDto.Id != songId)
                throw new BadRequestException("Không thể cập nhật bài hát");

            var songToUpdate = SongMapper.SongUpdateDtoToEntity(songUpdateDto); //map

            // Update new photo if available (cloudinary)
            if (songUpdateDto.ImgFile != null)
            {
                var resultUploadImg = await _cloudinaryService.AddImageAsync(songUpdateDto.ImgFile);
                if (resultUploadImg.Error != null)
                    throw new BadRequestException(resultUploadImg.Error);

                songToUpdate.ImgUrl = resultUploadImg.Url;
                songToUpdate.PublicImgId = resultUploadImg.PublicId;
                await _unit.Song.UpdateImgFileAsync(songToUpdate); // update img file
            }

            // Update new song file if available (cloudinary)
            if (songUpdateDto.SongFile != null)
            {
                var resultUploadSong = await _cloudinaryService.AddFileAsync(songUpdateDto.SongFile);
                if (resultUploadSong.Error != null)
                    throw new BadRequestException(resultUploadSong.Error);

                songToUpdate.SongUrl = resultUploadSong.Url;
                songToUpdate.PublicSongId = resultUploadSong.PublicId;
                await _unit.Song.UpdateSongFileAsync(songToUpdate); // update song file
            }


            // update song_genres
            var currentGenreList = await _unit.Song.GetAllGenreBySongIdAsync(songId);
            // genres need add
            var genresToAdd = songUpdateDto.GenreList.Except(currentGenreList.Select(sg => sg.GenreId))
                .Select(genreId => new SongGenre(songId, genreId));
            // genres need remove
            var genresToRemove = currentGenreList.Select(sg => sg.GenreId).Except(songUpdateDto.GenreList)
                .Select(genreId => new SongGenre(songId, genreId));
            // add, remove to db
            await _unit.SongGenre.AddRangeAsync(genresToAdd);
            _unit.SongGenre.DeleteRange(genresToRemove);



            // update song_singers
            var currentSingerList = await _unit.Song.GetAllSingerBySongIdAsync(songId);
            // singers need add
            var singersToAdd = songUpdateDto.SingerList.Except(currentSingerList.Select(ss => ss.SingerId))
                .Select(singerId => new SongSinger(songId, singerId));
            // singers need remove
            var singersToRemove = currentSingerList.Select(ss => ss.SingerId).Except(songUpdateDto.SingerList)
                .Select(singerId => new SongSinger(songId, singerId));
            // add, remove to db
            await _unit.SongSinger.AddRangeAsync(singersToAdd);
            _unit.SongSinger.DeleteRange(singersToRemove);

            // update orther property song
            await _unit.Song.UpdateSongAsync(songToUpdate);

            // save to db
            if (await _unit.CompleteAsync())
            {
                var songToReturn = await _unit.Song.GetAsync(s => s.Id == songId);
                return SongMapper.EntityToSongDto(songToReturn);
            }
            throw new BadRequestException("Xảy ra lỗi khi cập nhật bài hát");
        }

        public async Task UpdateVipAsync(int songId, bool vip)
        {
            var song = await _unit.Song.GetAsync(s => s.Id == songId);
            if (song == null) throw new NotFoundException("Không tìm thấy bài hát");

            await _unit.Song.UpdateSongVipAsync(songId, vip);

            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Xảy ra lỗi khi cập nhật vip của bài hát");
            }
            
        }
    }
}
