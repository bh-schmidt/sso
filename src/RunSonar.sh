set -e
cat << eof

Updating Sonnar

eof

PROJECT_KEY="sso.net"
SONAR_SCANNER_LOCATION="C:/workspace/sonar-scanner/SonarScanner.MSBuild.dll"
OPENCOVER_LOCATION="SSO.Tests\coverage.opencover.xml"


dotnet test //p:CollectCoverage=true //p:CoverletOutputFormat=opencover
dotnet build-server shutdown
dotnet $SONAR_SCANNER_LOCATION begin //k:$PROJECT_KEY //d:sonar.cs.opencover.reportsPaths=$OPENCOVER_LOCATION /d:sonar.coverage.exclusions="SSO.Tests/**/*.cs"
dotnet build
dotnet $SONAR_SCANNER_LOCATION end


cat << eof

Sonar update succeeded

eof