﻿namespace AIS_Airport.Core
{
	/// <summary>
	/// The application state as a view model
	/// </summary>
	public class ApplicationViewModel : BaseViewModel
	{
		/// <summary>
		/// The current page of the application
		/// </summary>
		public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

		/// <summary>
		/// The view model to use for the current page when the CurrentPage changes
		/// NOTE: This is not a live up-to-date view model of the current page
		///		  it's simply used to set the view model of the current page 
		///		  at the time it changes
		/// </summary>
		public BaseViewModel CurrentPageViewModel { get; private set; }

		/// <summary>
		/// Navigates to the specified page
		/// </summary>
		/// <param name="page">The page to go to</param>
		/// <param name="viewModel">The view model, if any, to set explicitly to the new page</param>
		public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
		{
			// Set the view model
			CurrentPageViewModel = viewModel;

			// See if page has changed
			var different = CurrentPage != page;

			// Set the current page
			CurrentPage = page;

			// If the page has'n changed, fore off notification
			// So pages still update if just the view model has changed
			if (!different)
			{
				OnPropertyChanged(nameof(CurrentPage));
			}
		}
	}
}