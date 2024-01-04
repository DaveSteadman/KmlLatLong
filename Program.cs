using System;
using System.Text;
using System.IO;

class KmlGenerator
{

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
        kmlContent.AppendLine("  <Style id=\"Level0\">");
        kmlContent.AppendLine("    <LineStyle>");
        kmlContent.AppendLine("      <color>ff0000ff</color>"); // Red color for Level0
        kmlContent.AppendLine("      <width>3</width>"); // Thicker line for Level0
        kmlContent.AppendLine("    </LineStyle>");
        kmlContent.AppendLine("  </Style>");

        // Level1 Style
        kmlContent.AppendLine("  <Style id=\"Level1\">");
        kmlContent.AppendLine("    <LineStyle>");
        kmlContent.AppendLine("      <color>ff00ff00</color>"); // Green color for Level1
        kmlContent.AppendLine("      <width>2</width>"); // Medium line for Level1
        kmlContent.AppendLine("    </LineStyle>");
        kmlContent.AppendLine("  </Style>");

        // Level2 Style
        kmlContent.AppendLine("  <Style id=\"Level2\">");
        kmlContent.AppendLine("    <LineStyle>");
        kmlContent.AppendLine("      <color>ffff0000</color>"); // Blue color for Level2
        kmlContent.AppendLine("      <width>1</width>"); // Thinner line for Level2
        kmlContent.AppendLine("    </LineStyle>");
        kmlContent.AppendLine("  </Style>");

        // Level2 Style
        kmlContent.AppendLine("  <Style id=\"Level3\">");
        kmlContent.AppendLine("    <LineStyle>");
        kmlContent.AppendLine("      <color>777777ff</color>"); // Blue color for Level2
        kmlContent.AppendLine("      <width>1</width>"); // Thinner line for Level2
        kmlContent.AppendLine("    </LineStyle>");
        kmlContent.AppendLine("  </Style>");

        // Text Label Style
        kmlContent.AppendLine("  <Style id=\"textLabelStyle\">");
        kmlContent.AppendLine("    <LabelStyle>");
        kmlContent.AppendLine("      <color>ff0000ff</color>"); // Example: blue color (ARGB format)
        kmlContent.AppendLine("      <scale>1.5</scale>"); // Example: 1.5 times the normal size
        kmlContent.AppendLine("    </LabelStyle>");
        kmlContent.AppendLine("  </Style>");
    }

    private void AddLatLine(StringBuilder kmlContent, float latitude, string styleUrl)
    {
        kmlContent.AppendLine("  <Placemark>");
        kmlContent.AppendLine($"    <styleUrl>#{styleUrl}</styleUrl>");
        kmlContent.AppendLine("    <LineString>");
        kmlContent.AppendLine("      <coordinates>");
        kmlContent.AppendLine($"        -180,{latitude:F3},0 180,{latitude:F3},0");
        kmlContent.AppendLine("      </coordinates>");
        kmlContent.AppendLine("    </LineString>");
        kmlContent.AppendLine("  </Placemark>");
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
        generator.GenerateKmlFile_5Deg();
        generator.GenerateKmlFile_1Deg();
        generator.GenerateKmlFile_0p2Deg();

        generator.GenerateKmlFile_Lvl0TileCodes();
    }
}
