namespace Infrastructure.Persistence;

using Application.Abstractions.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public sealed class AppDbContext(
    DbContextOptions<AppDbContext> options)
    : DbContext(options), IAppDbContext
{
    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();

    public DbSet<Student> Students => Set<Student>();

    public DbSet<Admission> Admissions => Set<Admission>();
    public DbSet<Course> Courses => Set<Course>();

    public DbSet<AdmissionCourse> AdmissionCourses => Set<AdmissionCourse>();

    public DbSet<RevokedToken> RevokedTokens => Set<RevokedToken>();
}