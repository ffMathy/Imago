using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using Imago.Services;

namespace Imago.ViewModels
{
	public class ViewModelLocator
	{
		private static IContainer container;
		
		public MainViewModel Main => container.Resolve<MainViewModel>();

		public ViewModelLocator()
		{
			var builder = new ContainerBuilder();

			builder.RegisterModule<ServicesModule>();
			builder.RegisterModule<ViewModelsModule>();

			if (ViewModelBase.IsInDesignModeStatic)
			{
				builder.RegisterModule<DesignServicesModule>();
			}
			else
			{
				builder.RegisterModule<RuntimeServicesModule>();
			}

			container = builder.Build();
			
			ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
		}

		public static void Cleanup()
		{
			container?.Dispose();
		}
	}
}