using System;
public class InitializationParams
{
    public string ApiKey { get; }

    public string LocalConfigurationPath { get; }

    public string RemoteConfigurationURL { get; }

    public string ProviderId { get; }

    public bool DisableDidomiRemoteConfig { get; }

    public string LanguageCode { get; }

    public string NoticeId { get; }

    public string AndroidTvNoticeId { get; }

    public bool AndroidTvEnabled { get; }

    public InitializationParams(
        string apiKey,
        string localConfigurationPath,
        string remoteConfigurationURL,
        string providerId,
        bool disableDidomiRemoteConfig,
        string languageCode,
        string noticeId,
        string androidTvNoticeId,
        bool androidTvEnabled)
    {
        this.ApiKey = apiKey;
        this.LocalConfigurationPath = localConfigurationPath;
        this.RemoteConfigurationURL = remoteConfigurationURL;
        this.ProviderId = providerId;
        this.DisableDidomiRemoteConfig = disableDidomiRemoteConfig;
        this.LanguageCode = languageCode;
        this.NoticeId = noticeId;
        this.AndroidTvNoticeId = androidTvNoticeId;
        this.AndroidTvEnabled = androidTvEnabled;
    }
}
