using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel){
            return new CommentDto{
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                CreatedBy = commentModel.AppUser.UserName,
                StockId = commentModel.StockId
            };
        }

        public static Comment ToCommentFromCreate (this CreateCommentDto commentDto, int stockId, string appUserId){
            return new Comment{
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId,
                AppUserId = appUserId
            };
        }

        public static Comment ToCommentFromUpdate (this UpdateCommentRequestDto commentDto){
            return new Comment{
                Title = commentDto.Title,
                Content = commentDto.Content
            };
        }
    }
}