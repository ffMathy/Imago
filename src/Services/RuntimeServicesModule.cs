using Autofac;
using Imago.Services.Runtime;

namespace Imago.Services
{
	public class RuntimeServicesModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<HistoryService>();

			base.Load(builder);
		}
	}
}
