﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Talent.Common.Aws;
using Talent.Common.Contracts;
using System.Web;


namespace Talent.Common.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _environment;
        private readonly string _tempFolder;
        private IAwsService _awsService;

        public FileService(IHostingEnvironment environment, 
            IAwsService awsService)
        {
            _environment = environment;
            _tempFolder = "images\\";
            _awsService = awsService;
        }

        public async Task<string> SaveFile(IFormFile file, FileType type)
        {

            var filePath = Path.Combine(_environment.ContentRootPath , _tempFolder, file.FileName);
            using (var stream = File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            return filePath;
            
        }


        public async Task<bool> DeleteFile(string id, FileType type)
        {
            if (File.Exists(id))
            {
                File.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<string> GetFileURL(string id, FileType type)
        {
            var url = Path.Combine(_tempFolder, Path.GetFileName(id));
            return url;
        }

        



        #region Document Save Methods

        private async Task<string> SaveFileGeneral(IFormFile file, string bucket, string folder, bool isPublic)
        {
            //Your code here;
            throw new NotImplementedException();
        }
        
        private async Task<bool> DeleteFileGeneral(string id, string bucket)
        {
            //Your code here;
            throw new NotImplementedException();
        }
        #endregion
    }
}
