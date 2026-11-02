namespace Api.Common.Authorization;

using System.Security.Claims;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
public sealed class AdmissionOwnerHandler
: AuthorizationHandler<AdmissionOwnerRequirement, Admission>
{
    protected override Task HandleRequirementAsync(
    AuthorizationHandlerContext context,
    AdmissionOwnerRequirement requirement,
    Admission resource)
    {
        if (context.User.IsInRole(nameof(UserRole.Registrar)))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
        Console.WriteLine("=== ADMISSION AUTHORIZATION DEBUG ===");
        Console.WriteLine($"Authenticated: {context.User.Identity?.IsAuthenticated}");
        Console.WriteLine($"User Role: {context.User.FindFirstValue(ClaimTypes.Role)}");
        Console.WriteLine($"Student ID Claim: {context.User.FindFirstValue("student_id")}");
        Console.WriteLine($"Admission Student ID: {resource.StudentId}");
        var studentIdClaim = context.User.FindFirstValue("student_id");
        if (Guid.TryParse(studentIdClaim, out var studentId) && resource.StudentId ==
        studentId)
        {
            context.Succeed(requirement);
        }
        // Not calling Succeed means the check fails - no context.Fail() needed
        return Task.CompletedTask;
    }
}