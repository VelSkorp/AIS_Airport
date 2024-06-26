﻿using AIS_Airport.Core;
using System.Security;

namespace AIS_Airport
{
	/// <summary>
	/// Interaction logic for LoginPage.xaml
	/// </summary>
	public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
	{

		/// <summary>
		/// The secure password for this login page
		/// </summary>
		public SecureString Password => PasswordText.SecurePassword;

		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public LoginPage()
		{
			InitializeComponent();

		}

		/// <summary>
		/// Constructor with specific view model
		/// </summary>
		/// <param name="specificViewModel">The specific view model to use for this page</param>
		public LoginPage(LoginViewModel specificViewModel = null) : base(specificViewModel)
		{
			InitializeComponent();
		}

		#endregion
	}
}