namespace POS.Infrastructure.Commons.Bases.Request
{
    public class BasePaginationRequest
    {
        public int NumPage { get; set; } = 1;
        public int NumRecordsPage { get; set; } = 10;

        private readonly int NumMaxRecordsPage = 50;

        public string Orden { get; set; } = "asc";

        public string? Sort { get; set; } = null;

        public int Records //para los registros que vamos a mostrar
        {
            get => NumRecordsPage;
            set
            {
                NumRecordsPage = value > NumMaxRecordsPage ? NumMaxRecordsPage : value;    //si el valor de este mismo es decir del numRecordsPage
            }
        }

    }
}
