using System.Threading.Tasks;

namespace Pharmaease.Services.OpenFDA
{
    public interface IMediServices
    {
        Task<MediResponse> GetMediByBrandName(string brandName);
    }
}
