<#
.SYNOPSIS
    Publishes the Datadog.Api package to nuget.org.

.DESCRIPTION
    This script performs the following steps:
    1. Checks for uncommitted git changes (porcelain)
    2. Determines the Nerdbank GitVersioning version
    3. Validates nuget-key.txt exists, has content, and is gitignored
    4. Runs unit tests (unless -SkipTests is specified)
    5. Publishes to nuget.org

.PARAMETER SkipTests
    If specified, skips running unit tests.

.EXAMPLE
    .\Publish.ps1
    .\Publish.ps1 -SkipTests
#>
param(
    [switch]$SkipTests
)

$ErrorActionPreference = 'Stop'

# Step 1: Check for uncommitted git changes
Write-Host "Checking for uncommitted git changes..." -ForegroundColor Cyan
$gitStatus = git status --porcelain
if ($gitStatus) {
    Write-Error "There are uncommitted changes in the repository. Please commit or stash them before publishing."
    exit 1
}
Write-Host "No uncommitted changes detected." -ForegroundColor Green

# Step 2: Determine the Nerdbank GitVersioning version
Write-Host "Determining Nerdbank GitVersioning version..." -ForegroundColor Cyan
$nbgvOutput = nbgv get-version
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to get Nerdbank GitVersioning version. Ensure nbgv is installed (dotnet tool install -g nbgv)."
    exit 1
}
$versionLine = $nbgvOutput | Where-Object { $_ -match '^NuGetPackageVersion:\s*(.+)$' }
if ($versionLine -match '^NuGetPackageVersion:\s*(.+)$') {
    $version = $Matches[1]
} else {
    Write-Error "Could not parse NuGetPackageVersion from nbgv output."
    exit 1
}
Write-Host "Version: $version" -ForegroundColor Green

# Step 3: Check that nuget-key.txt exists, has content, and is gitignored
Write-Host "Validating nuget-key.txt..." -ForegroundColor Cyan
$nugetKeyPath = Join-Path $PSScriptRoot "nuget-key.txt"

if (-not (Test-Path $nugetKeyPath)) {
    Write-Error "nuget-key.txt does not exist in the solution root."
    exit 1
}

$nugetKey = (Get-Content $nugetKeyPath -Raw).Trim()
if ([string]::IsNullOrWhiteSpace($nugetKey)) {
    Write-Error "nuget-key.txt is empty."
    exit 1
}

$gitIgnoreCheck = git check-ignore $nugetKeyPath 2>&1
if ($LASTEXITCODE -ne 0) {
    Write-Error "nuget-key.txt is not gitignored. Please add it to .gitignore."
    exit 1
}
Write-Host "nuget-key.txt validated successfully." -ForegroundColor Green

# Step 4: Run unit tests (unless -SkipTests is specified)
if (-not $SkipTests) {
    Write-Host "Running unit tests..." -ForegroundColor Cyan
    dotnet test "$PSScriptRoot\Datadog.Api.Test\Datadog.Api.Test.csproj" --configuration Release --no-build
    if ($LASTEXITCODE -ne 0) {
        # Try with build
        dotnet test "$PSScriptRoot\Datadog.Api.Test\Datadog.Api.Test.csproj" --configuration Release
        if ($LASTEXITCODE -ne 0) {
            Write-Error "Unit tests failed."
            exit 1
        }
    }
    Write-Host "Unit tests passed." -ForegroundColor Green
} else {
    Write-Host "Skipping unit tests as requested." -ForegroundColor Yellow
}

# Step 5: Build and publish to nuget.org
Write-Host "Building package..." -ForegroundColor Cyan
dotnet build "$PSScriptRoot\Datadog.Api\Datadog.Api.csproj" --configuration Release
if ($LASTEXITCODE -ne 0) {
    Write-Error "Build failed."
    exit 1
}

$nupkgPath = Get-ChildItem -Path "$PSScriptRoot\Datadog.Api\bin\Release" -Filter "*.nupkg" | Sort-Object LastWriteTime -Descending | Select-Object -First 1
if (-not $nupkgPath) {
    Write-Error "Could not find .nupkg file in Datadog.Api\bin\Release."
    exit 1
}

Write-Host "Publishing $($nupkgPath.Name) to nuget.org..." -ForegroundColor Cyan
dotnet nuget push $nupkgPath.FullName --api-key $nugetKey --source https://api.nuget.org/v3/index.json --skip-duplicate
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to publish to nuget.org."
    exit 1
}

Write-Host "Successfully published $($nupkgPath.Name) to nuget.org." -ForegroundColor Green
exit 0
