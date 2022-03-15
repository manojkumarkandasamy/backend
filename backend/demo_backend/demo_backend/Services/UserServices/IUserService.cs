using acima_mbl_bknd.Helpers;
using demo_backend.BOs;
using System.Collections.ObjectModel;

namespace demo_backend.Services.UserServices
{
    public interface IUserService
    {
        public ServiceResult<ObservableCollection<UserBO>> get_user();
        public ServiceResult<int> delete_user(int id);
        public ServiceResult<int> update_user(string name, int id);
        public ServiceResult<int> insert_user(int id, string name);
    }
}
