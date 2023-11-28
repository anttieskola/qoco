#!/bin/bash

# cleanup
rm -rf .sonarqube
dotnet clean

# prepare
dotnet-sonarscanner begin /key:QOCO /name:QOCO /d:sonar.host.url=http://localhost:9999 /d:sonar.login=admin /d:sonar.password=sonar /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml

# build
dotnet build --no-incremental

# test with coverage
dotnet-coverage collect "dotnet test" -f xml -o "coverage.xml"

# analyze
dotnet-sonarscanner end /d:sonar.login=admin /d:sonar.password=sonar
