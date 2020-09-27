. ".\common.ps1"

# Create directory if not exists
if (-Not (Test-Path -Path '.\nupkgs\')) {
    mkdir nupkgs
}

# Rebuild all solutions
foreach ($solution in $solutions) {
    $solutionFolder = Join-Path $rootFolder $solution
    Set-Location $solutionFolder
    & dotnet restore
}

# Create all packages
foreach ($project in $projects) {
    
    $projectFolder = Join-Path $rootFolder $project

    # Create nuget pack
    Set-Location $projectFolder
    Remove-Item -Recurse (Join-Path $projectFolder "bin/Release")
    & dotnet msbuild /t:build /t:pack /p:Configuration=Release

    if (-Not $?) {
        Write-Host ("Packaging failed for the project: " + $projectFolder)
        Set-Location $packFolder
        exit $LASTEXITCODE
    }
    Write-Information $projectFolder
    # Copy nuget package
    $projectName = $project.Substring($project.LastIndexOf("/") + 1)
    $projectPackPath = Join-Path $projectFolder ("/bin/Release/" + $projectName + ".*.nupkg")
    Move-Item -Force $projectPackPath (Join-Path $packFolder "nupkgs")

}

# Go back to the pack folder
Set-Location $packFolder