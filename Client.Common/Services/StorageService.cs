﻿using System.Threading.Tasks;
using WinRtUtility;

namespace Client.Common.Services
{
    public class StorageService : IStorageService
    {
        public async Task Save<T>(T data)
        {
            var objectStorageHelper = new ObjectStorageHelper<T>(StorageType.Roaming);
            await objectStorageHelper.SaveAsync(data);
        }

        public async Task Save<T>(T data, string handle)
        {
            var objectStorageHelper = new ObjectStorageHelper<T>(StorageType.Roaming);
            await objectStorageHelper.SaveAsync(data, handle);
        }

        public async Task<T> Load<T>()
        {
            var objectStorageHelper = new ObjectStorageHelper<T>(StorageType.Roaming);
            return await objectStorageHelper.LoadAsync();
        }

        public async Task<T> Load<T>(string handle)
        {
            var objectStorageHelper = new ObjectStorageHelper<T>(StorageType.Roaming);
            return await objectStorageHelper.LoadAsync(handle);
        }

        public async Task Delete<T>()
        {
            var objectStorageHelper = new ObjectStorageHelper<T>(StorageType.Roaming);
            await objectStorageHelper.DeleteAsync();
        }
    }
}