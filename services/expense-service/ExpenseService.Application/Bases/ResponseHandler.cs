using ExpenseService.Application.Resources;
using ExpenseService.Domain.Commons;
using Microsoft.Extensions.Localization;
using System.Net;

namespace ExpenseService.Application.Bases
{
    public class ResponseHandler
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ResponseHandler(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }

        // Success (200)
        public Response<T> Success<T>(T data, string? message = null, object meta = null) =>
            Response<T>.Success(
                data,
                message ?? _localizer[SharedResourcesKeys.Success],
                HttpStatusCode.OK,
                meta
            );

        // Created (201)
        public Response<T> Created<T>(T data, string? message = null, object meta = null) =>
            Response<T>.Success(
                data,
                message ?? _localizer[SharedResourcesKeys.Created],
                HttpStatusCode.Created,
                meta
            );

        // Deleted (200 / 204)
        public Response<T> Deleted<T>(string? message = null, bool noContent = false) =>
            Response<T>.Success(
                default,
                message ?? _localizer[SharedResourcesKeys.Deleted],
                noContent ? HttpStatusCode.NoContent : HttpStatusCode.OK
            );

        // BadRequest (400)
        public Response<T> BadRequest<T>(string? message = null, List<string>? errors = null) =>
            Response<T>.Fail(
                message ?? _localizer[SharedResourcesKeys.BadRequest],
                HttpStatusCode.BadRequest,
                errors
            );

        // Unauthorized (401)
        public Response<T> Unauthorized<T>(string? message = null) =>
            Response<T>.Fail(
                message ?? _localizer[SharedResourcesKeys.UnAuthorized],
                HttpStatusCode.Unauthorized
            );

        // NotFound (404)
        public Response<T> NotFound<T>(string? message = null) =>
            Response<T>.Fail(
                message ?? _localizer[SharedResourcesKeys.NotFound],
                HttpStatusCode.NotFound
            );

        // UnprocessableEntity (422)
        public Response<T> UnprocessableEntity<T>(string? message = null, List<string>? errors = null) =>
            Response<T>.Fail(
                message ?? _localizer[SharedResourcesKeys.UnprocessableEntity],
                HttpStatusCode.UnprocessableEntity,
                errors
            );

        // InternalServerError (500)
        public Response<T> InternalServerError<T>(string? message = null, List<string>? errors = null) =>
            Response<T>.Fail(
                message ?? _localizer[SharedResourcesKeys.InternalServerError],
                HttpStatusCode.InternalServerError,
                errors
            );
    }
}
