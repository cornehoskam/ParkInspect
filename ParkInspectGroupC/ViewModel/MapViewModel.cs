﻿using GalaSoft.MvvmLight.CommandWpf;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ParkInspectGroupC.ViewModel
{
    public class MapViewModel
    {
        public ICommand ShowInspectionsCommand { get; set; }
        public GMapControl gmap { get; set; }
        public IEnumerable<GMapMarker> markers { get; set; }
        public IEnumerable<GMapMarker> Markers { get; set; }

        public MapViewModel()
        int frequency;
        public MapViewModel(IEnumerable<Inspection> PInspections)
        {
            var point = new GMap.NET.PointLatLng(52.855864177854, 9.140625);
            Console.WriteLine(point);
            GMapMarker marker = new GMapMarker(point);
            markers = new List<GMapMarker>();
            marker.Shape = new Ellipse
            {
                Width = 10,
                Height = 10,
                Stroke = Brushes.Black,
                StrokeThickness = 1.5
            };
            markers = markers.Concat(new[] { marker });
            point = new GMap.NET.PointLatLng(51.80438169999999, 5.760212799999977);
            marker = new GMapMarker(point);
            marker.Shape = new Ellipse

            AddInspections(PInspections);
        }

        private void AddInspections(IEnumerable<Inspection> PInspections)
        {
            Markers = new List<GMapMarker>();
            foreach (var insp in PInspections)
            {
                using (var context = new ParkInspectEntities())
                {
                     frequency = (from i in context.Inspection
                                     where i.Id == insp.Id
                                     select i).Count();
                    var Lat = (from c in context.Coordinates 
                               where c.InspectionId == insp.Id 
                               select c).FirstOrDefault().Latitude;
                    var Long = (from c in context.Coordinates 
                                where c.InspectionId == insp.Id 
                                select c).FirstOrDefault().Longitude;
                }
            }
            var point = new GMap.NET.PointLatLng(Lat,Long);
            GMapMarker marker = new GMapMarker(point);
            Markers = Markers.Concat(new[] { marker });
            marker.Shape = new Ellipse
            {
                Width = 10,
                Width = frequency * 10,
                Height = 10,
                Stroke = Brushes.Black,
                StrokeThickness = 1.5
            };
            markers = markers.Concat(new[] { marker });
            ShowInspectionsCommand = new RelayCommand(ShowInspections, CanShowInspections);
        }
        private void ShowInspections()
        {
           
            Markers = Markers.Concat(new[] { marker });
        }

        private bool CanShowInspections()
        {
            
            return true;
        }    
    }
}
