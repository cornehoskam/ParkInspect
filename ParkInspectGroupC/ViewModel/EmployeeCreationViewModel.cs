﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LocalDatabase.Domain;
using ParkInspectGroupC.Encryption;
using ParkInspectGroupC.Miscellaneous;
using ParkInspectGroupC.View;

namespace ParkInspectGroupC.ViewModel
{
	public class EmployeeCreationViewModel : ViewModelBase
	{
	    private string _message;
	    public string Message
	    {
	        get { return _message; }
            set { _message = value; RaisePropertyChanged("Message"); }
	    }

		public EmployeeCreationViewModel()
		{
			SaveCommand = new RelayCommand<object>(SaveEmployee, CanSaveEmployee);
			ResetFieldsCommand = new RelayCommand(ResetFields);

			// Retreive abailable data from database.
			using (var context = new LocalParkInspectEntities())
			{
				var regionList = context.Region.ToList();
				AvailableRegions = new ObservableCollection<Region>(regionList);

				var managerList = (from m in context.Employee where m.IsManager == true select m);
				AvailableManagers = new ObservableCollection<Employee>(managerList);
			}
		}


	    private void SaveEmployee(object parameter)
	    {
	        using (var context = new LocalParkInspectEntities())
	        {
	            var guid = PassEncrypt.GenerateGuid();
	            //var tempPass = "parkinspect";
	            var passwordContainer = parameter as IHavePassword;
	            if (passwordContainer != null)
	            {
	                var secureString = passwordContainer.Password;
	                var pass = PassEncrypt.ConvertToUnsecureString(secureString);
	                PasswordInVM = PassEncrypt.GetPasswordHash(pass, guid);

	                var employees = (from a in context.Employee select a).ToList();
	                var newEmployees = employees.Max(u => u.Id);
	                if (newEmployees == null)
	                {
	                    newEmployees = 1;
	                }
 
	                var nEmployee = new Employee
	                {
	                    FirstName = this.FirstName,
	                    SurName = this.SurName,
	                    Gender = GenderEnum.ToString().ElementAt(0).ToString(),
	                    City = this.City,
	                    Address = this.Street + " " + this.Number,
	                    ZipCode = this.ZipCode,
	                    Phonenumber = this.TelNumber,
	                    Email = this.Email,
	                    IsInspecter = true,
	                    IsManager = false,
                        Id = (int)newEmployees + 1,
	                };
	                if (!string.IsNullOrWhiteSpace(Prefix))
	                    nEmployee.Prefix = this.Prefix;

	                nEmployee.Region = (from r in context.Region where r.Id == SelectedRegion.Id select r).FirstOrDefault();
	                nEmployee.Manager =
	                    (from m in context.Employee where m.Id == SelectedManager.Id select m).FirstOrDefault();

                    var accounts = (from a in context.Employee select a).ToList();
                    var newAccount = accounts.Max(u => u.Id);
                    if (newAccount == null)
                    {
                        newEmployees = 1;
                    }

                    var nAccount = new Account
	                {
	                    Username = this.Username,
	                    UserGuid = guid,
	                    Password = PasswordInVM,
	                    Employee = nEmployee,
                        Id = (int)newAccount + 1,
	                };

	                context.Employee.Add(nEmployee);
	                context.Account.Add(nAccount);
	                context.SaveChanges();
	            }
	        }
            Navigator.SetNewView(new LoginView());
        }

	    private bool CanSaveEmployee(object parameter)
		{
		    if (string.IsNullOrWhiteSpace(Username)
		        || string.IsNullOrWhiteSpace(SurName)
		        || string.IsNullOrWhiteSpace(City)
		        || string.IsNullOrWhiteSpace(Street)
		        || string.IsNullOrWhiteSpace(ZipCode)
		        || string.IsNullOrWhiteSpace(TelNumber)
		        || string.IsNullOrWhiteSpace(Email))
		    {
		        Message = "Vul alle velden in.";
		        return false;
		    }

		    if (Username.Length < 5 || Username.Length > 25)
		    {
		        Message = "Username heeft niet de juiste lengte [5,25].";
		        return false;
		    }

            var passwordContainer = parameter as IHavePassword;
		    if (passwordContainer != null)
		    {
                var secureString = passwordContainer.Password;
                var pass = PassEncrypt.ConvertToUnsecureString(secureString);

		        if (pass.Length < 5 || pass.Length > 25)
		        {
		            Message = "Wachtwoord heeft niet de juiste lengte [5.25].";
		            return false;
		        }

		        if (!pass.Any(c => char.IsDigit(c)))
		        {
		            Message = "Wachtwoord moet minstens een cijfer bevatten [0,9].";
		            return false;
		        }

		        if (!pass.Any(c => char.IsLetter(c)))
		        {
		            Message = "Wachtwoord moet minstens een letter bevatten [A-Z].";
		            return false;
		        }
            }

            using (var context = new LocalParkInspectEntities())
            {
                List<Account> nameList = (from a in context.Account select a).ToList();

                foreach (var employee in nameList)
                {
                    if (string.Equals(Username, employee.Username, StringComparison.Ordinal))
                    {
                        Message = "Gebruikersnaam bestaad al.";
                        return false;
                    }
                }
            }

		    Message = string.Empty;
			return true;
		}

