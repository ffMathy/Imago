using Autofac;
using Imago.Services.Design;

namespace Imago.Services
{
	public class DesignServicesModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder
				.RegisterType<DesignHistoryService>()
				.AsImplementedInterfaces();

			base.Load(builder);
		}
	}
}
