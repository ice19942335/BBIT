namespace BBIT.WEB.Service.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version1 = "v1";

        public const string BaseV1 = Root + "/" + Version1;

        public static class Authentication
        {
            public const string LoginV1 = BaseV1 + "/auth/login";

            public const string RegisterV1 = BaseV1 + "/auth/register";

            public const string RefreshV1 = BaseV1 + "/auth/refresh";
        }
    }
}
