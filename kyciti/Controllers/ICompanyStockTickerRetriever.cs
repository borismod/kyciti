namespace kyciti.Controllers
{
    public interface ICompanyStockTickerRetriever
    {
        string GetCompanyStockTicker(string companyName);
    }
}