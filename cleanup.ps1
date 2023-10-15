# Define the script location and the artifacts path
$artifactPath = Join-Path -Path $scriptLocation -ChildPath "artifacts"

# Delete the artifacts directory
Remove-Item -Path $artifactPath -Recurse -Force -ErrorAction SilentlyContinue