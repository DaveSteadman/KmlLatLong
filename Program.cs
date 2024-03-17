using System;
using System.Text;
using System.IO;

class KmlGenerator
{

    public void GenerateKmlFile_30Deg()
    {
        string filePath = "KmlLatLong_30Deg.kml";
        var kmlContent = new StringBuilder();

        WriteKmlHeader(kmlContent);

        // Generate Latitude Lines
        string styleUrl = "Level0";
        for (int lat = -90; lat <= 90; lat+=30)
            AddLatLine(kmlContent, lat, styleUrl);

        // Generate Longitude Lines
        for (int lon = -180; lon <= 180; lon+=30)
            AddLonLine(kmlContent, lon, styleUrl);

        WriteKmlFooter(kmlContent);

        File.WriteAllText(filePath, kmlContent.ToString());
    }

    public void GenerateKmlFile_45Deg()
    {
        string filePath = "KmlLatLong_45Deg.kml";
        var kmlContent = new StringBuilder();

        WriteKmlHeader(kmlContent);

        // Generate Latitude Lines
        string styleUrl = "Level0";
        for (int lat = -80; lat <= 80; lat+=40)
            AddLatLine(kmlContent, lat, styleUrl);

        // Generate Longitude Lines
        for (int lon = -180; lon <= 180; lon+=45)
            AddLonLine(kmlContent, lon, styleUrl);

        WriteKmlFooter(kmlContent);

        File.WriteAllText(filePath, kmlContent.ToString());
    }

    public void GenerateKmlFile_5Deg()
    {
        string filePath = "KmlLatLong_5Deg.kml";
        var kmlContent = new StringBuilder();

        WriteKmlHeader(kmlContent);

        // Generate Latitude Lines
        string styleUrl = "Level1";
        for (int lat = -80; lat <= 80; lat+=5)
            AddLatLine(kmlContent, lat, styleUrl);

        // Generate Longitude Lines
        for (int lon = -180; lon <= 180; lon+=5)
            AddLonLine(kmlContent, lon, styleUrl);

        WriteKmlFooter(kmlContent);

        File.WriteAllText(filePath, kmlContent.ToString());
    }

    public void GenerateKmlFile_1Deg()
    {
        string filePath = "KmlLatLong_1Deg.kml";
        var kmlContent = new StringBuilder();

        WriteKmlHeader(kmlContent);

        // Generate Latitude Lines
        string styleUrl = "Level2";
        for (int lat = -80; lat <= 80; lat++)
            AddLatLine(kmlContent, lat, styleUrl);

        // Generate Longitude Lines
        for (int lon = -180; lon <= 180; lon++)
            AddLonLine(kmlContent, lon, styleUrl);

        WriteKmlFooter(kmlContent);

        File.WriteAllText(filePath, kmlContent.ToString());
    }

    public void GenerateKmlFile_0p2Deg()
    {
        string filePath = "KmlLatLong_0p2Deg.kml";
        var kmlContent = new StringBuilder();

        WriteKmlHeader(kmlContent);

        // Generate Latitude Lines
        string styleUrl = "Level3";
        for (float lat = -80; lat <= 80; lat += 0.2f)
            AddLatLine(kmlContent, lat, styleUrl);

        // Generate Longitude Lines
        for (float lon = -180; lon <= 180; lon += 0.2f)
            AddLonLine(kmlContent, lon, styleUrl);

        WriteKmlFooter(kmlContent);

        File.WriteAllText(filePath, kmlContent.ToString());
    }

    // --------------------------------------------------------------------------------------------

    public void GenerateKmlFile_30DegLabels()
    {
        string filePath = "KmlLatLong_30Deg_Labels.kml";
        var kmlContent = new StringBuilder();

        WriteKmlHeader(kmlContent);

        // Generate Latitude Lines
        string styleUrl = "LabelStyleLevel0";

        for (int lat = -90; lat <=90; lat+=30)
        {
            float adjLon = -180f + 15f;
            AddLabel(kmlContent, lat, adjLon, styleUrl, $"Lat {lat}");
        }

        for (int lon = -180; lon<=180; lon+=30)
        {
            float adjLat = -60f;
            AddLabel(kmlContent, adjLat, lon, styleUrl, $"Lon {lon:F0}");
        }

        WriteKmlFooter(kmlContent);
        File.WriteAllText(filePath, kmlContent.ToString());
    }

