namespace Application.Features.Courses.UpdateCourse;

using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

public sealed class UpdateCourseCommandHandler(
    IAppDbContext dbContext)
    : ICommandHandler<UpdateCourseCommand, Result<UpdateCourseResponse>>
{
    public async Task<Result<UpdateCourseResponse>> HandleAsync(
        UpdateCourseCommand command,
        CancellationToken cancellationToken = default)
    {
        var course = await dbContext.Courses
            .FirstOrDefaultAsync(c => c.Id == command.Id, cancellationToken);

        if (course is null)
        {
            return Result<UpdateCourseResponse>.Failure(
                Error.NotFound("Course.NotFound", "Course not found."));
        }

        course.Code = command.Code;
        course.Title = command.Title;
        course.Credits = command.Credits;

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result<UpdateCourseResponse>.Success(
            new UpdateCourseResponse(
                course.Id,
                course.Code,
                course.Title,
                course.Credits));
    }
}