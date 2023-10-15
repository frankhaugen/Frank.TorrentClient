param (
    [string]$configuration = "Release",
    [string]$framework = "net7.0",
    [string]$version = (Get-Date).ToString("yyyy.MM.dd.HHmm")
)

# Summerize the parameters and output them
Write-Host "Publishing the project with the following parameters: "
Write-Host "Configuration: $configuration"
Write-Host "Framework: $framework"
Write-Host "Version: $version"

# Get the script location
$scriptLocation = Split-Path -Parent $MyInvocation.MyCommand.Path

# Set the project path
$projectPath = Join-Path -Path $scriptLocation -ChildPath "Src/Frank.TorrentClient"

# Set the output path
$outputPath = Join-Path -Path $scriptLocation -ChildPath "Build/$($configuration)/$($framework)"

# Change to the project directory
Set-Location $projectPath

# Restore the project
dotnet restore --verbosity quiet

# Set the version
dotnet build /p:Version=$version --no-restore --verbosity quiet

# Publish the project
dotnet publish --configuration $configuration --framework $framework --output $outputPath --no-build --verbosity quiet

# Set the package version suffix, if the configuration is not Release
$packageVersionSuffix = "" # Default
if ($configuration -ne "Release") {
    $packageVersionSuffix = "-$($configuration)"
}

# Create the NuGet package
dotnet pack --configuration $configuration --output $outputPath --version-suffix $packageVersionSuffix --no-build --verbosity quiet