    public void GenerateKmlFile_45DegLabels()
    {
        string filePath = "KmlLatLong_45Deg_Labels.kml";
        var kmlContent = new StringBuilder();

        WriteKmlHeader(kmlContent);

        // Generate Latitude Lines
        string styleUrl = "LabelStyleLevel0";

        for (int lat = -80; lat <=80; lat+=40)
        {
            float adjLon = -180f + 22.5f;
            AddLabel(kmlContent, lat, adjLon, styleUrl, $"Lat {lat}");
        }

        for (int lon = -180; lon<=180; lon+=45)
        {
            float adjLat = -60f;
            AddLabel(kmlContent, adjLat, lon, styleUrl, $"Lon {lon:F0}");
        }

        WriteKmlFooter(kmlContent);
        File.WriteAllText(filePath, kmlContent.ToString());
    }

    public void GenerateKmlFile_5DegLabels()
    {
        string filePath = "KmlLatLong_5Deg_Labels.kml";
        var kmlContent = new StringBuilder();

        WriteKmlHeader(kmlContent);

        // Generate Latitude Lines
        string styleUrl = "LabelStyleLevel1";

        for (int lat = -80; lat <=80; lat+=5)
        {
            for (int lon = -180; lon<=180; lon+=45)
            {
                float adjLon = lon + 2.5f;
                AddLabel(kmlContent, lat, adjLon, styleUrl, $"Lat {lat}");
            }
        }

        for (int lon = -180; lon<=180; lon+=5)
        {
            for (int lat = -80; lat <=79; lat+=40)
            {
                float adjLat = lat + 2.5f;
                AddLabel(kmlContent, adjLat, lon, styleUrl, $"Lon {lon:F0}");
            }

        }

        WriteKmlFooter(kmlContent);
        File.WriteAllText(filePath, kmlContent.ToString());
    }

    public void GenerateKmlFile_1DegLabels()
    {
        string filePath = "KmlLatLong_1Deg_Labels.kml";
        var kmlContent = new StringBuilder();

        WriteKmlHeader(kmlContent);

        // Generate Latitude Lines
        string styleUrl = "LabelStyleLevel2";

        for (int lat = -80; lat <=80; lat+=1)
        {
            for (int lon = -180; lon<=180; lon+=5)
            {
                float adjLon = lon + 0.5f;
                AddLabel(kmlContent, lat, adjLon, styleUrl, $"Lat {lat}");
            }
        }

        for (int lon = -180; lon<=180; lon+=1)
        {
            for (int lat = -80; lat <=79; lat+=5)
            {
                float adjLat = lat + 0.5f;
                AddLabel(kmlContent, adjLat, lon, styleUrl, $"Lon {lon}");
            }
        }

        WriteKmlFooter(kmlContent);
        File.WriteAllText(filePath, kmlContent.ToString());
    }

    // --------------------------------------------------------------------------------------------

    public void GenerateKmlFile_Lvl0TileCodes()
    {
        string filePath = "KmlLatLong_Lvl0TileCodes.kml";
        var kmlContent = new StringBuilder();

        string[] charArray = {"A", "B", "C", "D", "E", "F", "G", "H"};

        WriteKmlHeader(kmlContent);

        string styleUrl = "textLabelStyle";

        int rowIndex = 3;
        for (int lat = -80; lat < 79.9; lat+=40)
        {
            double adjLat = lat + 20;

            // Generate Longitude Lines
            int colIndex = 1;
            for (int lon = -180; lon < 179.9; lon+=45)
            {
                double adjLon = lon + 22.5;
                AddLabel(kmlContent, adjLat, adjLon, styleUrl, $"{charArray[rowIndex]}{colIndex}");

                colIndex++;
            }
            rowIndex--;
        }

        WriteKmlFooter(kmlContent);

        File.WriteAllText(filePath, kmlContent.ToString());
    }

