﻿using System.Windows;
using System.Windows.Controls;

namespace AIS_Airport
{
	/// <summary>
	/// The MonitorPassword attached property for a <see cref="PasswordBox"/>
	/// </summary>
	public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
	{
		public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			// Make sure it is a password box
			if (sender is not PasswordBox passwordBox)
			{
				return;
			}

			// Remove any previous events
			passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

			// If the caller set MonitorPassword to true...
			if ((bool)e.NewValue)
			{
				// Set default value
				HasTextProperty.SetValue(passwordBox);

				// Start listening out for password changes
				passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
			}
		}

		/// <summary>
		/// Fired when the password box password value changes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
		{
			var passwordBox = (PasswordBox)sender;

			// Set the attached HasText value
			HasTextProperty.SetValue(passwordBox);

			// Update validation
			TextValidationProperty.SetValue(passwordBox, passwordBox.SecurePassword.Length);
		}
	}

	/// <summary>
	/// The HasText attached property for a <see cref="PasswordBox"/>
	/// </summary>
	public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
	{
		/// <summary>
		/// Sets the HasText property based on if the caller <see cref="PasswordBox"/> has any text
		/// </summary>
		/// <param name="sender"></param>
		public static void SetValue(DependencyObject sender)
		{
			SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
		}
	}
}