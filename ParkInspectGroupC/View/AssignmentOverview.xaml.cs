﻿using ParkInspectGroupC.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xaml;

namespace ParkInspectGroupC.View
{
	/// <summary>
	/// Interaction logic for AssignmentOverview.xaml
	/// </summary>
	public partial class AssignmentOverview : UserControl
	{
		public AssignmentOverview()
		{
			
			InitializeComponent();
			
			DataContext = new AssignmentOverviewViewModel();

			
		}
	}
}
