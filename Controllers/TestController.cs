
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Api01.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public string Test1()
    {

        string hostname = Dns.GetHostName();
        string stripadr = "";
        try
        {
            var iphostinfo = Dns.GetHostEntry(hostname);
            var ipAddresses = iphostinfo.AddressList.Where(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToList().Select(a => a.ToString());
            stripadr = string.Join(" ", ipAddresses);

        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

        string res = $"HostName: {hostname} Ip: {stripadr}";

        return res;

    }
}