using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IO.Didomi.SDK;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LocalNoticeTests
{
    private bool sdkReady = false;

    [SetUp]
    public void setup()
    {
        try
        {
            string apiKey = "c3cd5b46-bf36-4700-bbdc-4ee9176045aa";
            string noticeId = null;
            string localConfigurationPath = null;
            string remoteConfigurationURL = null;
            string providerId = null;
            bool disableDidomiRemoteConfig = true;
            string languageCode = null;

            Debug.Log("Tests: Initializing sdk");

            Didomi didomi = Didomi.GetInstance();

            didomi.Initialize(
                apiKey,
                localConfigurationPath,
                remoteConfigurationURL,
                providerId,
                disableDidomiRemoteConfig,
                languageCode,
                noticeId);

            didomi.OnReady(
                () => {
                    sdkReady = true;
                }
                );
            didomi.OnError(
                () => {
                    sdkReady = true;
                }
                );
        }
        catch (Exception ex)
        {
            Debug.LogError($"Exception : {ex.Message}");
        }
    }

    [Test]
    public void NotPossible()
    {
        Assert.True(false);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PurposesAndVendorsCountAfterReset()
    {
        Debug.Log("Tests: Waiting for sdk ready");

        yield return new WaitUntil(() => sdkReady);

        Debug.Log("Tests: sdk is ready!");

        Didomi.GetInstance().Reset();

        var disabledPurposeIds = Didomi.GetInstance().GetDisabledPurposeIds();
        var disabledPurposes = Didomi.GetInstance().GetDisabledPurposes();
        var disabledVendorIds = Didomi.GetInstance().GetDisabledVendorIds();
        var disabledVendors = Didomi.GetInstance().GetDisabledVendors();

        var enabledPurposeIds = Didomi.GetInstance().GetEnabledPurposeIds();
        var enabledPurposes = Didomi.GetInstance().GetEnabledPurposes();
        var enabledVendorIds = Didomi.GetInstance().GetEnabledVendorIds();
        var enabledVendors = Didomi.GetInstance().GetEnabledVendors();

        var requiredPurposeIds = Didomi.GetInstance().GetRequiredPurposeIds();
        var requiredPurposes = Didomi.GetInstance().GetRequiredPurposes();
        var requiredVendorIds = Didomi.GetInstance().GetRequiredVendorIds();
        var requiredVendors = Didomi.GetInstance().GetRequiredVendors();

        var disabledSum =
            disabledPurposeIds.Count()
            + disabledPurposes.Count()
            + disabledVendorIds.Count()
            + disabledVendors.Count();

        var enabledSum =
            enabledPurposeIds.Count()
            + enabledPurposes.Count()
            + enabledVendorIds.Count()
            + enabledVendors.Count();

        var requiredSum =
           requiredPurposeIds.Count()
           + requiredPurposes.Count()
           + requiredVendorIds.Count()
           + requiredVendors.Count();

        Assert.Equals(enabledSum, 0);
        Assert.Equals(disabledSum, 0);
        Assert.Equals(requiredSum, 4);
    }
}
