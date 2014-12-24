$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'
$version = [System.Reflection.Assembly]::LoadFile("$root\src\Heijden.Dns\bin\Release\Heijden.Dns.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\NuGet\Heijden.Dns.nuspec)
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\nuget\Heijden.Dns.compiled.nuspec

& $root\NuGet\NuGet.exe pack $root\nuget\Heijden.Dns.compiled.nuspec -Symbols
