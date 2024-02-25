namespace PT.Application.Static
{
    public static class StatusResponse
    {
        /// <summary>
        /// Solicitud exitosa.
        /// </summary>
        public const int OK = 200;
        /// <summary>
        /// Errores en la solicitud.
        /// </summary>
        public const int BAD_REQUEST = 400;
        /// <summary>
        /// La solicitud no se pudo procesar debido a la falta de autenticación válida.
        /// </summary>
        public const int UNAUTHORIZED = 401;
        /// <summary>
        /// Resursos no encontrados.
        /// </summary>
        public const int NOT_FOUND = 404;
        /// <summary>
        /// Error interno que impide el proceso de la solicitud, puede deberse a problemas de la lógica de la aplicación o
        /// en la base de datos.
        /// </summary>
        public const int INTERNAL_SERVER_ERROR = 500;
    }
}
