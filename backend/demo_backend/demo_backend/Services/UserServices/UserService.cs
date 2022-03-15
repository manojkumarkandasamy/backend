using acima_mbl_bknd.Helpers;
using demo_backend.BOs;
using demo_backend.Helper.DataStore;
using System.Collections.ObjectModel;

namespace demo_backend.Services.UserServices
{
    public class UserService : IUserService
    {
        public ServiceResult<ObservableCollection<UserBO>> get_user()
        {
            try
            {
                var response = UserSchema.get_user();
                if (response != null)
                {
                    return new ServiceResult<ObservableCollection<UserBO>>()
                    {
                        Status = ServiceStatus.Success,
                        Message = "Success",
                        Content = response
                    };
                }

                return new ServiceResult<ObservableCollection<UserBO>>()
                {
                    Status = ServiceStatus.Failed,
                    Message = "response from DB is null",
                    Content = null

                };

            }
            catch (Exception ex)
            {
                return new ServiceResult<ObservableCollection<UserBO>>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = null
                };
            }
        }

        public ServiceResult<int> insert_user(int id, string name)
        {
            try
            {
                var response = UserSchema.insert_user(id,name);
                if (response != null)
                {
                    return new ServiceResult<int>()
                    {
                        Status = ServiceStatus.Success,
                        Message = "Success",
                        Content = response
                    };
                }

                return new ServiceResult<int>()
                {
                    Status = ServiceStatus.Failed,
                    Message = "response from DB is null",
                    Content = 0

                };

            }
            catch (Exception ex)
            {
                return new ServiceResult<int>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = 0
                };
            }
        }

        public ServiceResult<int> delete_user(int id)
        {
            try
            {
                var response = UserSchema.delete_user(id);
                if (response != null)
                {
                    return new ServiceResult<int>()
                    {
                        Status = ServiceStatus.Success,
                        Message = "Success",
                        Content = response
                    };
                }

                return new ServiceResult<int>()
                {
                    Status = ServiceStatus.Failed,
                    Message = "response from DB is null",
                    Content = 0

                };

            }
            catch (Exception ex)
            {
                return new ServiceResult<int>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = 0
                };
            }
        }

        public ServiceResult<int> update_user(string name, int id)
        {
            try
            {
                var response = UserSchema.update_user(name, id);
                if (response != null)
                {
                    return new ServiceResult<int>()
                    {
                        Status = ServiceStatus.Success,
                        Message = "Success",
                        Content = response
                    };
                }

                return new ServiceResult<int>()
                {
                    Status = ServiceStatus.Failed,
                    Message = "response from DB is null",
                    Content = 0

                };

            }
            catch (Exception ex)
            {
                return new ServiceResult<int>()
                {
                    Status = ServiceStatus.Failed,
                    Message = ex.Message,
                    Content = 0
                };
            }
        }


    }
}
