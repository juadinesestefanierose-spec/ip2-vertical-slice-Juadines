namespace Application.Features.Courses.UpdateCourse;

using Application.Abstractions.Messaging;
using Domain.Common;

public sealed record UpdateCourseCommand(
    Guid Id,
    string Code,
    string Title,
    int Credits
) : ICommand<Result<UpdateCourseResponse>>;

public sealed record UpdateCourseResponse(
    Guid Id,
    string Code,
    string Title,
    int Credits
);