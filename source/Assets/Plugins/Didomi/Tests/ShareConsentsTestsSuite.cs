using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using IO.Didomi.SDK;

/// <summary>
/// Tests related to sharing consent with Webview / Web SDK
/// </summary>
public class ShareConsentsTestSuite: DidomiBaseTests
{
    private bool sdkReady = false;

    [UnitySetUp]
    public IEnumerator setup()
    {
        yield return LoadSdk();
    }

    [Test]
    public void TestGetJavaScriptForWebView()
    {
        var jsString = Didomi.GetInstance().GetJavaScriptForWebView();

        Debug.Log("JS String = " + jsString);
        
        Assert.IsFalse(string.IsNullOrWhiteSpace(jsString));
    }
}
