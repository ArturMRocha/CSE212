using System.Collections.Generic;

/// <summary>
/// Represents the top-level object from the USGS GeoJSON data feed.
/// It contains a list of all earthquake features.
/// </summary>
public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

/// <summary>
/// Represents a single earthquake event.
/// </summary>
public class Feature
{
    public EarthquakeProperties Properties { get; set; }
}

/// <summary>
/// Holds the specific details about an earthquake, like its magnitude and location.
/// </summary>
public class EarthquakeProperties
{
    public decimal Mag { get; set; }
    public string Place { get; set; }
}