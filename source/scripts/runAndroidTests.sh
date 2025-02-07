#!/bin/bash

#--------------------------------------------------------------------
# Run automated tests on Android for Didomi Plugin.
# Note: Older Unity versions do not correctly run tests on Android.
# Tested successfully with Unity LTS 2021.3.20f1.
#--------------------------------------------------------------------

# Retrieve scripts directory
scriptsDir="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

UNITY_PATH=$(awk -F= '/^editor/ {print $2}' $scriptsDir/unity.properties)
RESULTS_PATH="artifacts/android-test-results.xml"
LOG_PATH="artifacts/androidTestsRun.log"

# Run the tests
$UNITY_PATH -batchmode -buildTarget Android -runTests -testResults $RESULTS_PATH -testPlatform Android -logFile $LOG_PATH

result=$?
if [ $result -eq 0 ]
then
    echo "Android tests passed!"
else
    echo "Android tests failed with exit code $result"
    exit 1
fi
