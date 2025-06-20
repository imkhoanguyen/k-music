﻿using System.Diagnostics;
using System.Linq.Expressions;
using Music.Application.DTOs.Comments;
using Music.Application.Mappers;
using Music.Application.Parameters;
using Music.Application.Repositories;
using Music.Application.Service.Abstract;
using Music.Application.Utilities;
using Music.Domain.Exceptions;
using Music.Domain.Entities;
using Music.Domain.Enum;

namespace Music.Application.Service.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unit;

        public CommentService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<CommentDto> AddAsync(CommentCreateDto dto)
        {
            if (!Enum.TryParse<CommentType>(dto.RelatedType, out var commentType))
            {
                throw new BadRequestException("Invalid RelatedType.");
            }

            if (dto.RelatedId < 1)
            {
                switch (commentType)
                {
                    case CommentType.Playlist:
                        throw new BadRequestException("Không tìm thấy danh sách phát để bình luận.");

                    case CommentType.Song:
                        throw new BadRequestException("Không tìm thấy bài hát để bình luận.");

                    case CommentType.Singer:
                        throw new BadRequestException("Không tìm thấy ca sĩ để bình luận.");
                }
            }

            var entity = new Comment
            {
                Content = dto.Content,
                RelatedId = dto.RelatedId,
                RelatedType = commentType,
                UserId = dto.UserId,
            };

            await _unit.Comment.AddAsync(entity);

            if (await _unit.CompleteAsync())
            {
                var returnEntity = await _unit.Comment.GetAsync(c => c.Id == entity.Id);
                return CommentMapper.EntityToCommentDto(returnEntity);
            }

            throw new BadRequestException("Có lỗi xảy ra khi thêm bình luận");
        }

        public async Task<CommentDto> AddReplyAsync(ReplyCreateDto dto)
        {
            if (!Enum.TryParse<CommentType>(dto.RelatedType, out var commentType))
            {
                throw new BadRequestException("Invalid RelatedType.");
            }

            if (dto.RelatedId < 1)
            {
                switch (commentType)
                {
                    case CommentType.Playlist:
                        throw new BadRequestException("Không tìm thấy danh sách phát để bình luận.");

                    case CommentType.Song:
                        throw new BadRequestException("Không tìm thấy bài hát để bình luận.");

                    case CommentType.Singer:
                        throw new BadRequestException("Không tìm thấy ca sĩ để bình luận.");
                }
            }

            var entity = new Comment
            {
                Content = dto.Content,
                RelatedId = dto.RelatedId,
                RelatedType = commentType,
                UserId = dto.UserId,
                ParentCommentId = dto.ParentCommentId,
            };

            await _unit.Comment.AddAsync(entity);

            if (await _unit.CompleteAsync())
            {
                var returnEntity = await _unit.Comment.GetAsync(c => c.Id == entity.Id);
                return CommentMapper.EntityToCommentDto(returnEntity);
            }

            throw new BadRequestException("Có lỗi xảy ra khi thêm bình luận");
        }

        public async Task<PagedList<CommentDto>> GetAllAsync(Expression<Func<Comment, bool>> expression, CommentParams prm)
        {
            var pagedList = await _unit.Comment.GetAllAsync(expression, prm);

            var dtos = pagedList.Select(CommentMapper.EntityToCommentDto);

            return new PagedList<CommentDto>(dtos, pagedList.TotalCount, pagedList.CurrentPage, pagedList.PageSize);
        }

        public async Task<CommentDto> GetAsync(Expression<Func<Comment, bool>> expression)
        {
            var entity = await _unit.Comment.GetAsync(expression);
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy bình luận");
            }
            return CommentMapper.EntityToCommentDto(entity);
        }

        public async Task RemoveAsync(Expression<Func<Comment, bool>> expression)
        {
            var entity = await _unit.Comment.GetAsync(expression, true);
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy bình luận");
            }

            _unit.Comment.Remove(entity);

            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Có lỗi xảy ra khi xóa bình luận");
            }
        }

        public async Task<CommentDto> UpdateAsync(CommentUpdateDto dto)
        {
            var entity = await _unit.Comment.GetAsync(c => c.Id == dto.Id, true);
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy bình luận");
            }

            entity.Updated = DateTime.Now;
            entity.Content = dto.Content;

            if (await _unit.CompleteAsync())
            {
                var returnEntity = await _unit.Comment.GetAsync(c => c.Id == entity.Id);
                return CommentMapper.EntityToCommentDto(returnEntity);
            }

            throw new BadRequestException("Có lỗi xảy ra khi chỉnh sửa bình luận");
        }
    }
}
