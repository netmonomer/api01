
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
        var iphostinfo = Dns.GetHostEntry(hostname);
        var ipAddresses =  iphostinfo.AddressList.Where(a=>a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToList().Select(a=>a.ToString());
        var stripadr = string.Join(" ", ipAddresses);
        string res = $"HostName: {hostname} Ip: {stripadr}";
        return res;

    }
}