        private void ResetFields()
		{
			
		}

        private string _passwordInVM;
        public string PasswordInVM
        {
            get { return _passwordInVM; }
            set { _passwordInVM = value; RaisePropertyChanged(PasswordInVM); }
        }

        private string _username;
		public string Username
		{
			get { return _username; }
			set { _username = value.Trim(); RaisePropertyChanged("Username"); }
		}

	    private string _password;

	    public string Password
	    {
	        get { return _password; }
            set { _password = value; RaisePropertyChanged("Password"); }
	    }

		private string _firstName;
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value.Trim(); RaisePropertyChanged("FirstName"); }
		}

		private string _prefix;
		public string Prefix
		{
			get { return _prefix; }
			set { _prefix = value.Trim(); RaisePropertyChanged("Prefix"); }
		}

		private string _surName;
		public string SurName
		{
			get { return _surName; }
			set { _surName = value.Trim(); RaisePropertyChanged("SurName"); }
		}

		private string _gender;
		public string Gender
		{
			get { return _gender; }
			set { _gender = value.Trim(); RaisePropertyChanged("Gender"); }
		}

		private GenderOption _genderEnum;
		public GenderOption GenderEnum
		{
			get { return _genderEnum; }
			set { _genderEnum = value; RaisePropertyChanged("GenderEnum"); }
		}

		private string _street;
		public string Street
		{
			get { return _street; }
			set { _street = value.Trim(); RaisePropertyChanged("Street"); }
		}

		private string _number;
		public string Number
		{
			get { return _number; }
			set { _number = value.Trim(); RaisePropertyChanged("Number"); }
		}

		/*
		private char _numberPrefix;
		public char NumberPrefix
		{
			get { return _numberPrefix; }
			set { _numberPrefix = value; RaisePropertyChanged("NumberPrefix"); }
		}
		*/

		private string _city;
		public string City
		{
			get { return _city; }
			set { _city = value.Trim(); RaisePropertyChanged("City"); }
		}

		private string _email;
		public string Email
		{
			get { return _email; }
			set { _email = value.Trim(); RaisePropertyChanged("Email"); }
		}

		private string _zipCode;
		public string ZipCode
		{
			get { return _zipCode; }
			set { _zipCode = value.Trim(); RaisePropertyChanged("ZipCode"); }
		}

		private string _telNumber;
		public string TelNumber
		{
			get { return _telNumber; }
			set { _telNumber = value.Trim(); RaisePropertyChanged("TelNumber"); }
		}


		private Region _selectedRegion;
		public Region SelectedRegion
		{
			get { return _selectedRegion; }
			set { _selectedRegion = value; RaisePropertyChanged("SelectedRegion"); }
		}

		private Employee _selectedManager;
		public Employee SelectedManager
		{
			get { return _selectedManager; }
			set { _selectedManager = value; RaisePropertyChanged("SelectedManager"); }
		}

		public ObservableCollection<Region> AvailableRegions { get; set; }
		public ObservableCollection<Employee> AvailableManagers { get; set; }

		private bool _isInspector;
		public bool IsInspector
		{
			get { return _isInspector; }
			set { _isInspector = value; RaisePropertyChanged("IsInspector"); }
		}

		private bool _isManager;
		public bool IsManager
		{
			get { return _isManager; }
			set { _isManager = value; RaisePropertyChanged("IsManager"); }
		}

		public ICommand SaveCommand { get; set; }
		public ICommand ResetFieldsCommand { get; set; }

	}

	public enum GenderOption
	{
		Male,
		Female
	}
}
