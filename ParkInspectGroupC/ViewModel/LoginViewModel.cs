﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParkInspectGroupC.DOMAIN;
using ParkInspectGroupC.Encryption;
using ParkInspectGroupC.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspectGroupC.ViewModel
{
	public class LoginViewModel : ViewModelBase
	{

		public ICommand LoginCommand { get; set; }

		private string _loginMessage;
		public string LoginMessage
		{
			get { return _loginMessage; }
			set { _loginMessage = value; RaisePropertyChanged(); }
		}

		private string _username;
		public string Username
		{
			get { return _username; }
			set { _username = value.Trim();  RaisePropertyChanged(); }
		}

		private string _passwordInVM;
		public string PasswordInVM
		{
			get { return _passwordInVM; }
			set { _passwordInVM = value; RaisePropertyChanged(PasswordInVM); }
		}

		public LoginViewModel()
		{
			_loginMessage = string.Empty;
			LoginCommand = new RelayCommand<object>(Login, CanLogin);
		}

		private bool CanLogin(object parameter)
		{
			return true;
		}

		private void Login(object parameter)
		{
			var passwordContainer = parameter as IHavePassword;
			if (passwordContainer != null)
			{
				var secureString = passwordContainer.Password;
				PasswordInVM = PassEncrypt.ConvertToUnsecureString(secureString);

				using(var context = new ParkInspectEntities())
				{
					var acc = (from a in context.Account where a.Username.CompareTo(Username) == 0 select a).FirstOrDefault();

					// Account does not excist.
					if (acc == null)
					{
						LoginMessage = "Het ingevoerde gebruikersnaam bestaat niet.";
						return;
					}

					LoginMessage = PasswordInVM;

					// Check password
					string passToCheck = PasswordInVM + acc.UserGuid;
					if(!ValidateAccount(acc.Password, passToCheck))
					{
						LoginMessage = "De ingevoerde gebruikersnaam en/of wachtwoord is niet geldig.";
						return;
					}

					// Username and Password are correct, continue the application.
					LoginMessage = "Succes!";
				}

			}
		}

		private bool ValidateAccount(string password, string passwordToCheck)
		{
			string hashedPassword = PassEncrypt.GetPasswordHash(passwordToCheck);

			return (password.CompareTo(hashedPassword) == 0);
		}
	}
}