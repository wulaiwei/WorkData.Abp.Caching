# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of solutions
$solutions = (
    ""
    # "abp_io"
)

# List of projects
$projects = (
    "WorkData.Abp.Caching"
)