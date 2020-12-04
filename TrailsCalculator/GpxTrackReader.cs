using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using TrailsCalculator.Models;

namespace TrailsCalculator
{
    public class GpxTrackReader
    {
        private readonly string _pathToGpxTrack;
        private IReadOnlyCollection<TrackModel> _trackModels;

        public GpxTrackReader(string pathToGpxTrack)
        {
            _pathToGpxTrack = pathToGpxTrack;
            LoadGpxTracks();
        }

        public TrackModel GetTrack(string trackName)
        {
            return _trackModels.FirstOrDefault(x => x.Name == trackName);
        }

        private XDocument GetGpxDoc()
        {
            XDocument gpxDoc = XDocument.Load(_pathToGpxTrack);
            return gpxDoc;
        }

        private XNamespace GetGpxNameSpace()
        {
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            return gpx;
        }

        private void LoadGpxTracks()
        {
            XDocument gpxDoc = GetGpxDoc();
            XNamespace gpx = GetGpxNameSpace();

            var trackKey = gpx + "trk";
            var trackNameKey = gpx + "name";
            var trackPointKey = gpx + "trkpt";
            var trackPointElevationKey = gpx + "ele";
            var trackPointTimeKey = gpx + "time";

            _trackModels = gpxDoc.Descendants(trackKey)
                .Select(track =>
                {
                    var name = track.Element(trackNameKey)?.Value;
                    var points = track.Descendants(trackPointKey)
                        .Select(point =>
                        {
                            double lat = XmlConvert.ToDouble(point.Attribute("lat")?.Value);
                            double lon = XmlConvert.ToDouble(point.Attribute("lon")?.Value);
                            double elevation = XmlConvert.ToDouble(point.Element(trackPointElevationKey)?.Value);
                            DateTime time = XmlConvert.ToDateTime(point.Element(trackPointTimeKey)?.Value);

                            return new PointModel(lat, lon, elevation, time);
                        }).ToList();

                    return new TrackModel(name, points);
                }).ToList();
        }
    }
}