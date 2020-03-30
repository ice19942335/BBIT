namespace BBIT.Domain.Entities.BBIT.WEB.Service.Contracts
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

        public static class HouseRoute  
        {
            public const string HouseV1 = BaseV1 + "/houses";

            public const string HouseByIdV1 = BaseV1 + "/houses/{id}";
        }

        public static class FlatRoute
        {
            public const string FlatV1 = BaseV1 + "/flats";

            public const string FlatByIdV1 = BaseV1 + "/flats/{id}";
        }
            
        public static class ResidentRoute
        {
            public const string ResidentV1 = BaseV1 + "/residents";

            public const string ResidentByIdV1 = BaseV1 + "/residents/{id}";
        }
    }
}
