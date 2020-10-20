﻿using System.Windows;
using AIS_Airoport.Core;

namespace AIS_Airoport
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		/// <summary>
		/// Custom startup so we load our IoC immediately before anything else
		/// </summary>
		/// <param name="e"></param>
		protected override void OnStartup(StartupEventArgs e)
		{
			// Let the base application do what it needs
			base.OnStartup(e);

			// Setup the main application
			ApplicationSetup();

			//Log it
			IoC.Logger.Log("Application starting up...", LogLevel.Debug);
		}

		/// <summary>
		/// Configures our application ready for use
		/// </summary>
		private void ApplicationSetup()
		{
			// Setup IoC
			IoC.Setup();

			// Bind a logger
			IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[]
			{
				// TODO: Add ApplicationSettings so we can set/edit a location
				//       For now just log to the path where this application is running
				new Core.FileLogger("OldLog.txt"),
			}));

			// Add our task manager
			IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

			// Bind a file manager
			IoC.Kernel.Bind<IFileManager>().ToConstant(new FileManager());
		}
	}
}