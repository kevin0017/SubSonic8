﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.ApplicationModel.Search;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.ApplicationSettings;

namespace Client.Common.Services
{
    public class WinRTWrappersService : IWinRTWrappersService
    {
        public void RegisterSearchQueryHandler(TypedEventHandler<SearchPane, SearchPaneQuerySubmittedEventArgs> handler)
        {
            SearchPane.GetForCurrentView().QuerySubmitted += handler;
        }

        public void RegisterSettingsRequestedHandler(TypedEventHandler<SettingsPane, SettingsPaneCommandsRequestedEventArgs> handler)
        {
            SettingsPane.GetForCurrentView().CommandsRequested += handler;
        }

        public async Task<IStorageFile> GetNewStorageFile()
        {
            var fileSavePicker = new FileSavePicker();
            fileSavePicker.FileTypeChoices.Add("Subsonic8 playlist", new List<string> { ".spls" });
            fileSavePicker.DefaultFileExtension = ".spls";
            fileSavePicker.SuggestedFileName = "playlist.spls";
            fileSavePicker.SettingsIdentifier = "PlaylistPicker";

            return await fileSavePicker.PickSaveFileAsync();
        }

        public async Task<IStorageFile> OpenStorageFile()
        {
            var fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.FileTypeFilter.Add(".spls");
            fileOpenPicker.ViewMode = PickerViewMode.List;
            return await fileOpenPicker.PickSingleFileAsync();
        }

        public async Task<T> LoadFromFile<T>(IStorageFile storageFile)
            where T : new()
        {
            var randomAccessStream = await storageFile.OpenReadAsync();
            var xmlSerializer = new XmlSerializer(typeof(T));
            var result = new T();
            try
            {
                result = (T)xmlSerializer.Deserialize(randomAccessStream.AsStreamForRead());
            }
            catch (Exception)
            {
            }
            finally
            {
                randomAccessStream.Dispose();
            }

            return result;
        }

        public async Task SaveToFile<T>(IStorageFile storageFile, T @object)
        {
            var randomAccessStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite);
            var outputStream = randomAccessStream.GetOutputStreamAt(0);

            var xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(outputStream.AsStreamForWrite(), @object);
            outputStream.Dispose();

            await randomAccessStream.FlushAsync();
            randomAccessStream.Dispose();
        }
    }
}