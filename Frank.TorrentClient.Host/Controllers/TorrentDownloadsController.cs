using Frank.TorrentClient.Search;
using Frank.TorrentClient.Service;

using Microsoft.AspNetCore.Mvc;

namespace Frank.TorrentClient.Host.Controllers;

[ApiController]
[Route("torrents/downloads")]
public class TorrentDownloadsController : ControllerBase
{
    private readonly ITorrentService _torrentService;

    public TorrentDownloadsController(ITorrentService torrentService)
    {
        _torrentService = torrentService;
    }

    [HttpPost]
    public void SelectResultToDownload([FromBody] TorrentSearchResult torrent)
    {
        _torrentService.SelectResultToDownload(torrent);
    }
}