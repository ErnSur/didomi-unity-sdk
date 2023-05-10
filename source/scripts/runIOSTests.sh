#!/bin/bash

UNITY_PATH="/Applications/Unity/Hub/Editor/2019.4.36f1/Unity.app/Contents/MacOS/Unity"
RESULTS_PATH="test-results.xml"
LOG_PATH="testsRun.log"

# Run the tests for Didomi Plugin on iOS
# Note: Currently Unity does not correctly run tests on Android 
$UNITY_PATH -batchmode -runTests -testResults $RESULTS_PATH -testPlatform iOS -logFile $LOG_PATH

if [ $? -eq 0 ]
then
    echo "Tests passed!"
else
    echo "Tests failed!"
fi
