namespace IbsRestApi.Application.CommonModels;

public static class AppConstants
{
    public const string JWT_SECRET_KEY =
      "AVJWT_ciuntmkucuqzzomvghfakprhgdvoajjmlphxpsAQADyMMaVBKqy7A2LyXlirpSPDI4u1HiPLXFAyouaw6Km0VQTTpcdljyjzdiqagvkwcjgxumfwhrjmlphxpsAQADyMMaVBKqy7A2LyXlir";

    public static string APIKEY_KEY_NAME { get { return "x-iMoneytor-auth"; } }

    public static string APIKEY_BRANCH { get { return "x-branch-name"; } }

    public static string APIKEY_CLIENT_USERNAME { get { return "x-client-username"; } }
}
