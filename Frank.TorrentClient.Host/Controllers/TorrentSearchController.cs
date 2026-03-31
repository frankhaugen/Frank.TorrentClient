using Frank.TorrentClient.Search;
using Frank.TorrentClient.Service;

using Microsoft.AspNetCore.Mvc;

namespace Frank.TorrentClient.Host.Controllers;

[ApiController]
[Route("torrents/search")]
public class TorrentSearchController : ControllerBase
{
    private readonly ITorrentService _torrentService;

    public TorrentSearchController(ITorrentService torrentService)
    {
        _torrentService = torrentService;
    }

    [HttpGet]
    public async Task<IEnumerable<TorrentSearchResult>> SearchAsync([FromQuery] string query)
    {
        return await _torrentService.SearchAsync(query);
    }
}