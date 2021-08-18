using System.Threading.Tasks;

namespace DependencyInversion
{
    public interface IToaster
    {
        Task<Bread> ToastBread(Bread bread);
    }
}