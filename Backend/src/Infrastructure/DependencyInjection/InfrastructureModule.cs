using Autofac;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependencyInjection
{
	public class InfrastructureModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(context =>
			{
				var configuration = context.Resolve<IConfiguration>();
				var connectionString = configuration.GetConnectionString("DefaultConnection");

				var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
				optionsBuilder.UseSqlServer(connectionString);

				return new ApplicationDbContext(optionsBuilder.Options);
			}).InstancePerLifetimeScope();

			builder.RegisterType<EmployeeRepository>().As <IRepository<Employee>>().InstancePerLifetimeScope();
			builder.RegisterType<CafeRepository>().As<IRepository<Cafe>>().InstancePerLifetimeScope();
		}
	}
}
