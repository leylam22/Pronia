﻿using Microsoft.EntityFrameworkCore;
using Pronia.Core.Entities;

namespace Pronia.DataAccess.Contexts;

public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

	public DbSet<Slider> Sliders { get; set; } = null!;
}
