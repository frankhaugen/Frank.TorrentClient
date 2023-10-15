# Get script location
$scriptLocation = Split-Path -Parent $MyInvocation.MyCommand.Path

# Get test torrent
$testTorrentFilePath = Get-Item -Path (Join-Path -Path $scriptLocation -ChildPath "Test/Frank.TorrentClientTest/Files/debian-9.3.0-s390x-netinst.torrent")
if (-not $testTorrentFilePath.Exists) {
    throw "Test torrent file not found"
}

# Set download path
$userDownloadPath = Get-Item -Path "$HOME/Downloads"
if (-not $userDownloadPath.Exists) {
    throw "User download path not found"
}

# build arguments
$arguments = @("--file", $testTorrentFilePath, "--directory", $userDownloadPath)
$arguments | ForEach-Object {
    Write-Host $_
}

# project path
$projectPath = Join-Path -Path $scriptLocation -ChildPath "Src/Frank.TorrentClient.Cli"

# Change to the project directory
Set-Location $projectPath

# Run the test
dotnet run --configuration Release -- $arguments

# Change to the script directory
Set-Location $scriptLocation
