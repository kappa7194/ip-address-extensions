git reset --hard
git clean -d -f -x
NuGet.exe Restore Albireo.IPAddressExtensions.sln
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe Albireo.IPAddressExtensions.sln /property:Configuration=Debug /maxcpucount /nodeReuse:false
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe Albireo.IPAddressExtensions.sln /property:Configuration=Release /maxcpucount /nodeReuse:false
NuGet.exe Pack Albireo.IPAddressExtensions\Albireo.IPAddressExtensions.csproj -Prop Configuration=Release -Symbols
PAUSE
