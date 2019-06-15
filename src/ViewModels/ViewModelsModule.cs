using Autofac;

namespace Imago.ViewModels
{
	public class ViewModelsModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<MainViewModel>()
				.AsSelf()
				.SingleInstance();

			base.Load(builder);
		}
	}
}
