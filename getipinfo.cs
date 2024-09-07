using System.Text.Json;
class GetIpInfo
{
    
    public static string getIP()
    {
        Console.Clear();
        Console.WriteLine("Enter the IP adress: ");
        string IP = Console.ReadLine()!;
        return $"http://ipwho.is/{IP}";
    }
    public async Task getipinfo()
    
    {
        Console.Clear();
        using (HttpClient client = new HttpClient())
        {
            string request = getIP();
            
            HttpResponseMessage response = await client.GetAsync(request);
            response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();
            var fullIpInfo = JsonSerializer.Deserialize<Rootobject>(responseString);

            if (fullIpInfo.success == true)
            {
                Console.Clear();
                Console.WriteLine($"IP: {fullIpInfo.ip}");
                Console.WriteLine($"Type: {fullIpInfo.type}");
                Console.WriteLine($"Country: {fullIpInfo.country}");
                Console.WriteLine($"Region: {fullIpInfo.region}");
                Console.WriteLine($"City: {fullIpInfo.city}");
                Console.WriteLine($"Latitude: {fullIpInfo.latitude}");
                Console.WriteLine($"Longitude: {fullIpInfo.longitude}");
                Console.WriteLine($"Is EU: {fullIpInfo.is_eu}");
                Console.WriteLine($"Postal Code: {fullIpInfo.postal}");
                Console.WriteLine($"Calling Code: {fullIpInfo.calling_code}");
                Console.WriteLine($"Capital: {fullIpInfo.capital}");
                Console.WriteLine($"Borders: {fullIpInfo.borders}");
                Console.WriteLine($"Flag: {fullIpInfo.flag.img}");
            }
        }
    }

}





public class Rootobject
{
    public required string ip { get; set; }
    public bool success { get; set; }
    public required string type { get; set; }
    public required string continent { get; set; }
    public required string continent_code { get; set; }
    public required string country { get; set; }
    public required string country_code { get; set; }
    public required string region { get; set; }
    public required string region_code { get; set; }
    public required string city { get; set; }
    public required float latitude { get; set; }
    public required float longitude { get; set; }
    public required bool is_eu { get; set; }
    public required string postal { get; set; }
    public required string calling_code { get; set; }
    public required string capital { get; set; }
    public required string borders { get; set; }
    public required Flag flag { get; set; }
    public required Connection connection { get; set; }
    public required Timezone timezone { get; set; }
}

public class Flag
{
    required public string img { get; set; }
    required public string emoji { get; set; }
    required public string emoji_unicode { get; set; }
}

public class Connection
{
    required public int asn { get; set; }
    required public string org { get; set; }
    required public string isp { get; set; }
    required public string domain { get; set; }
}

public class Timezone
{
    required public string id { get; set; }
    required public string abbr { get; set; }
    public bool is_dst { get; set; }
    public int offset { get; set; }
    required public string utc { get; set; }
    public DateTime current_time { get; set; }
}