    private void WriteKmlHeader(StringBuilder kmlContent)
    {
        kmlContent.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        kmlContent.AppendLine("<kml xmlns=\"http://www.opengis.net/kml/2.2\">");
        kmlContent.AppendLine("<Document>");
        kmlContent.AppendLine("<name>Latitude and Longitude Grid</name>");
        AddStyles(kmlContent);
    }

    private void WriteKmlFooter(StringBuilder kmlContent)
    {
        kmlContent.AppendLine("</Document>");
        kmlContent.AppendLine("</kml>");
    }

    private void AddStyles(StringBuilder kmlContent)
    {
        // Level0 Style
        kmlContent.AppendLine("<Style id=\"Level0\"><LineStyle><color>ff0000ff</color><width>3</width></LineStyle></Style>");
        kmlContent.AppendLine("<Style id=\"Level1\"><LineStyle><color>ff00ff00</color><width>2</width></LineStyle></Style>");
        kmlContent.AppendLine("<Style id=\"Level2\"><LineStyle><color>ffff0000</color><width>1</width></LineStyle></Style>");
        kmlContent.AppendLine("<Style id=\"Level3\"><LineStyle><color>66666666</color><width>1</width></LineStyle></Style>");

        // Level Label Style
        kmlContent.AppendLine("<Style id=\"LabelStyleLevel0\"><LabelStyle><color>ff0000ff</color><scale>1.0</scale></LabelStyle></Style>");
        kmlContent.AppendLine("<Style id=\"LabelStyleLevel1\"><LabelStyle><color>ff00ff00</color><scale>1.0</scale></LabelStyle></Style>");
        kmlContent.AppendLine("<Style id=\"LabelStyleLevel2\"><LabelStyle><color>ffffdddd</color><scale>1.0</scale></LabelStyle></Style>");
    }

    private void AddLatLine(StringBuilder kmlContent, float latitude, string styleUrl)
    {
        kmlContent.AppendLine( "  <Placemark>");
        kmlContent.AppendLine($"    <styleUrl>#{styleUrl}</styleUrl>");
        kmlContent.AppendLine( "    <LineString>");
        kmlContent.AppendLine( "      <coordinates>");
        kmlContent.AppendLine($"        -180,{latitude:F3},0 180,{latitude:F3},0");
        kmlContent.AppendLine( "      </coordinates>");
        kmlContent.AppendLine( "    </LineString>");
        kmlContent.AppendLine( "  </Placemark>");
    }

    private void AddLonLine(StringBuilder kmlContent, float longitude, string styleUrl)
    {
        kmlContent.AppendLine("  <Placemark>");
        kmlContent.AppendLine($"    <styleUrl>#{styleUrl}</styleUrl>");
        kmlContent.AppendLine("    <LineString>");
        kmlContent.AppendLine("      <coordinates>");
        kmlContent.AppendLine($"        {longitude:F3},-80,0 {longitude:F3},80,0");
        kmlContent.AppendLine("      </coordinates>");
        kmlContent.AppendLine("    </LineString>");
        kmlContent.AppendLine("  </Placemark>");
    }

    private void AddLabel(StringBuilder kmlContent, double lat, double lon, string stylename, string text)
    {
        kmlContent.AppendLine("  <Placemark>");
        kmlContent.AppendLine($"    <styleUrl>{stylename}</styleUrl>");
        kmlContent.AppendLine($"   <name>{text}</name>");
        kmlContent.AppendLine("    <Point>");
        kmlContent.AppendLine("      <coordinates>");
        kmlContent.AppendLine($"        {lon},{lat},0");
        kmlContent.AppendLine("      </coordinates>");
        kmlContent.AppendLine("    </Point>");
        kmlContent.AppendLine("  </Placemark>");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var generator = new KmlGenerator();
        generator.GenerateKmlFile_45Deg();
        generator.GenerateKmlFile_45DegLabels();

        generator.GenerateKmlFile_5Deg();
        generator.GenerateKmlFile_5DegLabels();

        generator.GenerateKmlFile_1Deg();
        generator.GenerateKmlFile_1DegLabels();

        generator.GenerateKmlFile_0p2Deg();
        generator.GenerateKmlFile_Lvl0TileCodes();

        // V2
        generator.GenerateKmlFile_30Deg();
        generator.GenerateKmlFile_30DegLabels();

    }
}
